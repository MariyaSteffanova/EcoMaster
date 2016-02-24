using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Econom.Web.Startup))]

namespace Econom.Web
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
             app.MapSignalR();

            ConfigureAuth(app);
          
        }
    }
}
