


using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.OrderFolder
{
    public class OrderRequestModel
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int AddressId { get; set; }
        public List<Pizza> Pizzas { get; set; }
        public List<RankHistory> RankHistory { get; set; }
    }
}
