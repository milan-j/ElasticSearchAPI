namespace ElasticSearchAPI
{
    public static class Constants
    {
        public const string OBJECT_TEST_INDEX_NAME = "object_text_index";

        public class ErrorMessages
        {
            public const string ElasticSeedError = "An error occurred during seeding test data to Elastic Search during startup.";
            public const string ElasticIndexDocumentError = "Failed to index document. {ElasticsearchServerError}";
        }
    }
}
