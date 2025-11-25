using Elastic.Clients.Elasticsearch;

namespace ElasticSearchAPI
{
    /// <summary>
    /// Provides functionality to seed Index configuration and test data into Elastic Search.
    /// </summary>

    public class TestDataSeederService
    {
        private const string OBJECT_TEST_INDEX_NAME = "object_text_index"; //TODO: Move to config

        private readonly IObjectTextService ObjectTextService;
        private readonly IElasticSearchConfigurationService ElasticSearchConfigurationService;
        private readonly ElasticsearchClient ElasticsearchClient;


        public TestDataSeederService(
            IObjectTextService objectTextService, 
            IElasticSearchConfigurationService elasticSearchConfigurationService,
            ElasticsearchClient elasticsearchClient)
        {
            ObjectTextService = objectTextService;
            ElasticSearchConfigurationService = elasticSearchConfigurationService;
            ElasticsearchClient = elasticsearchClient;
        }

        public async Task SeedAsync()
        {
            await DropRecreateAndConfigureElasticIndex();
            foreach (var objectText in ObjectTextService.GetAllData())
            {
                var r = await ElasticsearchClient.IndexAsync<ObjectTextData>(objectText, idx => idx.Index(OBJECT_TEST_INDEX_NAME));
                //TODO: Log reponse
            }
        }

        private async Task DropRecreateAndConfigureElasticIndex()
        {
            await ElasticSearchConfigurationService.DropAllIndecesAsync();
            //TODO: Should check if index is really dropped before recreating
            await ElasticSearchConfigurationService.CreateAllIndecesAsync();
            //TODO: Check if index is created again
        }
    }
}
