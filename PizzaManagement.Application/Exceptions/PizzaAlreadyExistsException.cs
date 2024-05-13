

namespace PizzaManagement.Application.Exceptions
{
    public class PizzaAlreadyExistsException : Exception
    {
        public PizzaAlreadyExistsException() : base() { }
        public PizzaAlreadyExistsException(string message) : base(message) { }

        public readonly string Code = "Pizza Already Exists";
    }
}
