using System.ComponentModel.DataAnnotations;

namespace MT.Shop.Domain.Entities.BaseEntities;

public interface IIdentifiable<T>
{
    T Id { get; }

}
