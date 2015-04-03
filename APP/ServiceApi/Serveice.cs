using DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServiceApi
{
    public class Serveice : ClientBase<IServer>, ServerApi
    {
        static readonly NetMsmqBinding BINDING = new NetMsmqBinding(NetMsmqSecurityMode.None);
        static readonly EndpointAddress ADDRESS = new EndpointAddress("net.msmq://localhost/private/requestqueue");
        public void Request(int val)
        {
            Console.WriteLine("Request:{0}", val);
            Channel.Request(val);
        }
        public Serveice()
            : base(BINDING, ADDRESS)
        {

        }
    }
}
