using System;
using System.ServiceModel;
using Microsoft.Practices.Unity;

namespace QIQO.Core.IoC
{
    public class UnityServiceHost : ServiceHost
    {
        public UnityServiceHost(IUnityContainer container, Type serviceType, params Uri[] baseAddresses)
          : base(serviceType, baseAddresses)
        {
            if (container == null)
            {
                throw new ArgumentNullException("container");
            }

            foreach (var cd in this.ImplementedContracts.Values)
            {
                cd.Behaviors.Add(new UnityInstanceProvider(container));
            }
        }
    }

}
