using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.Entities.OrderFolder;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class OrderValidator : AbstractValidator<OrderRequestModel>
    {
        public OrderValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ErrorMessages.UserNotFound);

            RuleFor(x => x.Pizzas)
                .NotEmpty().WithMessage(ErrorMessages.OrderPizzaList);
        }
    }
}
