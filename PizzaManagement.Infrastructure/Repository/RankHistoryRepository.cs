using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Infrastructure.Repository
{
    public class RankHistoryRepository : IRankHistoryRepository
    {
        
        private List<RankHistory> _rankHistories = new List<RankHistory>
        {
            new RankHistory { UserId = 1, PizzaId = 1, Rank = 5 },
            new RankHistory { UserId = 2, PizzaId = 2, Rank = 7 },
            new RankHistory { UserId = 2, PizzaId = 3, Rank = 10 },
            new RankHistory { UserId = 1, PizzaId = 3, Rank = 3 }
        };
        
        public async Task Create(RankHistory rankHistory)
        {
            _rankHistories.Add(rankHistory);
        }


        public async Task<bool> Exists(int userId, int pizzaId)
        {
            return await Task.FromResult(_rankHistories.Any(rankHistory => rankHistory.UserId == userId && rankHistory.PizzaId == pizzaId));
        }

        public async Task<RankHistory> Get(int userId, int pizzaId)
        {
            return await Task.FromResult(_rankHistories.Single(rankHistory => rankHistory.UserId == userId && rankHistory.PizzaId == pizzaId));
        }

        public async Task<List<RankHistory>> GetMany(params (int,int)[] id)
        {
            List<RankHistory> rankHistories = new List<RankHistory>();
            foreach ((int,int) i in id)
            {
                rankHistories.Add(await Get(i.Item1, i.Item2));
            }
            return rankHistories;
        }


        public async Task<int> Length()
        {
            return _rankHistories.Count;
        }

        public async Task<List<RankHistory>> GetAll()
        {
            return _rankHistories;
        }
    }
}
