$(function () {
    
    var current_tab = $('#current-tab').val();
    $('#myTab a[href="' + current_tab + '"]').tab('show');
    $('#myTab a').click(function (e) {
        e.preventDefault();
        $(this).tab('show');
        $('#current-tab').val($(this).attr("href"));
        $('#category-list').slimScroll();
    });

    $('#category-list').slimScroll({
        height: '780px',
        position: 'right',
        color: '#eee',
        railVisible: true,
        alwaysVisible: false,
        allowPageScroll: false
    });

   
});