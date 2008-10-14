<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCMessage.ascx.cs" Inherits="BaseManageFramework.Web.UC.UCMessage" %>
<div style="position: fixed; height: 100%; width: 100%; top: 0px; left: 0px; background-color: #000000;
    filter: alpha(opacity=55); -moz-opacity: .55; opacity: .55; z-index: 50; display:none;" id="pagedimmer" runat="server">
    &nbsp;</div>
<div style="position: fixed; background-color: #888888; border: 1px solid #999999;
    z-index: 50; left: 31%; right: 31%; top: 20%;display:none;" id="msgbox" runat=server>
    <div style="margin: 0px; margin-left:0px; margin-right:0px;">
<table id="tbPopMessage" runat="server" border="0" cellpadding="0"
    cellspacing="0" align="center">
    <tr>
        <td align="center" valign="top">
            <table width="200" border="0" cellpadding="0" cellspacing="0">
                <tr>
                    <td runat="server" id="tdHead" height="48" valign="middle" background="/images/BaseFramework/MessageIcon/MessageHead.gif">
                        <table width="100%" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="7%" height="8">
                                </td>
                                <td width="93%" align="left">
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">
                                    <span class="MessageTitle" id="lblMessageTitle" runat="server"></span>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td runat="server" id="tdBody" background="/images/BaseFramework/MessageIcon/MessageBody.gif">
                        <table width="100%" style="table-layout: fixed;" border="0" cellspacing="0" cellpadding="0">
                            <tr>
                                <td width="6%">
                                    &nbsp;
                                </td>
                                <td width="11%" height="120">
                                    <img id="imgMessageIcon" runat="server">
                                </td>
                                <td width="77%" align="left">
                                    <table width="100%" border="0" cellspacing="10" cellpadding="0">
                                        <tr>
                                            <td style="word-break: break-all;" id="tdMessageBody" runat="server">
                                            </td>
                                        </tr>
                                    </table>
                                </td>
                                <td width="6%">
                                    &nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    &nbsp;
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td align="left">&nbsp;
                                    &nbsp;<asp:Button ID="btnOk" runat="server" Text="确定" CausesValidation=false OnClick="btnOk_OnClick" />
                                    &nbsp;<asp:Button ID="btnYes" runat="server" Text="是" CausesValidation=false />
                                    &nbsp;<asp:Button ID="btnNo" runat="server" Text="否" CausesValidation=false />
                                    &nbsp;<asp:Button ID="btnAbort" runat="server" Text="退出" CausesValidation=false />
                                    &nbsp;<asp:Button ID="btnRetry" runat="server" Text="重试" CausesValidation=false />
                                    &nbsp;<asp:Button ID="btnCancel" runat="server" Text="取消" CausesValidation=false />
                                    &nbsp;<asp:Button ID="btnIgnore" runat="server" Text="忽略" CausesValidation=false />
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <img id="imgEnd" runat="server" src="/images/BaseFramework/MessageIcon/MessageEnd.gif"/>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>
    </div>
</div>