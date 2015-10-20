$("[name='buy']").each(function () {
    $(this).on('click', function () {
        if ($(this).text() != "尚未开始") {
            window.location.href = "introduce.aspx?procode=" + $(this).attr("procode") + "&type=1&activityid=" + $(this).attr("id");
        }
    });
});
$("img[name='timebuy']").each(function () {
    $(this).on('click', function () {
        window.location.href = "introduce.aspx?procode=" + $(this).attr("procode") + "&type=1&activityid=" + $(this).attr("id");
    });
});
$("a[name='poll']").each(function () {
    $(this).on('click', function () {
        $.ajax({
            type: "GET",
            url: "../Api/poll.ashx?ID=" + $(this).attr("code"),
            dataType: "text",
            success: function (data) {
                if (data == "1") {
                    alert("投票成功!");
                }
            }
        });
    });
});
//大于320屏幕设备缩放页面
var autoScale = function () {
    setTimeout(function () {
        var winW = document.documentElement.clientWidth;
        var scale = (winW / 320).toFixed(4);
        var mainCssText = '-webkit-transform:scale(' + scale + ');-webkit-transform-origin:center top';
        $('.act_overlay,.act_content').attr('style', mainCssText);
        $('.act_overlay').hide();
    }, 300)
};
if ($(window).width() > 320) {
    autoScale();
}
window.addEventListener("onorientationchange" in window ? "orientationchange" : "resize", autoScale, false); //切换横竖屏
$('.r_arrow').on('click', function () {
    $('.mod_rule').toggleClass('open')
});