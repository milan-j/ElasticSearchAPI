using ElasticSearchAPI.SeedData;

namespace ElasticSearchAPI
{
    /// <inheritdoc/>
    public class ObjectTextService : IObjectTextService
    {
        /// <inheritdoc/>
        public IEnumerable<ObjectTextData> GetAllData()
        {
            return TestData.GetObjectTextTestData();
        }

        public ObjectTextData? GetDataById(long id) => GetAllData().SingleOrDefault(o => o.ObjectId == id);
    }
}