namespace Basket.API.Basket.DeleteBasket
{
    public record DeleteBasketCommand(string UserName) : IQuery<DeleteBasketResult>;
    public record DeleteBasketResult(bool IsSuccess);

    public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
    {
        public DeleteBasketCommandValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
        }
    }

    internal class DeleteBasketHandler(IDocumentSession session)
        : IQueryHandler<DeleteBasketCommand, DeleteBasketResult>
    {
        public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command,
            CancellationToken cancellationToken)
        {
            //var basket = await session.LoadAsync<ShoppingCart>(command.UserName, cancellationToken);
            //if (basket is null)
            //{
            //    throw new BasketNotFoundException(command.UserName);
            //}
            //session.Delete<ShoppingCart>(command.UserName);
            //await session.SaveChangesAsync(cancellationToken);

            return new DeleteBasketResult(true);
        }
    }
}
