using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.EFRepositories.Products;

public class ProductRepository : IProductRepository
{
    private readonly ApplicationDbContext _dbContext;

    public ProductRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task AddAsync(Product product, CancellationToken cancellationToken)
        => await _dbContext.AddAsync(product, cancellationToken);

    public async Task<bool> AnyAsync(int id, CancellationToken cancellationToken)
        => await _dbContext.Products.AnyAsync(x => x.Id == id, cancellationToken);

    public async Task DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(product.Id);
        record.IsDelete = true;
        _dbContext.Products.Update(record);
        await _dbContext.SaveChangesAsync(cancellationToken);
    }

    public async Task<Product> GetByIdAsync(int id) { 
        var product = await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id);
        if (product == null) throw new BadRequestEntityException(ProductErrors.NotExist);
        
        return product;
    }

    public async Task<List<Product>> GetByIdsAsync(IEnumerable<int> productIds)
    {
        if (productIds == null || !productIds.Any())
        {
            throw new NullReferenceException(string.Format(ProductErrors.NotExist, nameof(productIds)));
        }

        return await _dbContext.Products
            .Where(x => productIds.Contains(x.Id))
            .ToListAsync();
    }

    public async Task UpdateAsync(Product product)
    {
        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }

    public async Task UpdateRangeAsync(IEnumerable<Product> productIds)
    {
        _dbContext.Products.UpdateRange(productIds);
        await _dbContext.SaveChangesAsync();
    }
}
