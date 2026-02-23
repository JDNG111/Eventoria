using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Eventoria.Core.Entities;
using Eventoria.Infrastructure.Repositories;
using Eventoria.Infrastructure.Data;

namespace Eventoria.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Authorize]
public class EventsController : ControllerBase
{
    private readonly IEventRepository _eventRepository;
    private readonly AppDbContext _context;

    public EventsController(IEventRepository eventRepository, AppDbContext context)
    {
        _eventRepository = eventRepository;
        _context = context;
    }

    private int GetCurrentUserId()
    {
        var userIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        
        if (string.IsNullOrEmpty(userIdClaim))
        {
            throw new UnauthorizedAccessException("Usuario no autenticado");
        }
        
        if (!int.TryParse(userIdClaim, out int userId))
        {
            throw new UnauthorizedAccessException("Token de usuario inválido");
        }
        
        return userId;
    }

    // Helper para convertir Event a EventDto
    private EventDto MapToDto(Event e)
    {
        return new EventDto
        {
            Id = e.Id,
            Title = e.Title,
            Description = e.Description,
            StartDate = e.StartDate,
            EndDate = e.EndDate,
            Location = e.Location,
            TicketPrice = e.TicketPrice,
            MaxAttendees = e.MaxAttendees,
            IsPublic = e.IsPublic,
            CreatedAt = e.CreatedAt,
            CreatedBy = new UserDto
            {
                Id = e.CreatedBy.Id,
                Name = e.CreatedBy.Name,
                Email = e.CreatedBy.Email
            },
            AttendeesCount = e.Attendees?.Count ?? 0
        };
    }

    [HttpGet]
    public async Task<IActionResult> GetEvents()
    {
        try
        {
            var events = await _eventRepository.GetUpcomingEventsAsync();
            var eventDtos = events.Select(MapToDto).ToList();
            return Ok(eventDtos);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { message = "Error al cargar eventos", error = ex.Message });
        }
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetEvent(int id)
    {
        var @event = await _context.Events
            .Include(e => e.CreatedBy)
            .Include(e => e.Attendees)
            .FirstOrDefaultAsync(e => e.Id == id);
            
        if (@event == null)
            return NotFound(new { message = "Evento no encontrado" });

        return Ok(MapToDto(@event));
    }

    [HttpPost]
    public async Task<IActionResult> CreateEvent(CreateEventRequest request)
    {
        try
        {
            int userId;
            try
            {
                userId = GetCurrentUserId();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

            var @event = new Event
            {
                Title = request.Title,
                Description = request.Description,
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                Location = request.Location,
                TicketPrice = request.TicketPrice,
                MaxAttendees = request.MaxAttendees,
                IsPublic = request.IsPublic,
                CreatedById = userId,
                CreatedAt = DateTime.UtcNow
            };

            var created = await _eventRepository.AddAsync(@event);
            
            // Cargar el usuario creador
            await _context.Entry(created)
                .Reference(e => e.CreatedBy)
                .LoadAsync();
            
            // Inicializar Attendees como lista vacía para el DTO
            created.Attendees = new List<EventAttendance>();
            
            var eventDto = MapToDto(created);
            
            return CreatedAtAction(nameof(GetEvent), new { id = created.Id }, eventDto);
        }
        catch (Exception ex)
        {
            return StatusCode(500, new { 
                message = "Error al crear evento", 
                error = ex.Message
            });
        }
    }

    [HttpPost("{id}/attend")]
    public async Task<IActionResult> AttendEvent(int id)
    {
        try
        {
            // Obtener userId
            int userId;
            try
            {
                userId = GetCurrentUserId();
            }
            catch (UnauthorizedAccessException ex)
            {
                return Unauthorized(new { message = ex.Message });
            }

            Console.WriteLine($"=== ATTEND EVENT ===");
            Console.WriteLine($"Event ID: {id}");
            Console.WriteLine($"User ID: {userId}");

            // Buscar el evento con sus asistentes
            var @event = await _context.Events
                .Include(e => e.Attendees)
                .Include(e => e.CreatedBy)  // ← IMPORTANTE: incluir CreatedBy aquí
                .FirstOrDefaultAsync(e => e.Id == id);

            if (@event == null)
            {
                Console.WriteLine($"ERROR: Evento {id} no encontrado");
                return NotFound(new { message = "Evento no encontrado" });
            }

            Console.WriteLine($"Evento encontrado: {@event.Title}");
            Console.WriteLine($"Asistentes actuales: {@event.Attendees.Count}/{@event.MaxAttendees}");

            // Verificar si ya asiste
            var alreadyAttending = @event.Attendees.Any(a => a.UserId == userId);
            if (alreadyAttending)
            {
                Console.WriteLine($"ERROR: Usuario {userId} ya está registrado");
                return BadRequest(new { message = "Ya estás registrado en este evento" });
            }

            // Verificar capacidad
            if (@event.Attendees.Count >= @event.MaxAttendees)
            {
                Console.WriteLine($"ERROR: Evento lleno");
                return BadRequest(new { message = "El evento ha alcanzado su capacidad máxima" });
            }

            // Crear el registro de asistencia
            var attendance = new EventAttendance
            {
                UserId = userId,
                EventId = id,
                RegisteredAt = DateTime.UtcNow,
                HasPaid = @event.TicketPrice.HasValue ? false : true
            };

            Console.WriteLine("Agregando asistencia...");
            _context.EventAttendances.Add(attendance);
            await _context.SaveChangesAsync();
            
            Console.WriteLine("✅ Asistencia registrada exitosamente");
            
            // Recargar el evento con la nueva asistencia
            await _context.Entry(@event)
                .Collection(e => e.Attendees)
                .LoadAsync();
            
            Console.WriteLine($"Asistentes después de guardar: {@event.Attendees.Count}/{@event.MaxAttendees}");
            
            // Devolver el DTO actualizado
            var eventDto = MapToDto(@event);
            Console.WriteLine($"DTO AttendeesCount: {eventDto.AttendeesCount}");
            
            return Ok(eventDto);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"=== ERROR EN ATTEND ===");
            Console.WriteLine($"Message: {ex.Message}");
            Console.WriteLine($"StackTrace: {ex.StackTrace}");
            Console.WriteLine($"InnerException: {ex.InnerException?.Message}");
            
            return StatusCode(500, new { 
                message = "Error al registrar asistencia", 
                error = ex.Message,
                details = ex.InnerException?.Message
            });
        }
    }
}

public class CreateEventRequest
{
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public decimal? TicketPrice { get; set; }
    public int MaxAttendees { get; set; }
    public bool IsPublic { get; set; }
}

public class EventDto
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public string Location { get; set; } = string.Empty;
    public decimal? TicketPrice { get; set; }
    public int MaxAttendees { get; set; }
    public bool IsPublic { get; set; }
    public DateTime CreatedAt { get; set; }
    public UserDto CreatedBy { get; set; } = null!;
    public int AttendeesCount { get; set; }
}

public class UserDto
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
}
