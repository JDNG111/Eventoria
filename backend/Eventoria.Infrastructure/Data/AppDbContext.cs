using Microsoft.EntityFrameworkCore;
using Eventoria.Core.Entities;

namespace Eventoria.Infrastructure.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
    
    public DbSet<User> Users { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<EventAttendance> EventAttendances { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configurar relaciones
        modelBuilder.Entity<Event>()
            .HasOne(e => e.CreatedBy)
            .WithMany(u => u.CreatedEvents)
            .HasForeignKey(e => e.CreatedById);
            
        modelBuilder.Entity<EventAttendance>()
            .HasOne(ea => ea.User)
            .WithMany(u => u.AttendingEvents)
            .HasForeignKey(ea => ea.UserId);
            
        modelBuilder.Entity<EventAttendance>()
            .HasOne(ea => ea.Event)
            .WithMany(e => e.Attendees)
            .HasForeignKey(ea => ea.EventId);
            
        // Índices
        modelBuilder.Entity<User>()
            .HasIndex(u => u.Email)
            .IsUnique();
            
        modelBuilder.Entity<Event>()
            .HasIndex(e => e.StartDate);
    }
}