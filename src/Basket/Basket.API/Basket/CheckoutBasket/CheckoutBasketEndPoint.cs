using Basket.API.Dtos;

namespace Basket.API.Basket.CheckoutBasket;

public record CheckoutBasketRequest(BasketCheckoutDto BasketCheckoutDto);  
public record CheckoutBasketResponse(bool IsSuccess);
public class CheckoutBasketEndPoint : ICarterModule
{
	public void AddRoutes(IEndpointRouteBuilder app)
	{
		throw new NotImplementedException();
	}
}
