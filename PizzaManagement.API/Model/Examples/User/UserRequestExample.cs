using PizzaManagement.Application.Entities.UserFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.User
{
    public class UserRequestExample : IExamplesProvider<UserRequestModel>
    {
        public UserRequestModel GetExamples()
        {
            return new UserRequestModel()
            {
                Id = 2,
                FirstName = "Emily",
                LastName = "Johnson",
                Email = "emily.johnson@example.com",
                PhoneNumber = "1234567890",
                Addresses = new List<Domain.Entity.Address> {
            new Domain.Entity.Address { Id = 1, UserId = 2,
                City = "Los Angeles", Country = "United States",
                Region = "California", Description = "Home address"
            }
        }
            };
        }
    }
}
