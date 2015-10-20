var type = $('#form input[name=type]').val();
var code = $('#form input[name=code]').val();
var activityid = $('#form input[name=activityid]').val();
var isCanBuy = false;
if (type == "1") {
    setInterval(function () {
        $.ajax({
            type: "GET",
            url: "../Api/checktime.ashx?code="+code+"&activityid="+activityid,
            dataType: "text",
            success: function (data) {
                if (data == "0") {
                    isCanBuy = true;
                    $("#orderSendTxt").html("<span class=\"am-icon-credit-card\"></span>支付订单");
                } else {
                    isCanBuy = false;
                    $("#orderSendTxt").html("<span class=\"am-icon-calendar\"></span>" + data);
                }
            }
        });
    }, 1000);
}
var width = (window.innerWidth > 0) ? window.innerWidth : screen.width;
var height = (window.innerHeight > 0) ? window.innerHeight : screen.height;
$("#submitOrder").click(function () {
    if (type == "1") {
        if (!isCanBuy) {
            return;
        }
    } 
    var consignee = $('.address-form input[name=consignee]').val();
    var remark = $('.address-form input[name=remark]').val();
    var mobile = $('.address-form input[name=mobile]').val();
    var address = $('.address-form input[name=address]').val();
    var receiver_state = $('.address-form select[name=__district_id]').find("option:selected").text();
    var receiver_city = $('.address-form select[name=_district_id]').find("option:selected").text();
    var receiver_district = $('.address-form select[name=district_id]').find("option:selected").text();
    var membernum = $('.address-form input[name=membernum]').val();
    var district_id = $('.address-form select[name=district_id]').val();

    if (consignee.length < 1 || consignee.match(/[\<\>\"\']/)) {
        alert("请填写收货人姓名，且姓名中不得含有引号('\")和尖括号(<>)");
        return false;
    }

    if (!mobile.match(/^1\d{10}$/)) {
        alert('请填写格式正确的收货人手机号码');
        return false;
    }

    if (!district_id) {
        alert('请您填写完整的地区信息');
        return false;
    }
    if (address.length < 3 || address.match(/[\<\>\"\']/)) {
        alert("请填写街道地址，且其中不得含有引号('\")和尖括号(<>)");
        return false;
    }
    $(this).find('input[name=consignee]').val(consignee);
    $(this).find('input[name=membernum]').val(membernum);
    $(this).find('input[name=mobile]').val(mobile);
    $(this).find('input[name=remark]').val(remark);
    $(this).find('input[name=receiver_state]').val(receiver_state);
    $(this).find('input[name=receiver_city]').val(receiver_city);
    $(this).find('input[name=receiver_district]').val(receiver_district);
    $(this).find('input[name=address]').val(address);
    var orderstr = "";
    $("table[name=order-list]").find("tr").each(function () {
        if ($(this).hasClass("hiddenClass")) {
            return true;
        }
        $(this).find('input[name=address]').val(address);
        orderstr += $(this).attr("id") + "," + $(this).find("[name=buynum]").text() + ",";
    });
    $("form").find('input[name=orderbuy]').val(orderstr.substr(0, orderstr.length - 1));
    if (setTotal() == 0) {
        return false;
    } else {
        $("form").submit();
    }
    //if (bank == "") {
    //    layer.alert('确认支付方式', {
    //        skin: 'layui-layer-molv',
    //        title: "请选择支付方式",
    //        closeBtn: false, //不显示关闭按钮
    //        content: '<div style="color:#000;"><input type="radio" name="paytype" value="MOBILEICBC" />工银E支付<img src="build/工银.jpg" /><br /><input type="radio" name="paytype" value="YINLIAN" />银联支付<img src="build/银联.png" /></div>'
    //    }, function () {
    //        bank = $('input[name="paytype"]:checked').val();
    //        $(".order-submit").submit();
    //    });
    //    return false;
    //} else {
    //    $(this).find('input[name=bank]').val(bank);
    //}
});
var t = $("#buynum");
$("div[id=add]").click(function () {
    t = $(this).prev();
    if (t.text() == "") {
        t.text("1");
    }
    t.text(parseInt(t.text()) + 1)
    setTotal();
})
$("div[id=min]").click(function () {
    t = $(this).next();
    if (t.text() == "0") {
        return false;
    }
    if (t.text() == "") {
        t.text("1");
    }
    t.text(parseInt(t.text()) - 1)
    setTotal();
})
function setTotal() {
    var allPrice = 0;
    $("[name=buynum]").each(function () {
        if ($(this).parents("tr").hasClass("hiddenClass")) {
            return true;//continue;
        }
        var price = $(this).parent().nextAll("[name=oneprice]").val();
        if (isMN) {
            price -= 10;
        }
        var num = $(this).text();
        allPrice += price * num;
    });
    var hasYunfei = false;
    if (type == 2) {
        if (allPrice != 0) {
            if (allPrice < 88) {
                allPrice += 10;
                hasYunfei = true;
            }
        }
    }
    if (hasYunfei == true) {
        $("#yunfei").text("10");
    } else {
        $("#yunfei").text("0");
    }
    $(".price").html("总计：" + (allPrice).toFixed(2));
    return allPrice;
}
$("input[name=kidcheck]").click(function () {
    if (!$(this).prop("checked") && $("input[name=kidcheck]:checked").length == 0) {
        alert("至少选择一种商品");
        return false;
    }
    if (!$(this).prop("checked")) {
        $("#" + $(this).val()).addClass("hiddenClass");
    } else {
        $("#" + $(this).val()).removeClass("hiddenClass");
    }
    setTotal();
});
var isMN = false;
function checkMemberNum() {
    var mn = $("label[name=membernum]").val();
    if (!isNaN(mn)) {
        isMN = true;
    } else {
        isMN = false;
    }
}
$("label[name=membernum]").blur(function () {
    checkMemberNum();
    setTotal();
});
$("label[name=membernum]").keyup(function () {
    checkMemberNum();
    setTotal();
});
setTotal();