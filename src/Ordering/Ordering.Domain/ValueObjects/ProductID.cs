namespace Ordering.Domain.ValueObjects;

public record ProductID
{
    public Guid Value { get;}
    private ProductID(Guid value)
    {
        Value = value;
    }
    public static ProductID Of(Guid value)
    {
        ArgumentNullException.ThrowIfNull(value);
        if (value == Guid.Empty)
        {
            throw new DomainException("CustomerId cannot be empty.");
        }

        return new ProductID(value);
    }

}
