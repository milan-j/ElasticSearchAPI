namespace ElasticSearchAPI
{
    /// <inheritdoc/>
    public class ObjectTextService : IObjectTextService
    {
        /// <inheritdoc/>
        public IEnumerable<ObjectTextData> GetAllData()
        {
            var testData = new List<ObjectTextData>
            {
                new ObjectTextData
                {
                    ObjectId = 1,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "English, latin, haircut, djordjevik.",
                    TextLanguage = Language.English
                },
                new ObjectTextData
                {
                    ObjectId = 2,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Srpski, latinica, šišanje, đorđević.",
                    TextLanguage = Language.Serbian
                },
                new ObjectTextData
                {
                    ObjectId = 3,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Srpski, krnja latinica, sisanje, djordjevic.",
                    TextLanguage = Language.Serbian
                },
                new ObjectTextData
                {
                    ObjectId = 4,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Српски, ћирилица, шишање, ђорђевић, које-kude.",
                    TextLanguage = Language.Serbian
                },
                new ObjectTextData
                {
                    ObjectId = 5,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Nepoznat jezik. Mix content. Шчa?"
                },
                new ObjectTextData
                {
                    ObjectId = 6,
                    ObjectTypeId = 100,
                    Module = "Module B",
                    TextTypeId = 10,
                    Text = "Српски, ћирилица, шишање, ђорђевић, које-kude, пример неназначеног језика."
                }
            };

            return testData;
        }

        public ObjectTextData? GetDataById(long id) => GetAllData().SingleOrDefault(o => o.ObjectId == id);
    }
}
