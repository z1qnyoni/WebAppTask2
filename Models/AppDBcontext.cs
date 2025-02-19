using Microsoft.EntityFrameworkCore;


 namespace TodoApi.Models;

public class AppDBcontext : DbContext
{
    public AppDBcontext(DbContextOptions options) : base(options) { }
    public DbSet<House> Houses { get; set; }

    public DbSet<Apartment> Apartments { get; set; }

    public DbSet<Resident> Residents { get; set;  }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Resident>()
            .HasMany(r => r.Apartments)
            .WithMany(a => a.Residents);

        modelBuilder.Entity<Apartment>()
           .HasOne(a => a.House)
           .WithMany(h => h.Apartments)
           .HasForeignKey(a => a.HouseId);
    }
}
   

