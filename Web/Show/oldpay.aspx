<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="oldpay.aspx.cs" Inherits="Web.Show.oldpay" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <title>正在跳转至工商银行支付地址</title>
</head>
<body>
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
</body>
</html>
