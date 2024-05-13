using PizzaManagement.Application.Entities.PizzaFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Pizza
{
    public class PizzaListResponseExample : IExamplesProvider<List<PizzaResponseModel>>
    {
        public List<PizzaResponseModel> GetExamples()
        {
            return new List<PizzaResponseModel>
        {
            new PizzaResponseModel()
            {
                Id = 3,
                Name = "Quattro Formaggi",
                Price = 13,
                Description = "Pizza topped with four different types of cheese.",
                CaloryCount = 900
            }
        };
        }
    }
}
