
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

        /// <summary>
        /// Retrieves objects by filter.
        /// </summary>
        Task<IEnumerable<ObjectTextData>> GetDataByFilterAsync(ObjectTextAPIFilter filter);
    }
}