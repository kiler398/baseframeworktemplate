<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="BaseManageFramework.Web.MainPage.Login"
    meta:resourcekey="PageResource1" UICulture="auto" Theme="Default" %>
<%@ Register src="../UC/UCMessage.ascx" tagname="UCMessage" tagprefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>{$SystemName}--登录</title>
    <script type="text/javascript"> 
if (parent!=null && parent.location.href != self.location.href)   
        parent.location.href = 'Login.aspx'; 
    </script>
</head>
<body bgcolor="#FFFFFF">
    <form id="form1" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server">
    </asp:ScriptManager>
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
    <ContentTemplate>
     <table id="Table3" height="100%" cellspacing="0" cellpadding="0" width="100%" border="0">
        <tr>
            <td valign="middle" height="*" align="center">
                <table id="Table1" cellspacing="0" cellpadding="10" width="641" align="center" border="0"
                    bordercolor="#0066ff" height="438" class="login_table" style="background-image: url(../images/BaseFramework/Login/login_bg.jpg);
                    background-repeat: no-repeat;width: 641px;
                    height: 438px">
                    <tr>
                        <td colspan="2" align="right" height="45px" valign="bottom">
                            <asp:DropDownList ID="ddlLanguage" runat="server" AutoPostBack="True" 
                                meta:resourcekey="ddlLanguageResource1" 
                                onselectedindexchanged="ddlLanguage_SelectedIndexChanged">
                                <asp:ListItem Value="auto" meta:resourcekey="ListItemResource1">自动</asp:ListItem>
                                <asp:ListItem Selected="True" Value="zh-CN" meta:resourcekey="ListItemResource2">简体中文</asp:ListItem>
                                <asp:ListItem Value="zh-TW" meta:resourcekey="ListItemResource3">繁體中文</asp:ListItem>
                                <asp:ListItem Value="en-US" meta:resourcekey="ListItemResource4">English</asp:ListItem>
                            </asp:DropDownList>
                            &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 49%" valign="middle" align="right" class="TD_Class">
                            <asp:Image ID="imgSiteName" runat="server" BorderStyle="None" BorderWidth="0px" ImageUrl="~/images/BaseFramework/Login/sitename_login.jpg"
                                meta:resourcekey="imgSiteNameResource1" />
                            <br />
                            <asp:Label ID="lblSystemVersion" CssClass="login_system_version" runat="server" meta:resourcekey="lblSystemVersionResource1">高级版 v3.2.0.485</asp:Label>
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <br />
                            <asp:HyperLink ID="lnkLoginHelp" NavigateUrl="#" Target="_blank" runat="server" meta:resourcekey="lnkLoginHelpResource1">登录帮助</asp:HyperLink>
                            &nbsp;&nbsp;
                            <asp:HyperLink ID="lnkSupportUrl" runat="server" NavigateUrl="#" Target="_blank"
                                meta:resourcekey="lnkSupportUrlResource1">软件网站首页</asp:HyperLink>
                            <br />
                            <br />
                            <br />
                            <br />
                        </td>
                        <td width="51%" valign="middle" align="left">
                            <table id="Table2" cellspacing="0" cellpadding="1" border="0" class="" width="200px">
                                <tr>
                                    <td>
                                        <asp:Label ID="lblLoginUserName" CssClass="label" runat="server" meta:resourcekey="lblLoginUserNameResource1">用户名:</asp:Label>
                                        <asp:TextBox ID="txtLoginUserName" runat="server" MaxLength="255" Width="100%" meta:resourcekey="txtLoginUserNameResource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Label ID="lblPassword" CssClass="label" runat="server" meta:resourcekey="lblPasswordResource1">密码:</asp:Label>
                                        <asp:TextBox ID="txtPassword" TextMode="Password" MaxLength="20" Width="100%" runat="server"
                                            meta:resourcekey="txtPasswordResource1"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="left" colspan="1">
                                        &nbsp;
                                        <asp:CheckBox ID="chkAutoLogin" Text="自动登录" runat="server" Checked="False" meta:resourcekey="chkAutoLoginResource1" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" height="2px">
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" align="right">
                                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                        <asp:Button ID="btnLogin" runat="server" Text="登  录" Width="72px" meta:resourcekey="btnLoginResource1"
                                            OnClick="btnLogin_Click" />&nbsp;&nbsp; &nbsp;
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="1" height="2px">
                                    </td>
                                </tr>
                            </table>
                            <asp:HyperLink ID="lnkGetPass" CssClass="Login_GetPass" NavigateUrl="#" runat="server"
                                meta:resourcekey="lnkGetPassResource1">忘记密码？</asp:HyperLink>
                            <br />
                            &nbsp;
                            <p>
                                <asp:RequiredFieldValidator ID="rfvLoginUserName" runat="server" Display="Dynamic"
                                    ErrorMessage="用户名不能为空！<br/>" ControlToValidate="txtLoginUserName" meta:resourcekey="rfvLoginUserNameResource1"></asp:RequiredFieldValidator><asp:RequiredFieldValidator
                                        ID="rfvPassword" runat="server" Display="Dynamic" ErrorMessage="密码不能为空！" ControlToValidate="txtPassword"
                                        meta:resourcekey="rfvPasswordResource1"></asp:RequiredFieldValidator>
                            </p>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <uc1:UCMessage ID="UCMessage1" runat="server" ButtonStyle=OK />   
    
    </ContentTemplate>
    </asp:UpdatePanel>

    </form>
</body>
</html>
