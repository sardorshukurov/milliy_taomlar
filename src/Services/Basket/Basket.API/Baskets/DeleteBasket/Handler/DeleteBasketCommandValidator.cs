namespace Basket.API.Baskets.DeleteBasket.Handler;

using FluentValidation;

public class DeleteBasketCommandValidator : AbstractValidator<DeleteBasketCommand>
{
    public DeleteBasketCommandValidator()
    {
        RuleFor(c => c.Username)
            .NotEmpty()
            .WithMessage("Username is required");
    }
}
