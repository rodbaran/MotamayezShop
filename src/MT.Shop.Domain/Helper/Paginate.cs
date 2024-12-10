using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Helper.Types;
using Newtonsoft.Json.Linq;


namespace MT.Shop.Domain.Helper;

public static class Pagination
{
    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection, PagedQueryBase query)
    {
        return await collection.PaginateAsync(query.Page, query.Results, query.MultiSortMeta, query.Filters);
    }

    public static async Task<PagedResult<T>> PaginateAsync<T>(this IQueryable<T> collection,
        int page = 1, int resultsPerPage = 10, List<MultiSortMetaItem> multiSortMeta = null, JObject filters = null)
    {
        if (page <= 0) page = 1;
        if (resultsPerPage <= 0) resultsPerPage = 10;
        var isEmpty = await collection.AnyAsync() == false;
        if (isEmpty) return PagedResult<T>.Empty;

        collection = collection.WhereByGrid(filters);

        if (multiSortMeta != null && multiSortMeta.Any())
            collection = collection.OrderByGrid(multiSortMeta);

        var totalResults = await collection.CountAsync();
        var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);
        var data = await collection.Limit(page, resultsPerPage).ToListAsync();

        return PagedResult<T>.Create(data, page, resultsPerPage, totalPages, totalResults);
    }

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, PagedQueryBase query)
    {
        return collection.Limit(query.Page, query.Results);
    }

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection,
        int page = 1, int resultsPerPage = 10)
    {
        if (page <= 0) page = 1;
        if (resultsPerPage <= 0) resultsPerPage = 10;
        var skip = (page - 1) * resultsPerPage;
        var data = collection.Skip(skip)
            .Take(resultsPerPage);

        return data;
    }
}