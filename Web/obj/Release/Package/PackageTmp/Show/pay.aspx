<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="pay.aspx.cs" Inherits="Web.Show.pay" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>正在跳转至工商银行支付地址</title>
</head>
<body>
    <% if (bank == "ICBC")
       {
    %>
    <form method="post" action="<%= icmcModel.OrderPostUrl %>" id="order-pc">
        <div style="width: 500px; margin: auto auto; padding: 10px; line-height: 30px;">
            正在跳转至工商银行支付地址.....
        </div>
        <input type="hidden" name="interfaceName" value="<%= icmcModel.InterfaceName %>" />
        <input type="hidden" name="interfaceVersion" value="<%= icmcModel.InterfaceVersion %>" />
        <input type="hidden" name="tranData" value="<%= icmcModel.TranData %>" />
        <input type="hidden" name="merSignMsg" value="<%= icmcModel.MerSignMsg %>" />
        <input type="hidden" name="merCert" value="<%= icmcModel.MerCert %>" />
        <script type="text/javascript">        document.getElementById("order-pc").submit();</script>
    </form>
    <%
            }
       else if (bank == "MOBILEICBC")
       {
    %>
    <form method="post" action="<%= icmcMobileModel.OrderPostUrl %>" id="order-mobile">
        <div style="width: 500px; margin: auto auto; padding: 10px; line-height: 30px;">
            正在跳转至工商银行支付地址.....
        </div>
        <input type="hidden" name="interfaceName" value="<%= icmcMobileModel.InterfaceName %>" />
        <input type="hidden" name="interfaceVersion" value="<%= icmcMobileModel.InterfaceVersion %>" />
        <input type="hidden" name="tranData" value="<%= icmcMobileModel.TranData %>" />
        <input type="hidden" name="merSignMsg" value="<%= icmcMobileModel.MerSignMsg %>" />
        <input type="hidden" name="merCert" value="<%= icmcMobileModel.MerCert %>" />

        <input type="hidden" name="clientType" value="<%= icmcMobileModel.ClientType %>" />
        <script type="text/javascript">        document.getElementById("order-mobile").submit();</script>
    </form>
    <% } %>
</body>
</html>
