using Microsoft.EntityFrameworkCore;

namespace MovieClub.test.Taools.Infrastructure.DatabaseConfig.Unit;

public static class DbContextHelper
{
    public static void Save<TDbContext, TEntity>(
        this TDbContext dbContext,
        TEntity entity)
        where TDbContext : DbContext
        where TEntity : class
    {
        dbContext.Add(entity);
        dbContext.SaveChanges();
    }
}