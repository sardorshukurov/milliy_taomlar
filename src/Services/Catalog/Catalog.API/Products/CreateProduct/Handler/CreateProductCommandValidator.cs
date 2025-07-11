namespace Catalog.API.Products.CreateProduct.Handler;

using FluentValidation;

public class CreateProductCommandValidator : AbstractValidator<CreateProductCommand>
{
    public CreateProductCommandValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty()
            .WithMessage("Product name is required.")
            .Length(2, 100)
            .WithMessage("Product name must be between 2 and 100 characters.");

        RuleFor(x => x.Description)
            .MaximumLength(500)
            .WithMessage("Product description must not exceed 500 characters.");

        RuleFor(x => x.Price)
            .GreaterThan(0)
            .WithMessage("Product price must be greater than zero.");

        RuleFor(x => x.Categories)
            .NotEmpty()
            .WithMessage("Categories are required.");
    }
}