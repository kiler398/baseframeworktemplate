<%@ Page Title="" Language="C#" MasterPageFile="~/Admin/Admin.Master" AutoEventWireup="true"
    CodeBehind="AlbumAdd.aspx.cs" Inherits="PhotoWeb.Admin.AlbumAdd" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <table border="0" width="100%">
        <tr>
            <td>
                相册添加
            </td>
        </tr>
        <tr>
            <td>
                <a href="AlbumManage.aspx">返回</a>
            </td>
        </tr>
        <tr>
            <td>
                <table border="1" width="100%">
                    <tr>
                        <td width="20%">
                            相册名：
                        </td>
                        <td>
                            <asp:TextBox ID="txtName" runat="server" Width="58%"></asp:TextBox><asp:RequiredFieldValidator ID="rfvtxtName" runat="server" 
                                ErrorMessage="相册名不能为空" ControlToValidate="txtName" Display="Dynamic"></asp:RequiredFieldValidator>
                            *</td>
                    </tr>
                    <tr>
                        <td width="20%">
                            描述：
                        </td>
                        <td>
                            <asp:TextBox ID="txtDescription" runat="server" Height="152px" TextMode="MultiLine" 
                                Width="80%"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td width="20%">
                            是否显示：
                        </td>
                        <td>
                            <asp:CheckBox ID="chkIsShow" runat="server" />
                        </td>
                    </tr>
                                        <tr>
                        <td colspan=2>

                            <asp:Button ID="btnSave" runat="server" onclick="btnSave_Click" Text="保存" />
                            <asp:Label ID="lblMessage" runat="server" EnableViewState="False"></asp:Label>

                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
