using QIQO.Core.IoC;
using QIQO.Core.Logging;
using QIQO.Services.IoC;
using System;
using SM = System.ServiceModel;

namespace QIQO.Services.Host
{
    class Program
    {
        static void Main(string[] args)
        {
            //ServiceHost host = new ServiceHost(typeof(LRPService));
            //host.Open();

            //Console.WriteLine("Services started. Press [Enter] to exit.");
            //Console.ReadLine();

            //host.Close();

            Log.Info("Starting the application...");
            Unity.Container = UnityLoader.Init();
            
            using (Unity.Container)
            {
                Log.Info("Configuring UnityServiceHost...");
                // Step 2 Create a ServiceHost instance
                SM.ServiceHost hostLRPService = new UnityServiceHost(Unity.Container, typeof(LRPService));

                try
                {
                    StartService(hostLRPService, "LRP Service");

                    Console.WriteLine("");
                    Console.WriteLine("Press [Enter] to exit.");
                    Console.ReadLine();
                    Console.WriteLine("");

                    StopService(hostLRPService, "LRP Service");

                }
                catch (SM.CommunicationException ce)
                {
                    Log.Error("An exception occurred: {0}", ce.Message);
                }
                catch (Exception ex)
                {
                    Log.Error("An exception occurred: {0}", ex.Message);
                }
                finally
                {
                    hostLRPService.Abort();
                }
            }
        }

        static void StartService(SM.ServiceHost host, string serviceDescription)
        {
            host.Open();
            Log.Info("Service '{0}' started.", serviceDescription);

            foreach (var endpoint in host.Description.Endpoints)
            {
                Log.Info(string.Format("Listening on endpoint:"));
                Log.Info(string.Format("Address: {0}", endpoint.Address.Uri.ToString()));
                Log.Info(string.Format("Binding: {0}", endpoint.Binding.Name));
                Log.Info(string.Format("Contract: {0}", endpoint.Contract.ConfigurationName));
            }
            Console.WriteLine();
        }

        static void StopService(SM.ServiceHost host, string serviceDescription)
        {
            host.Close();
            Log.Info("Service '{0}' stopped.", serviceDescription);
        }

    }
}
