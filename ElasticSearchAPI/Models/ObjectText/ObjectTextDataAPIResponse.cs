namespace ElasticSearchAPI.Models.ObjectText
{
    /// <summary>
    /// Represents the response returned from an API call that retrieves a collection of ObjectTextData.
    /// </summary>
    public class ObjectTextDataAPIResponse
    {
        /// <summary>
        /// Gets or sets the collection of object text data.
        /// </summary>
        public required IEnumerable<ObjectTextData> Objects { get; set; }

        /// <summary>
        /// Gets the number of elements contained in the Objects collection.
        /// </summary>
        public int Count => Objects.Count();
    }
}
