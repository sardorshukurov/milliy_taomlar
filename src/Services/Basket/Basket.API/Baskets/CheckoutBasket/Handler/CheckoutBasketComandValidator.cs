namespace Basket.API.Baskets.CheckoutBasket.Handler;

using FluentValidation;

public class CheckoutBasketComandValidator
    : AbstractValidator<CheckoutBasketCommand>
{
    public CheckoutBasketComandValidator()
    {
        RuleFor(x => x.Basket).NotNull().WithMessage("Basket is required");
        RuleFor(x => x.Basket.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(x => x.Basket.CustomerId).NotEmpty().WithMessage("CustomerId is required");
        RuleFor(x => x.Basket.TotalPrice).GreaterThan(0).WithMessage("TotalPrice must be greater than 0");
        RuleFor(x => x.Basket.FirstName).NotEmpty().WithMessage("FirstName is required");
        RuleFor(x => x.Basket.LastName).NotEmpty().WithMessage("LastName is required");
        RuleFor(x => x.Basket.Email).NotEmpty().WithMessage("Email is required");
        RuleFor(x => x.Basket.AddressLine).NotEmpty().WithMessage("AddressLine is required");
        RuleFor(x => x.Basket.Country).NotEmpty().WithMessage("Country is required");
        RuleFor(x => x.Basket.State).NotEmpty().WithMessage("State is required");
        RuleFor(x => x.Basket.ZipCode).NotEmpty().WithMessage("ZipCode is required");
        RuleFor(x => x.Basket.CardNumber).NotEmpty().WithMessage("CardNumber is required");
        RuleFor(x => x.Basket.CardHolderName).NotEmpty().WithMessage("CardHolderName is required");
        RuleFor(x => x.Basket.CardExpiration).NotEmpty().WithMessage("CardExpiration is required");
        RuleFor(x => x.Basket.CardSecurityCode).NotEmpty().WithMessage("CardSecurityCode is required");
        RuleFor(x => x.Basket.PaymentMethod).NotEmpty().WithMessage("PaymentMethod is required");
        RuleFor(x => x.Basket.PaymentMethod).IsInEnum().WithMessage("Invalid payment method");
        RuleFor(x => x.Basket.CardExpiration).NotEmpty().WithMessage("CardExpiration is required");
        RuleFor(x => x.Basket.CardExpiration).Must(x => DateTime.TryParse(x, out _)).WithMessage("Invalid card expiration date");
        RuleFor(x => x.Basket.CardSecurityCode).NotEmpty().WithMessage("CardSecurityCode is required");
        RuleFor(x => x.Basket.CardSecurityCode).Length(3).WithMessage("CardSecurityCode must be 3 digits");
        RuleFor(x => x.Basket.CardSecurityCode).Must(x => int.TryParse(x, out _)).WithMessage("Invalid card security code");
        RuleFor(x => x.Basket.CardNumber).Must(x => x.Length == 16).WithMessage("CardNumber must be 16 digits");
        RuleFor(x => x.Basket.CardNumber).Must(x => x.All(char.IsDigit)).WithMessage("CardNumber must contain only digits");
    }
}
