using Elastic.Clients.Elasticsearch;

namespace ElasticSearchAPI
{
    /// <summary>
    /// Provides functionality to seed Index configuration and test data into Elastic Search.
    /// </summary>
    public class TestDataSeederService
    {
        private readonly IObjectTextService ObjectTextService;
        private readonly IElasticService ElasticService;


        public TestDataSeederService(
            IObjectTextService objectTextService,
            IElasticService elasticService)
        {
            ObjectTextService = objectTextService;
            ElasticService = elasticService;
        }

        /// <summary>
        /// Seeds initial test data into Elastic Search.
        /// </summary>
        /// <returns></returns>
        public async Task SeedAsync()
        {
            await DropRecreateAndConfigureElasticIndex();
            await ElasticService.SeedAsync<ObjectTextData>(ObjectTextService.GetAllData(), Constants.OBJECT_TEST_INDEX_NAME);
        }

        private async Task DropRecreateAndConfigureElasticIndex()
        {
            await ElasticService.DropAllIndecesAsync();
            await ElasticService.CreateAllIndecesAsync();
        }
    }
}
