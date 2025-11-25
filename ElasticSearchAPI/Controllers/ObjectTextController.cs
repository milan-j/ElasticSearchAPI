using ElasticSearchAPI.Models.ObjectText;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        [HttpPost]
        public async Task<ObjectTextDataAPIResponse> Post([FromBody] ObjectTextAPIFilter ObjectTextfilter)
        {
            return new ObjectTextDataAPIResponse { Objects = await ElasticService.FindAsync(ObjectTextfilter) };
        }
    }
}