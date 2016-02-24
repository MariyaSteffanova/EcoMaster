(function () {

    'use strict';

    $.connection.hub.start().done(function () {
        console.log("connection on");
    });

    var recipeSuggestions = $.connection.recipeSuggestionsHub;
    recipeSuggestions.client.receiveRecipe = receiveRecipe2;


    function receiveRecipe2(recipe) {
        if ($.connection != null) {
            console.log('nope');
        }

        if (recipe) {
            var img = $('<img/>').attr('src', recipe.Recipe.ImageUrl),
                btnApprove = $('<a href="/Private/Suggestions/Approve/"' + recipe.RecipeID + '>Approve</a>').addClass("btn").addClass("kendo-style-bg");

            $('#notification-title').text(recipe.Recipe.Title);
            $('#notification-rank').text(recipe.Recipe.SocialRank);
            $('#notification-img').append(img);
            $('#notification-notes').text(recipe.Notes);
            $('#notification-approved-count').text(recipe.Approvals + '');
            console.log(recipe.Title);
            $('#notificationRecipe').show();
            $('#notificationRecipe').append(btnApprove);
                              
        }
        console.log(recipe);
        //  $('#notificationRecipeTitle').title(recipe.recipe.Title);
      
        console.log("yep");
    };

}());