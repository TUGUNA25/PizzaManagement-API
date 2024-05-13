using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;


namespace PizzaManagement.Infrastructure.Repository
{
    public class PizzaRepository : IPizzaRepository
    {

         
        

        private List<Pizza> _pizzas = new List<Pizza>
        {
            new Pizza { Id = 1, Name = "Prosciutto e Funghi", Price = 10, Description = "Classic pizza with tomato sauce, mozzarella cheese, ham, and mushrooms.", CaloryCount = 800 },
            new Pizza { Id = 2, Name = "Quattro Stagioni", Price = 12, Description = "Pizza with tomato sauce, mozzarella cheese, ham, artichokes, olives, and mushrooms.", CaloryCount = 950 },
            new Pizza { Id = 3, Name = "Capricciosa", Price = 11, Description = "Pizza topped with tomato sauce, mozzarella cheese, ham, artichokes, mushrooms, and olives.", CaloryCount = 850 }
        };

   



        public async Task Create(Pizza pizza)
        {
            _pizzas.Add(pizza);
        }

        public async Task Delete(int id)
        {
            var pizza = await Get(id);
            _pizzas.Remove(pizza);
        }

        public async Task<bool> Exists(int id)
        {
            return await Task.FromResult(_pizzas.Any(pizza => pizza.Id == id));
        }

        public async Task<Pizza> Get(int id)
        {
            return await Task.FromResult(_pizzas.Single(_pizzas => _pizzas.Id == id));
        }

        public async Task<List<Pizza>> GetMany(params int[] id)
        {
            List<Pizza> pizzas = new List<Pizza>();
            foreach (int i in id)
            {
                pizzas.Add(await Get(i));
            }
            return pizzas;
        }

        public async Task Update(Pizza pizza)
        {
            _pizzas[pizza.Id - 1] = pizza;

        }
        public async Task<int> Length()
        {
            return _pizzas.Count;
        }

        public async Task<List<Pizza>> GetAll()
        {
            return _pizzas;
        }
    }
}
