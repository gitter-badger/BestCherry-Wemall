<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="CreateActivity.aspx.cs" Inherits="Admin.Show.CreateActivity" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">生成二维码</strong> / <small>未来更多功能</small></div>
    </div>
    <div class="am-g am-margin-top">
        <div class="am-u-sm-12 am-u-md-6">
            <input type="text" class="am-form-field" id="doc-qr-text">
        </div>
        <div class="am-u-sm-12 am-u-md-12">
            <button class="am-btn am-btn-default" type="button" id="Button1">生成</button>
        </div>
    </div>
    <div id="doc-qrcode" class="am-text-center"></div>

    <script>
        $(function () {
            var $input = $('#doc-qr-text');
            $qr = $('#doc-qrcode');
            function makeCode(text) {
                $qr.empty().qrcode(text);
            }
            $input.val(location.href);
            makeCode(location.href);
            $('#doc-gen-qr').on('click', function () {
                makeCode($input.val());
            });
            $input.on('focusout', function () {
                makeCode($input.val());
            });
        });
    </script>
</asp:Content>
