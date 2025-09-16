namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderCommand(OrderDto OrderDto) 
    :ICommand<CreateOrderResult>;

public record CreateOrderResult(Guid Id);

public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidator()
    {
        RuleFor(x => x.OrderDto.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required.");
        RuleFor(x => x.OrderDto.OrderName)
            .NotEmpty()
            .WithMessage("OrderName is required.");
        RuleFor(x => x.OrderDto.OrderItems)
            .NotNull()
            .WithMessage("OrderItems are required.");
    }
}