using System.ServiceModel;

namespace Chat
{
    class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public OperationContext OperationContext { get; set; }
    }
}
