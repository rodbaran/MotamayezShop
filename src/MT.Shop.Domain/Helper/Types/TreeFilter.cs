using System.Linq.Expressions;

namespace MT.Shop.Domain.Helper.Types;

public class TreeFilter : WhereFilter
{
    /// <summary>
    ///     Filters with infinite nesting and boolean operations therebetween.
    /// </summary>
    public TreeFilter()
    {
        Condition = TreeFilterType.None;
    }

    /// <summary>
    ///     Type of logical operator.
    /// </summary>
    public TreeFilterType Condition { get; set; }

    /// <summary>
    ///     Operands of boolean expressions.
    /// </summary>
    public List<TreeFilter> Rules { get; set; }

    public Expression<Func<T, bool>> ToExpression<T>()
    {
        if (Rules == null || !Rules.Any())
        {
            return x => true; // اگر قوانین وجود ندارند، فیلتر بی‌اثر باشد
        }

        ParameterExpression parameter = Expression.Parameter(typeof(T), "x");
        Expression body = BuildExpressionBody(parameter);

        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }

    private Expression BuildExpressionBody(ParameterExpression parameter)
    {
        if (Rules == null || !Rules.Any())
            return Expression.Constant(true);

        Expression result = null;

        foreach (var rule in Rules)
        {
            var ruleExpression = rule.BuildExpressionBody(parameter);

            if (result == null)
            {
                result = ruleExpression;
            }
            else
            {
                if (Condition == TreeFilterType.And)
                {
                    result = Expression.AndAlso(result, ruleExpression);
                }
                else if (Condition == TreeFilterType.Or)
                {
                    result = Expression.OrElse(result, ruleExpression);
                }
            }
        }

        return result ?? Expression.Constant(true);
    }


}

