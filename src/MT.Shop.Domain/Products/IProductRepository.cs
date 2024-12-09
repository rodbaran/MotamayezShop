namespace MT.Shop.Domain.Products;

public interface IProductRepository
{
    Task<Product> GetByIdAsync(int id, CancellationToken cancellationToken);
    Task<bool> AnyAsync(int id, CancellationToken cancellationToken);
    Task AddAsync(Product product, CancellationToken cancellationToken);

    Task UpdateAsync(Product product);

    void DeleteAsync(Product product, CancellationToken cancellationToken);
}
