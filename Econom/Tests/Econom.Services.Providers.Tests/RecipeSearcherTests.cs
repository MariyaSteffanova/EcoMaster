namespace MvcTemplate.Services.Web.Tests
{
    using System.Collections.Generic;
    using Econom.Data.Models;
    using Econom.Services.Data.Contracts;
    using Econom.Services.Searchers;
    using Econom.Tests.Common.Repositories;
    using Moq;
    using NUnit.Framework;

    [TestFixture]
    public class RecipeSearcherTests
    {
        private List<StorageProduct> products;
        private RecipesSearcherService recipeSearcher;

        [OneTimeSetUp]
        public void IngredientsCollectionSetup()
        {
            this.products = StorageProductsRepository.Get();
            var storageProductsService = new Mock<IStorageProductsService>();
        }

        [OneTimeTearDown]
        public void IngredientsCollectionDestroy()
        {
            this.products.Clear();
        }

    }
}
