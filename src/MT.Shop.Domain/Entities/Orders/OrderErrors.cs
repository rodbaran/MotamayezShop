namespace MT.Shop.Domain.Entities.Orders;

public static class OrderErrors
{
    public const string Required = "مقدار {0} اجباری می باشد ";

    public const string ProductNotFound = "کالای {0} یافت نشد";

    public const string OrderNotFound = "چنین سفارشی به شناسه {0} یافت نشد ";

    public const string NotAuthorized = "مشتری در سیستم یافت نشد";

    public const string InStockMultiple = "موجودی کالای {0} کافی نمی باشد";

    public const string RequiredOrderDetail = "سفارش شما دارای آیتم نمی باشد";

    public const string GreaterThanZeroQuantity = "مقدار باید از 0 بیشتر باشد";

    public const string InStock = "موجودی کالای {0} کافی نمی باشد لطفا مجدد تلاش کنید ";

    public const string DraftOnlyApprovable = "فقط فاکتور های با وضیعت پیش نویس قابلیت تایید شدن دارند ";

    public const string OrderAlreadyCanceled = "سفارش شما در وضیعت ابطال می باشد و نیازی به ابطال آن نیست";

    public const string EmptyOrderDetails = "جزییات نمی تواند خالی باشد ";

    public const string InsufficientStock = "موجودی به تعداد کافی نمی باشد";

    public const string OrderForUserNotFound = "سفارشی برای کاربر با شناسه {0} وجود ندارد ";
}
