namespace Basket.API.Baskets.StoreBasket.Handler;

using FluentValidation;

public class StoreBasketCommandValidator : AbstractValidator<StoreBasketCommand>
{
    public StoreBasketCommandValidator()
    {
        RuleFor(c => c.Cart).NotNull().WithMessage("Cart cannot be null");
        RuleFor(c => c.Cart.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(c => c.Cart.Items).NotEmpty().WithMessage("Items are required");
        RuleFor(c => c.Cart.Items).Must(items => items.All(item => item.Quantity > 0))
            .WithMessage("Quantity must be greater than 0");
    }
}
