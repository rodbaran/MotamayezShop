using Microsoft.EntityFrameworkCore;
using MT.Shop.Domain.Helper.Types;
using Newtonsoft.Json.Linq;

namespace MT.Shop.Domain.Helper;

public static class Pagination
{
    public static async Task<PagedResult<T>> PaginateAsync<T>(
        this IQueryable<T> collection,
        PagedQueryBase query,
        CancellationToken cancellationToken = default)
    {
        return await collection.PaginateAsync(
            query.Page,
            query.Results,
            query.MultiSortMeta,
            query.Filters,
            cancellationToken);
    }

    public static async Task<PagedResult<T>> PaginateAsync<T>(
        this IQueryable<T> collection,
        int page = 1,
        int resultsPerPage = 10,
        List<MultiSortMetaItem> multiSortMeta = null,
        JObject filters = null,
        CancellationToken cancellationToken = default)
    {
        if (page <= 0) page = 1;
        if (resultsPerPage <= 0) resultsPerPage = 10;

        // بررسی خالی بودن مجموعه
        var isEmpty = await collection.AnyAsync(cancellationToken) == false;
        if (isEmpty) return PagedResult<T>.Empty;

        // بارگذاری داده‌ها به حافظه
        var dataInMemory = await collection.ToListAsync(cancellationToken);

        // اعمال فیلتر و مرتب‌سازی در حافظه
        var filteredData = dataInMemory
            .WhereByGrid(filters)
            .OrderByGrid(multiSortMeta)
            .Skip((page - 1) * resultsPerPage)
            .Take(resultsPerPage)
            .ToList();

        var totalResults = filteredData.Count;
        var totalPages = (int)Math.Ceiling((decimal)totalResults / resultsPerPage);

        return PagedResult<T>.Create(filteredData, page, resultsPerPage, totalPages, totalResults);
    }

    public static IQueryable<T> Limit<T>(this IQueryable<T> collection, PagedQueryBase query)
    {
        return collection.Limit(query.Page, query.Results);
    }

    public static IQueryable<T> Limit<T>(
        this IQueryable<T> collection,
        int page = 1,
        int resultsPerPage = 10)
    {
        if (page <= 0) page = 1;
        if (resultsPerPage <= 0) resultsPerPage = 10;
        var skip = (page - 1) * resultsPerPage;
        var data = collection.Skip(skip)
            .Take(resultsPerPage);

        return data;
    }
}
