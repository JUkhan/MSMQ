using DataModel;
using ServiceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerHost
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Server is Running...");
            using (var host = new ServiceHost(typeof(Server)))
            {
                var bin = new NetMsmqBinding(NetMsmqSecurityMode.None);
                host.AddServiceEndpoint(typeof(IServer), bin, "net.msmq://localhost/private/requestqueue");
                host.Open();

                Console.ReadLine();
            }
        }
    }
}
