using Mapster;
using PizzaManagement.Application.Entities.AddressFolder;
using PizzaManagement.Application.Exceptions;
using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.PizzaFolder
{
    public class PizzaService : IPizzaService
    {
        private readonly IPizzaRepository _repositoryPizza;

        public PizzaService(IPizzaRepository repositoryPizza)
        {
            _repositoryPizza = repositoryPizza;
        }

        public async Task Create(PizzaRequestModel pizza)
        {
            var adapted = pizza.Adapt<Pizza>();

            if (await _repositoryPizza.Exists(adapted.Id))
            {
                throw new PizzaAlreadyExistsException();
            }
            await _repositoryPizza.Create(adapted);
        }

        public async Task Delete(int id)
        {
            if (!await _repositoryPizza.Exists(id))
            {
                throw new PizzaNotFoundException();
            }
            await _repositoryPizza.Delete(id);
        }

        public async Task<PizzaResponseModel> Get(int id)
        {
            if (!await _repositoryPizza.Exists(id))
            {
                throw new PizzaNotFoundException();
            }
            
            var result = await _repositoryPizza.Get(id);
            return result.Adapt<PizzaResponseModel>();
        }

        public async Task<List<PizzaResponseModel>> GetMany(params int[] id)
        {
            foreach (int i in id)
            {
                if (!await _repositoryPizza.Exists(i))
                {
                    throw new PizzaNotFoundException();
                }
            }
            var result = await _repositoryPizza.GetMany(id);
            return result.Adapt<List<PizzaResponseModel>>();
        }

        public async Task Update(PizzaRequestModel pizza)
        {
            var adapted = pizza.Adapt<Pizza>();
            if (!await _repositoryPizza.Exists(adapted.Id))
            {
                throw new PizzaNotFoundException();
            }
            await _repositoryPizza.Update(adapted);
        }

        public async Task<List<PizzaResponseModel>> GetAll()
        {
            var result = await _repositoryPizza.GetAll();
            return result.Adapt<List<PizzaResponseModel>>();
        }

        public async Task<int> Length()
        {
            return await _repositoryPizza.Length();
        }
    }
}
