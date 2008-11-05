<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" CodeBehind="ListPage.aspx.cs" Inherits="BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage.ListPage"
    Theme="Default" EnableEventValidation="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
            <script type="text/javascript">
        
            function updated() {
                //  close the popup
                tb_remove();
                
                //  refresh the update panel so we can view the changes
                $('#<%= this.btnUpdatePage.ClientID %>').click();      
            }
            
            function pageLoad(sender, args) {
                if(args.get_isPartialLoad()){
                    //  reapply the thick box stuff
                    tb_init('a.thickbox');
                }
            }
        
        </script>   
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
                <asp:Button ID="btnUpdatePage" runat="server" Text="刷新" 
                    onclick="btnUpdatePage_Click" />
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
                                            onrowcommand="grdSystemApplicationList_RowCommand" Width="100%">
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
                                                <asp:TemplateField HeaderText="操作管理" ItemStyle-HorizontalAlign=Center>
                                                    <ItemTemplate>
                                                    <a id="btnEdit" runat="server" class="thickbox" 
                                    title='<%# Eval("SystemApplicationName", "编辑 {0}") %>' 
                                    href='<%# Eval("SystemApplicationID", "EditPage.aspx?ID={0}&TB_iframe=true&height=330&width=600") %>'>编辑</a>&nbsp;&nbsp;&nbsp;&nbsp;<a id="btnView" runat="server" class="thickbox" 
                                    title='<%# Eval("SystemApplicationName", "查看 {0}") %>' 
                                    href='<%# Eval("SystemApplicationID", "ViewPage.aspx?ID={0}&TB_iframe=true&height=330&width=600") %>'>查看</a> 
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
                            <table width="100%" class="detailgrid" >
                                <tr align="center">
                                    <td colspan="4">
                                        检索
                                    </td>
                                </tr>
                                <tr>
                                    <td style="width: 15%">
                                        应用程序名：
                                    </td>
                                    <td style="width: 35%">
                                        <asp:TextBox ID="txtSearchSystemApplicationName" runat="server"></asp:TextBox>
                                    </td>
                                    <td style="width: 15%">
                                    </td>
                                    <td style="width: 35%">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="4" align="left">
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
