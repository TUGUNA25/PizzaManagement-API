

using PizzaManagement.Application.Entities.UserFolder;

namespace PizzaManagement.Application.Entities.RankHistoryFolder
{
    public interface IRankHistoryService
    {
        public Task<List<RankHistoryResponseModel>> GetMany(params (int,int)[] id);
        public Task<RankHistoryResponseModel> Get(int userId, int pizzaId);
        public Task Create(RankHistoryRequestModel pizza);
        public Task<List<RankHistoryResponseModel>> GetAll();
        public Task<int> Length();
    }
}
