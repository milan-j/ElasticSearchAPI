
namespace ElasticSearchAPI
{
    public interface IElasticSearchConfigurationService
    {
        Task CreateAllIndecesAsync();
        Task DropAllIndecesAsync();
    }
}