using PizzaManagement.API.Model.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.User
{
    public class UserDTOListExample : IExamplesProvider<List<UserResponseDTO>>
    {
        public List<UserResponseDTO> GetExamples()
        {
            return new List<UserResponseDTO>()
    {
        new UserResponseDTO {
            Id = 1,
            FirstName = "Emily",
            LastName = "Johnson",
            Email = "emily.johnson@example.com",
            PhoneNumber = "1234567890",
            AddressIds = new List<int> { 1 }
        }
    };
        }
    }
}
