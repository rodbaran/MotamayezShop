using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.BaseEntities;
using MT.Shop.Domain.Helper;


namespace MT.Shop.Infrastructure.UnitOfWorks;

public interface IUnitOfWork : IDisposable
{
    DbContext Context { get; }
    Task<int> Save(CancellationToken cancellationToken);
    IGenericRepository<T> Repository<T>() where T : BaseEntity<int>;

}
