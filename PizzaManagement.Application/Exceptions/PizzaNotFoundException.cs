

namespace PizzaManagement.Application.Exceptions
{
    public class PizzaNotFoundException : Exception
    {
        public PizzaNotFoundException() : base() { }
        public PizzaNotFoundException(string message) : base(message) { }

        public readonly string Code = "Pizza Not Found";
    }
}
