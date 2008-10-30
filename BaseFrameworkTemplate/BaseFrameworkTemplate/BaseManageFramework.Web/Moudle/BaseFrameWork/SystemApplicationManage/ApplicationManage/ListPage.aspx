<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage.ListPage"
    Theme="Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="系统应用列表管理" OperationName="列表系统应用">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" 
                    ForeColor="Red"></asp:Label>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnAdd" runat="server" Text="添加" CommandName="cmdAdd" OnClick="btnClick" />&nbsp;
                                                        <asp:Button ID="btnDelete" runat="server" CommandName="cmdDelete" Text="删除" OnClick="btnClick" />
            </td>
        </tr>
        <tr>
            <td>
                <AspAjax:TabContainer ID="tabList" runat="server" ActiveTabIndex="0">
                    <AspAjax:TabPanel ID="TabPanelMain" runat="server">
                        <HeaderTemplate>
                            列表系统应用
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table border="0" width="100%">
                                <tr>
                                    <td>
                                        <asp:GridView ID="grdSystemApplicationList" runat="server" 
                                            AutoGenerateColumns="False" DataKeyNames="SystemApplicationID" 
                                            onrowcommand="grdSystemApplicationList_RowCommand">
                                            <Columns>
                                                <asp:TemplateField HeaderText="选择">
                                                    <HeaderTemplate>
                                                        <input id="chkSelectAll" runat="server" type="checkbox" />&nbsp;&nbsp;全选
                                                    </HeaderTemplate>
                                                    <ItemTemplate>
                                                        <input id="chkSelect" runat="server" type="checkbox" disabled='<%# Eval("SystemApplicationIsSystemApplication") %>' />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:BoundField HeaderText="应用程序名称" DataField="SystemApplicationName" />
                                                <asp:BoundField HeaderText="应用程序描述" DataField="SystemApplicationDescription" />
                                                <asp:BoundField HeaderText="应用程序链接" DataField="SystemApplicationUrl" />
                                                <asp:TemplateField HeaderText="操作管理">
                                                    <ItemTemplate>
                                                        <asp:Button ID="btnView" runat="server" CommandName="cmdView" Text="查看" />&nbsp;
                                                        <asp:Button ID="btnEdit" runat="server" CommandName="cmdEdit" Text="编辑" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td>                <webdiyer:AspNetPager ID="Pager" runat="server" OnPageChanged="Pager_PageChanged">
                </webdiyer:AspNetPager></td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                    <AspAjax:TabPanel ID="TabPanelSearch" runat="server">
                        <HeaderTemplate>
                            搜索
                        </HeaderTemplate>
                        <ContentTemplate>
                            <table width="100%" border="0" cellspacing="1" cellpadding="3" align="center">
                                <tr align="center" valign="middle">
                                    <td colspan="4" class="table_body">
                                        检索
                                    </td>
                                </tr>
                                <tr>
                                    <td class="table_body" style="width: 15%">
                                        应用程序名：
                                    </td>
                                    <td class="table_none" style="width: 35%">
                                        <asp:TextBox ID="txtSearchSystemApplicationName" runat="server"></asp:TextBox>
                                    </td>
                                    <td class="table_none" style="width: 15%">
                                    </td>
                                    <td class="table_none" style="width: 35%">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="left" class="table_body">
                                        <asp:Button ID="btnQuery" runat="server" Text="查询" OnClick="btnQuery_Click" />
                                        <asp:Button ID="btnClearQuery" runat="server" Text="清除查询条件" OnClick="btnClearQuery_Click" />
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </AspAjax:TabPanel>
                </AspAjax:TabContainer>
            </td>
        </tr>
    </table>
</asp:Content>
