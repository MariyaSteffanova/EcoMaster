using Econom.Web.Areas.Private.ViewModels;
using Econom.Web.Hubs;
using Microsoft.AspNet.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Econom.Web.Areas.Private.Controllers
{
    public class RecipeSuggestionsController : Controller
    {
        // GET: Private/RecipeSuggestions
        public ActionResult Index()
        {
            return View();
        }

        public void Send(RecipeSearchResultViewModel recipeModel)
        {
            var context = GlobalHost.ConnectionManager.GetHubContext<RecipeSuggestionsHub>();
            context.Clients.All.receiveRecipe("hello world");
        }
    }
}