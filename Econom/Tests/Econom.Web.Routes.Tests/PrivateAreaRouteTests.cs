namespace Econom.Web.Routes.Tests
{
    using System.Net.Http;
    using System.Web.Mvc;
    using System.Web.Routing;
    using Econom.Web;
    using MvcRouteTester;
    using NUnit.Framework;
    using Areas.Private;
    using Areas.Private.Controllers;
    using Moq;
    using Services.Data;
    using System.Web;
    using System;
    [TestFixture]
    public class PrivateAreaRouteTests
    {
        private RouteCollection routeCollection;

        [OneTimeSetUp]
        public void RouteCollectionSetup()
        {
            var area = new PrivateAreaRegistration();
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
        public void TestHomeStorageIndexRoute()
        {
            const string Url = "/Private/HomeStorage/";
            this.routeCollection.ShouldMap(Url).To<HomeStorageController>(c => c.Index());
        }

        [Test]
        public void TestHomeStorageCreateRoute()
        {
            const string Url = "/Private/HomeStorage/Create";
            this.routeCollection.ShouldMap(Url).To<HomeStorageController>(HttpMethod.Get, c => c.Create());
        }

        [Test]
        public void TestHomeStoragePostCreateRoute()
        {
            const string Url = "/Private/HomeStorage/PostCreate";
            this.routeCollection.ShouldMap(Url).To<HomeStorageController>(HttpMethod.Get, c => c.PostCreate());
        }

        [Test]
        public void TestFlatmatesIndexRoute()
        {
            const string Url = "/Private/Flatmates/Index";
            this.routeCollection.ShouldMap(Url).To<FlatmatesController>(HttpMethod.Get, c => c.Index());
        }

        [Test]
        public void TestFlatMatesGetRoute()
        {
            const string Url = "/Private/Flatmates/Get";
            this.routeCollection.ShouldMap(Url).To<FlatmatesController>(HttpMethod.Get, c => c.Get(null));
        }

        [Test]
        public void TestKitchenIndexRoute()
        {
            const string Url = "/Private/Kitchen";
            this.routeCollection.ShouldMap(Url).To<KitchenController>(HttpMethod.Get, c => c.Index());
        }

        [Test]
        public void TestKitchenGetRoute()
        {
            const string Url = "/Private/Kitchen/List";
            this.routeCollection.ShouldMap(Url).To<KitchenController>(HttpMethod.Get, c => c.List());
        }

        [Test]
        public void TestKitchenGetRecipesRoute()
        {
            const string Url = "/Private/Kitchen/GetRecipes";
            this.routeCollection.ShouldMap(Url).To<KitchenController>(HttpMethod.Get, c => c.GetRecipes(new int[5]));
        }

        [Test]
        public void TestStorageProductsAddRoute()
        {
            const string Url = "/Private/StorageProducts/AddProduct?id=5";
            this.routeCollection.ShouldMap(Url).To<StorageProductsController>(HttpMethod.Get, c => c.AddProduct(5));
        }

        [Test]
        public void TestStorageProductsIndexRoute()
        {
            const string Url = "/Private/StorageProducts/Index";
            this.routeCollection.ShouldMap(Url).To<StorageProductsController>(HttpMethod.Get, c => c.Index());
        }

    }
}
