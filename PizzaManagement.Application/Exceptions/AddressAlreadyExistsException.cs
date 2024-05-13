

namespace PizzaManagement.Application.Exceptions
{
    public class AddressAlreadyExistsException : Exception
    {
        public AddressAlreadyExistsException() : base() { }
        public AddressAlreadyExistsException(string message) : base(message) { }

        public readonly string Code = "Address Already Exists";
    }
}
