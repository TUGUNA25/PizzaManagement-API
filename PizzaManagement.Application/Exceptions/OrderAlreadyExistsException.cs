

namespace PizzaManagement.Application.Exceptions
{
    public class OrderAlreadyExistsException : Exception
    {
        public OrderAlreadyExistsException() : base() { }
        public OrderAlreadyExistsException(string message) : base(message) { }

        public readonly string Code = "Order Already Exists";
    }
}
