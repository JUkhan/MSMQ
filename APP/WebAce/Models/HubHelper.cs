using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebAce.Models
{
    
    public class HubHelper<THub> :object where THub : IHub
    {
        Lazy<IHubContext> hub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<THub>());
        
        protected IHubContext HUB
        {
            get { return hub.Value; }
        }
       
    }
    
}