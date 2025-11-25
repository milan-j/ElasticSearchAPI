using Elastic.Clients.Elasticsearch;

namespace ElasticSearchAPI
{
    /// <summary>
    /// Provides ability to automatically configure Elastic Search indices.
    /// </summary>
    public class ElasticSearchConfigurationService : IElasticSearchConfigurationService
    {
        private const string OBJECT_TEST_INDEX_NAME = "object_text_index"; //TODO: Move to config

        private readonly ElasticsearchClient ElasticsearchClient;

        public ElasticSearchConfigurationService(ElasticsearchClient elasticsearchClient)
        {
            ElasticsearchClient = elasticsearchClient;
        }

        public async Task CreateAllIndecesAsync()        
        {
            await ElasticsearchClient.Indices.CreateAsync(OBJECT_TEST_INDEX_NAME, 
                ic => ic.Mappings(
                    m => m.Properties<ObjectTextData>(
                        p => p
                        .Keyword(o => o.TextTypeId)
                        .LongNumber(o => o.ObjectId)
                        .LongNumber(o => o.ObjectTypeId)
                        .MatchOnlyText(o => o.Module)
                        .Text(o => o.Text, field => field.Fields(subFields => subFields
                            .Text("serbian", s => s.Analyzer("serbian")) 
                            .Text("english", l => l.Analyzer("english"))                
                        )))));
        }

        public async Task DropAllIndecesAsync()
        {
            await ElasticsearchClient.Indices.DeleteAsync(OBJECT_TEST_INDEX_NAME);
        }
    }
}
