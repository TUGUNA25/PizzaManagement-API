

namespace PizzaManagement.Application.Entities.UserFolder
{
    public interface IUserService
    {
        public Task<List<UserResponseModel>> GetMany(params int[] id);
        public Task<UserResponseModel> Get(int id);
        public Task Create(UserRequestModel pizza);
        public Task Update(UserRequestModel pizza);
        public Task Delete(int id);
        public Task<List<UserResponseModel>> GetAll();
        public Task<int> Length();
    }
}
