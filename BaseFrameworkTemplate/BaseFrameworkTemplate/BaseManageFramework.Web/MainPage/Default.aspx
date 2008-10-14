<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Theme="Default" Inherits="BaseManageFramework.Web.MainPage.Default" meta:resourcekey="PageResource1" uiculture="auto" %>

<html>
<head id="Head1" runat=server>
    <title></title>
    <meta http-equiv="Content-Type" content="text/html; charset=utf-8" />
    <style type="text/css">
        .navPoint
        {
            font-family: Webdings;
            font-size: 9pt;
            color: white;
            cursor: pointer;
        }
        p
        {
            font-size: 9pt;
        }
        .font_size
        {
            font-family: "Verdana" , "Arial" , "Helvetica" , "sans-serif";
            font-size: 12px;
            font-weight: normal;
            font-variant: normal;
            text-transform: none;
        }
    </style>
</head>

<body scroll="no" leftmargin="0" topmargin="0" marginheight="0" marginwidth="0">
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
    <table border="0" cellspacing="0" cellpadding="0" width="100%" height="100%">
        <tr>
            <td width="100%" height="50" colspan="3" style="border-bottom: 1px solid #000000">
                <table height="49" border="0" cellspacing="0" cellpadding="0" width="100%" class="font_size">
                    <tr>
                        <td width="300">
                            <asp:Label ID="lblWelcomeMessage" runat="server" 
                                meta:resourcekey="lblWelcomeMessageResource1"></asp:Label>
                        </td>
                        <td style="background-image: url(../images/BaseFramework/top-gray.gif); background-repeat: no-repeat;
                            background-position: right top" valign="bottom">
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <%

            MenuStyle = 0;
            switch (MenuStyle)
            {
                case 0:
        %>
        <tr>
            <td id="frmTitle" name="frmTitle" nowrap="nowrap" valign="middle" align="center"
                width="198" style="border-right: 1px solid #000000">
                <iframe name="BoardTitle" style="height: 100%; visibility: inherit; width: 198; z-index: 2"
                    scrolling="auto" frameborder="0" src="Left.aspx"></iframe>
            </td>
            <td style="width: 10pt" bgcolor="#7898A8" width="10" title="<%= this.GetLocalResourceObject("OpenOrCloseLeftMenu").ToString() %>" class="navPoint">
                <table border="0" cellpadding="0" cellspacing="0" width="11" height="100%" align="right">
                    <tr>
                        <td valign="middle" align="right" class="middleCss">
                            <img border="0" src="../images/BaseFramework/Menu/close.gif" id="menuimg" alt="<%= this.GetLocalResourceObject("CloseLeftMenu").ToString() %>" onmouseover="javascript: menuonmouseover();"
                                onmouseout="javascript: menuonmouseout();" onclick="javascript:switchSysBar()"
                                style="cursor: hand" width="11" height="76" />
                        </td>
                    </tr>
                </table>
            </td>
            <td style="width: 100%">
                <iframe id="mainFrame" name="mainFrame" style="height: 100%; visibility: inherit;
                    width: 100%; z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;
        case 1:
        case 2:
        %>
        <tr>
            <td height="51px">
                <iframe name="MainTop" style="height: 100%; visibility: inherit; width: 100%; z-index: 1"
                    scrolling="no" frameborder="0" src="Menu2.aspx"></iframe>
            </td>
        </tr>
        <tr>
            <td style="width: 100%">
                <iframe id="Iframe" name="mainFrame" style="height: 100%; visibility: inherit; width: 100%;
                    z-index: 1" scrolling="auto" frameborder="0" src="right.aspx"></iframe>
            </td>
        </tr>
        <%
            break;

    }
        %>
        <tr>
            <td colspan="3" height="20">
                <table border="0" cellpadding="0" cellspacing="0" width="100%" height="20">
                    <tr>
                        <td class="down_text">
                            <asp:Label ID="lblCopyRight" runat="server" 
                                meta:resourcekey="lblCopyRightResource1"> Powered By <a href='http://www.supesoft.com' target='_blank'><font color='#ffffff'>
                            Supesoft.com</font></a>
                            Information Technology Logistics Inc.
                            
                            </asp:Label>
                        </td>
                        <td align="right" width="400" bgcolor="#000000">
                            <table border="0" cellpadding="0" cellspacing="0" width="100%">
                                <tr>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;">
                                        &nbsp;<img src="../images/BaseFramework/about.gif" style="margin-bottom: -3px">&nbsp;<asp:Label
                                            ID="lblVersionInfo" runat="server" ForeColor="White" 
                                            meta:resourcekey="lblVersionInfoResource1">版本信息</asp:Label>
                                    </td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;">
                                        &nbsp;<img src="../images/BaseFramework/userset.gif" style="margin-bottom: -3px">&nbsp;<asp:Label
                                            ID="lblUserSetting" runat="server" ForeColor="White" 
                                            meta:resourcekey="lblUserSettingResource1">个人设定</asp:Label>
                                    </td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="javascript: window.mainFrame.location.href='right.aspx'">
                                        &nbsp;<img src="../images/BaseFramework/house.gif" style="margin-bottom: -3px">&nbsp;<asp:Label
                                            ID="lblReturnDefault" runat="server" ForeColor="White" 
                                            meta:resourcekey="lblReturnDefaultResource1">回到首页</asp:Label>
                                    </td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="logout();">
                                        &nbsp;<img src="../images/BaseFramework/logout.gif" style="margin-bottom: -3px">&nbsp;<asp:Label
                                            ID="lblLogOut" runat="server" ForeColor="White" 
                                            meta:resourcekey="lblLogOutResource1">退出系统</asp:Label>
                                        <asp:LinkButton ID="lbtnLogOut"
                                                runat="server" onclick="lbtnLogOut_Click" OnClientClick="return confirm('确认要退出系统？')"
                                            meta:resourcekey="lbtnLogOutResource1"></asp:LinkButton>
                                    </td>
                                    <td style="cursor: pointer; border-left: 1px solid #FFFFFF;" onclick="javascript:window.open('http://framework.supesoft.com/help/');">
                                        &nbsp;<img src="../images/BaseFramework/help.gif" style="margin-bottom: -3px">&nbsp;&lt;<asp:Label
                                            ID="lblHelp" runat="server" ForeColor="White" 
                                            meta:resourcekey="lblHelpResource1">帮助手册</asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    </form>
