using PizzaManagement.API.Model.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.User
{
    public class UserCreateExample : IExamplesProvider<UserCreateModel>
    {
        public UserCreateModel GetExamples()
        {
            return new UserCreateModel()
            {
                FirstName = "Emily",
                LastName = "Johnson",
                Email = "emily.johnson@example.com",
                PhoneNumber = "9876543210",
                Addresses = new List<Domain.Entity.Address> {
        new Domain.Entity.Address { Id = 1, UserId = 1,
            City = "Los Angeles", Country = "United States",
            Region = "California", Description = "Apartment address"
            }
         }
            };
        }
    }
}
