using Prism.Events;
using QIQO.Services;
using System.ServiceModel;

namespace QIQO.Client.Services
{
    public class LRPClient : ILRPClient, ILRPServiceCallBack
    {
        private readonly IEventAggregator _eventAggregator;

        public LRPClient(IEventAggregator eventAggregator) // ILRPService proxy
        {
            _eventAggregator = eventAggregator;
            var proxy = new LRPProxy(new InstanceContext(this));
            proxy.RunService();
        }
        public bool LRPServiceUpdate(int number)
        {
            _eventAggregator.GetEvent<NumberUpdatedEvent>().Publish(number.ToString());
            return false;
        }
    }

    public interface ILRPClient { }
}
