using Agent.Servive;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Web;

namespace WebAce.Models.Agent
{
    public class AgentClient : ClientBase<IAgent>, AgentApi
    {
        static readonly NetMsmqBinding BINDING = new NetMsmqBinding("MSMQ_BINDING_CONFIG");
        
        public AgentClient(string address)
            : base(BINDING, new EndpointAddress(address))
        {
            
        }

        public void TestMethod(ExecuteInfo val)
        {
            Channel.TestMethod(val);
        }

       
    }
}