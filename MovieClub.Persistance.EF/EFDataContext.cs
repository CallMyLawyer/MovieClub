using Microsoft.EntityFrameworkCore;
using MovieClub.Entities.Categories;
using MovieClub.Entities.Movies;

namespace MovieClub.Persistance.EF;

public class EFDataContext : DbContext
{
    public EFDataContext(string connectionString) :
        this(new DbContextOptionsBuilder().UseSqlServer(connectionString).Options)
    { }

     
    public EFDataContext(DbContextOptions options) : base(options)
    {
    }

    public DbSet<Movie> Movies { get; set; }
    public DbSet<Category> Categories{ get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly
            (typeof(EFDataContext).Assembly);
    }
}