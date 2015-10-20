<%@ Page Title="" Language="C#" MasterPageFile="~/Master/Admin.Master" AutoEventWireup="true" CodeBehind="TimeBuy.aspx.cs" Inherits="Admin.Show.TimeBuy" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="am-cf am-padding">
        <div class="am-fl am-cf"><strong class="am-text-primary am-text-lg">限时购</strong> / <small>Table</small></div>
    </div>
    <form id="form" class="am-form" runat="server">
        <div class="am-g">
             <div class="am-u-sm-12 am-u-md-6">
            <div class="am-btn-toolbar">
                <div class="am-btn-group am-btn-group-xs">
                    <a href="TimeAdd.aspx" class="am-btn am-btn-default"><span class="am-icon-plus"></span>新增</a>
                   <%-- <button type="button" class="am-btn am-btn-default"><span class="am-icon-trash-o"></span>删除</button>--%>
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
            <div class="am-u-sm-12 am-u-md-3">
                <div class="am-input-group am-input-group-sm">
                    <input type="text" class="am-form-field" id="namelike" runat="server">
                    <span class="am-input-group-btn">
                        <asp:Button ID="btnSave" OnClick="Search_click" CssClass="am-btn am-btn-default" runat="server" Text="搜索" />
                    </span>
                </div>
            </div>
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
                                    <th class="table-name">活动名称</th>
                                 <%--   <th class="table-buytime">限购时间</th>
                                    <th class="table-num">限购数量</th>--%>
                                    <th class="table-code">活动代码</th>
                                    <th class="table-nong">操作</th>
                                </tr>
                            </thead>
                            <tbody>
                    </HeaderTemplate>
                    <ItemTemplate>
                        <tr>
                            <td><%#Eval("name") %></td>
                     <%--       <td><%#Eval("buytime") %></td>
                            <td><%#Eval("num") %></td>--%>
                            <td><%#Eval("code") %></td>
                            <td>
                                <div class="am-btn-toolbar">
                                    <div class="am-btn-group am-btn-group-xs">
                                        <asp:LinkButton runat="server" ID="lblEdit" CommandArgument='<%#Eval("CODE") %>' CommandName="Edit" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary" Text="<span class='am-icon-pencil-square-o'></span>编辑"></asp:LinkButton>
                                               <asp:LinkButton runat="server" ID="lblDel" CommandArgument='<%#Eval("ID") %>' CommandName="Delete" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary" Text="<span class='am-icon-pencil-square-o'></span>删除" Visible="false"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lblConnect" CommandArgument='<%#Eval("CODE") %>' CommandName="Connect" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary" Text="<span class='am-icon-pencil-square-o'></span>关联商品"></asp:LinkButton>
                                        <asp:LinkButton runat="server" ID="lblReset" CommandArgument='<%#Eval("ID") %>' CommandName="Reset" CssClass="am-btn am-btn-default am-btn-xs am-text-secondary" Text="<span class='am-icon-pencil-square-o'></span>重置" OnClientClick="return confirm('是否确定重置?')"></asp:LinkButton>
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
</asp:Content>