namespace Basket.API.Basket.StoreBasket
{
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
    internal class StoreBasketHandler(IDocumentSession session) :
        ICommandHandler<StoreBasketCommand, StoreBasketResult>
    {
        public async Task<StoreBasketResult> Handle(StoreBasketCommand command, 
            CancellationToken cancellationToken)
        {
           ShoppingCart shoppingCart = command.Cart;
            //ToDo Store Basket in database (use marten upsert if exist update and
            //if not create new one)
            //ToDo update cash
            return new StoreBasketResult("ahmed");
        }
    }
}
