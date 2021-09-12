using Microsoft.EntityFrameworkCore;
using PowerPlant.Domain;
using PowerPlant.Domain.Entities;

namespace PowerPlant.Infrastructure
{
    public class AppDbContext : DbContext
    {
        public DbSet<PowerPlantDef> PowerPlants { get; set; }
        public DbSet<PowerPlantHourlyDatum> PlantHourlyData { get; set; }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<PowerPlantDef>()
                         .HasKey(k => k.Id);


            modelBuilder.Entity<PowerPlantDef>().Property(b => b.Id).HasMaxLength(50);


            modelBuilder.Entity<PowerPlantHourlyDatum>()
                                    .HasKey(k => new { k.PowerPlantId, k.CreatedDate });

            modelBuilder.Entity<PowerPlantHourlyDatum>().Property(b => b.PowerPlantId).HasMaxLength(50);

            modelBuilder.Entity<PowerPlantDef>()
                .HasMany<PowerPlantHourlyDatum>(g => g.PowerPlantHourlyData)
                .WithOne(s => s.PowerPlant)
                .HasForeignKey(s => s.PowerPlantId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<PowerPlantDef>()
                   .HasIndex(u => u.WebId)
                   .IsUnique();
        }

    }
}
