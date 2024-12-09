using System.ComponentModel.DataAnnotations;

namespace MT.Shop.Domain.BaseEntities;

public class SimpleEntity<T> : BaseEntity<T>
{
    [Required]
    public string Code { get; protected set; }

    [MaxLength(255)]
    [Required]
    public string Name { get; protected set; }

    [MaxLength(255)]
    public bool IsActive { get; protected set; } = true;


    // متدهای مدیریت فعال بودن
    public void Activate() => IsActive = true;
    public void Deactivate() => IsActive = false;
}
