<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="nofound.aspx.cs" Inherits="Web.Show.nofound" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
  <meta charset="utf-8">
  <meta http-equiv="X-UA-Compatible" content="IE=edge">
  <title>错误提示</title>
  <meta name="description" content="nofound">
  <meta name="keywords" content="nofound">
  <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no">
  <meta name="renderer" content="webkit">
  <meta http-equiv="Cache-Control" content="no-siteapp" />
  <meta name="apple-mobile-web-app-title" content="" />
  <link rel="stylesheet" href="../Assets/css/amazeui.min.css"/>
  <link rel="stylesheet" href="../Assets/css/admin.css">
</head>
<body>
    <div class="am-cf am-padding">
      <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">这是错误提示页面</strong> / <small>ERROR</small></div>
    </div>

    <div class="am-g">
      <div class="am-u-sm-12">
        <p class="am-text-center"><%=msg %></p>
        <center><img src="../Assets/img/404.jpg" /></center>
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
                <a href="profile.aspx">
                    <span class="am-icon-user"></span>
                    <span class="am-navbar-label">个人中心</span>
                </a>
            </li>
        </ul>
    </div>
</body>
</html>
