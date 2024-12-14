using Newtonsoft.Json.Linq;


namespace MT.Shop.Domain.Helper.Types;

public interface IPagedQuery : IQuery
{
    int Page { get; protected set; }
    int Results { get; protected set; }
    List<MultiSortMetaItem> MultiSortMeta { get; set; }
    JObject Filters { get; set; }
}