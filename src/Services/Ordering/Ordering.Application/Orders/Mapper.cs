namespace Ordering.Application.Orders;

using Dtos;
using Domain.Entities;
using Domain.ValueObjects;
using Commands.CreateOrder;
using Commands.UpdateOrder;

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

    public static void UpdateEntity(this Order order, UpdateOrderCommand command)
    {
        order.Update(
            OrderName.Of(command.Order.Name),
            command.Order.ShippingAddress.ToEntity(),
            command.Order.BillingAddress.ToEntity(),
            command.Order.Payment.ToEntity(),
            command.Order.Status);
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

    public static AddressDto ToDto(this Address address)
    {
        return new AddressDto(
            address.FirstName,
            address.LastName,
            address.Email,
            address.AddressLine,
            address.Country,
            address.State,
            address.ZipCode);
    }

    public static PaymentDto ToDto(this Payment payment)
    {
        return new PaymentDto(
            payment.CardNumber,
            payment.CardHolderName,
            payment.CardExpiration,
            payment.CardSecurityCode,
            payment.PaymentMethod);
    }

    public static OrderDto ToDto(this Order order)
    {
        return new OrderDto(
            order.Id.Value,
            order.CustomerId.Value,
            order.Name.Value,
            order.ShippingAddress.ToDto(),
            order.BillingAddress.ToDto(),
            order.Payment.ToDto(),
            order.Status,
            [.. order.Items.Select(i => new OrderItemDto(
                order.Id.Value,
                i.ProductId.Value,
                i.Quantity,
                i.Price))]);
    }
}
