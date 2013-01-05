$(function () {
    $('#list_pager a').click(function () {
        alert($(this).attr('href'));
        $.ajax({
            url: $(this).attr('href'),
            type: "GET",
            success: function (response) {

                $('#list_content').html(response);
            }
        });
        return false;
    });
});