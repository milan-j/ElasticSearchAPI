namespace ElasticSearchAPI
{
    public class ObjectTextAPIFilter
    {
        /// <summary>
        /// Gets or sets the starting index for an operation.
        /// </summary>
        public int From { get; set; }

        /// <summary>
        /// Gets or sets the size of the result set.
        /// </summary>
        public int Size { get; set; }

        /// <summary>
        /// Filter by text type identifier.
        /// </summary>
        public long TextTypeId { get; set; }

        /// <summary>
        /// Filter text content by specified keywords.
        /// </summary>
        public IEnumerable<string>? Keywords { get; set; }
    }
}