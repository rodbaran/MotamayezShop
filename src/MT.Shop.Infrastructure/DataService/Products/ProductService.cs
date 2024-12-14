using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Entities.Products;
using MT.Shop.Domain.Entities.Products.Dto;
using MT.Shop.Domain.Exceptions;
using MT.Shop.Domain.Helper;
using MT.Shop.Domain.Helper.Types;
using MT.Shop.Infrastructure.DBContext;

namespace MT.Shop.Infrastructure.DataService.Products;

public sealed class ProductService : IProductService
{
    private readonly ApplicationDbContext _dbContext;

    public ProductService(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<List<ProductDto>> GetListProductsAsync(CancellationToken cancellationToken)
    {
        var lst = await _dbContext.Products
            .AsNoTracking()
            .Select(x => new ProductDto(x))
            .ToListAsync(cancellationToken);
        return lst;
    }

    public async Task<ProductDto> GetProductById(int id, CancellationToken cancellationToken)
    {
        var item = await _dbContext.Products
            .AsNoTracking()
            .Select(x => new ProductDto(x))
            .FirstOrDefaultAsync(cancellationToken);

        return item ?? throw new NotFoundEntityException(ProductErrors.NotExist);
    }

    public async Task<List<ProductDto>> GetProductsByName(string name, CancellationToken cancellationToken)
    {
        var lst = await _dbContext.Products
             .Where(p => EF.Functions.Like(p.Name, $"%{name}%"))
             .AsNoTracking()
             .Select(x => new ProductDto(x))
            .ToListAsync();
        return lst;
    }

    public async Task<PagedResult<ProductDto>>  GetPagedProductsAsync(PagedQueryBase query, CancellationToken cancellationToken)
    {
        var page = await _dbContext.Products
                .AsNoTracking()
                .Select(x => new ProductDto(x))
                .PaginateAsync(query, cancellationToken);
        return page;

    }
}

