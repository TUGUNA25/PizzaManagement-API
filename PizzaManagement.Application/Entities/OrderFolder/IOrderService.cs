

using PizzaManagement.Application.Entities.UserFolder;

namespace PizzaManagement.Application.Entities.OrderFolder
{
    public interface IOrderService
    {
        public Task<List<OrderResponseModel>> GetMany(params int[] id);
        public Task<OrderResponseModel> Get(int id);
        public Task Create(OrderRequestModel pizza);
        public Task<List<OrderResponseModel>> GetAll();
        public Task<int> Length();
    }
}
