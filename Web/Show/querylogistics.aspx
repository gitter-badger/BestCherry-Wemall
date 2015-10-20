<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="querylogistics.aspx.cs" Inherits="Web.Show.querylogistics" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>查询物流</title>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <form id="form1" runat="server" class="am-form-inline" role="form">
        <asp:Repeater ID="rptLogistics" runat="server">
            <HeaderTemplate>
                 <table class="tablesaw" data-tablesaw-mode="column toggle" style="font-size:1.5rem; width:100%">
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
        </ul>
    </div>
</asp:Content>
