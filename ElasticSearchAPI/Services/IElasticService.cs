
namespace ElasticSearchAPI
{
    /// <summary>
    /// Elastic Search CRUD.
    /// </summary>
    public interface IElasticService
    {
        /// <summary>
        /// Holds logic to create all required indeces in Elastic Search.
        /// </summary>
        Task CreateAllIndecesAsync();

        /// <summary>
        /// Frops all indexes from the underlying data store.
        /// </summary>
        Task DropAllIndecesAsync();

        /// <summary>
        /// Seeds the specified collection of objects into the specified index.
        /// </summary>
        Task SeedAsync<T>(IEnumerable<T> objectCollection, string indexName);

        /// <summary>
        /// Finds documents on Elastic based of a filter
        /// </summary>
        /// <param name="filter"></param>
        /// <returns></returns>
        Task<IEnumerable<ObjectTextData>> FindAsync(ObjectTextAPIFilter filter);
    }
}