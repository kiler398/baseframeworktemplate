<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage/PageTemplate.Master"
    AutoEventWireup="true" CodeBehind="AddPage.aspx.cs" Inherits="BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage.AddPage" Theme="Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="PageBody" runat="server">
    <asp:ScriptManagerProxy ID="ScriptManagerProxy1" runat="server">
    </asp:ScriptManagerProxy>
    <table width="100%" border="0" cellpadding="1" cellspacing="3">
        <tr>
            <td>
                <UcMenuHead:UCMenuHead ID="UCMenuHead1" runat="server" MoudleName="系统应用管理" OperationName="添加系统应用">
                </UcMenuHead:UCMenuHead>
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Button ID="btnSave" runat="server" CssClass="AdminButton" Text="保存" OnClick="btnSave_Click"
                    ValidationGroup="vgSystemApplication" />
                &nbsp;&nbsp;<asp:Button ID="btnReturn" CssClass="AdminButton" runat="server" CausesValidation="False"
                    Text="返回列表" OnClick="btnReturn_Click" />
            </td>
        </tr>
        <tr>
            <td align="right">
                <asp:Label ID="lblMessage" runat="server" EnableViewState="False" ForeColor="Red"></asp:Label>&nbsp;
            </td>
        </tr>
        <tr>
            <td>
                <table width="100%" cellpadding="1" cellspacing="3" border="0">
                    <tr align="center" valign="middle">
                        <td colspan="4" class="table_body">
                            系统应用
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;" class="table_body" align="left">
                            应用程序名称:
                        </td>
                        <td class="table_none" colspan="3" tyle="width:85%;">
                            <asp:TextBox ID="txtSystemApplicationName" ToolTip="输入应用程序名称" MaxLength='200' runat="server"
                                ValidationGroup="vgSystemApplication"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtSystemApplicationName" runat="server"
                                ControlToValidate="txtSystemApplicationName" Display="None" ErrorMessage="【应用程序名称】项不能为空！"
                                SetFocusOnError="True" ValidationGroup="vgSystemApplication"></asp:RequiredFieldValidator>
                            <AspAjax:ValidatorCalloutExtender ID="rfvtxtSystemApplicationName_ValidatorCalloutExtender" runat="server"
                                TargetControlID="rfvtxtSystemApplicationName">
                            </AspAjax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;" class="table_body" align="left">
                            应用程序描述:
                        </td>
                        <td class="table_none" colspan="3" tyle="width:85%;">
                            <asp:TextBox ID="txtSystemApplicationDescription" ToolTip="输入应用程序描述" MaxLength='2000'
                                runat="server" ValidationGroup="vgSystemApplication"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtSystemApplicationDescription" runat="server"
                                ControlToValidate="txtSystemApplicationDescription" Display="None" ErrorMessage="【应用程序描述】项不能为空！"
                                SetFocusOnError="True" ValidationGroup="vgSystemApplication"></asp:RequiredFieldValidator>
                            <AspAjax:ValidatorCalloutExtender ID="vcerfvtxtSystemApplicationDescription" runat="server"
                                TargetControlID="rfvtxtSystemApplicationDescription">
                            </AspAjax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;" class="table_body" align="left">
                            应用程序链接:
                        </td>
                        <td class="table_none" colspan="3" tyle="width:85%;">
                            <asp:TextBox ID="txtSystemApplicationUrl" ToolTip="输入应用程序链接" MaxLength='200' runat="server"
                                ValidationGroup="vgSystemApplication"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvtxtSystemApplicationUrl" runat="server" ControlToValidate="txtSystemApplicationUrl"
                                Display="None" ErrorMessage="【应用程序链接】项不能为空！" SetFocusOnError="True" ValidationGroup="vgSystemApplication"></asp:RequiredFieldValidator>
                            <AspAjax:ValidatorCalloutExtender ID="vcerfvtxtSystemApplicationUrl" runat="server"
                                TargetControlID="rfvtxtSystemApplicationUrl">
                            </AspAjax:ValidatorCalloutExtender>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 15%;" class="table_body" align="left">
                            是否为系统应用:
                        </td>
                        <td class="table_none" colspan="3" tyle="width:85%;">
                            <asp:CheckBox ID="chkSystemApplicationIsSystemApplication" runat="server" ToolTip="SystemApplicationIsSystemApplication"
                                ValidationGroup="vgSystemApplication" />
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
