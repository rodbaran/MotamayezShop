using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MT.Shop.Domain.Helper.Types;
using Microsoft.EntityFrameworkCore;

namespace MT.Shop.Domain.Helper;

public static class Extensions
{
    public static IEnumerable<T> WhereByGrid<T>(this IEnumerable<T> query, JObject filters)
    {
        if (filters == null || !filters.HasValues)
            return query;

        foreach (var filter in filters)
        {
            var propertyName = filter.Key;
            var value = filter.Value.ToString();

            query = query.Where(item => EF.Property<string>(item, propertyName).Contains(value));
        }

        return query;
    }

    public static IEnumerable<T> OrderByGrid<T>(this IEnumerable<T> query, List<MultiSortMetaItem> multiSortMeta)
    {
        if (multiSortMeta == null || !multiSortMeta.Any())
            return query;

        foreach (var sortMeta in multiSortMeta)
        {
            var propertyName = sortMeta.Field;
            var isDescending = sortMeta.Order;

            if (isDescending == 1)
            {
                query.OrderByDescending(x => EF.Property<object>(x, propertyName));
            }
            else
            {
                query.OrderBy(x => EF.Property<object>(x, propertyName));
            }
              
        }
        return query;
    }
}
