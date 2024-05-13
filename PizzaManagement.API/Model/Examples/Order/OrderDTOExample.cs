using PizzaManagement.API.Model.DTO;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Model.Examples.Order
{
    public class OrderDTOExample : IExamplesProvider<OrderResponseDTO>
    {
        public OrderResponseDTO GetExamples()
        {
            return new OrderResponseDTO()
            {
                UserId = 2,
                AddressId = 3,
                PizzaIds = new List<int> { 2, 3 },
                Ranks = new List<int> { 3, 4 }
            };
        }
    }
}
