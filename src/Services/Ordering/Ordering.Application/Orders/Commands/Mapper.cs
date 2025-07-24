namespace Ordering.Application.Orders.Commands;

using CreateOrder;
using Dtos;
using Domain.Entities;
using Domain.ValueObjects;

public static class Mapper
{
    public static Order ToEntity(this CreateOrderCommand command)
    {
        var order = Order.Create(
            OrderId.New(),
            CustomerId.Of(command.CustomerId),
            OrderName.Of(command.Name),
            command.ShippingAddress.ToEntity(),
            command.BillingAddress.ToEntity(),
            command.Payment.ToEntity());

        foreach (var item in command.Items)
        {
            order.AddItem(
                ProductId.Of(item.ProductId),
                item.Quantity,
                item.Price);
        }

        return order;
    }

    public static Address ToEntity(this AddressDto address)
    {
        return Address.Of(
            address.FirstName,
            address.LastName,
            address.Email,
            address.AddressLine,
            address.Country,
            address.State,
            address.ZipCode);
    }

    public static Payment ToEntity(this PaymentDto payment)
    {
        return Payment.Of(
            payment.CardNumber,
            payment.CardHolderName,
            payment.CardExpiration,
            payment.CardSecurityCode,
            payment.PaymentMethod);
    }
}
