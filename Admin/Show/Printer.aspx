<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="Printer.aspx.cs" Inherits="Admin.Show.Printer" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <script src="../Assets/js/LodopFuncs.js"></script>
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">已付款订单</strong> / <small>打印订单Table</small></div>
    </div>
    <form id="form" class="am-form" runat="server">
        <div class="am-g">
            <div class="am-u-sm-12 am-u-md-3">
                <div class="am-form-group">
                    <asp:DropDownList ID="typeList" runat="server" AutoPostBack="true" data-am-selected="{btnSize: 'sm',maxHeight: 100}" OnSelectedIndexChanged="Type_click"></asp:DropDownList>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-3">
                <div class="am-form-group">
                    <asp:DropDownList ID="activityList" runat="server" data-am-selected="{btnSize: 'sm'}"></asp:DropDownList>
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-3">
                <div class="am-input-group am-input-group-sm">
<%--                    <a href="javascript:myPrintSetup()">打印维护</a>
                    <a href="javascript:Preview2()">打印预览</a>--%>
                    已打印<asp:CheckBox runat="server" ID="check" OnCheckedChanged="Search_click" />
                </div>
            </div>
            <div class="am-u-sm-12 am-u-md-3">
                <div class="am-input-group am-input-group-sm">
                    <input type="text" class="am-form-field" id="namelike" runat="server">
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
                                    <th class="table-remark">送货备注</th>
                                    <th class="table-isprinted">是否已打印</th>
                                    <th class="table-logistics">单号</th>
                                    <th class="table-nong">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr id="<%#Eval("ID") %>">
                            <td><%#Eval("consignee") %></td>
                            <td><%#Eval("mobile") %></td>
                            <td><%#Eval("RECEIVER_STATE") %><%#Eval("RECEIVER_CITY") %><%#Eval("RECEIVER_DISTRICT") %><%#Eval("ADDRESS") %></td>
                            <td><%#BLL.Common.GetAllTitle(Eval("orderlist").ToString()) %></td>
                            <td><%#Eval("paydate") %></td>
                            <td><%#Eval("amount") %></td>
                            <td><%#Eval("remark") %></td>
                            <td><%#Eval("isprinted")=="True"?"是":"否" %></td>
                            <td><%#Eval("logistics") %></td>
                            <td>
                                <div class="am-btn-toolbar">
                                    <div class="am-btn-group am-btn-group-xs">
                                        <a href="javascript:myPrint('<%#Eval("ID") %>')">打印物流单</a>
                                    </div>
                                </div>
                            </td>
                        </tr>
                    </ItemTemplate>
                    <FooterTemplate>
                        </tbody>
                                            </table>
                    </FooterTemplate>
                </asp:Repeater>
            </div>
        </div>
        <div class="am-modal am-modal-prompt" tabindex="-1" id="my-prompt">
            <div class="am-modal-dialog">
                <div class="am-modal-hd">
                    当前打印:<lable id="name"></lable>
                    <input type="hidden" id="currentID"/>
                </div>
                <div class="am-modal-bd">
                    请输入物流单号
                    <input type="text" class="am-modal-prompt-input" id="logisticsno">
                </div>
                <div class="am-modal-footer">
                    <span class="am-modal-btn" data-am-modal-cancel>取消</span>
                    <span class="am-modal-btn" data-am-modal-confirm>打印</span>
                </div>
            </div>
        </div>
    </form>
    <script language="javascript" type="text/javascript">
        var LODOP; //声明为全局变量
        var INDEX = "";
        var ISFIRST = true;
        function myPrintSetup() {
            CreatePage();
            LODOP.PRINT_DESIGN();
        };
        function Preview2() {
            CreatePage();
            LODOP.PREVIEW();
        };
        function myPrint(value) {
            $("#currentID").val(value);
            var name = $("#" + value).find("td").eq(0).text();
            var address = $("#" + value).find("td").eq(2).text();
            var title = $("#" + value).find("td").eq(3).text();
            var mobile = $("#" + value).find("td").eq(1).text();
            $("#name").text(name);
            LODOP = getLodop();
            if (INDEX == "") {
                INDEX = LODOP.SELECT_PRINTER();//选择打印机
                LODOP.SET_PRINTER_INDEX(INDEX);
            }
            LODOP.SET_PRINT_MODE("TRYLINKPRINTER_NOALERT", true);//这个语句设置网络共享打印机连接不通时是否提示一下
            LODOP.PRINT_INIT("黑猫宅急送");
            LODOP.ADD_PRINT_TEXT(264, 168, 75, 20, "牡丹惠");
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(91, 543, 194, 20, Date());
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(291, 163, 223, 50, "上海广中西路777弄99号402");
            LODOP.ADD_PRINT_TEXT(66, 162, 75, 20, name);
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(166, 402, 208, 20, title);
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(99, 161, 216, 75, address);
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(336, 449, 59, 24, "220211");
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(92, 408, 105, 20, Date());
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(344, 165, 100, 20, "021-36696682");
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(185, 175, 75, 20, mobile);
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            LODOP.ADD_PRINT_TEXT(363, 467, 100, 20, "220211915200");
            LODOP.SET_PRINT_STYLE("FontSize", 15);
            if (!ISFIRST) {
                $('#my-prompt').modal('open');
            } else {
                $('#my-prompt').modal({
                    closeOnConfirm: false,
                    closeViaDimmer: false,
                    onConfirm: function (e) {
                        if (LODOP.SET_PRINTER_INDEX(INDEX)) {
                            LODOP.PRINT();
                            $.ajax({
                                url: "../Services/AddLogistics.ashx",
                                data: {
                                    ID: $("#currentID").val(),
                                    Logistics: $("#logisticsno").val()
                                },
                                asnyc: true
                            });
                            var tr = $("#" + $("#currentID").val()).next("tr");
                            if (tr != "undefined") {
                                if ($(tr).find("td").eq(7).text() == "否") {
                                    myPrint($(tr).attr("id"));
                                }
                            }
                        }
                    }
                });
                ISFIRST = false;
            }
        }
        function CreatePage() {
            LODOP = getLodop();
            LODOP.PRINT_INIT("黑猫宅急送");
            LODOP.ADD_PRINT_SETUP_BKIMG("<img border='0' src='../Images/printer.jpg'>");
            LODOP.ADD_PRINT_TEXT(264, 168, 75, 20, "寄件人姓名");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(91, 543, 194, 20, "预定收件日");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(291, 163, 223, 50, "寄件人的详细地址");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(70, 167, 75, 20, "收件人姓名");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(166, 402, 208, 20, "商品名称");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(99, 161, 216, 75, "收件人详细地址");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(336, 449, 59, 24, "寄发店代码");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(92, 408, 105, 20, "寄件办理日");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(344, 165, 100, 20, "寄件人电话");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(185, 175, 75, 20, "收件人电话");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
            LODOP.ADD_PRINT_TEXT(363, 467, 100, 20, "顾客代码");
            LODOP.SET_PRINT_STYLE(0, "FontSize", 15);
        };
    </script>
</asp:Content>
