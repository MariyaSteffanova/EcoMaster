$(document).ready(function () {

    var products = $("#products").data("kendoMultiSelect");


    products.wrapper.attr("id", "products-wrapper");

    $('a[data-role="generate-recipe"]').click(function (e) {
        var $target = $(e.target),
            url = $target.data('href'),
         data = [];

        for (var k in selectedIds) {
            if (selectedIds.hasOwnProperty(k)) {
                if (selectedIds[k] % 2 == 1) {
                    data.push(+k);
                }
            }
        }

        $.ajax({
            url: url,
            type: "POST",
            data: { data: data },
            dataSource: 'application/json',
            success: function (data) {
                console.log("success!");
                $('#recipes').html(data);
            }
        })
        e.preventDefault();
    });



});