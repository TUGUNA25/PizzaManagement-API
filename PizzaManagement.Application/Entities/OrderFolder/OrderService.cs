
using Mapster;
using PizzaManagement.Application.Entities.AddressFolder;
using PizzaManagement.Application.Entities.PizzaFolder;
using PizzaManagement.Application.Exceptions;
using PizzaManagement.Application.Repositories;
using PizzaManagement.Domain.Entity;

namespace PizzaManagement.Application.Entities.OrderFolder
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _repositoryOrder;
        private readonly IUserRepository _userRepository;
        private readonly IPizzaRepository _pizzaRepository;

        public OrderService(IOrderRepository repositoryOrder, IUserRepository userRepository, IPizzaRepository pizzaRepository)
        {
            _repositoryOrder = repositoryOrder;
            _userRepository = userRepository;
            _pizzaRepository = pizzaRepository;
        }

        public async Task Create(OrderRequestModel order)
        {
            var adapted = order.Adapt<Order>();

            if (await _repositoryOrder.Exists(adapted.Id))
            {
                throw new OrderAlreadyExistsException();
            }
            if (!await _userRepository.Exists(adapted.UserId))
                throw new UserNotFoundException();

            foreach (var pizza in adapted.Pizzas)
            {
                if (!await _pizzaRepository.Exists(pizza.Id))
                    throw new PizzaNotFoundException();
            }
            await _repositoryOrder.Create(adapted);
        }

        public async Task<OrderResponseModel> Get(int id)
        {

            if (!await _repositoryOrder.Exists(id))
            {
                throw new OrderNotFoundException();
            }

            var result = await _repositoryOrder.Get(id);
            return result.Adapt<OrderResponseModel>();
        }

        public async Task<List<OrderResponseModel>> GetMany(params int[] id)
        {
            foreach (int i in id)
            {
                if (!await _repositoryOrder.Exists(i))
                {
                    throw new OrderNotFoundException();
                }
            }
            var result = await _repositoryOrder.GetMany(id);
            return result.Adapt<List<OrderResponseModel>>();
        }

        

        public async Task<List<OrderResponseModel>> GetAll()
        {
            var result = await _repositoryOrder.GetAll();
            return result.Adapt<List<OrderResponseModel>>();
        }

        public async Task<int> Length()
        {
            return await _repositoryOrder.Length();
        }
    }
}
