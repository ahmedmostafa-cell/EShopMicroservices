using Ordering.Domain.Enums;

namespace Ordering.Infrastructure.Data.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id).HasConversion(
                orderId => orderId.Value,
                dbId => OrderId.Of(dbId));


        builder.HasMany(o => o.Items).WithOne().HasForeignKey(oi => oi.OrderId);

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.ComplexProperty(o => o.OrderName , nameBuilder=>
        {
            nameBuilder.Property(n => n.Value).HasColumnName(nameof(Order.OrderName))
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.ComplexProperty(o => o.ShippingAddress, nameBuilder =>
        {
            nameBuilder.Property(s => s.FirstName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(s => s.LastName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(s => s.EmailAddress).HasMaxLength(50);
            nameBuilder.Property(s => s.AddressLine).HasMaxLength(100).IsRequired();
            nameBuilder.Property(s => s.Country).HasMaxLength(50);
            nameBuilder.Property(s => s.State).HasMaxLength(50);
            nameBuilder.Property(s => s.ZipCode).HasMaxLength(5);
        });

        builder.ComplexProperty(o => o.BillingAddress, nameBuilder =>
        {
            nameBuilder.Property(b => b.FirstName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(b => b.LastName).HasMaxLength(50).IsRequired();
            nameBuilder.Property(b => b.EmailAddress).HasMaxLength(50);
            nameBuilder.Property(b => b.AddressLine).HasMaxLength(180).IsRequired();
            nameBuilder.Property(b => b.Country).HasMaxLength(50);
            nameBuilder.Property(b => b.State).HasMaxLength(50);
            nameBuilder.Property(b => b.ZipCode).HasMaxLength(5);

        });

        builder.ComplexProperty(o => o.Payment, nameBuilder =>
        {
            nameBuilder.Property(p => p.CardName).HasMaxLength(50);
            nameBuilder.Property(p => p.CardNumber).HasMaxLength(24).IsRequired();
            nameBuilder.Property(p => p.Expiration).HasMaxLength(10);
            nameBuilder.Property(p => p.CVV).HasMaxLength(3);
            nameBuilder.Property(p => p.PaymentMethod).HasMaxLength(50);

        });

        builder.Property(c => c.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
               s => s.ToString(),
               dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus),dbStatus));


        builder.Property(c => c.TotalPrice);
    }
}
