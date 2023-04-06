using Audience.DAL.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.Reflection.Emit;

namespace Audience.DAL.EF;

public class AudienceDbContext : DbContext
{
    public DbSet<Class> Class { get; set; }
    public DbSet<Audiences> Audiences { get; set; }
    public DbSet<Lecturer> Lecturers { get; set; }
    public DbSet<TimetableOfClasses> TimetableOfClasses { get; set; }
    public AudienceDbContext(DbContextOptions<AudienceDbContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        builder.Entity<Class>()
            .HasOne(p=>p.timetableOfClasses)
            .WithMany(t=>t.ItemsClass)
            .HasForeignKey(i => i.timetableOfClassesId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Class>()
            .HasOne(p => p.Audiences)
            .WithMany(t => t.ItemsClass)
            .HasForeignKey(i => i.AudiencesId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.Entity<Class>()
            .HasOne(p => p.Lecturer)
            .WithMany(t => t.ItemsClass)
            .HasForeignKey(i => i.LecturerId)
            .OnDelete(DeleteBehavior.Cascade);

        base.OnModelCreating(builder);
    }
    protected override void ConfigureConventions(ModelConfigurationBuilder builder)
    {
        builder.Properties<DateOnly>()
            .HaveConversion<DateOnlyConverter>()
            .HaveColumnType("date");
    }
}
public class DateOnlyConverter : ValueConverter<DateOnly, DateTime>
{
    public DateOnlyConverter() : base(
            d => d.ToDateTime(TimeOnly.MinValue),
            d => DateOnly.FromDateTime(d))
    { }
}
