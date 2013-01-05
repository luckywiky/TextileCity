$(function () {
    $('#list_pager a[href]').click(function () {
        var href = $(this).attr('href');
        if (href == '' || href == '#')
            return;      
        $.ajax({
            url: $(this).attr('href'),
            type: "GET",
            beforeSend:show_loading,
            success: function (response) {
                $('#list_content').html(response);
                hide_loading();
            },
            error: hide_loading,
            complete: hide_loading
        });
        return false;
    });
});

function show_loading() {
    $('#list_content').hide();
    $('#loading').show();
}
function hide_loading() {
    $('#loading').hide();
    $('#list_content').show();
}
