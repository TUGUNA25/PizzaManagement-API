
namespace PizzaManagement.Application.Exceptions
{
    public class RankHistoryAlreadyExistsException : Exception
    {
        public RankHistoryAlreadyExistsException() : base() { }
        public RankHistoryAlreadyExistsException(string message) : base(message) { }

        public readonly string Code = "Rank History Already Exists";
    }
}
