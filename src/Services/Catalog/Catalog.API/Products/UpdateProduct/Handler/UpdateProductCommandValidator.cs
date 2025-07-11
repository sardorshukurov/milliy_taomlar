using FluentValidation;

namespace Catalog.API.Products.UpdateProduct.Handler;

public class UpdateProductCommandValidator : AbstractValidator<UpdateProductCommand>
{
    public UpdateProductCommandValidator()
    {
        RuleFor(c => c.Id)
            .NotEmpty()
            .WithMessage("Id is required.");

        RuleFor(c => c.Name)
            .NotEmpty()
            .WithMessage("Name is required.")
            .Length(2, 100)
            .WithMessage("Name must be between 2 and 100 characters.");

        RuleFor(c => c.Description)
            .MaximumLength(500)
            .WithMessage("Description must not exceed 500 characters.");

        RuleFor(c => c.Price)
            .GreaterThan(0)
            .WithMessage("Price must be greater than 0.");

        RuleFor(c => c.Categories)
            .NotEmpty()
            .WithMessage("Categories are required.");
    }
}
