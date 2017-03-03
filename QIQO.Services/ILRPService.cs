using System.ServiceModel;

namespace QIQO.Services
{
    [ServiceContract (CallbackContract =typeof(ILRPServiceCallBack))]
    public interface ILRPService
    {
        [OperationContract(IsOneWay = true)]
        void RunService();
    }

    [ServiceContract]
    public interface ILRPServiceCallBack
    {
        [OperationContract]
        bool LRPServiceUpdate(int number);
    }
}
