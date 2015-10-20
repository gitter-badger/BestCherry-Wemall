<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="querylogistics.aspx.cs" Inherits="Web.Show.querylogistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>查询物流</title>
    <script src="../Assets/js/tablesaw.js"></script>
    <link rel="stylesheet" href="../Assets/css/tablesaw.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="am-form-inline" role="form">
        <div class="am-input-group">
            <input type="text" class="am-form-field" placeholder="输入手机号" id="mobile" runat="server">
            <span class="am-input-group-btn">
                <asp:Button ID="btnSearch" OnClick="Search_click" CssClass="am-btn am-btn-danger" runat="server" Text="查询" />
            </span>
        </div>
        <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
            <HeaderTemplate>
                <table class="tablesaw" data-tablesaw-mode="column toggle" style="font-size:1.5rem;">
                    <thead>
                        <tr>
                            <th>商品</th>
                            <th>物流</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td   style="font-size:1.5rem;"><%# GetSmallTile(Eval("ORDERLIST").ToString()) %></td>
                    <td  style="font-size:1.5rem; text-align:center;">
                        <asp:LinkButton runat="server" ID="lblSearch" CommandArgument='<%#Eval("LOGISTICS") %>' CommandName="Search" CssClass="am-btn am-btn-xs am-btn-danger" Text="<span class='am-icon-search'></span>查询"></asp:LinkButton></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
        <asp:Repeater ID="rptLogistics" runat="server">
            <HeaderTemplate>
                 <table class="tablesaw" data-tablesaw-mode="column toggle" style="font-size:1.5rem;">
                    <thead>
                        <tr>
                            <th>状况</th>
                            <th>时间</th>
                            <th>营业所名</th>
                        </tr>
                    </thead>
                    <tbody>
            </HeaderTemplate>
            <ItemTemplate>
                <tr>
                    <td   style="font-size:1.5rem;"><%#Eval("STATUS") %></td>
                    <td  style="font-size:1.5rem;"><%#Eval("TIME") %></td>
                    <td  style="font-size:1.5rem;"><%#Eval("NAME") %></td>
                </tr>
            </ItemTemplate>
            <FooterTemplate>
                </tbody>
                    </table>
            </FooterTemplate>
        </asp:Repeater>
    </form>
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
        </ul>
    </div>
</asp:Content>
