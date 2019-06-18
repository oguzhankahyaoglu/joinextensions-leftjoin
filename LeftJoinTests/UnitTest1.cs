using System.Linq;
using LeftJoin;
using NUnit.Framework;

namespace Tests
{
    public partial class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        public static readonly TestData[] DATA = new[]
        {
            new TestData(1, "Data1", "Desc1"),
            new TestData(2, "Data2", "Desc2"),
            new TestData(3, "Data3", "Desc3"),
        };

        [Test]
        public void TestQueryable()
        {
            var data2 = new RelatedData[]
            {
                new RelatedData {DataId = 1, Name = "Related1"},
                new RelatedData {DataId = 2, Name = "Related2"},
            };

            var result = DATA
                .AsQueryable()
                .LeftJoin(data2.AsQueryable(), td => td.ID, a => a.DataId, (td, a) => new {td, a})
                .Where(a => a.a != null)
                .ToArray();
            Assert.True(result.Length == 2);
        } 
        [Test]
        public void TestEnumerableQueryable()
        {
            var data2 = new RelatedData[]
            {
                new RelatedData {DataId = 1, Name = "Related1"},
                new RelatedData {DataId = 2, Name = "Related2"},
            };

            var result = DATA
                .LeftJoin(data2.AsQueryable(), td => td.ID, a => a.DataId, (td, a) => new {td, a})
                .Where(a => a.a != null)
                .ToArray();
            Assert.True(result.Length == 2);
        }
    }
}