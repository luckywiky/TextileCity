

$(window).load(function () {
    // We only want these styles applied when javascript is enabled
    $('div.navigation').css({ 'width': '320px', 'float': 'right' });
    $('div.content-img').css('display', 'block');

    // Initially set opacity on thumbs and add
    // additional styling for hover effect on thumbs
    var onMouseOutOpacity = 0.5;
    $('#thumbs ul.thumbs li span').opacityrollover({
        mouseOutOpacity: onMouseOutOpacity,
        mouseOverOpacity: 0.0,
        fadeSpeed: 'fast',
        exemptionSelector: '.selected'
    });

    // Initialize Advanced Galleriffic Gallery
    var gallery = $('#thumbs').galleriffic({
        delay: 7000,
        numThumbs: 6,
        preloadAhead: 6,
        enableTopPager: false,
        enableBottomPager: false,
        imageContainerSel: '#slideshow',
        controlsContainerSel: '#controls',
        captionContainerSel: '',
        loadingContainerSel: '',
        renderSSControls: true,
        renderNavControls: false,
        playLinkText: 'Play Slideshow',
        pauseLinkText: 'Pause Slideshow',
        prevLinkText: 'Prev',
        nextLinkText: 'Next',
        nextPageLinkText: 'Next',
        prevPageLinkText: 'Prev',
        enableHistory: true,
        autoStart: 7000,
        syncTransitions: true,
        defaultTransitionDuration: 900,

        onSlideChange: function (prevIndex, nextIndex) {
            // 'this' refers to the gallery, which is an extension of $('#thumbs')
            this.find('ul.thumbs li span')
                .css({ opacity: 0.5 })
        },
        onPageTransitionOut: function (callback) {
            this.find('ul.thumbs li span').css({ display: 'block' });
        },
        onPageTransitionIn: function () {
            this.find('ul.thumbs li span').css({ display: 'none' });
        }
    });

    gallery.find('a.prev').click(function (e) {
        gallery.previousPage();
        e.preventDefault();
    });

    gallery.find('a.next').click(function (e) {
        gallery.nextPage();
        e.preventDefault();
    });
});

$(function () {
    $('#style-list a').click(function (e) {
        var current = $('#style').val();
        var id = $(this).attr("id");
        id = id.replace('style-', '');
        if (id == current)
            return;
        $('#style').val(id);
        $('#current-style-price').val($('#style-price-' + id).text());
        $('#style-block-' + current).removeClass('active');
        $('#style-block-' + id).addClass('active');
        total();
    });
    $('#craft-list .craft-item').click(function (e) {
        var current = $('#craft').val();
        var id = $(this).attr("id");
        id = id.replace('craft-', '');
        if (id == current)
            return;
        $('#craft').val(id);
        $('#current-craft-price').val($('#craft-price-' + id).text());
        $('#craft-block-' + current).removeClass('active');
        $('#craft-block-' + id).addClass('active');
        total();
    });
    $('#craft-list li .craft-item:first').click();
    $('#craft-list .craft-item a').click(function (e) {
        e.stopPropagation();
        var id = $(this).attr('id');
        id = id.replace('craft-intro-', '');
        show_intro(id);
    });

    
    $('#mstyle-list .craft-item').click(function (e) {
        var current = $('#mstyle').val();
        var id = $(this).attr("id");
        id = id.replace('mstyle-', '');
        if (id == current)
            return;
        $('#mstyle').val(id);
        $('#current-mstyle-price').val($('#mstyle-price-' + id).text());
        $('#mstyle-block-' + current).removeClass('active');
        $('#mstyle-block-' + id).addClass('active');
        totalm();
    });
    $('#mstyle-list li .craft-item:first').click();

});

function show_intro(id) {
    $.ajax({
        url: '/craft/ajaxModel/'+id,
        type: 'get',
        dataType: "json",
        success: function (result) {
            bindModalHtml(result.Name, result.Price, result.Intro);
           // $('#craftIntroModal').modal({ backdrop: false });
            $('#craftIntroModal').modal('show');
        },
        error: function (result) {
            bindModalHtml('', '');
        }
    });
}
function bindModalHtml(name, price, intro) {
    $('#craft-modal-price').html('<em class="mar-r5 txt-black">¥</em>' + price);
    $('#craft-modal-header').html(name+'制作工艺');
    $('#craft-modal-body').html(intro);
}

function total() {
    var style_price = $('#current-style-price').val();
    var craft_price = $('#current-craft-price').val();
    var count = $('#count').val();
    if (!checkCount(count)) {
        $('#total-price').text('0');
        return;
    }
    style_price = parseFloat(style_price);
    craft_price = parseFloat(craft_price);
    var total = (style_price + craft_price) * count;
    total = Number(total);
    $('#total-price').text(total.toFixed(2));
}

function totalm() {
    var style_price = $('#current-mstyle-price').val();
    var count = $('#count').val();
    if (!checkCount(count)) {
        $('#total-price').text('0');
        return;
    }
    style_price = parseFloat(style_price);
    var total = style_price * count;
    total = Number(total);
    $('#total-price').text(total.toFixed(2));
}

function checkCount(count) {
    var reg = /^[1-9]\d*$/;
    if (reg.test(count)) {
        $('#count-msg').hide();
        return true;
    }
    else {
        $('#count-msg').show();
        return false;
    }
}

function countChange() {
    var count = $('#count').val();
    count = parseInt(count);
    if (count <= 10)
    {
        $('#sub10').addClass('disabled');

    }
    else {
        $('#sub10').removeClass('disabled');
    }
    total();
}

function add(value)
{
    var count = $('#count').val();
    if (!checkCount(count)) {
        return;
    }
    value = parseInt(value);
    count = parseInt(count);
    if ((value + count) <= 0) {
        $('#count').val(1);
        return;
    }
    $('#count').val(count + value);
    total();
}

function countChangeM() {
    var count = $('#count').val();
    count = parseInt(count);
    if (count <= 10) {
        $('#sub10').addClass('disabled');

    }
    else {
        $('#sub10').removeClass('disabled');
    }
    totalm();
}

function addM(value) {
    var count = $('#count').val();
    if (!checkCount(count)) {
        return;
    }
    value = parseInt(value);
    count = parseInt(count);
    if ((value + count) <= 0) {
        $('#count').val(1);
        return;
    }
    $('#count').val(count + value);
    totalm();
}

function bindSubmitModel(count, price) {
    price = Number(price);
    $('#cart-count').text(count);
    $('#cart-price').text(price.toFixed(2));
}

function ajaxsubmit() {
    var count = $('#count').val();
    if (!checkCount(count)) {
        return;
    }
   
    $.ajax({
        url: '/cart/AddFabric',
        type: 'get',
        dataType: "json",
        data: $('#form-fabric').serialize(),
        success: function (result) {
          
            if (result.flag == 1) {
                bindSubmitModel(result.count, result.total);
                $('#submitModal').modal('show');
            }
            else {
                alert('添加失败');
            }
        },
        error: function (result) {
            alert('添加失败');
        }
    });
}

function ajaxsubmitM() {
    var count = $('#count').val();
    if (!checkCount(count)) {
        return;
    }
    $.ajax({
        url: '/cart/AddAccessory',
        type: 'get',
        dataType: "json",
        data: $('#form-accessory').serialize(),
        success: function (result) {          
            if (result.flag == 1) {
                bindSubmitModel(result.count, result.total);
                $('#submitModal').modal({ backdrop: false });
                $('#submitModal').modal('show');
            }
            else {
                alert('添加失败');
            }
        },
        error: function (result) {          
            alert('添加失败');
        }
    });
}