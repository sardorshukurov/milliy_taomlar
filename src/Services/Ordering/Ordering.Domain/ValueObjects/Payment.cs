namespace Ordering.Domain.ValueObjects;

public record Payment
{
    public string CardNumber { get; } = string.Empty;
    public string CardHolderName { get; } = string.Empty;
    public string CardExpiration { get; } = string.Empty;
    public string CardSecurityCode { get; } = string.Empty;
    public int PaymentMethod { get; }

    protected Payment() { }

    private Payment(
        string cardNumber,
        string cardHolderName,
        string cardExpiration,
        string cardSecurityCode,
        int paymentMethod)
    {
        CardNumber = cardNumber;
        CardHolderName = cardHolderName;
        CardExpiration = cardExpiration;
        CardSecurityCode = cardSecurityCode;
        PaymentMethod = paymentMethod;
    }

    public static Payment Of(
        string cardNumber,
        string cardHolderName,
        string cardExpiration,
        string cardSecurityCode,
        int paymentMethod)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(cardNumber);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardHolderName);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardExpiration);
        ArgumentException.ThrowIfNullOrWhiteSpace(cardSecurityCode);
        ArgumentOutOfRangeException.ThrowIfNotEqual(cardSecurityCode.Length, 3,
            "Card security code must be 3 digits");

        return new Payment(
            cardNumber,
            cardHolderName,
            cardExpiration,
            cardSecurityCode,
            paymentMethod);
    }
}
