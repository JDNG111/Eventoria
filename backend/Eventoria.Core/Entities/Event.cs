namespace Eventoria.Core.Entities;

public class Event
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
    public int CreatedById { get; set; }
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Relaciones
    public User CreatedBy { get; set; } = null!;
    public ICollection<EventAttendance> Attendees { get; set; } = new List<EventAttendance>();
}