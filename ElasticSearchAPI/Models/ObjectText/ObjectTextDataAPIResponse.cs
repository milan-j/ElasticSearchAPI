namespace ElasticSearchAPI.Models.ObjectText
{
    public class ObjectTextDataAPIResponse
    {
        public required IEnumerable<ObjectTextData> Objects { get; set; }

        public int Count => Objects.Count();
    }
}
