using GestAgro.Domain.Entities;
using GestAgro.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GestAgro.Infrastructure.Persistence.Data;

public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
{
    public DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(200);

            entity.Property(e => e.Email)
                .HasConversion(
                    ts => ts.Value,
                    to => Email.Parse(to)
                )
                .IsRequired()
                .HasMaxLength(255)
                .HasColumnName("Email");

            entity.Property(e => e.PhoneNumber)
                .HasConversion(
                    ts => ts.E164,
                    to => TelephoneNumber.FromE164(to)
                )
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("PhoneNumber");

            entity.Property(e => e.Region)
                .HasConversion(
                    ts => ts.Value,
                    to => CountryCode.Parse(to))
                .IsRequired()
                .HasMaxLength(2)
                .HasColumnName("Region");

            entity.Property(e => e.Status).IsRequired();
            entity.Property(e => e.CreatedAt).IsRequired();
            entity.Property(e => e.ConfirmedAt);
            entity.Property(e => e.VerificationToken).HasMaxLength(100);
        });
    }
}