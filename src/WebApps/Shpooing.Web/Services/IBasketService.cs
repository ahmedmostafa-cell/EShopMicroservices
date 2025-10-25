namespace Shpooing.Web.Services;

public interface IBasketService
{
    [Post("/basket-service/basket")]
    Task<StoreBasketResponse> StoreBasketRequest(StoreBasketRequest request);

    [Get("/basket-service/basket/{username}")]
    Task<GetBasketResponse> GetBasket(string username);

    [Delete("/basket-service/basket/{UserName}")]
    Task<DeleteBasketResponse> DeleteBasket(string UserName);

    [Post("/basket-service/basket/checkout")]
    Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);

    public async Task<ShoppingCartModel> LoadUserBasket()
    {
        var username = "Fawza";
        try 
        {
			var basket = await GetBasket(username);

			return basket.Cart;
		}
        catch(Exception ex) 
        {
			return new  ShoppingCartModel { UserName = username };

		}


	}

}
