namespace ElasticSearchAPI
{
    public class ObjectTextAPIFilter
    {
        /// <summary>
        /// Filter by text type identifier.
        /// </summary>
        public long TextTypeId { get; set; }

        /// <summary>
        /// Filter text content by specified keywords.
        /// </summary>
        public IEnumerable<string>? Keywords { get; set; }

        /// <summary>
        /// Operator to apply for keyword filtering.
        /// </summary>
        public string Operator { get; set; } = KeywordOperator.Or.ToString();
    }
}