</body>
</html>

<script language="JavaScript" type="text/javascript">

    // <%= this.GetLocalResourceObject("IsLeavePage").ToString() %>


    function logout() { 
            lbtnLogOut.click();
    }
    
    rnd.today = new Date();

    rnd.seed = rnd.today.getTime();

    function rnd() {
        rnd.seed = (rnd.seed * 9301 + 49297) % 233280;
        return rnd.seed / (233280.0);

    };

    function rand(number) {
        return Math.ceil(rnd() * number);

    };



    var var_frmTitle = document.getElementById("frmTitle");
    var var_menuimg = document.getElementById("menuimg");

    function switchSysBar() {

        if (var_frmTitle.style.display == "none") {
            var_frmTitle.style.display = ""
            var_menuimg.src = "../images/BaseFramework/Menu/close.gif";
            var_menuimg.alt = '<%= this.GetLocalResourceObject("CloseLeftMenu").ToString() %>'
        }
        else {
            var_frmTitle.style.display = "none"
            var_menuimg.src = "../images/BaseFramework/Menu/open.gif";
            var_menuimg.alt = '<%= this.GetLocalResourceObject("OpenLeftMenu").ToString() %>'
        }



    }

    function menuonmouseover() {
        if (var_frmTitle.style.display == "none") {
            var_menuimg.src = "../images/BaseFramework/Menu/open_on.gif";
        }
        else {
            var_menuimg.src = "../images/BaseFramework/Menu/close_on.gif";
        }
    }
    function menuonmouseout() {
        if (var_frmTitle.style.display == "none") {
            var_menuimg.src = "../images/BaseFramework/Menu/open.gif";
        }
        else {
            var_menuimg.src = "../images/BaseFramework/Menu/close.gif";
        }
    }
    if (top != self) {
        top.location.href = "default.aspx";
    }
   
</script>