

namespace PizzaManagement.Application.Exceptions
{
    public class RankHistoryNotFoundException : Exception
    {
        public RankHistoryNotFoundException() : base() { }
        public RankHistoryNotFoundException(string message) : base(message) { }

        public readonly string Code = "Rank History Not Found";
    }
}
