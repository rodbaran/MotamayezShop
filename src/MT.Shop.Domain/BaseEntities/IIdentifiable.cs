using System.ComponentModel.DataAnnotations;

namespace MT.Shop.Domain.BaseEntities;

public interface IIdentifiable<T>
{
    T Id { get; }

    [Timestamp]
    byte[] VersionCtrl { get; }
}
