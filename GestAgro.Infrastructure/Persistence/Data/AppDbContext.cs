using GestAgro.Domain.Entities.EarlyRegister;
using GestAgro.Domain.ValueObjects;
using Microsoft.EntityFrameworkCore;

namespace GestAgro.Infrastructure.Persistence.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
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
                            
                            vo => vo.ToString(),

                            dbValue => Email.Parse(dbValue)
                        )
                        .IsRequired()
                        .HasMaxLength(255)
                        .HasColumnName("Email");

                entity.Property(e => e.PhoneNumber)
                    .IsRequired()
                    .HasMaxLength(50) 
                    .HasColumnName("PhoneNumber");

                entity.Property(e => e.Region)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("Region");

                entity.Property(e => e.Status).IsRequired();
                entity.Property(e => e.CreatedAt).IsRequired();
                entity.Property(e => e.ConfirmedAt);
                entity.Property(e => e.VerificationToken).HasMaxLength(100);
            });
        }
    }
}
