using Newtonsoft.Json.Linq;
using Newtonsoft.Json;
using MT.Shop.Domain.Helper.Types;
using System.Linq.Expressions;

namespace MT.Shop.Domain.Helper;

public static class Extensions
{
    public static IQueryable<T> WhereByGrid<T>(this IQueryable<T> query, JObject filters)
    {
        if (filters != null)
        {
            var filter = JsonConvert.DeserializeObject<TreeFilter>(filters.ToString(Formatting.None));
            var predicate = filter.ToExpression<T>();
            query = query.Where(predicate);
        }

        return query;
    }

    public static IOrderedQueryable<T> OrderByGrid<T>(this IQueryable<T> query, List<MultiSortMetaItem> sorts)
    {
        IOrderedQueryable<T> ordered = null;
        if (!sorts.Any())
        {
            ordered = query.OrderBy(x => 0);
        }
        else
        {
            var expr = ToLambda<T>(sorts[0].Field);
            if (sorts[0].Order == 1)
                ordered = query.OrderBy(expr);
            else
                ordered = query.OrderByDescending(expr);

            sorts.Remove(sorts[0]);
        }

        if (sorts != null && sorts.Any())
            foreach (var sort in sorts)
            {
                var expr = ToLambda<T>(sort.Field);
                if (sort.Order == 1)
                    ordered = ordered.ThenBy(expr);
                else
                    ordered = ordered.ThenByDescending(expr);
            }

        return ordered;
    }


    private static Expression<Func<T, object>> ToLambda<T>(string propertyName)
    {
        var parameter = Expression.Parameter(typeof(T));
        var property = Expression.Property(parameter, propertyName);
        var propAsObject = Expression.Convert(property, typeof(object));

        return Expression.Lambda<Func<T, object>>(propAsObject, parameter);
    }


}
