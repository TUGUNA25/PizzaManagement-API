using Mapster;
using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Model.Examples.Address;
using PizzaManagement.API.Model.Requests;
using PizzaManagement.Application.Entities.AddressFolder;
using Swashbuckle.AspNetCore.Filters;

namespace AddressManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly IAddressService _AddressService;

        public AddressController(IAddressService AddressService)
        {
            _AddressService = AddressService;
        }

        

        /// <summary>
        /// Get All Addresses
        /// </summary>
        /// <returns>Addresses</returns>
        /// <response code = "200" > All The Addresses Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddressListExample))]
        [HttpGet]
        public async Task<List<AddressResponseModel>> GetAll()
        {
            return await _AddressService.GetAll();
        }

        /// <summary>
        /// Get Address
        /// </summary>
        /// <returns>Address by Id</returns>
        /// <response code = "200" > Address by Id Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddressResponseExample))]
        [HttpGet("{id}")]
        public async Task<AddressResponseModel> Get(int id)
        {
            return await _AddressService.Get(id);
        }

        /// <summary>
        /// Get Many Addresses
        /// </summary>
        /// <returns>Addresses by Ids</returns>
        /// <response code = "200" > Addresses by Ids Returned</response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(AddressListExample))]
        [HttpGet("GetMany")]
        public async Task<List<AddressResponseModel>> GetMany([FromQuery] int[] ids)
        {
            return await _AddressService.GetMany(ids);
        }

        /// <summary>
        /// Create Address
        /// </summary>        
        /// <remarks>
        /// Note that Id is not necessary.
        /// </remarks>
        /// <response code = "200" > Address Created </response>
        [SwaggerRequestExample(typeof(AddressCreateModel), typeof(AddressCreateExample))]
        [HttpPost]
        public async Task Post(AddressCreateModel request)
        {
            var entity = request.Adapt<AddressRequestModel>();
            entity.Id = await _AddressService.Length() + 1;
            await _AddressService.Create(entity);
        }


        /// <summary>
        /// Delete Address
        /// </summary>
        /// <response code = "200" > Address Deleted </response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _AddressService.Delete(id);
        }


        /// <summary>
        /// Update Addresses
        /// </summary>        
        /// <response code = "200" > Address Updated </response>
        [SwaggerRequestExample(typeof(AddressRequestModel), typeof(AddressResponseExample))]
        [HttpPut]
        public async Task Put(AddressRequestModel Address)
        {
            await _AddressService.Update(Address);
        }
        
    }
}
