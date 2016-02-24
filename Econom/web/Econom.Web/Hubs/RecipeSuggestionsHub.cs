namespace Econom.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Econom.Web.Areas.Private.ViewModels;
    using System;
    public class RecipeSuggestionsHub : Hub
    {
        public void Hello(RecipeSearchResultViewModel recipe)
        {
            try
            {
                var a = Context.ConnectionId;
                Clients.All.receiveRecipe( "Hey");
            }
            catch (Exception ex)
            {

            }
        }
    }
}