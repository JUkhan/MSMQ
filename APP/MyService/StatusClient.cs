using Status.Service;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace MyService
{
    public class StatusClient : ClientBase<IStatus>, StatusApi
    {
        static readonly NetMsmqBinding BINDING = new NetMsmqBinding("MSMQ_BINDING_CONFIG");
        public StatusClient()
            : base(BINDING, new EndpointAddress(ConfigurationManager.AppSettings["STATUS_SERVICE"]))
        {

        }
        public void Status(Agent.Servive.ExecuteInfo info)
        {
            Channel.Status(info);
        }
    }
}