using PizzaManagement.Application.Entities.OrderFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Order
{
    public class OrderRequestExample : IExamplesProvider<OrderRequestModel>
    {
        public OrderRequestModel GetExamples()
        {
            return new OrderRequestModel()
            {
                Id = 2,
                UserId = 2,
                AddressId = 3,
                Pizzas = new List<Domain.Entity.Pizza> {
            new Domain.Entity.Pizza {
                Id = 2,
                Name = "Prosciutto e Funghi",
                Price = 10,
                Description = "Classic pizza with tomato sauce, mozzarella cheese, ham, and mushrooms.",
                CaloryCount = 800
            }
    },
                RankHistory = new List<Domain.Entity.RankHistory> {
        new Domain.Entity.RankHistory {
            UserId = 2,
            PizzaId = 2,
            Rank = 5 },
        new Domain.Entity.RankHistory {
            UserId = 2,
            PizzaId = 3,
            Rank = 3
        }
    }
            };
        }
    }
}
