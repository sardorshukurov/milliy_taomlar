namespace Ordering.Application.Dtos;

public record PaymentDto(
    string CardNumber,
    string CardHolderName,
    string CardExpiration,
    string CardSecurityCode,
    int PaymentMethod
);
