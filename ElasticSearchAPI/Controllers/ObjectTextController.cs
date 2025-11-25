using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectTextController : ControllerBase
    {
        private readonly IObjectTextService ObjectTextService;

        public ObjectTextController(IObjectTextService objectTextService)
        {
            ObjectTextService = objectTextService;
        }

        /// <summary>
        /// Get all objects without filtering.
        /// </summary>
        [HttpGet("")]
        public IEnumerable<ObjectTextData> Get()
        {
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
        public IEnumerable<ObjectTextData> Post([FromBody] ObjectTextAPIFilter ObjectTextfilter)
        {
            throw new NotImplementedException();
        }
    }
}