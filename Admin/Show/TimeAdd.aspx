<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="TimeAdd.aspx.cs" Inherits="Admin.Show.TimeAdd" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">限时购</strong> / <small>新增活动</small></div>
    </div>
    <form id="form" class="am-form" runat="server">
        <div class="am-g am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">
                活动名称
           
            </div>
            <div class="am-u-sm-8 am-u-md-4">
                <input type="text" class="am-input-sm" id="name" runat="server">
            </div>
            <div class="am-hide-sm-only am-u-md-6"></div>
        </div>
        <div class="am-g am-margin-top">
            <div class="am-u-sm-4 am-u-md-2 am-text-right">
                活动代码
           
            </div>
            <div class="am-u-sm-8 am-u-md-4">
                <input type="text" class="am-input-sm" id="code" runat="server">
            </div>
            <div class="am-u-sm-12 am-u-md-6"></div>
        </div>
        <div class="am-margin">
            <asp:Button ID="btnSave" OnClick="Save_click" CssClass="am-btn am-btn-primary am-btn-xs" runat="server" Text="提交保存" />
        </div>
    </form>
</asp:Content>