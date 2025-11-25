
namespace ElasticSearchAPI
{
    /// <summary>
    /// Defines a service for ObjectText data CRUD.
    /// </summary>
    public interface IObjectTextService
    {
        /// <summary>
        /// Retrieves all available ObjectText data entries.
        /// </summary>
        IEnumerable<ObjectTextData> GetAllData();

        /// <summary>
        /// Retrieves ObjectText by id.
        /// </summary>
        ObjectTextData? GetDataById(long id);
    }
}