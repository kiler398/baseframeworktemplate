﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMenuHead.ascx.cs" Inherits="BaseManageFramework.Web.UC.UCMenuHead" %>
<table border='0' cellpadding='0' cellspacing='0' width='100%' align='center'>
    <tr>
        <td class='menubar_title'>
            <asp:Image ID="imgHead" runat="server" BorderWidth="0" ImageUrl="~/images/BaseFramework/ICON/default.gif"
                ImageAlign="AbsMiddle" hspace='3' vspace='3' />&nbsp;<asp:Label ID="lblMoudleName" runat="server"
                    Text=""></asp:Label></td>
        <td class='menubar_readme_text' valign='bottom'>
            <asp:Image ID="imgHelp" BorderWidth="0" ImageAlign="AbsMiddle" ImageUrl="~/images/BaseFramework/ICON/office.gif"
                runat="server" />&nbsp;帮助？</td>
    </tr>
    <tr>
        <td class='menubar_function_text' colspan=2>
            目前操作功能：<asp:Label ID="lblOperationName" runat="server" Text=""></asp:Label></td>
    </tr>
</table>