using QIQO.Core.Contracts;

namespace QIQO.Data.Entities
{
    public class TestData : IEntity
    {
        public long TestId { get; set; }
        public string TestCode { get; set; }
        public string TestName { get; set; }
        public string TestDesc { get; set; }
        public int EntityRowKey
        {
            get { return (int)TestId; }
            set { TestId = value; }
        }
    }
}
