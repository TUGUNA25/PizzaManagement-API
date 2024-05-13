using PizzaManagement.Domain.Entity;

namespace PizzaManagement.API.Model.Requests
{
    public class UserCreateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public List<Address> Addresses { get; set; }
    }
}
