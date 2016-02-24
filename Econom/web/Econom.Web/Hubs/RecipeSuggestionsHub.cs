namespace Econom.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Econom.Web.Areas.Private.ViewModels;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using Services.Data.Contracts;
    using System.Linq;

    public class RecipeSuggestionsHub : Hub
    {
        private static readonly Dictionary<string, string> users = new Dictionary<string, string>();
        private IUserService usersService;
        private IRecipesService recipesService;
        private ISuggestionsService suggestionsService;

        public Dictionary<string, string> ConnectionsDictionary
        {
            get { return users; }
        }

        public RecipeSuggestionsHub(IUserService usersService, IRecipesService recipesService, ISuggestionsService suggestionsService)

        {
            this.usersService = usersService;
            this.recipesService = recipesService;
            this.suggestionsService = suggestionsService;
        }

        public override Task OnConnected()
        {
            var a = Context.User.Identity.GetUserId();
            string userid = a;
            string connectionId = Context.ConnectionId;

            if (!users.ContainsKey(userid))
            {
                users.Add(userid, connectionId);
            }

            users[userid] = connectionId;

            return base.OnConnected();
        }
        public void Send(RecipeSearchResultViewModel recipe)
        {
            var recipeId = this.recipesService.CreateBasic(recipe.Id, recipe.Title, recipe.ImageUrl, recipe.SocialRank);
            var senderId = Context.User.Identity.GetUserId();

            var suggestion = this.suggestionsService.Create(senderId, recipeId, string.Empty); // TODO: Map

            var flatmates = this.usersService.GetFlatmates(senderId);

            var flatIds = flatmates.Select(x => x.Id).ToList();

            foreach (var id in flatIds)
            {
                if (this.ConnectionsDictionary.ContainsKey(id))
                {
                    var connectionId = this.ConnectionsDictionary[id];
                    Clients.Client(connectionId).receiveRecipe(suggestion);
                }
            }
        }
    }
}