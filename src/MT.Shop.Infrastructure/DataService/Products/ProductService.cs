using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Domain.Helper;
using MT.Shop.Domain.Helper.Types;
using MT.Shop.Domain.Products;
using MT.Shop.Domain.Products.Dto;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.DataService.Products;

public class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDto>> GetListAsync()
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
            .Select(x => new ProductDto(x))
            .FirstOrDefaultAsync();

        return item ?? throw new NotFoundEntityException();
    }

    public async Task<List<ProductDto>> GetByName(string name)
    {
        var lst = await _dbContext.Products
             .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
             .AsNoTracking()
             .Select(x => new ProductDto(x))
            .ToListAsync();
        return lst;
    }

    public async Task<PagedResult<ProductDto>> GetPageAsync(PagedQueryBase query)
    {
        var page = await _dbContext.Products
                .AsNoTracking()
                .Select(x => new ProductDto(x))
                .PaginateAsync();
        return page;

    }
}

