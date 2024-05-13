using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.Entities.UserFolder;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class UserValidator : AbstractValidator<UserRequestModel>
    {
        public UserValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty().WithMessage(ErrorMessages.UserFirstname)
                .Length(2, 20).WithMessage(ErrorMessages.UserFirstname);

            RuleFor(x => x.LastName)
                .NotEmpty().WithMessage(ErrorMessages.UserLastname)
                .Length(2, 30).WithMessage(ErrorMessages.UserLastname);

            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress().WithMessage(ErrorMessages.UserEmail);

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .Matches("^[0-9]+$").WithMessage(ErrorMessages.UserPhoneNumber);
        }
    }
}
