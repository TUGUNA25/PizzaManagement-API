using FluentValidation;
using PizzaManagement.API.Infrastructure.Localization;
using PizzaManagement.Application.Entities.RankHistoryFolder;

namespace PizzaManagement.API.Infrastructure.Validators
{
    public class RankHistoryValidator : AbstractValidator<RankHistoryRequestModel>
    {
        public RankHistoryValidator()
        {
            RuleFor(x => x.UserId)
                .GreaterThan(0).WithMessage(ErrorMessages.UserNotFound);

            RuleFor(x => x.PizzaId)
                .GreaterThan(0).WithMessage(ErrorMessages.PizzaNotFound);

            RuleFor(x => x.Rank)
                .InclusiveBetween(1, 10).WithMessage(ErrorMessages.Rank);
        }
    }
}
