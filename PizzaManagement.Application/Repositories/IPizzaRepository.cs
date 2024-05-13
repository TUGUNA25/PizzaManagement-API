using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Repositories
{
    public interface IPizzaRepository
    {
        public Task<List<Pizza>> GetMany(params int[] id);
        public Task<Pizza> Get(int id);
        public Task Create(Pizza pizza);
        public Task Update(Pizza pizza);
        public Task Delete(int id);
        public Task<bool> Exists(int id);
        public Task<int> Length();
        public Task<List<Pizza>> GetAll();
    }
}
