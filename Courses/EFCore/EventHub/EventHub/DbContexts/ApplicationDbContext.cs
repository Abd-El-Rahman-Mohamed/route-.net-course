using EventHub.Entities;
using Microsoft.EntityFrameworkCore;

namespace EventHub.DbContexts;

public class ApplicationDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(
            "Server=.; Database=EventHub; Trusted_Connection=True; TrustServerCertificate=True;");
    }

    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Once their account is set up, an organizer can publish events on the platform.
        modelBuilder.Entity<Organizer>()
            .HasMany(o => o.Events)
            .WithOne(e => e.Organizer)
            .HasForeignKey(e => e.OrganizerId);
        
        // the platform issues them a badge — a credential uniquely numbered per attendee, stamped
        //  with the date it was issued, and assigned a tier based on their registration
        //  history: either Standard or VIP.
        modelBuilder.Entity<Attendee>()
            .HasOne(a => a.Badge)
            .WithOne(b => b.Attendee)
            .HasForeignKey<Badge>(b => b.AttendeeId);
        
        // a credential uniquely numbered per attendee
        modelBuilder.Entity<Badge>()
            .HasIndex(b => b.SequentialNumber)
            .IsUnique();
        
        // and the platform automatically records the exact date and time the registration was completed.
        modelBuilder.Entity<Registrations>()
            .Property(r => r.RegistrationCompletionDateTime)
            .HasDefaultValueSql("GETUTCDATE()");
        
        // Finally, the system silently tracks when each event record was first created in the
        //  database and when it was last modified
        modelBuilder.Entity<Event>()
            .Property<DateTime>("FirstCreatedAt")
            .HasDefaultValueSql("GETUTCDATE()");
        
        modelBuilder.Entity<Event>()
            .Property<DateTime>("LastModifiedAt")
            .HasDefaultValueSql("GETUTCDATE()");
    }
    
    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        var modifiedEvents = ChangeTracker.Entries<Event>()
            .Where(e => e.State == EntityState.Modified);

        // these timestamps are maintained by
        //  the platform internally and are never displayed on the public event page, nor
        //  are they part of the event’s data model as visible fields.
        foreach (var entry in modifiedEvents)
        {
            entry.Property("LastModifiedAt").CurrentValue = DateTime.UtcNow;
        }

        return base.SaveChangesAsync(cancellationToken);
    }
    
    public DbSet<Organizer> Organizers { get; set; }
    public DbSet<Event> Events { get; set; }
    public DbSet<Attendee> Attendees { get; set; }
    public DbSet<Registrations> Registrations { get; set; }
    public DbSet<Badge> Badges { get; set; }
}