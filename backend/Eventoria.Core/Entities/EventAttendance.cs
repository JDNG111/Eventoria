namespace Eventoria.Core.Entities;

public class EventAttendance
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public int EventId { get; set; }
    public DateTime RegisteredAt { get; set; } = DateTime.UtcNow;
    public bool HasPaid { get; set; }
    
    // Relaciones
    public User User { get; set; } = null!;
    public Event Event { get; set; } = null!;
}