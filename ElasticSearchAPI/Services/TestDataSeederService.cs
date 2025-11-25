namespace ElasticSearchAPI
{
    public class TestDataSeederService
    {
        private readonly IObjectTextService ObjectTextService;

        public TestDataSeederService(IObjectTextService objectTextService)
        {
            ObjectTextService = objectTextService;
        }

        public async Task SeedAsync()
        {
            var objectTextData = ObjectTextService.GetAllData();
            
            //Seed to elastic
        }

    }
}
