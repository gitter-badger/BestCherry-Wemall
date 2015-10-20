<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="orderlist.aspx.cs" Inherits="Web.Show.orderlist" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div data-am-widget="tabs"
        class="am-tabs am-tabs-d2" style="margin: 0px;">
        <ul class="am-tabs-nav am-cf">
            <li class="am-active"><a href="[data-tab-panel-0]">待付款</a></li>
             <li class=""><a href="[data-tab-panel-1]">全部订单</a></li>
        </ul>
        <div class="am-tabs-bd" style="border: none;">
            <div data-tab-panel-0 class="am-tab-panel am-active">
                <table class="tablesaw" data-tablesaw-mode="column toggle" style="font-size: 1.5rem; width: 100%">
                    <thead>
                        <tr>
                            <th>商品</th>
                            <th>总价</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>苹果*1,橘子*2,青芒*3</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">付款</button></td>
                        </tr>
                        <tr>
                            <td>苹果*1</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">付款</button></td>
                        </tr>
                        <tr>
                            <td>苹果等...</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">付款</button></td>
                        </tr>
                        <tr>
                            <td>苹果等...</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">付款</button></td>
                        </tr>
                        <tr>
                            <td>苹果等...</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">付款</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
            <div data-tab-panel-1 class="am-tab-panel ">
                <table class="tablesaw" data-tablesaw-mode="column toggle" style="font-size: 1.5rem; width: 100%">
                    <thead>
                        <tr>
                            <th>商品</th>
                            <th>总价</th>
                            <th>操作</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>苹果*1,橘子*2,青芒*3</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">查询物流</button></td>
                        </tr>
                        <tr>
                            <td>苹果*1</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">查询物流</button></td>
                        </tr>
                        <tr>
                            <td>苹果等...</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">查询物流</button></td>
                        </tr>
                        <tr>
                            <td>苹果等...</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">查询物流</button></td>
                        </tr>
                        <tr>
                            <td>苹果等...</td>
                            <td>￥298</td>
                            <td>
                                <button class="am-btn am-radius am-topbar-btn am-btn-sm am-btn-danger">查询物流</button></td>
                        </tr>
                    </tbody>
                </table>
            </div>
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
                    <span class="am-icon-user"></span>
                    <span class="am-navbar-label">个人中心</span>
                </a>
            </li>
        </ul>
    </div>
</asp:Content>
