

namespace PizzaManagement.Application.Exceptions
{
    public class UserAlreadyExistsException : Exception
    {
        public UserAlreadyExistsException() : base() { }
        public UserAlreadyExistsException(string message) : base(message) { }

        public readonly string Code = "User Already Exists";
    }
}
