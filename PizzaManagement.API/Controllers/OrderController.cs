using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Model.DTO;
using PizzaManagement.API.Model.Examples.Order;
using PizzaManagement.API.Model.Examples.Pizza;
using PizzaManagement.API.Model.Requests;
using PizzaManagement.Application.Entities.OrderFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _OrderService;

        public OrderController(IOrderService OrderService)
        {
            _OrderService = OrderService;
        }

        

        /// <summary>
        /// Get All Orders
        /// </summary>
        /// <returns>Orders</returns>
        /// <response code = "200" > All The Orders Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrderDTOListExample))]
        [HttpGet]
        public async Task<List<OrderResponseDTO>> GetAll()
        {
            var result = await _OrderService.GetAll();
            return result.Adapt<List<OrderResponseDTO>>();
        }


        /// <summary>
        /// Get Order
        /// </summary>
        /// <returns>Order by Id</returns>
        /// <response code = "200" > Order by Id Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrderDTOExample))]
        [HttpGet("{id}")]
        public async Task<OrderResponseDTO> Get(int id)
        {
            var result = await _OrderService.Get(id);
            return result.Adapt<OrderResponseDTO>();
        }

        /// <summary>
        /// Get Many Orders
        /// </summary>
        /// <returns>Orders by Ids</returns>
        /// <response code = "200" > Orders by Ids Returned</response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(OrderDTOListExample))]
        [HttpGet("GetMany")]
        public async Task<List<OrderResponseDTO>> GetMany([FromQuery] int[] ids)
        {
            var result = await _OrderService.GetMany(ids);
            return result.Adapt<List<OrderResponseDTO>>();
        }

        /// <summary>
        /// Create Order
        /// </summary>        
        /// <remarks>
        /// Note that Id is not necessary.
        /// </remarks>
        /// <response code = "200" > Order Created </response>
        [SwaggerRequestExample(typeof(OrderCreateModel), typeof(OrderCreateExample))]
        [HttpPost]
        public async Task Post(OrderCreateModel request)
        {
            var entity = request.Adapt<OrderRequestModel>();
            entity.Id = await _OrderService.Length() + 1;
            await _OrderService.Create(entity);
        }

    
        
    }
}
