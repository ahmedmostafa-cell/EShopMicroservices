namespace Ordering.Application.Orders.Commands.CreateOrder;


public class CreateOrderHandler:
        ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public async Task<CreateOrderResult> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
    {

        // create order entiy from command object
        // save order to database
        // return the result with the order id
        throw new NotImplementedException();
    }
}
