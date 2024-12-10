
namespace MT.Shop.Domain.BaseEntities;

public abstract class BaseEntity<T> : IIdentifiable<T>
{
    public T Id { get; protected set; }

    // کنترل هم‌زمانی
    public byte[] VersionCtrl { get; protected set; }

    public DateTime CreatedOn { get; protected set; } = DateTime.Now;
    public int CreatedBy { get; protected set; }
    public DateTime? ModifiedOn { get; protected set; }
    public int? ModifiedBy { get; protected set; }

    public bool IsDelete { get;  set; } = false;

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

