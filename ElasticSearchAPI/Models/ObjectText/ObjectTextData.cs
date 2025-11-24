using System.Text.Json.Serialization;

namespace ElasticSearchAPI
{
    /// <summary>
    /// Represents ObjectText domain model.
    /// </summary>
    public class ObjectTextData
    {
        /// <summary>
        /// Gets or sets the unique identifier for the object.
        /// </summary>
        public int ObjectId { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the object type associated with this instance.
        /// </summary>
        public long ObjectTypeId { get; set; }

        /// <summary>
        /// Gets or sets the name of the module associated with this instance.
        /// </summary>
        public required string Module { get; set; }

        /// <summary>
        /// Gets or sets the unique identifier for the text type associated with this entity.
        /// </summary>
        public long TextTypeId { get; set; }

        /// <summary>
        /// Gets or sets the text content.
        /// </summary>
        public string? Text { get; set; }

        /// <summary>
        /// Gets or sets the language in the text. Optional.
        /// </summary>
        [JsonIgnore]
        public Language? TextLanguage { get; set; }
    }
}