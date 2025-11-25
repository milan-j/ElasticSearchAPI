namespace ElasticSearchAPI
{
    /// <summary>
    /// Provides extension methods for seeding test data during startup
    /// scenarios.
    /// </summary>
    public static class DataSeedingExtension
    {
        public static async Task SeedTestDataAsync(this WebApplication app)
        {
            using var scope = app.Services.CreateScope();
            var testDataseeder = scope.ServiceProvider.GetRequiredService<TestDataSeederService>();

            try
            {
                await testDataseeder.SeedAsync();
            }
            catch (Exception ex)
            {
                var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
                logger.LogError(ex, "An error occurred during seeding test data to Elastic Search during startup.");
                throw;
            }
        }
    }
}
