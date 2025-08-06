namespace Ordering.Application.Dtos;

public record OrderItemDto(
    Guid OrderId,
    decimal Price,
    int Quantity);
