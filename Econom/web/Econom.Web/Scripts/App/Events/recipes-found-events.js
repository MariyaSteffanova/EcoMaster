(function () {

    $('a[data-role="show-ingredients"]').click(function (e) {
        $($(e.target).siblings('.ingredients')[0]).show();
    });

    $('a[data-role="hide-ingredients"]').click(function (e) {
        $('.ingredients').hide();
    });

}());