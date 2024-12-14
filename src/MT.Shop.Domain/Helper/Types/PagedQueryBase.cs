using Newtonsoft.Json.Linq;
using System.Collections.Generic;

namespace MT.Shop.Domain.Helper.Types;

public abstract class PagedQueryBase : IPagedQuery
{
    protected PagedQueryBase()
    {
        MultiSortMeta = new List<MultiSortMetaItem>();
    }

    public int Page { get; set; }
    public int Results { get; set; }
    public List<MultiSortMetaItem> MultiSortMeta { get; set; }
    public JObject? Filters { get; set; }
}