namespace Econom.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using Econom.Web;
    using MvcRouteTester;
    using NUnit.Framework;
    using Areas.Admin;
    using Areas.Admin.Controllers;

    [TestFixture]
    public class AdminAreaRouteTests
    {
        private RouteCollection routeCollection;

        [OneTimeSetUp]
        public void RouteCollectionSetup()
        {
            var area = new AdminAreaRegistration();
            var area4Context = new AreaRegistrationContext(area.AreaName, RouteTable.Routes);
            area.RegisterArea(area4Context);

            RouteConfig.RegisterRoutes(RouteTable.Routes);

            this.routeCollection = RouteTable.Routes;
        }

        [OneTimeTearDown]
        public void RouteCollectionDestroy()
        {
            RouteTable.Routes.Clear();
        }

        [Test]
        public void TestDashboardRoute()
        {
            const string Url = "/Admin/Dashboard/";
            this.routeCollection.ShouldMap(Url).To<DashboardController>(c => c.Index());
        }

        [Test]
        public void TestFoodStoragesIndexdRoute()
        {
            const string Url = "/Admin/FoodStorages/";
            this.routeCollection.ShouldMap(Url).To<FoodStoragesController>(c => c.Index());
        }

        [Test]
        public void TestUsersIndexRoute()
        {
            const string Url = "/Admin/Users/";
            this.routeCollection.ShouldMap(Url).To<UsersController>(c => c.Index());
        }
    }
}
