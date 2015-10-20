<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="ConnectPro.aspx.cs" Inherits="Admin.Show.ConnectPro" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg"><span id="name" runat="server"></span></strong>/ <small>关联商品列表</small></div>
    </div>
    <form id="form" class="am-form" runat="server">
        <input type="hidden" class="am-input-sm" id="activityID" runat="server">
        <input type="hidden" class="am-input-sm" id="type" runat="server">
        <div class="am-modal am-modal-confirm" tabindex="-1" id="doc-modal-1">
            <div class="am-modal-dialog">
                <div class="am-modal-hd">
                    选择商品
                    <a href="javascript: void(0)" class="am-close am-close-spin" data-am-modal-close>&times;</a>
                </div>
                <div class="am-modal-bd">
                    <asp:DropDownList ID="productlist" runat="server" data-am-selected="{btnWidth: '100%', btnSize: 'sm',searchBox: 1}"></asp:DropDownList>
                    <%if (type.Value == "1") {%>
                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-4 am-u-md-3 am-text-right">
                            限购时间
                        </div>
                        <div class="am-u-sm-8 am-u-md-4">
                            <input type="text" class="am-input-sm" id="buytime">
                        </div>
                        <div class="am-hide-sm-only am-u-md-5">*格式为yyyyMMddHHmmss</div>
                    </div>

                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-4 am-u-md-3 am-text-right">
                            限购数量
           
                        </div>
                        <div class="am-u-sm-8 am-u-md-4">
                            <input type="text" class="am-input-sm" id="num">
                        </div>
                        <div class="am-hide-sm-only am-u-md-5">*必填</div>
                    </div>
                          <% }%>
                     <div class="am-g am-margin-top">
                        <div class="am-u-sm-4 am-u-md-3 am-text-right">
                            宣传图地址
           
                        </div>
                        <div class="am-u-sm-8 am-u-md-4">
                            <input type="text" class="am-input-sm" id="imagepath">
                        </div>
                        <div class="am-hide-sm-only am-u-md-5">*</div>
                    </div>
                    <div class="am-g am-margin-top">
                        <div class="am-u-sm-4 am-u-md-3 am-text-right">
                            介绍图地址
           
                        </div>
                        <div class="am-u-sm-8 am-u-md-4">
                            <input type="text" class="am-input-sm" id="desimgpath">
                        </div>
                        <div class="am-hide-sm-only am-u-md-5">*</div>
                    </div>
                </div>
                <div class="am-modal-footer">
                    <span class="am-modal-btn" data-am-modal-cancel>取消</span>
                    <span class="am-modal-btn" data-am-modal-confirm>确定</span>
                </div>
            </div>
        </div>
        <div class="am-g">
            <div class="am-u-sm-12 am-u-md-6">
                <div class="am-btn-toolbar">
                    <div class="am-btn-group am-btn-group-xs">
                        <a href="#" id="add" class="am-btn am-btn-default"><span class="am-icon-plus"></span>新增</a>
                        <%-- <button type="button" class="am-btn am-btn-default" id="doc-confirm-toggle"><span class="am-icon-plus-o"></span>新增</button>--%>
                    </div>
                </div>
            </div>
            <%--<div class="am-u-sm-12 am-u-md-6">
            <div class="am-form-group">
                <select data-am-selected="{btnSize: 'sm'}" runat="server" id="select">
                    <option value="0">所有类别</option>
                    <option value="1">限时购</option>
                    <option value="2">正常</option>
                    <option value="3">投票</option>
                    <option value="4">闲置</option>
                </select>
            </div>
        </div>--%>
        </div>

        <div class="am-g">
            <div class="am-u-sm-12">
                <asp:Repeater ID="rptList" runat="server" OnItemCommand="rptList_ItemCommand">
                    <HeaderTemplate>
                        <table class="am-table am-table-striped am-table-hover table-main">
                            <thead>
                                <tr>
                                    <%--<th class="table-check">
                                <input type="checkbox" /></th>--%>
                                    <th class="table-title">商品名称</th>
                                    <th class="table-code">商品代码</th>
                                             <%if (type.Value == "1") {%>
                                    <th class="table-buytime">限购时间</th>
                                    <th class="table-num">限购数量</th>
                                    <%} %>
                                    <th class="table-imagepath">宣传图地址</th>
                                    <th class="table-imagepath">介绍图地址</th>
                                    <th class="table-nong">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("title") %></td>
                            <td><%#Eval("code") %></td>
                              <%if (type.Value == "1") {%>
                            <td><%#Eval("buytime") %></td>
                            <td><%#Eval("num") %></td>
                            <%} %>
                            <td><%#Eval("imagepath") %></td>
                            <td><%#Eval("desimgpath") %></td>
                            <td>
                                <div class="am-btn-toolbar">
                                    <div class="am-btn-group am-btn-group-xs">
                                            <asp:LinkButton runat="server" ID="lblEdit" CommandArgument='<%#Eval("ID") %>' CommandName="Edit" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary" Text="<span class='am-icon-pencil-square-o'></span>编辑"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lblDel" CommandArgument='<%#Eval("ID") %>' CommandName="Delete" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary" Text="<span class='am-icon-pencil-square-o'></span>删除"></asp:LinkButton>
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
        $('#add').on('click', function () {
            $('#doc-modal-1').modal({
                relatedTarget: this,
                onConfirm: function () {
                    $.ajax({
                        url: "../Services/AddPro.ashx",
                        data: {
                            activityID: "<%=activityID.Value%>",
                            code: $("#<%=productlist.ClientID %> option:selected").val(),
                            buytime: $("#buytime").val(),
                            num: $("#num").val(),
                            imagepath: $("#imagepath").val(),
                            desimgpath:$("#desimgpath").val()
                        },
                        asnyc: false,
                        success: function (data) {
                            window.location.reload();
                        }
                    });
                }
            });
        });
    </script>
</asp:Content>
