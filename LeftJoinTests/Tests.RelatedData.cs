namespace Tests
{
    public partial class Tests
    {
        public class RelatedData
        {
            public int DataId { get; set; }
            public string Name { get; set; }

            public RelatedData(int dataId, string name)
            {
                DataId = dataId;
                Name = name;
            }

            public RelatedData()
            {
            }
        }
    }
}