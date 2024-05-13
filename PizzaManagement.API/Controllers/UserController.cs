using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Model.DTO;
using PizzaManagement.API.Model.Examples.Pizza;
using PizzaManagement.API.Model.Examples.User;
using PizzaManagement.API.Model.Requests;
using PizzaManagement.Application.Entities.PizzaFolder;
using PizzaManagement.Application.Entities.UserFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _UserService;

        public UserController(IUserService UserService)
        {
            _UserService = UserService;
        }

      

        /// <summary>
        /// Get All Users
        /// </summary>
        /// <returns>Users</returns>
        /// <response code = "200" > All The Users Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserDTOListExample))]
        [HttpGet]
        public async Task<List<UserResponseDTO>> GetAll()
        {
            var result = await _UserService.GetAll();
            return result.Adapt<List<UserResponseDTO>>();
        }


        /// <summary>
        /// Get User
        /// </summary>
        /// <returns>User by Id</returns>
        /// <response code = "200" > User by Id Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserDTOExample))]
        [HttpGet("{id}")]
        public async Task<UserResponseDTO> Get(int id)
        {
            var result = await _UserService.Get(id);
            return result.Adapt<UserResponseDTO>();
        }

        /// <summary>
        /// Get Many Users
        /// </summary>
        /// <returns>Users by Ids</returns>
        /// <response code = "200" > Users by Ids Returned</response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(UserDTOListExample))]
        [HttpGet("GetMany")]
        public async Task<List<UserResponseDTO>> GetMany([FromQuery] int[] ids)
        {
            var result = await _UserService.GetMany(ids);
            return result.Adapt<List<UserResponseDTO>>();
        }

        /// <summary>
        /// Create User
        /// </summary>        
        /// <remarks>
        /// Note that Id is not necessary.
        /// </remarks>
        /// <response code = "200" > User Created </response>
        [SwaggerRequestExample(typeof(UserCreateModel), typeof(UserCreateExample))]
        [HttpPost]
        public async Task Post(UserCreateModel request)
        {
            var entity = request.Adapt<UserRequestModel>();
            entity.Id = await _UserService.Length() + 1;
            await _UserService.Create(entity);
        }

        /// <summary>
        /// Delete User
        /// </summary>
        /// <response code = "200" > User Deleted </response>
        [HttpDelete("{id}")]
        public async Task Delete(int id)
        {
            await _UserService.Delete(id);
        }


        /// <summary>
        /// Get Many Users
        /// </summary>        
        /// <response code = "200" > User Updated </response>
        [SwaggerRequestExample(typeof(UserRequestModel), typeof(UserRequestExample))]
        [HttpPut]
        public async Task Put(UserRequestModel User)
        {
            await _UserService.Update(User);
        }
      
    }
}
