using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Products;
using MT.Shop.Domain.Products.Dto;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.DataService.Product;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDto>> GetAll()
    {
        var lst = await _dbContext.Products
            .AsNoTracking()
            .Select(x => new ProductDto(x))
            .ToListAsync();
        return lst;
    }

    public async Task<ProductDto> GetById(int id)
    {
        var item = await _dbContext.Products
            .AsNoTracking()
            .Select (x => new ProductDto(x))
            .FirstOrDefaultAsync();

        return item ?? throw new Exception("رکوردی با این شناسه وجود ندارد");
    }

    public async Task<List<ProductDto>> GetByName(string name)
    {
        var lst = await _dbContext.Products
             .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
             .AsNoTracking()
             .Select(x=> new ProductDto(x))
            .ToListAsync();
        return lst;
    }
}

