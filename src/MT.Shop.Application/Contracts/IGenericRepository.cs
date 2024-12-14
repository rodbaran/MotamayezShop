using MT.Shop.Domain.Entities.BaseEntities;
using System.Linq.Expressions;


namespace MT.Shop.Application.Contracts;

public interface IGenericRepository<T> where T : BaseEntity<int>
{
    Task<T> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<IReadOnlyList<T>> GetAllAsync(CancellationToken cancellationToken);
    Task<T> AddAsync(T entity, CancellationToken cancellationToken);
    Task<T> UpdateAsync(T entity);
    Task Delete(T entity, CancellationToken cancellationToken);
    Task<bool> AnyAsync(Expression<Func<T, bool>> expression, CancellationToken cancellationToken);
    IQueryable<T> Where(Expression<Func<T, bool>> expression);
    Task<bool> AnyAsync(CancellationToken cancellationToken);

}