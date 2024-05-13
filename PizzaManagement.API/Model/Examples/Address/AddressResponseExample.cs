using PizzaManagement.Application.Entities.AddressFolder;
using PizzaManagement.Application.Entities.PizzaFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Address
{
    public class AddressResponseExample : IExamplesProvider<AddressResponseModel>
    {
        public AddressResponseModel GetExamples()
        {
            return new AddressResponseModel()
            {
                Id = 3,
                UserId = 2,
                City = "Barcelona",
                Country = "Spain",
                Region = "Catalonia",
                Description = "City Park"
            };
        }
    }
}
