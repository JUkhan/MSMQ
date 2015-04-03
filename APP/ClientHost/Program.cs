using DataModel;
using ServiceApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientHost
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var host = new ServiceHost(typeof(Client)))
            {
                var bin = new NetMsmqBinding(NetMsmqSecurityMode.None);
                host.AddServiceEndpoint(typeof(IClient), bin, "net.msmq://localhost/private/responsequeue");
                host.Open();

                var proxy = new Serveice();
                proxy.Request(700);               
                Console.ReadLine();
            }
        }
    }
}
