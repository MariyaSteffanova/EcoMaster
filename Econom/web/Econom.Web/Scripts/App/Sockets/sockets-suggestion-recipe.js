(function () {

    // Socket Notifications
    $('a[data-role="make-suggestion"]').click(function (e) {
        e.preventDefault();
        var $target = $(e.target),
            url = $target.data('href'),
            id = $target.data('id'),
            title = $target.data('title'),
            imageUrl = $target.data('image-url'),

        data = {
            id: id,
            title: title,
            imageUrl: imageUrl
        };

        console.log(data);

        $.ajax({
            url: url,
            method: 'POST',
            data: data,
            success: function () {
               $('#notification-suggestion-sent').show();
            }
        });
    });
}());