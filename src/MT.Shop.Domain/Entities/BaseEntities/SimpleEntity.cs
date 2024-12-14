using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MT.Shop.Domain.Entities.BaseEntities;

public class SimpleEntity<T> : BaseEntity<T>
{
    [Column(Order = 1)]
    [MaxLength(20)]
    [Required]
    public string Code { get; protected set; }

    [MaxLength(60)]
    [Column(Order = 2)]
    [Required]
    public string Name { get; protected set; }


    [Column(Order = 991)]
    public bool? IsActive { get; protected set; } = true;


    // متدهای مدیریت فعال بودن
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
