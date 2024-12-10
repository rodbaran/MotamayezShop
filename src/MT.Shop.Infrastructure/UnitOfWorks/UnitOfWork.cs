using MT.Shop.Domain.BaseInfo;
using MT.Shop.Domain.Orders;
using MT.Shop.Domain.Products;
using MT.Shop.Infrastructure.DBContext;
using MT.Shop.Infrastructure.EFRepositories.BaseInfo;
using MT.Shop.Infrastructure.EFRepositories.Orders;
using MT.Shop.Infrastructure.EFRepositories.Products;


namespace MT.Shop.Infrastructure.UnitOfWorks;

public class UnitOfWork : IUnitOfWork
{

    private readonly ApplicationDbContext _dbContext;


    private bool disposed = false;

    public UnitOfWork(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }


    private  IUserRepository? _userRepo;
    private  IProductRepository? _productRepo;
    private  IOrderRepository? _orderRepo;

    public IUserRepository UserRepo 
    {
        get 
        {
            if (_userRepo == null)
                _userRepo = new UserRepository(_dbContext);
            return _userRepo;
        }

    }

    public IOrderRepository OrderRepo
    {
        get
        {
            if( _orderRepo == null)
                _orderRepo = new OrderRepository(_dbContext);
            return _orderRepo;
        }
    }

    public IProductRepository ProductRepo
    {
        get
        {
            if( _productRepo == null)
                _productRepo = new ProductRepository(_dbContext);
            return _productRepo;
        }
    }

    public async Task CommitAsync(CancellationToken cancellationToken)
    {
        await _dbContext.SaveChangesAsync();
    }

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

    //GenericRepository

    //public IGenericRepository<T> Repository<T>() where T : BaseEntity<int>
    //{
    //    return new GenericRepository<T>(_dbContext);
    //}


}
