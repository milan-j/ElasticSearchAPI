using Elastic.Clients.Elasticsearch;

namespace ElasticSearchAPI
{
    /// <inheritdoc/> 
    public class ElasticService : IElasticService //TODO: Could be moved to a specialization class, and this one should become abstract
    {
        private readonly ElasticsearchClient ElasticsearchClient;
        private readonly ILogger Logger;

        public ElasticService(ElasticsearchClient elasticsearchClient, ILogger<ElasticService> logger)
        {
            ElasticsearchClient = elasticsearchClient;
            Logger = logger;
        }

        /// <inheritdoc/> 
        public async Task CreateAllIndecesAsync()        
        {
            await ElasticsearchClient.Indices.CreateAsync(Constants.OBJECT_TEST_INDEX_NAME,
                ic => ic.Mappings(
                    m => m.Properties<ObjectTextData>(
                        p => p
                        .Keyword(o => o.TextTypeId)
                        .LongNumber(o => o.ObjectId)
                        .LongNumber(o => o.ObjectTypeId)
                        .MatchOnlyText(o => o.Module)
                        .Text(o => o.Text, field => field.Fields(subFields => subFields
                            .Text(Language.Serbian.ToString().ToLower(), p => p.Analyzer(Language.Serbian.ToString().ToLower()))
                            .Text(Language.English.ToString().ToLower(), p => p.Analyzer(Language.English.ToString().ToLower()))
                            // More language specific analyzers can be added if needed
                        )))));
        }


        /// <inheritdoc/> 
        public async Task DropAllIndecesAsync()
        {
            await ElasticsearchClient.Indices.DeleteAsync(Constants.OBJECT_TEST_INDEX_NAME);
        }

        /// <inheritdoc/> 
        public async Task SeedAsync<T>(IEnumerable<T> objectCollection, string indexName)
        {
            foreach (T o in objectCollection)
            {
                var r = await ElasticsearchClient.IndexAsync<T>(o, idx => idx.Index(indexName));

                if (!r.IsValidResponse)
                {
                    Logger.LogError(Constants.ErrorMessages.ElasticIndexDocumentError, r.ElasticsearchServerError);
                }
            }
        }

        /// <inheritdoc/> 
        /// 

        //TODO: Could be moved to a specialization class
        public async Task<IEnumerable<ObjectTextData>> FindAsync(ObjectTextAPIFilter filter)
        {
            var response = await ElasticsearchClient.SearchAsync<ObjectTextData>(s => s
                .Indices(Constants.OBJECT_TEST_INDEX_NAME)
                .From(filter.From)
                .Size(filter.Size)
                .Query(q => q
                    .Term(t => t
                        .Field(x => x.TextTypeId)
                        .Value(filter.TextTypeId))));

            return response.Documents;
        }
    }
}
