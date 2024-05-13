using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        
        private List<Order> _orders = new List<Order>
        {
            new Order { Id = 1, UserId = 1, AddressId = 2, Pizzas = new List<Pizza> { new Pizza { Id = 1, Name = "Prosciutto e Funghi", Price = 10, Description = "Classic pizza with tomato sauce, mozzarella cheese, ham, and mushrooms.", CaloryCount = 800 } }, RankHistory = new List<RankHistory> { new RankHistory { UserId = 1, PizzaId = 1, Rank = 5 }, new RankHistory { UserId = 1, PizzaId = 3, Rank = 3 } } },
            new Order { Id = 2, UserId = 2, AddressId = 3, Pizzas = new List<Pizza> { new Pizza { Id = 2, Name = "Quattro Stagioni", Price = 12, Description = "Pizza with tomato sauce, mozzarella cheese, ham, artichokes, olives, and mushrooms.", CaloryCount = 950 }, new Pizza { Id = 3, Name = "Vegetarian", Price = 11, Description = "Loaded with assorted vegetables like bell peppers, onions, and mushrooms.", CaloryCount = 850 } }, RankHistory = new List<RankHistory> { new RankHistory { UserId = 2, PizzaId = 2, Rank = 7 }, new RankHistory { UserId = 2, PizzaId = 3, Rank = 10 } } }
        };
       
        public async Task Create(Order order)
        {
            _orders.Add(order);
        }


        public async Task<bool> Exists(int id)
        {
            return await Task.FromResult(_orders.Any(orders => orders.Id == id));
        }

        public async Task<Order> Get(int id)
        {
            return await Task.FromResult(_orders.Single(orders => orders.Id == id));
        }

        public async Task<List<Order>> GetMany(params int[] id)
        {
            List<Order> orders = new List<Order>();
            foreach (int i in id)
            {
                orders.Add(await Get(i));
            }
            return orders;
        }

      
        public async Task<int> Length()
        {
            return _orders.Count;
        }

        public async Task<List<Order>> GetAll()
        {
            return _orders;
        }
    }
}
