using QIQO.Services;
using System.ServiceModel;

namespace QIQO.Client.Services
{
    public class LRPProxy : ILRPService
    {
        private ILRPService channel = null;

        public LRPProxy(InstanceContext ic)
        {
            channel = new DuplexChannelFactory<ILRPService>(ic, "NetTcpBinding_ILRPService").CreateChannel();
        }
        public void RunService()
        {
            channel.RunService();
        }
    }
}
