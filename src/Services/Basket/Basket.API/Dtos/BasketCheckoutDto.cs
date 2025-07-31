namespace Basket.API.Dtos;

public record BasketCheckoutDto
{
    public string Username { get; init; } = string.Empty;

    public Guid CustomerId { get; init; }

    public decimal TotalPrice { get; init; }

    // Shipping and Billing Address
    public string FirstName { get; init; } = string.Empty;

    public string LastName { get; init; } = string.Empty;

    public string Email { get; init; } = string.Empty;

    public string AddressLine { get; init; } = string.Empty;

    public string Country { get; init; } = string.Empty;

    public string State { get; init; } = string.Empty;

    public string ZipCode { get; init; } = string.Empty;

    // Payment
    public string CardNumber { get; init; } = string.Empty;

    public string CardHolderName { get; init; } = string.Empty;

    public string CardExpiration { get; init; } = string.Empty;

    public string CardSecurityCode { get; init; } = string.Empty;

    public int PaymentMethod { get; init; }
}
