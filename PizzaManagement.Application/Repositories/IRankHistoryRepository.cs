using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Repositories
{
    public interface IRankHistoryRepository
    {
        public Task<List<RankHistory>> GetMany(params (int,int)[] id);
        public Task<RankHistory> Get(int userId, int pizzaId);
        public Task Create(RankHistory rankHistory);
        public Task<bool> Exists(int userId, int pizzaId);
        public Task<int> Length();
        public Task<List<RankHistory>> GetAll();
    }
}
