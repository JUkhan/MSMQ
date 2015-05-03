using Microsoft.Owin;
using Owin;
using WebAce.Models.Agent;

[assembly: OwinStartupAttribute(typeof(WebAce.Startup))]
namespace WebAce
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
            app.MapSignalR();
            
        }
    }
}
