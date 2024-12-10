using MT.Shop.Domain.BaseEntities;
using MT.Shop.Domain.Helper;
using MT.Shop.Domain.Orders;
using MT.Shop.Domain.Products;
using MT.Shop.Domain.Users;


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
