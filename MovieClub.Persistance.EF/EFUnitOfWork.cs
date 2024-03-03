using MovieClub.Contracts.Interfaces;

namespace MovieClub.Persistance.EF;

public class EFUnitOfWork : IUnitOfWork
{
    private readonly EFDataContext _context;

    public EFUnitOfWork(EFDataContext context)
    {
        _context = context;
    }
    public async Task Begin()
    {
        await _context.Database.BeginTransactionAsync();
    }

    public async Task Complete()
    {
        await _context.SaveChangesAsync();
    }

    public async Task Commit()
    {
        await _context.Database.CommitTransactionAsync();
    }

    public async Task Rollback()
    {
        await _context.Database.RollbackTransactionAsync();
    }
}