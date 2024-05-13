

namespace PizzaManagement.Application.Exceptions
{
    public class OrderNotFoundException : Exception
    {
        public OrderNotFoundException() : base() { }
        public OrderNotFoundException(string message) : base(message) { }

        public readonly string Code = "Order Not Found";
    }
}
