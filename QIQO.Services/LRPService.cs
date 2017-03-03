using QIQO.Core.Logging;
using System;
using System.Collections.Generic;
using System.ServiceModel;
using System.Threading;

namespace QIQO.Services
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Reentrant)]
    public class LRPService : ILRPService
    {
        public static bool Running { get; set; }
        static List<int> _Numbers = new List<int>();

        public void RunService()
        {
            var rnd = new Random(10000);
            bool cancel = false;

            for (int i = 0; i < 20; i++)
            {
                int gen = rnd.Next();
                Console.WriteLine("Generated {0}", gen);
                _Numbers.Add(gen);

                var callback = OperationContext.Current.GetCallbackChannel<ILRPServiceCallBack>();
                if (callback != null)
                    try
                    {
                        Log.Info($"LRPServiceUpdate Number: {gen}");
                        cancel = callback.LRPServiceUpdate(gen);
                    }
                    catch //(CommunicationException ex)
                    {
                        cancel = true;
                    }

                if (!cancel)
                    Thread.Sleep(3000);
                else
                    break;
            }
        }
    }
}
