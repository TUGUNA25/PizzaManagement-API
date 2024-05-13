using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.Entities.PizzaFolder;
namespace PizzaManagement.API.Infrastructure.Validators
{
    public class PizzaValidator : AbstractValidator<PizzaRequestModel>
    {
        public PizzaValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage(ErrorMessages.PizzaName)
                .Length(3, 20).WithMessage(ErrorMessages.PizzaName);

            RuleFor(x => x.Price)
                .NotEmpty().WithMessage(ErrorMessages.PizzaPizza)
                .GreaterThan(0).WithMessage(ErrorMessages.PizzaPizza);

            RuleFor(x => x.Description)
                .Length(0, 100).WithMessage(ErrorMessages.PizzaDescription);

            RuleFor(x => x.CaloryCount)
                .NotEmpty().WithMessage(ErrorMessages.PizzaCaloryCount)
                .GreaterThan(0).WithMessage(ErrorMessages.PizzaCaloryCount);
        }
    }
}
