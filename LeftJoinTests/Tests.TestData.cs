namespace Tests
{
    public partial class Tests
    {
        public class TestData
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }

            public TestData(int id, string name, string description)
            {
                ID = id;
                Name = name;
                Description = description;
            }

            public TestData()
            {
            }
        }
    }
}