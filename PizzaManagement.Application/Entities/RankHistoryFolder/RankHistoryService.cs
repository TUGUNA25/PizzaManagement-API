

using Mapster;
using PizzaManagement.Application.Exceptions;
using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.RankHistoryFolder
{
    public class RankHistoryService : IRankHistoryService
    {
        private readonly IRankHistoryRepository _repositoryRankHistory;
        private readonly IUserRepository _userRepository;
        private readonly IPizzaRepository _pizzaRepository;
        public RankHistoryService(IRankHistoryRepository repositoryRankHistory, IUserRepository userRepository, IPizzaRepository pizzaRepository)
        {
            _repositoryRankHistory = repositoryRankHistory;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task Create(RankHistoryRequestModel rankHistory)
        {
            var adapted = rankHistory.Adapt<RankHistory>();

            if (await _repositoryRankHistory.Exists(adapted.UserId, adapted.PizzaId))
            {
                throw new RankHistoryAlreadyExistsException();
            }
            if (!await _userRepository.Exists(adapted.UserId))
                throw new UserNotFoundException();
            if (!await _pizzaRepository.Exists(adapted.PizzaId))
                throw new PizzaNotFoundException();

            await _repositoryRankHistory.Create(adapted);
        }


        public async Task<RankHistoryResponseModel> Get(int userId, int pizzaId)
        {
            if (!await _repositoryRankHistory.Exists(userId, pizzaId))
            {
                throw new RankHistoryNotFoundException();
            }

            var result = await _repositoryRankHistory.Get(userId, pizzaId);
            return result.Adapt<RankHistoryResponseModel>();
        }

        public async Task<List<RankHistoryResponseModel>> GetMany(params (int,int)[] id)
        {
            foreach ((int,int) i in id)
            {
                if (!await _repositoryRankHistory.Exists(i.Item1, i.Item2))
                {
                    throw new RankHistoryNotFoundException();
                }
            }
            var result = await _repositoryRankHistory.GetMany(id);
            return result.Adapt<List<RankHistoryResponseModel>>();
        }

    

        public async Task<List<RankHistoryResponseModel>> GetAll()
        {
            var result = await _repositoryRankHistory.GetAll();
            return result.Adapt<List<RankHistoryResponseModel>>();
        }

        public async Task<int> Length()
        {
            return await _repositoryRankHistory.Length();
        }
    }
}
