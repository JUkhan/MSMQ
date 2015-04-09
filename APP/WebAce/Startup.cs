using Microsoft.Owin;
using Owin;

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
