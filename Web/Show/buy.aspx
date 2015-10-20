<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Web.Master" AutoEventWireup="true" CodeBehind="buy.aspx.cs" Inherits="Web.Show.buy" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <title>确认订单信息</title>
    <link rel="stylesheet" href="../Assets/css/buy.css">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <% if (type == "1")
       { 
    %>
    <header data-am-widget="header" class="am-header am-header-default" style="margin-bottom: 10px;">
        <h1 class="am-header-title">
            <span class="am-icon-ban" id="count">限<%=sum %>份,剩<%=count %>份</span>
        </h1>
    </header>
    <%}%>
    <div data-am-widget="titlebar" class="am-titlebar am-titlebar-default" style="display: none;">
        <h2 class="am-titlebar-title">产品种类
             <% foreach (Model.BestCherryInfo itemCheck in dt)
                {  
             %>
            <input name="kidcheck" type="checkbox" value="<%=itemCheck.CODE %>" checked="checked" /><%=itemCheck.SMALLTITLE %>
            <%
                } %>
        </h2>
    </div>
    
        <table class="am-table cart cart-checkout" name="order-list" style="margin-bottom: 7px;">
            <tbody>
                <% foreach (Model.BestCherryInfo item in dt)
                   {  
                %>
                <tr id='<%=item.CODE %>' style="color: #dd514c; font-size: 1.2rem; font-weight: bold">
                    <td>
                        <img src="<%=item.IMAGEPATH %>" width="60" height="60"></td>
                    <td style="font-size: 1.4rem; width: 25%"><%=item.TITLE %></td>
                    <td style="font-size: 1.2rem; width: 5%">
                        <% if (type == "1")
                           { 
                        %>
                            ￥<%=item.MEMBERPRICE %>
                        <%}
                           else
                           {%>
                            ￥<%=item.PRICE %>
                        <%} %>
                    </td>
                    <td>
                                <% if (type == "1")
                               { 
                            %>
                            <div name="buynum">1</div>
                            <%}
                               else
                               {%>
                        <div class="select" style="border: 1px #c5c8cf solid; display: inline-block; float: right">

                            <div class="sign" id="min">-</div>
                            <% if (type == "1")
                               { 
                            %>
                            <div class="buynum" name="buynum">1</div>
                            <%}
                               else
                               {%>
                            <div class="buynum" name="buynum">0</div>
                            <%} %>
                            <div class="sign" id="add">+</div>
                        </div>

                            <%} %>
                        <% if (type == "1")
                           { 
                        %>
                        <input name="oneprice" type="hidden" value="<%=item.MEMBERPRICE %>" />
                        <%}
                           else
                           {%>
                        <input name="oneprice" type="hidden" value="<%=item.PRICE %>" />
                        <%} %>
                    </td>
                </tr>
                <% } %>
            </tbody>
        </table>
        <% if (type != "1")
           { 
        %>
        <table class="am-table" style="margin-bottom: 0;">
            <tr style="color: #dd514c; font-size: 1.4rem; font-weight: bold">
                <td>配送费<span class="am-icon-gift am-icon-sm"></span>（满88即可包邮）</td>
                <td>
                    <div style="float: right">
                        ￥<span id="yunfei">10</span>
                    </div>
                </td>
            </tr>
        </table>
        <%} %>
        <div class="am-g address-form">
            <div class="am-u-md-8 am-u-sm-centered">
                <form class="am-form">
                    <fieldset class="am-form-set">
                        <div class="am-form-group">
                            <input type="text" name="consignee" placeholder="姓名(必填)">
                        </div>
                        <%--<input type="text" name="membernum" placeholder="集团优惠码(选填)" maxlength="6">--%>
                        <%-- <input type="text" name="membernum" placeholder="员工号(选填)" maxlength="6">--%>
                        <div class="am-form-group">
                            <input type="tel" name="mobile" placeholder="电话(必填)" maxlength="11">
                        </div>
                        <div class="am-form-group">
                            <span class="district_selector" id="span_area">
                                <select name="__district_id" style="display: none;">
                                    <option value="310000">上海</option>
                                </select>
                                <select name="_district_id" style="display: none;">
                                    <option value="310200">上海市</option>
                                </select>
                                <select name="district_id">
                                    <option value="11010101">闸北区</option>
                                    <option value="11010102">黄浦区</option>
                                    <option value="11010103">卢湾区</option>
                                    <option value="11010104">徐汇区</option>
                                    <option value="11010105">长宁区</option>
                                    <option value="11010106">静安区</option>
                                    <option value="11010107">普陀区</option>
                                    <option value="11010108">虹口区</option>
                                    <option value="11010109">杨浦区</option>
                                    <option value="11010110">闵行区</option>
                                    <option value="11010111">宝山区</option>
                                    <option value="11010112">嘉定区</option>
                                    <option value="11010113">浦东新区</option>
                                    <option value="11010114">金山区</option>
                                    <option value="11010115">松江区</option>
                                    <option value="11010116">青浦区</option>
                                    <option value="11010117">奉贤区</option>
                                    <option value="11010118">崇明县</option>
                                </select>
                            </span>
                        </div>
                        <div class="am-form-group">
                            <input type="text" name="address" placeholder="街道地址(必填)">
                        </div>
                        <div class="am-form-group">
                            <input type="text" name="remark" placeholder="送货备注(选填)">
                        </div>
                    </fieldset>
                </form>
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
                <li>
                    <a href="#">
                        <span class="am-icon-yen"></span>
                        <span class="am-navbar-label price"></span>
                    </a>
                </li>
                <li>
                    <a href="#" id="submitOrder">
                        <form action="pay.aspx" method="POST" class="order-submit" id="form">
                            <input type="hidden" name="consignee">
                            <input type="hidden" name="membernum">
                            <input type="hidden" name="mobile">
                            <input type="hidden" name="receiver_state">
                            <input type="hidden" name="receiver_city">
                            <input type="hidden" name="receiver_district">
                            <input type="hidden" name="address">
                            <input type="hidden" name="orderbuy">
                            <input type="hidden" name="bank">
                            <input type="hidden" name="remark">
                            <input type="hidden" name="type" value="<%=type %>">
                            <input type="hidden" name="typeactivityid" value="<%=BLL.Common.Encode(type+","+activityid)%>">
                            <input type="hidden" name="activityid" value="<%=activityid%>">
                            <input type="hidden" name="procode" value="<%=code%>">
                            <input type="hidden" name="searchmobile">
                            <span class="am-navbar-label" id="orderSendTxt"><span class="am-icon-credit-card"></span>支付订单</span>
                        </form>
                    </a>
                </li>
            </ul>
        </div>
        <script src="../Assets/js/buy.js"></script>
</asp:Content>
