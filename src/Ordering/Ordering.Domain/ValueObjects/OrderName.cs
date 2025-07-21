namespace Ordering.Domain.ValueObjects;

public record OrderName
{
    private const int DefaulLength = 5;
    public string Value { get;} = default!;
    private OrderName(string value)
    {
        Value = value;
    }
    public static OrderName Of(string value)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(value);
        ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length , DefaulLength);
        if (value == string.Empty)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new OrderName(value);
    }
}
