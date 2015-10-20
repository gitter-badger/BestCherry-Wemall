$("#openUNION").click(function () {
    $.ajax({
        type: "GET",
        url: "../Api/openUNION.ashx?cardno=" + code + "&orderid=" + activityid,
        dataType: "text",
        success: function (data) {
            $("#getSMS").click();
        }
    });
});

$("#openUNION").click(function () {
    $.ajax({
        type: "GET",
        url: "../Api/getSMS.ashx?cardno=" + code + "&orderid=" + activityid,
        dataType: "text",
        success: function (data) {
            alert("验证码已发送到您手机，请注意查收");
        }
    });
});