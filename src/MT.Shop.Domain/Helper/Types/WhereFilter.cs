namespace MT.Shop.Domain.Helper.Types;

public class WhereFilter
{
    /// <summary>
    ///     Tree filter for queryable expression.
    /// </summary>
    public WhereFilter()
    {
        Operator = WhereFilterType.None;
    }

    /// <summary>
    ///     Filter field name.
    /// </summary>
    public string Field { get; set; }

    /// <summary>
    ///     Type of field filtration.
    /// </summary>
    public WhereFilterType Operator { get; set; }

    /// <summary>
    ///     Value for filtering.
    /// </summary>
    public object Value { get; set; }
}