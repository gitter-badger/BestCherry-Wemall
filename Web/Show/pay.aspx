<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="Web.Show.pay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>订单支付</title>
    <link rel="stylesheet" href="../Assets/css/pay.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <ul class="am-list">
            <li class="title"><%=name %></li>
            <li>卡种:工银银联信用卡 
            </li>
            <li>总价：<b>￥<%=allPrice %></b></li>
            <li>总价：<b>￥<%=allPrice %></b></li>
        </ul>
    </div>
    <div style="background: #fffdf2; border: 1px solid #ffe2c6; margin: 10px; padding: 10px; font-size: 0.9em; line-height: 1.8em;">
        <p style="padding: 10px">您正在使用银联在线提供的快捷支付服务，我们将与银行核对后进行支付。<font color="#d90008">首次使用银联在线支付功能请先点击"开通"。</font></p>
        <div align="center" id="unionpay">
            <p>
                <input type="tel" readonly="" value="6282880073732647" placeholder="请输入银行卡号">
                <button type="button" class="am-btn am-btn-danger" id="openUNION">开通</button>
            </p>
            <div id="mobilephone" align="center"></div>
            <p>
                <input type="tel" style="width: 50%;" maxlength="6" placeholder="短信验证码">
                <button type="button" class="am-btn am-btn-danger" id="getSMS">获取验证码</button>
            </p>
            <button type="button" class="am-btn am-btn-success">确定</button>
        </div>
    </div>
    <div data-am-widget="navbar" class="am-navbar am-cf am-navbar-default " id="">
        <ul class="am-navbar-nav am-cf am-avg-sm-4">
            <li>
                <a href="index.aspx">
                    <span class="am-icon-home"></span>
                    <span class="am-navbar-label">首页</span>
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
