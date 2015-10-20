<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="profile.aspx.cs" Inherits="Web.Show.profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>个人中心</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div>
        <div style="background-color: #dd514c">
            <div style="text-align: center;">
                <img src="<%=Headimgurl %>" width="60" height="60" class="am-circle" style="margin-top: 40px" />
                <span class="name" style="color: #FFF; display: block; padding-bottom: 20px;padding-top:5px;"><%=Nickname %>123123</span>
            </div>
        </div>
        <nav data-am-widget="menu" class="am-menu am-menu-stack am-no-layout">
            <ul class="am-menu-nav am-avg-sm-1">
                    <li class=""><a href="orderlist.aspx" class="" style="color:#dd514c"><span class="am-icon-yen "></span>我的订单</a></li>
                    <li class=""><a href="address.aspx" class="" style="color:#dd514c"><span class="am-icon-map-marker "></span>我的收货地址</a></li>
          </ul>
        </nav>
    </div>
    <div data-am-widget="navbar" class="am-navbar am-cf am-navbar-default " id="">
        <ul class="am-navbar-nav am-cf am-avg-sm-4">
            <li>
                <a href="index.aspx">
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
                <a href="profile.aspx">
                    <span class="am-icon-user"></span>
                    <span class="am-navbar-label">个人中心</span>
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
