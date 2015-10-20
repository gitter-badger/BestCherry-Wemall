<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="sale.aspx.cs" Inherits="Web.Show.sale" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <link rel="stylesheet" href="../Assets/css/sale.css">
    <title>牡丹惠</title>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div data-am-widget="slider" class="am-slider am-slider-a1" data-am-slider='{"directionNav":false}'>
        <ul class="am-slides">
            <% foreach (Model.ActivityProM item in listTimeBuyPro)
               {
            %>
            <li>
                <div class="d_tag">
                    <span class="name"><span class="am-icon-heart"></span><%=item.BUYTIME.Substring(8,2) %>点<% if (item.BUYTIME.Substring(10, 2) != "00")
                                                                                                               {%><%=item.BUYTIME.Substring(10, 2) %><%} %>开抢</span>
                </div>
                <div class="d_title">
                    <p class="title">
                        <%=item.TITLE %>
                        <br />
                        ￥<%=item.MEMBERPRICE %>
                    </p>
                </div>
                <img src="<%=item.IMAGEPATH %>" alt="" name="timebuy" code="<%=item.CODE %>" id="<%=item.ACTIVITYID %>" />
                <div class="d_buy">
                    <button type="button" name="buy" class=" buy am-btn am-btn-danger" code="<%=item.CODE %>" id="<%=item.ACTIVITYID %>"><%=CheckTime(item.BUYTIME) %> </button>
                </div>
            </li>
            <%} %>
        </ul>
    </div>
    <div data-am-widget="list_news" class="am-list-news am-list-news-default">
        <div class="am-list-news-hd am-cf">
            <a href="#">
                <h2><span class="am-icon-reorder"></span>非限时商品</h2>
            </a>
        </div>
        <div class="am-list-news-bd">
            <ul class="am-list">
                <%  foreach (Model.ActivityProM item in listNormalPro)
                    { %>
                <li class="am-g am-list-item-desced am-list-item-thumbed am-list-item-thumb-left">
                    <div class="am-u-sm-4 am-list-thumb" style="max-height: 100px;">
                        <img src="<%=item.IMAGEPATH %>" alt="">
                    </div>
                    <div class="am-u-sm-8 am-list-main">
                        <h3 class="am-list-item-hd" style="font-size: 15px; color: #C7000B; font-weight: bold;">
                            <%=item.TITLE %> ￥<%=item.PRICE %>
                        </h3>
                        <div class="am-list-item-text"><%=item.SMALLTITLE %></div>
                        <button class="am-btn am-topbar-btn am-btn-sm am-btn-danger" style="float: right" onclick="window.location.href=' introduce.aspx?code=<%=item.CODE %>&type=2&activityid=<%=item.ACTIVITYID %>'">立即购买</button>
                    </div>
                </li>
                <%} %>
            </ul>
        </div>
    </div>
    <div data-am-widget="list_news" class="am-list-news am-list-news-default">
        <div class="am-list-news-hd am-cf">
            <a href="###">
                <h2><span class="am-icon-reorder"></span>参与投票+下期抢购由您来定</h2>
            </a>
        </div>
        <hr data-am-widget="divider" style="margin: 0.5rem auto" class="am-divider am-divider-default am-no-layout">
        <ul data-am-widget="gallery" class="am-gallery am-avg-sm-2
  am-avg-md-3 am-avg-lg-4 am-gallery-default"
            data-am-gallery="{ pureview: true }">
            <%  foreach (Model.ActivityProM item in listPollPro)
                { %>
            <li>
                <div class="am-gallery-item">
                    <a>
                        <img src="<%=item.IMAGEPATH %>" alt="">
                        <h3><%=item.TITLE %><a name="poll" code="<%=item.PROID %>" style="float: right">投票</a></h3>
                    </a>
                </div>
            </li>
            <%} %>
        </ul>
    </div>
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
                <a href="querylogistics.aspx">
                    <span class="am-icon-bus"></span>
                    <span class="am-navbar-label">查询物流</span>
                </a>
            </li>
        </ul>
    </div>
    <script src="../Assets/js/sale.js"></script>
</asp:Content>
