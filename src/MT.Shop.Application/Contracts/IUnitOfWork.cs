using MT.Shop.Domain.Entities.Orders;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Users;


namespace MT.Shop.Application.Contracts;

public interface IUnitOfWork : IDisposable
{
    // generic repository 
    //IGenericRepository<T> Repository<T>() where T : BaseEntity<int>;

    #region repository 

    IUserRepository UserRepo { get; }
    IProductRepository ProductRepo { get; }
    IOrderRepository OrderRepo { get; }

    #endregion

    Task CommitAsync(CancellationToken cancellationToken);



}
