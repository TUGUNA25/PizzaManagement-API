

namespace PizzaManagement.Application.Exceptions
{
    public class AddressNotFoundException : Exception
    {
        public AddressNotFoundException() : base() { }
        public AddressNotFoundException(string message) : base(message) { }

        public readonly string Code = "Address Not Found";
    }
}
