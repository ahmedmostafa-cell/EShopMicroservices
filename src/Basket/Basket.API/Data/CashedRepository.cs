using Microsoft.Extensions.Caching.Distributed;

namespace Basket.API.Data
{
    public class CashedRepository(IBasketRepository repository 
        , IDistributedCache cache)
        : IBasketRepository
    {
        public async Task<ShoppingCart> GetBasket(string userName, CancellationToken cancellationToken = default)
        {
            var cashedBasket = await cache.GetStringAsync(userName, cancellationToken);
            if(!string.IsNullOrEmpty(cashedBasket))
            {
                return JsonSerializer.Deserialize<ShoppingCart>(cashedBasket)!;
            }
            else 
            {
                var basket = await repository.GetBasket(userName, cancellationToken);
                await cache.SetStringAsync(userName,JsonSerializer.Serialize(basket), 
                    cancellationToken);

                return basket;
            }

        }

        public async Task<ShoppingCart> StoreBasket(ShoppingCart basket, 
            CancellationToken cancellationToken = default)
        {
            await cache.SetStringAsync(basket.UserName, JsonSerializer.Serialize(basket),
                   cancellationToken);
            return await repository.StoreBasket(basket, cancellationToken);
        }

        public async Task<bool> DeleteBasket(string userName,
            CancellationToken cancellationToken = default)
        {
            var cashedBasket = await cache.GetStringAsync(userName, cancellationToken);
            if (!string.IsNullOrEmpty(cashedBasket))
            {
                await cache.RemoveAsync(userName, cancellationToken);
            }

            return await repository.DeleteBasket(userName, cancellationToken);
        }
    }
}
