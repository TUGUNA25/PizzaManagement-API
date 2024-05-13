using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PizzaManagement.API.Model;
using PizzaManagement.API.Model.Examples.Address;
using PizzaManagement.API.Model.Examples.Pizza;
using PizzaManagement.API.Model.Examples.RankHistory;
using PizzaManagement.API.Model.Requests;
using PizzaManagement.Application.Entities.RankHistoryFolder;
using Swashbuckle.AspNetCore.Filters;

namespace PizzaManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RankHistoryController : ControllerBase
    {
        private readonly IRankHistoryService _RankHistoryService;

        public RankHistoryController(IRankHistoryService RankHistoryService)
        {
            _RankHistoryService = RankHistoryService;
        }

        

        /// <summary>
        /// Get All Ranks
        /// </summary>
        /// <returns>Ranks</returns>
        /// <response code = "200" > All The Ranks Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RankHistoryListExample))]
        [HttpGet]
        public async Task<List<RankHistoryResponseModel>> GetAll()
        {
            return await _RankHistoryService.GetAll();
        }


        /// <summary>
        /// Get Rank
        /// </summary>
        /// <returns>Rank by Id</returns>
        /// <response code = "200" > Rank by Id Returned </response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RankHistoryExample))]
        [HttpGet("{userId}/{pizzaId}")]
        public async Task<RankHistoryResponseModel> Get(int userId, int pizzaId)
        {
            return await _RankHistoryService.Get(userId, pizzaId);
        }


        /// <summary>
        /// Get Many Ranks
        /// </summary>
        /// <returns>Ranks by Ids</returns>
        /// <response code = "200" > Ranks by Ids Returned</response>
        [SwaggerResponseExample(StatusCodes.Status200OK, typeof(RankHistoryListExample))]
        [HttpGet("GetMany")]
        public async Task<List<RankHistoryResponseModel>> GetMany([FromQuery] RankTuple[] ids)
        {
            var parameters = ids.Select(tuple => (tuple.userId, tuple.PizzaId)).ToArray();
            return await _RankHistoryService.GetMany(parameters);
        }

        /// <summary>
        /// Create Rank
        /// </summary>        
        /// <remarks>
        /// Note that Id is not necessary.
        /// </remarks>
        /// <response code = "200" > Rank Created </response>
        [SwaggerRequestExample(typeof(RankHistoryCreateModel), typeof(RankHistoryExample))]
        [HttpPost]
        public async Task Post(RankHistoryCreateModel request)
        {
            var entity = request.Adapt<RankHistoryRequestModel>();
            await _RankHistoryService.Create(entity);
        }

       
    }
}
