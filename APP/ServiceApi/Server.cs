using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceApi
{
     //[ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Server : IServer
    {
        static readonly NetMsmqBinding BINDING = new NetMsmqBinding(NetMsmqSecurityMode.None);
        static readonly EndpointAddress ADDRESS = new EndpointAddress("net.msmq://localhost/private/responsequeue");
        // [OperationBehavior(TransactionScopeRequired = true)]
         public void Request(int val)
        {
            Thread.Sleep(2000);
            Client.StatusMesage("10% done");
            Thread.Sleep(3000);
            Client.StatusMesage("20% done");
            Thread.Sleep(4000);
            Client.StatusMesage("30% done");
            Thread.Sleep(4000);
            Client.StatusMesage("60% done");
            Thread.Sleep(5000);
            Client.StatusMesage("80% done");
            Thread.Sleep(6000);
            Client.StatusMesage("100% done");
            Client.StatusMesage("Succeessfully done");
            Client.Reply(val + 100);
        }
        public IClient Client
        {
            get
            {
                if (_client == null)
                    _client = new ChannelFactory<IClient>(BINDING, ADDRESS).CreateChannel();

                return _client;
            }
        }
        private IClient _client = null;
    }
}
