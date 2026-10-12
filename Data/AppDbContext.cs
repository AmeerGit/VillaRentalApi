using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

    public DbSet<Villa> Villas => Set<Villa>();   // table "Villas"

     protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        var seedDate = new DateTime(2026, 10, 9, 0, 0, 0, DateTimeKind.Utc);

        modelBuilder.Entity<Villa>().HasData(
            new Villa { Id = 1, Name = "Royal Villa",    Rate = 200, CreatedDate = seedDate },
            new Villa { Id = 2, Name = "Premium Pool Villa", Rate = 300, CreatedDate = seedDate },
            new Villa { Id = 3, Name = "Diamond Villa",  Rate = 400, CreatedDate = seedDate },
            new Villa { Id = 4, Name = "Sea View Villa", Rate = 250, CreatedDate = seedDate },
            new Villa { Id = 5, Name = "Mountain Retreat", Rate = 180, CreatedDate = seedDate }
        );
    }
    
}