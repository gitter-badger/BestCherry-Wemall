<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="HavePay.aspx.cs" Inherits="Admin.Show.HavePay" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Assets/js/LodopFuncs.js"></script>
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">已付款订单</strong> / <small>Table</small></div>
    </div>
    <form id="form" class="am-form" runat="server" enctype="multipart/form-data">
        <div class="am-g">
            <div class="am-u-sm-12 am-u-md-2">
                <div class="am-form-group">
                    <asp:DropDownList ID="typeList" runat="server" AutoPostBack="true" data-am-selected="{btnSize: 'sm',maxHeight: 100}" OnSelectedIndexChanged="Type_click"></asp:DropDownList>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-2">
                <div class="am-form-group">
                    <asp:DropDownList ID="activityList" runat="server" data-am-selected="{btnSize: 'sm'}"></asp:DropDownList>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-1">
                <div class="am-input-group am-input-group-sm">
                    <span class="am-input-group-btn">
                        <asp:Button ID="btnExport" OnClick="Export_click" CssClass="am-btn am-btn-default" runat="server" Text="导出" />
                    </span>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-2">
                <div class="am-form-group am-form-file">
                    <button type="button" class="am-btn am-btn-danger am-btn-sm">
                        <i class="am-icon-cloud-upload"></i>选择包含物流信息的Excel文件</button>
                    <input id="doc-form-file" name="file" type="file" multiple>
                    <div id="file-list"></div>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-1">
                <div class="am-input-group am-input-group-sm">
                    <span class="am-input-group-btn">
                        <asp:Button  ID="btnImport" OnClick="Import_click" CssClass="am-btn am-btn-default" runat="server" Text="导入" />
                    </span>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-2">
                <div class="am-input-group am-input-group-sm">
                    <input type="text" class="am-form-field" placeholder="选择日期" id="time" runat="server" data-am-datepicker readonly />
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-2">
                <div class="am-input-group am-input-group-sm">
                    <input type="text" class="am-form-field" id="namelike" runat="server" placeholder="姓名(模糊查询)">
                    <span class="am-input-group-btn">
                        <asp:Button ID="btnSearch" OnClick="Search_click" CssClass="am-btn am-btn-default" runat="server" Text="搜索" />
                    </span>
                </div>
            </div>
        </div>
        <div class="am-g">
            <div class="am-u-sm-12">
                <asp:Repeater ID="rptList" runat="server">
                    <HeaderTemplate>
                        <table class="am-table am-table-striped am-table-hover table-main">
                            <thead>
                                <tr>
                                    <%--<th class="table-check">
                                <input type="checkbox" /></th>--%>
                                    <th class="table-consignee">收件人姓名</th>
                                    <th class="table-mobile">手机号</th>
                                    <th class="table-address">收件人地址</th>
                                    <th class="table-orderlist">订单内容</th>
                                    <th class="table-paydate">付款时间</th>
                                    <th class="table-amount">付款金额</th>
                                    <th class="table-sendordertime">提交订单时间</th>
                                    <th class="table-remark">送货备注</th>
                                    <th class="table-LOGISTICS">物流号</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("consignee") %></td>
                            <td><%#Eval("mobile") %></td>
                            <td><%#Eval("RECEIVER_STATE") %><%#Eval("RECEIVER_CITY") %><%#Eval("RECEIVER_DISTRICT") %><%#Eval("ADDRESS") %></td>
                            <td><%#BLL.Common.GetAllTitle(Eval("orderlist").ToString()) %></td>
                            <td><%#Eval("paydate") %></td>
                            <td><%#Eval("amount") %></td>
                            <td><%#Eval("sendordertime") %></td>
                            <td><%#Eval("remark") %></td>
                            <td><%#Eval("LOGISTICS") %></td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
                <%--   <div class="am-cf">
                    共 15 条记录
                    <div class="am-fr">
                        <ul class="am-pagination">
                            <li class="am-disabled"><a href="#">«</a></li>
                            <li class="am-active"><a href="#">1</a></li>
                            <li><a href="#">2</a></li>
                            <li><a href="#">3</a></li>
                            <li><a href="#">4</a></li>
                            <li><a href="#">5</a></li>
                            <li><a href="#">»</a></li>
                        </ul>
                    </div>
                </div>--%>
            </div>
        </div>
    </form>
    <script>
        $(function () {
            $('#doc-form-file').on('change', function () {
                var fileNames = '';
                $.each(this.files, function () {
                    fileNames += '<span class="am-badge">' + this.name + '</span> ';
                });
                $('#file-list').html(fileNames);
            });
        });
    </script>
</asp:Content>

