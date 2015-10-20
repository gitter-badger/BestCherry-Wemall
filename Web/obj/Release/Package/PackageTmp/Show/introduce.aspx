<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="introduce.aspx.cs" Inherits="Web.Show.introduce" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <title>商品详情</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <!-- 第一屏 -->
    <img src="<%=desimgpath %>" alt="" id="img">
    <div data-am-widget="navbar" class="am-navbar am-cf am-navbar-default " id="">
        <ul class="am-navbar-nav am-cf am-avg-sm-4">
            <li>
                <a href="sale.aspx?timeBuyCode=10001&normalCode=20001&pollCode=30001">
                    <span class="am-icon-home"></span>
                    <span class="am-navbar-label">首页</span>
                </a>
            </li>
            <li data-am-navbar-share>
                <a href="###">
                    <span class="am-icon-share-square-o"></span>
                    <span class="am-navbar-label">分享</span>
                </a>
            </li>
            <li data-am-navbar-qrcode>
                <a href="###">
                    <span class="am-icon-qrcode"></span>
                    <span class="am-navbar-label">二维码</span>
                </a>
            </li>
            <li>
                <a  id="buy">
                    <span class="am-icon-paypal"></span>
                    <span class="am-navbar-label">立即购买</span>
                </a>
            </li>
        </ul>
    </div>
    <script>
        wWidth = $(window).width();
        $("#img").width(wWidth);
        $("#buy").click(function () {
            location.href = "buy.aspx?code=<%=code%>" + "&type=<%=type%>" + "&activityid=<%=activityid%>";
    });
</script>
</asp:Content>
