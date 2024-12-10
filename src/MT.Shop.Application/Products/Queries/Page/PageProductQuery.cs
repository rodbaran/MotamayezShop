using MediatR;
using MT.Shop.Domain.Helper.Types;
using MT.Shop.Domain.Products.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
namespace MT.Shop.Application.Products.Queries.Page;

public class PageProductsQuery : PagedQueryBase , IRequest<PagedResult<ProductDto>>;
