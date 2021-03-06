﻿namespace Econom.Web.Areas.Private.Controllers
{
    using Common;
    using Econom.Services.Data.Contracts;
    using Econom.Web.Infrastructure.Filters;
    using Microsoft.AspNet.Identity;
    using System;
    using System.Web.Mvc;

    [Authorize]
    public class StorageProductsController : Controller
    {
        private IStorageProductsService storageProductsService;

        public StorageProductsController(IStorageProductsService storageProductsService)
        {
            this.storageProductsService = storageProductsService;
        }

        // GET: Private/StorageProducts
        public ActionResult Index()
        {
            return View();
        }

        [HomeStorageOwnerWrapper]
        public ActionResult AddProduct(int id) // TODO: Move in another Controller
        {
            this.storageProductsService
                 .Add(id, this.User.Identity.GetUserId());

            var action = Convert.ToString(this.Session[GlobalConstants.ClientSearchMode]);
            TempData["Message"] =  "Product succesfully added to your Food Storage. You can continue searching for more products."; 
            return this.RedirectToAction("Input", action, new { area = "Public" });
        }

    }
}