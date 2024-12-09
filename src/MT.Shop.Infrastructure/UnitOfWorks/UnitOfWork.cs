using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.BaseEntities;
using MT.Shop.Domain.Helper;
using MT.Shop.Infrastructure.DBContext;
using MT.Shop.Infrastructure.Helper;


namespace MT.Shop.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;

    private bool disposed = false;

    public UnitOfWork(ApplicationDbContext context)
    {
        _dbContext = context;
    }
    public DbContext Context => _dbContext;

    public void Dispose()
    {
        Dispose(true);
        GC.SuppressFinalize(this);
    }
    public void Dispose(bool disposing)
    {
        if (!disposed)
        {
            if (disposing)
            {
                _dbContext.Dispose();
            }
        }
        disposed = true;
    }

    public IGenericRepository<T> Repository<T>() where T : BaseEntity<int>
    {
        return new GenericRepository<T>(_dbContext);
    }

    public async Task<int> Save(CancellationToken cancellationToken)
    {
        return await _dbContext.SaveChangesAsync(cancellationToken);
    }
}
