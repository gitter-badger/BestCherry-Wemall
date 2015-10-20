<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="Index.aspx.cs" Inherits="Admin.Show.Index" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="am-cf am-padding">
                    <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">首页</strong> / <small>今日动态</small></div>
                </div>
                <ul class="am-avg-sm-1 am-avg-md-2 am-margin am-padding am-text-center admin-content-list ">
                    <li><a href="#" class="am-text-success"><span class="am-icon-btn am-icon-file-text"></span>
                        <br />
                        未付款订单<br />
                        <%=notPay %></a></li>
                    <li><a href="#" class="am-text-warning"><span class="am-icon-btn am-icon-jpy"></span>
                        <br />
                        成交订单<br />
                        <%=havePay %></a></li>
                </ul>
</asp:Content>
