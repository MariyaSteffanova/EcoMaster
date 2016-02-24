namespace Econom.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Econom.Web;
    using Econom.Web.Areas.Public;
    using Econom.Web.Areas.Public.Controllers;
    using MvcRouteTester;
    using NUnit.Framework;
    using ViewModels;
    [TestFixture]
    public class PublicAreaRouteTests
    {
        private RouteCollection routeCollection;

        [OneTimeSetUp]
        public void RouteCollectionSetup()
        {
            var area = new PublicAreaRegistration();
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
        public void TestBarcodeSearchRoute()
        {
            const string Url = "/Keyboard/input";
            this.routeCollection.ShouldMap(Url).To<KeyboardController>(HttpMethod.Get, c => c.Input());
        }

        [Test]
        public void TestBarcodeSearchByKeyboardRoute()
        {
            const string Url = "/Keyboard/Find?barcode=1234";
            this.routeCollection.ShouldMap(Url).To<KeyboardController>(HttpMethod.Get, c => c.Find("1234"));
        }

        [Test]
        public void TestBarcodeNullSearchByKeyboardRoute()
        {
            const string Url = "/Keyboard/Find?";
            this.routeCollection.ShouldMap(Url).To<KeyboardController>(HttpMethod.Get, c => c.Find(null));
        }

        [Test]
        public void TestBarcodeNumberSearchByKeyboardRoute()
        {
            const string Url = "/Keyboard/Find?5";
            this.routeCollection.ShouldMap(Url).To<KeyboardController>(HttpMethod.Get, c => c.Find(null));
        }

        [Test]
        public void TestBarcodeManyParamsSearchByKeyboardRoute()
        {
            const string Url = "/Keyboard/Find?barcode=1234&nosuh=000";
            this.routeCollection.ShouldMap(Url).To<KeyboardController>(HttpMethod.Get, c => c.Find("1234"));
        }

        [Test]
        public void TestHomeRoute()
        {
            const string Url = "/Home/Index";
            this.routeCollection.ShouldMap(Url).To<HomeController>(HttpMethod.Get, c => c.Index());
        }

        [Test]
        public void TestAboutRoute()
        {
            const string Url = "/Home/About";
            this.routeCollection.ShouldMap(Url).To<HomeController>(HttpMethod.Get, c => c.About());
        }

        [Test]
        public void TestContactsRoute()
        {
            const string Url = "/Home/Contact";
            this.routeCollection.ShouldMap(Url).To<HomeController>(HttpMethod.Get, c => c.Contact());
        }

        [Test]
        public void TestLogoutRoute()
        {
            const string Url = "/Account/Logoff";
            this.routeCollection.ShouldMap(Url).To<AccountController>(HttpMethod.Get, c => c.LogOff());
        }

        [Test]
        public void TestRegisterRoute()
        {
            const string Url = "/Account/Register";
            this.routeCollection.ShouldMap(Url).To<AccountController>(HttpMethod.Get, c => c.Register());
        }

        [Test]
        public void TestImagesRoute()
        {
            const string Url = "/Images/GetImage?url=img";
            this.routeCollection.ShouldMap(Url).To<ImagesController>(HttpMethod.Get, c => c.GetImage("img"));
        }
    }
}
