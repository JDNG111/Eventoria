using Microsoft.EntityFrameworkCore;
using Eventoria.Core.Entities;
using Eventoria.Infrastructure.Data;

namespace Eventoria.Infrastructure.Repositories;

public interface IEventRepository : IRepository<Event>
{
    Task<IEnumerable<Event>> GetUpcomingEventsAsync();
    Task<IEnumerable<Event>> GetEventsByUserAsync(int userId);
}

public class EventRepository : Repository<Event>, IEventRepository
{
    public EventRepository(AppDbContext context) : base(context) { }
    
    public async Task<IEnumerable<Event>> GetUpcomingEventsAsync()
    {
        return await _dbSet
            .Where(e => e.StartDate > DateTime.UtcNow)
            .OrderBy(e => e.StartDate)
            .Include(e => e.CreatedBy)
            .Include(e => e.Attendees)  // ← ESTE ES EL CAMBIO CRÍTICO
            .ToListAsync();
    }
    
    public async Task<IEnumerable<Event>> GetEventsByUserAsync(int userId)
    {
        return await _dbSet
            .Where(e => e.CreatedById == userId)
            .OrderByDescending(e => e.CreatedAt)
            .Include(e => e.CreatedBy)
            .Include(e => e.Attendees)  // ← TAMBIÉN AQUÍ
            .ToListAsync();
    }
}