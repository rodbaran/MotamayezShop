using FluentValidation;
using MT.Shop.Application.Features.Orders.Commands.Create;
using MT.Shop.Domain.Entities.Orders;


namespace MT.Shop.Application.Features.Orders.Validators;

public class CreateOrderValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderValidator()
    {

        RuleFor(x => x.UserId)
            .NotEmpty().WithMessage(string.Format(OrderErrors.Required, nameof(CreateOrderCommand.UserId)));


        RuleFor(x => x.OrderDetails)
            .NotEmpty().WithMessage(OrderErrors.RequiredOrderDetail)
            .Must(details => details.Any()).WithMessage(OrderErrors.RequiredOrderDetail);


        RuleForEach(x => x.OrderDetails).ChildRules(orderDetail =>
        {

            orderDetail.RuleFor(od => od.ProductId)
                .NotEmpty().WithMessage(string.Format(OrderErrors.Required, "کالا"));

            orderDetail.RuleFor(od => od.Quantity)
                .GreaterThan(0).WithMessage(OrderErrors.GreaterThanZeroQuantity);

            orderDetail.RuleFor(od => od.UnitPrice)
                .GreaterThan(0).WithMessage(OrderErrors.GreaterThanZeroQuantity);
        });
    }

}
