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
        console.log(recipe);
        //  $('#notificationRecipeTitle').title(recipe.recipe.Title);
        $('#notificationRecipe').show();
        console.log("yep");
    };

}());