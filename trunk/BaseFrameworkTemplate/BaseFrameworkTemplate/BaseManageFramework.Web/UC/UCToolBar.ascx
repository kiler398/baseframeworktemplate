<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCToolBar.ascx.cs" Inherits="BaseManageFramework.Web.UC.UCToolBar" %>
<asp:Repeater ID="rptToolBar" runat="server" 
    onitemcommand="rptToolBar_ItemCommand" 
    onitemdatabound="rptToolBar_ItemDataBound">
    <HeaderTemplate>
        <table>
            <tr>
    </HeaderTemplate>
    <ItemTemplate>
        <td id="tdItem" runat=server style="CURSOR:hand">
            <table border="0">
                <tr>
                    <td>
                        <asp:ImageButton ID="btnOperationItem" runat="server" ImageUrl='<%# Eval("ImageUrl") %>' CommandName='<%# Eval("CommandName") %>' />
                    </td>
                    <td>
                        &nbsp;<asp:Label ID="lblCommandText" runat="server" Text='<%# Eval("Text") %>'></asp:Label>
                    </td>
                </tr>
            </table>
        </td>
    </ItemTemplate>
    <SeparatorTemplate>
        <td style="width: 5px">
        </td>
    </SeparatorTemplate>
    <FooterTemplate>
        </tr></table>
    </FooterTemplate>
</asp:Repeater>
