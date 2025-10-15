namespace Shpooing.Web.Services;

public interface IBasketService
{
    [Post("/basket-service/baskets/{request}")]
    Task<StoreBasketResponse> StoreBasketRequest(StoreBasketRequest request);

    [Get("/basket-service/baskets/{username}")]
    Task<GetBasketResponse> GetBasket(string username);

    [Delete("/basket-service/baskets/{UserName}")]
    Task<DeleteBasketResponse> DeleteBasket(string UserName);

    [Post("/basket-service/basket/checkout/{request}")]
    Task<CheckoutBasketResponse> CheckoutBasket(CheckoutBasketRequest request);

}
