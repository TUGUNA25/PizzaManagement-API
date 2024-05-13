using PizzaManagement.API.Model.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Pizza
{
    public class PizzaCreateExample : IExamplesProvider<PizzaCreateModel>
    {
        public PizzaCreateModel GetExamples()
        {
            return new PizzaCreateModel()
            {
                Name = "Quattro Formaggi",
                Price = 13,
                Description = "Pizza topped with four different types of cheese.",
                CaloryCount = 900
            };
        }
    }
}
