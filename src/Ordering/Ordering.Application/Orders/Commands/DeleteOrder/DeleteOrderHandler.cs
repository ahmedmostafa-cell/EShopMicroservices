﻿namespace Ordering.Application.Orders.Commands.DeleteOrder;

public class DeleteOrderHandler(IApplicationDbContext dbContext)
        : ICommandHandler<DeleteOrderCommand, DeleteOrderResult>
{
    public async Task<DeleteOrderResult> Handle(DeleteOrderCommand command,
        CancellationToken cancellationToken)
    {
        var orderId = OrderId.Of(command.orderId);
        var existingOrder = await dbContext.Orders
            .FindAsync([orderId], cancellationToken);
        if (existingOrder is null)
        {
            throw new OrderNotFoundException(command.orderId);
        }
        dbContext.Orders.Remove(existingOrder);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new DeleteOrderResult(true);
    }
}
