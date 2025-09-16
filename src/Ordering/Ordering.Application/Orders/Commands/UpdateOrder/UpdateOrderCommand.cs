﻿namespace Ordering.Application.Orders.Commands.UpdateOrder;

public record UpdateOrderCommand(OrderDto OrderDto)
    : ICommand<UpdateOrderResult>;

public record UpdateOrderResult(bool IsSuccess);

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(x => x.OrderDto.CustomerId)
            .NotEmpty()
            .WithMessage("CustomerId is required.");
        RuleFor(x => x.OrderDto.OrderName)
            .NotEmpty()
            .WithMessage("OrderName is required.");
        RuleFor(x => x.OrderDto.Id)
            .NotNull()
            .WithMessage("Id is required.");
    }
}
