using ElasticSearchAPI.Models.ObjectText;
using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectTextController : ControllerBase
    {
        private readonly IObjectTextService ObjectTextService;
        private readonly IElasticService ElasticService;

        public ObjectTextController(IObjectTextService objectTextService, IElasticService elasticService)
        {
            ObjectTextService = objectTextService;
            ElasticService = elasticService;
        }

        /// <summary>
        /// Get all objects without filtering.
        /// </summary>
        [HttpGet("")]
        public IEnumerable<ObjectTextData> Get()
        {
            //TODO: Refactor to match Task<ObjectTextDataAPIResponse>
            return ObjectTextService.GetAllData();
        }

        /// <summary>
        /// Get an object by it's identifier.
        /// </summary>
        [HttpGet("{id}")]
        public ObjectTextData? Get(long id)
        {
            return ObjectTextService.GetDataById(id);
        }

        /// <summary>
        /// Get all objects by applying filter.
        /// </summary>
        [HttpPost]
        public async Task<ObjectTextDataAPIResponse> Post([FromBody] ObjectTextAPIFilter ObjectTextfilter)
        {
            return new ObjectTextDataAPIResponse { Objects = await ElasticService.FindAsync(ObjectTextfilter) };
        }
    }
}