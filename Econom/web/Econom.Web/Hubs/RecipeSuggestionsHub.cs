namespace Econom.Web.Hubs
{
    using Microsoft.AspNet.SignalR;
    using Econom.Web.Areas.Private.ViewModels;
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Microsoft.AspNet.Identity;
    using System.Web.Mvc;
    using Microsoft.AspNet.SignalR.Hubs;


    [Microsoft.AspNet.SignalR.Authorize(Roles = "Admin")]
    public class RecipeSuggestionsHub : Hub
    {
        private static readonly Dictionary<string, string> users = new Dictionary<string, string>();

        public Dictionary<string, string> ConnectionsDictionary
        {
            get { return users; }
        }

        public override Task OnConnected()
        {
            var a = Context.Request.User.Identity.GetUserId();
            string userid = a;
            string connectionId = Context.ConnectionId;

            if (!users.ContainsKey(userid))
            {
                users.Add(userid, connectionId);
            }

            users[userid] = connectionId;

            return base.OnConnected();
        }
        public void Hello(RecipeSearchResultViewModel recipe)
        {
            var a = Context.ConnectionId;
            Clients.All.receiveRecipe("Hey");
        }
    }
}