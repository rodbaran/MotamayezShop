
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MT.Shop.Domain.Entities.BaseEntities;

public abstract class BaseEntity<T> : IIdentifiable<T>
{
    [Column(Order = 0)]
    public T Id { get; protected set; }


    [Column(Order = 993)]
    [Timestamp]
    public byte[]? VersionCtrl { get; protected set; }

    [Column(Order = 994)]
    public DateTime CreatedOn { get; protected set; } = DateTime.UtcNow;

    [Column(Order = 995)]
    public int CreatedBy { get; protected set; }

    [Column(Order = 996)]
    public DateTime? ModifiedOn { get; protected set; }

    [Column(Order = 997)]
    public int? ModifiedBy { get; protected set; }

    [Column(Order = 992)]
    public bool? IsDelete { get; set; } = false;

    // متد برای مقداردهی اولیه زمان و کاربر ایجادکننده
    public void SetCreatedBy(int userId)
    {
        CreatedBy = userId;
        CreatedOn = DateTime.UtcNow;
    }

    // متد برای تنظیم تغییرات
    public void SetModifiedBy(int userId)
    {
        ModifiedBy = userId;
        ModifiedOn = DateTime.UtcNow;
    }
    public void SetDeleted()
    {
        IsDelete = true;
    }
}

