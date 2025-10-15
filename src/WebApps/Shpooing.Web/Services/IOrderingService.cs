namespace Shpooing.Web.Services;

public interface IOrderingService
{
    [Get("/ordering-service/orders")]
    Task<GetOrdersResponse> GetOrders([AsParameters] PaginationRequest PaginationRequest);

    [Get("/ordering-service/orders/customer/{customerID}")]
    Task<GetOrderByCustomerResponse> GetOrderByCustomer(Guid customerID);

    [Get("/ordering-service/orders/{orderName}")]
    Task<GetOrderByNameResponse> GetOrderByName(string orderName);
}

public record PaginationRequest(int pageIndex = 0, int pageSize = 10);
