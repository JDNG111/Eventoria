namespace Eventoria.Core.Entities;

public class User
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PasswordHash { get; set; } = string.Empty;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    
    // Relaciones
    public ICollection<Event> CreatedEvents { get; set; } = new List<Event>();
    public ICollection<EventAttendance> AttendingEvents { get; set; } = new List<EventAttendance>();
}