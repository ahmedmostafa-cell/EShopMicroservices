namespace Basket.API.Basket.DeleteBasket;

public record DeleteBasketCommand(string UserName) : IQuery<DeleteBasketResult>;
public record DeleteBasketResult(bool IsSuccess);

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("UserName is required.");
    }
}

internal class DeleteBasketHandler(IBasketRepository basketRepository)
    : IQueryHandler<DeleteBasketCommand, DeleteBasketResult>
{
    public async Task<DeleteBasketResult> Handle(DeleteBasketCommand command,
        CancellationToken cancellationToken)
    {
        var result = await basketRepository.DeleteBasket(command.UserName, 
            cancellationToken);
            

        return new DeleteBasketResult(result);
    }
}
