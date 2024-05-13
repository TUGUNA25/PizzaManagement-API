using PizzaManagement.Domain.Entity;

namespace PizzaManagement.API.Model.Requests
{
    public class OrderCreateModel
    {
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<Pizza> Pizza { get; set; }
        public List<RankHistory> RankHistory { get; set; }
    }
}
