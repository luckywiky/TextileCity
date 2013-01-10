function setDelivery(type) {
    var value = $('#delivery-type').val();
    if (value == type)
        return;
    if (type == '1') {
        $('#delivery-type').val('1');
        $('#dbtn-2').removeClass('active');
        $('#dbtn-1').addClass('active');
        $('#address').hide('normal');
    }
    else {
        $('#delivery-type').val('2');
        $('#dbtn-1').removeClass('active');
        $('#dbtn-2').addClass('active');
        $('#address').show('normal');
    }
}

function itemdelete(id){
    $.ajax({
        url: '/cart/Delete',
        type: 'post',
        dataType: "json",
        data:'id='+id,
        success: function (dataObj) {
            if (dataObj.result == 1) {
                $('#item-' + id).hide('slow', function () {
                    $('#item-' + id).remove();
                });
                $('#order-total').html(dataObj.total);
                var count = $('#top-cart-count').html();
                count = parseInt(count);
                if (count > 1) {
                    count = count - 1;
                    $('#top-cart-count').html(count);
                    $('#itemsCount').html(count);
                   
                }
                else {
                    $('#top-cart-count').html('');
                    $('#itemsCount').html(0);
                }               
            }
            else {
                alert('删除失败');
            }
        },
        error: function (data) {
            alert('删除失败');
        }
    });
}


$(function () {
    $('#itemlist input').change(function () {
        var input_id = $(this).attr("id");
        var count = $(this).val();
        if (!checkCount(count, input_id))
            return;
        var id = input_id.replace('item-count-', '');
        $.ajax({
            url: '/cart/changecount',
            type: 'post',
            dataType: "json",
            data: {'id':id,'count':count},
            success: function (dataObj) {
                if (dataObj.result == 1) {
                    $('#item-total-' + id).html(dataObj.itemTotal);
                    $('#item-price-' + id).html(dataObj.price);
                    $('#order-total').html(dataObj.total);
                    $('#' + input_id).popover('destroy');
                }
                else {
                    $('#' + input_id).popover({ trigger: 'manual', title: '错误！', content:'数量太大了 :(' });
                    $('#' + input_id).popover('show');
                }
            },
            error: function (data) {
                $('#' + input_id).popover({ trigger: 'manual', title: '错误！', content: '修改失败 :(' });
                $('#' + input_id).popover('show');
            }
        });
    });
 
  
});

function checkCount(count,id) {
    var reg = /^[1-9]\d*$/;
    if (reg.test(count)) {       
        $('#' + id).popover('destroy');
        return true;
    }
    else {
        $('#' + id).popover({ trigger:'manual', title: '错误！', content: '数量必须为大于零的整数 :(' });
        $('#' + id).popover('show');
        return false;
    }
}
var success = true;
function formsubmit() {
    success = true;
    $('#itemlist input:text').each(
        function (i, val) {
            success = success & checkCount(val.value, val.id);
        });
    var delivery = $('#delivery-type').val();

    success = success & checkInput('input-name');
    success = success & checkInput('input-phone');
    if (delivery == 2) {
        success = success & checkInput('input-address');
    }
    if (success) {
        var save = $('#cb-save-addr').is(':checked');
        if (save) {
            $('#input-save-addr').val(1);
        }
        else {
            $('#input-save-addr').val(0);
        }
        $('#cartform').submit();
    }
}

function checkInput(id) {
    if ($('#' + id).val() == '') {
        $('#' + id).popover({ trigger: 'manual', title: '错误！', content: '不能为空！ :(' });
        $('#' + id).popover('show');
        return false;
    }
    else {
        $('#' + id).popover('destroy');
        return true;
    }
}

function saveAddrChage() {
    var save = $('#cb-save-addr').is(':checked');
    if (save) {
        $('#input-save-addr').val(1);
    }
    else {
        $('#input-save-addr').val(0);
    }
}