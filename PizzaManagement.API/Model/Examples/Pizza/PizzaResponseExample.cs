using PizzaManagement.Application.Entities.PizzaFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Pizza
{
    public class PizzaResponseExample : IExamplesProvider<PizzaResponseModel>
    {
        public PizzaResponseModel GetExamples()
        {
            return new PizzaResponseModel()
            {
                Id = 3,
                Name = "Quattro Formaggi",
                Price = 13,
                Description = "Pizza topped with four different types of cheese.",
                CaloryCount = 900
            };
        }
    }
}
