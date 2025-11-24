using Microsoft.AspNetCore.Mvc;

namespace ElasticSearchAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ObjectTextController : ControllerBase
    {
        /// <summary>
        /// Get all objects without filtering.
        /// </summary>
        [HttpGet("")]
        public ObjectTextData Get()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get an object by it's identifier.
        /// </summary>
        [HttpGet("{id}")]
        public ObjectTextData Get(long id)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Get all objects by filtering.
        /// </summary>
        [HttpPost]
        public IEnumerable<ObjectTextData> Post([FromBody] ObjectTextAPIFilter ObjectTextfilter)
        {
            throw new NotImplementedException();
        }
    }
}