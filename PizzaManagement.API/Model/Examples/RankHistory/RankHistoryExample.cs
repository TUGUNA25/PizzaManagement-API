using PizzaManagement.Application.Entities.PizzaFolder;
using PizzaManagement.Application.Entities.RankHistoryFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.RankHistory
{
    public class RankHistoryExample : IExamplesProvider<RankHistoryResponseModel>
    {
        public RankHistoryResponseModel GetExamples()
        {
            return new RankHistoryResponseModel()
            {
                UserId = 3,
                PizzaId = 3,
                Rank = 8
            };
        }
    }
}
