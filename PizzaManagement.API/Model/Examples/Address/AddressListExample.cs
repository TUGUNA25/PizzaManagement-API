using PizzaManagement.Application.Entities.AddressFolder;
using PizzaManagement.Application.Entities.PizzaFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Address
{
    public class AddressListExample : IExamplesProvider<List<AddressResponseModel>>
    {
        public List<AddressResponseModel> GetExamples()
        {
            return new List<AddressResponseModel>
            {
                new AddressResponseModel()
                {
                    Id = 3,
                    UserId = 2,
                    City = "Barcelona",
                    Country = "Spain",
                    Region = "Catalonia",
                    Description = "City Park"

                }
            };
        }
    }
}
