using Econom.Data.Contracts;
using Econom.Services.Data;
using Econom.Services.Data.Contracts;
using Econom.Web.App_Start;
using Econom.Web.Hubs;
using Econom.Web.Infrastructure.Activators;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Microsoft.Practices.Unity;
using Owin;
using System.Web.Routing;

[assembly: OwinStartupAttribute(typeof(Econom.Web.Startup))]

namespace Econom.Web
{
    public partial class Startup
    {
        public object NinjectIoC { get; private set; }

        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Index")
            });

            // Use a cookie to temporarily store information about a user logging in with a third party login provider
            //  app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);
            // app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

            //  RouteTable.Routes.MapHubs();

            //// Unity
            //var container = new UnityContainer();
            //container.RegisterType<IUserService, UserService>();
            //container.RegisterType<IRecipesService, RecipesService>();
            //container.RegisterType<ISuggestionsService, SuggestionsService>();
            //container.RegisterType <IRepository<,>) ,typeof(Repository<,>) > ();
            //GlobalHost.DependencyResolver.Register(typeof(IHubActivator), () => new UnityHubActivator(container));
            app.MapSignalR();
            ConfigureAuth(app);

        }
    }
}
