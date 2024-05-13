

namespace PizzaManagement.Application.Entities.AddressFolder
{
    public interface IAddressService
    {
        public Task<List<AddressResponseModel>> GetAll();
        public Task<List<AddressResponseModel>> GetMany(params int[] id);
        public Task<AddressResponseModel> Get(int id);
        public Task Create(AddressRequestModel pizza);
        public Task Update(AddressRequestModel pizza);
        public Task Delete(int id);
        public Task<int> Length();
    }
}
