$(function () {
    $('#news_list a').click(function (e) {
        e.preventDefault();
        var url = $(this).attr("href");
       
        $.ajax({
            url: url,
            type: 'get',
            beforeSend: show_loading,
            success: function (result) {
                hide_loading();
                $('#news_content').html(result);
            },
            error: function (result) {
                hide_loading();
                $('#news_content').html('');
            },           
            complete: hide_loading
        });
    });
   
    var firstUrl = $('#news_list a:first').attr("href");
    $.ajax({
        url: firstUrl,
        type: 'get',    
        success: function (result) {       
            $('#news_content').html(result);
        },
        error: function (result) {
          
            $('#news_content').html('');
        }              
    });
});

function show_loading() {

   // $('#news_content').fadeOut('fast');
    $('#news_content').hide();
    $('#loading').show();
}
function hide_loading() {
    $('#loading').hide();
    $('#news_content').show();
   // $('#news_content').fadeIn('fast');
}