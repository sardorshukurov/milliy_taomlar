namespace Ordering.Infrastructure.Data.Configurations;

using Domain.ValueObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.Property(o => o.Id).HasConversion(
            orderId => orderId.Value,
            dbId => OrderId.Of(dbId)
        );

        builder.HasOne<Customer>()
            .WithMany()
            .HasForeignKey(o => o.CustomerId)
            .IsRequired();

        builder.HasMany(o => o.Items)
            .WithOne()
            .HasForeignKey(oi => oi.OrderId);

        builder.ComplexProperty(
            o => o.Name, nameBuilder =>
        {
            nameBuilder.Property(n => n.Value)
                .HasColumnName(nameof(Order.Name))
                .HasMaxLength(100)
                .IsRequired();
        });

        builder.ComplexProperty(
            o => o.ShippingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(10)
                    .IsRequired();
            });

        builder.ComplexProperty(
            o => o.BillingAddress, addressBuilder =>
            {
                addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.State)
                    .HasMaxLength(50)
                    .IsRequired();

                addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(10)
                    .IsRequired();
            });

        builder.ComplexProperty(
            o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(p => p.CardNumber)
                    .HasMaxLength(24)
                    .IsRequired();

                paymentBuilder.Property(p => p.CardHolderName)
                    .HasMaxLength(50)
                    .IsRequired();

                paymentBuilder.Property(p => p.CardExpiration)
                    .HasMaxLength(10)
                    .IsRequired();

                paymentBuilder.Property(p => p.CardSecurityCode)
                    .HasMaxLength(3)
                    .IsRequired();

                paymentBuilder.Property(p => p.PaymentMethod);
            });

        builder.Property(o => o.Status)
            .HasDefaultValue(OrderStatus.Draft)
            .HasConversion(
                s => s.ToString(),
                dbStatus => Enum.Parse<OrderStatus>(dbStatus)
            );

        builder.Property(o => o.TotalPrice);
    }
}
