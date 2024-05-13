using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Model.Examples.Pizza;
using PizzaManagement.API.Model.Requests;
using PizzaManagement.Application.Entities.PizzaFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PizzaController : ControllerBase
    {
        private readonly IPizzaService _PizzaService;

        public PizzaController(IPizzaService PizzaService)
        {
            _PizzaService = PizzaService;
        }

        

        /// <summary>
        /// Get All Pizzas
        /// </summary>
        /// <returns>Pizzas</returns>
        /// <response code = "200" > All The Pizzas Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaListResponseExample))]
        [HttpGet]
        public async Task<List<PizzaResponseModel>> GetAll()
        {
            return await _PizzaService.GetAll();
        }

        /// <summary>
        /// Get Pizza
        /// </summary>
        /// <returns>Pizza by Id</returns>
        /// <response code = "200" > Pizza by Id Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaResponseExample))]
        [HttpGet("{id}")]
        public async Task<PizzaResponseModel> Get(int id)
        {
            return await _PizzaService.Get(id);
        }

        /// <summary>
        /// Get Many Pizzas
        /// </summary>
        /// <returns>Pizzas by Ids</returns>
        /// <response code = "200" > Pizzas by Ids Returned</response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(PizzaListResponseExample))]
        [HttpGet("GetMany")]
        public async Task<List<PizzaResponseModel>> GetMany([FromQuery] int[] ids)
        {
            return await _PizzaService.GetMany(ids);
        }

        /// <summary>
        /// Create Pizza
        /// </summary>        
        /// <remarks>
        /// Note that Id is not necessary.
        /// </remarks>
        /// <response code = "200" > Pizza Created </response>
        [SwaggerRequestExample(typeof(PizzaCreateModel),typeof(PizzaCreateExample))]
        [HttpPost]
        public async Task Post(PizzaCreateModel request)
        {
            var entity = request.Adapt<PizzaRequestModel>();
            entity.Id = await _PizzaService.Length() + 1;
            await _PizzaService.Create(entity);
        }

        /// <summary>
        /// Delete Pizza
        /// </summary>
        /// <response code = "200" > Pizza Deleted </response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _PizzaService.Delete(id);
        }

        /// <summary>
        /// Update Pizza
        /// </summary>        
        /// <response code = "200" > Pizza Updated </response>
        [SwaggerRequestExample(typeof(PizzaRequestModel), typeof(PizzaResponseExample))]
        [HttpPut] 
        public async Task Put(PizzaRequestModel pizza)
        {
            await _PizzaService.Update(pizza);
        }
        
    }
}
