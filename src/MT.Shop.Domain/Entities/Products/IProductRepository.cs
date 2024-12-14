namespace MT.Shop.Domain.Entities.Products;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id);

    Task<List<Product>> GetByIdsAsync(IEnumerable<int> productIds);

    Task<bool> AnyAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Product product, CancellationToken cancellationToken);

    Task UpdateAsync(Product product);

    Task UpdateRangeAsync(IEnumerable<Product> productIds);

    Task DeleteAsync(Product product, CancellationToken cancellationToken);


}
