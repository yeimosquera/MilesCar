
using FluentValidation;

namespace Application.Cars.Create;

public class CreateCarCommandValidator : AbstractValidator<CreateCarCommand>
{

    public CreateCarCommandValidator()
    {
        RuleFor(r => r.Plate)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Color)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Brand)
            .NotEmpty()
            .MaximumLength(50);

        RuleFor(r => r.Model)
                .NotEmpty()
                .MaximumLength(50)
                .WithName("Last Name");

        RuleFor(r => r.Country)
            .NotEmpty()
            .MaximumLength(30);

        RuleFor(r => r.Line1)
            .NotEmpty()
            .MaximumLength(20)
            .WithName("Addres Line 1");

        RuleFor(r => r.Line2)
            .MaximumLength(20)
            .WithName("Addres Line 2");

        RuleFor(r => r.City)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(r => r.State)
            .NotEmpty()
            .MaximumLength(40);

        RuleFor(r => r.ZipCode)
            .NotEmpty()
            .MaximumLength(10)
            .WithName("Zip Code");
    }
}