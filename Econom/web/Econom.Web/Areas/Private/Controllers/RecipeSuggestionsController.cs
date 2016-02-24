using Econom.Services.Data.Contracts;
using Econom.Web.Areas.Private.ViewModels;
using Econom.Web.Hubs;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.SignalR;
using System.Linq;
using System.Web.Mvc;

namespace Econom.Web.Areas.Private.Controllers
{
    [System.Web.Mvc.Authorize]
    public class RecipeSuggestionsController : Controller
    {
        private readonly IUserService usersService;
        private readonly RecipeSuggestionsHub hub;

        public RecipeSuggestionsController(IUserService usersService)
        {
            this.usersService = usersService;
           
        }
        // GET: Private/RecipeSuggestions
        public ActionResult Index()
        {
            return View();
        }

        public void Send(RecipeSearchResultViewModel recipeModel)
        {
            // TODO: Save suggestion
            // TODO: Get all flatmates ids
            var context = GlobalHost.ConnectionManager.GetHubContext<RecipeSuggestionsHub>();
            this.usersService.GetFlatmates(this.User.Identity.GetUserId())
                   .Select(x => x.Id)
                   .ToList()
                   .ForEach(x =>
                   {
                       var connectionId = this.hub.ConnectionsDictionary[x];
                       context.Clients.Client(connectionId).receiveRecipe("hello wordld");

                   });

            context.Clients.Client(this.User.Identity.GetUserId()).receiveRecipe("Hey, invoker! ");
        }
    }
}