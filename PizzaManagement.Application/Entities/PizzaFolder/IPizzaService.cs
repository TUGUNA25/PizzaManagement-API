using PizzaManagement.Application.Entities.UserFolder;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.PizzaFolder
{
    public interface IPizzaService
    {
        public Task<List<PizzaResponseModel>> GetMany(params int[] id);
        public Task<PizzaResponseModel> Get(int id);
        public Task Create(PizzaRequestModel pizza);
        public Task Update(PizzaRequestModel pizza);
        public Task Delete(int id);
        public Task<List<PizzaResponseModel>> GetAll();
        public Task<int> Length();
    }
}
