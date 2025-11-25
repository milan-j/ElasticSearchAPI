namespace ElasticSearchAPI.SeedData
{
    public static class TestData
    {
        public static IEnumerable<ObjectTextData> GetObjectTextTestData()
        {
            return new List<ObjectTextData>
            {
                new ObjectTextData
                {
                    ObjectId = 1,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "English, latin, haircut, djordjevik."
                },
                new ObjectTextData
                {
                    ObjectId = 2,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Srpski, latinica, šišanje, đorđević."
                },
                new ObjectTextData
                {
                    ObjectId = 3,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Srpski, krnja latinica, sisanje, djordjevic, koje-kude."
                },
                new ObjectTextData
                {
                    ObjectId = 4,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 10,
                    Text = "Српски, ћирилица, шишање, ђорђевић, које-куде."
                },
                new ObjectTextData
                {
                    ObjectId = 5,
                    ObjectTypeId = 100,
                    Module = "Module A",
                    TextTypeId = 20,
                    Text = "Nepoznat jezik. Mix content. Шчa?"
                },
                new ObjectTextData
                {
                    ObjectId = 6,
                    ObjectTypeId = 100,
                    Module = "Module B",
                    TextTypeId = 20,
                    Text = "Српски, ћирилица, шишање, ђорђевић, Модул Б."
                }
            };
        }
    }
}