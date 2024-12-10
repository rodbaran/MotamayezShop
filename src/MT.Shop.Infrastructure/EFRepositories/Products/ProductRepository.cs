using Microsoft.EntityFrameworkCore;

using MT.Shop.Domain.Products;
using MT.Shop.Infrastructure.DBContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

    public async void DeleteAsync(Product product, CancellationToken cancellationToken)
    {
        var record = await GetByIdAsync(product.Id);
        record.IsDelete = true;
        await UpdateAsync(product);
    }

    public async Task<Product> GetByIdAsync(int id)
        => await _dbContext.Products.FirstOrDefaultAsync(x => x.Id == id)
            ?? throw new Exception("رکوردی یافت نشد ");



    public async Task UpdateAsync(Product product)
    => await Task.Run(() => _dbContext.Update(product));
}
