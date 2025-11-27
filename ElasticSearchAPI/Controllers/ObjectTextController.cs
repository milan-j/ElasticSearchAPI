using ElasticSearchAPI.Models.ObjectText;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ObjectTextController : ControllerBase
    {
        private readonly IElasticService ElasticService;

        public ObjectTextController(IElasticService elasticService)
        {
            ElasticService = elasticService;
        }

        /// <summary>
        /// Get all objects matching applied filter.
        /// </summary>
        [Authorize]
        [HttpPost]
        public async Task<ObjectTextDataAPIResponse> Post([FromBody] ObjectTextAPIFilter ObjectTextfilter)
        {
            return new ObjectTextDataAPIResponse { Objects = await ElasticService.FindAsync(ObjectTextfilter) };
        }
    }
}