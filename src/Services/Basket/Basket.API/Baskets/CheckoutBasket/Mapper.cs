namespace Basket.API.Baskets.CheckoutBasket;

using Dtos;
using Shared.Messaging.Events;

public static class Mapper
{
    public static BasketCheckoutEvent ToEvent(this BasketCheckoutDto dto)
    {
        return new BasketCheckoutEvent
        {
            Username = dto.Username,
            CustomerId = dto.CustomerId,
            TotalPrice = dto.TotalPrice,
            FirstName = dto.FirstName,
            LastName = dto.LastName,
            Email = dto.Email,
            AddressLine = dto.AddressLine,
            Country = dto.Country,
            State = dto.State,
            ZipCode = dto.ZipCode,
            CardNumber = dto.CardNumber,
            CardHolderName = dto.CardHolderName,
            CardExpiration = dto.CardExpiration,
            CardSecurityCode = dto.CardSecurityCode,
            PaymentMethod = dto.PaymentMethod,
        };
    }
}
