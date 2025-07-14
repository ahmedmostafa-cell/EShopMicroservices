namespace Basket.API.Basket.StoreBasket;

public record StoreBasketCommand(ShoppingCart Cart)
: ICommand<StoreBasketResult>;
public record StoreBasketResult(string UserName);

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(x => x.Cart).NotNull().WithMessage("Cart Can Not Be nULL.");
        RuleFor(x => x.Cart.UserName).NotEmpty().WithMessage("UserName is required.");
    }
}
internal class StoreBasketHandler(IBasketRepository basketRepository ,
    DiscountProtoService.DiscountProtoServiceClient discountProto) :
    ICommandHandler<StoreBasketCommand, StoreBasketResult>
{
    public async Task<StoreBasketResult> Handle(StoreBasketCommand command, 
        CancellationToken cancellationToken)
    {
        await DeductDiscount(command, cancellationToken);

        var cart = await basketRepository.StoreBasket(command.Cart,
            cancellationToken);

        return new StoreBasketResult(cart.UserName);
    }

    private async Task DeductDiscount(StoreBasketCommand command, CancellationToken cancellationToken)
    {
        foreach (var item in command.Cart.Items)
        {
            var coupon = await discountProto.GetDiscountAsync(
                 new GetDiscountRequest { ProductName = item.ProductName },
                 cancellationToken: cancellationToken);
            if (coupon != null && coupon.Amount > 0)
            {
                item.Price -= coupon.Amount;
            }
        }
    }
}
