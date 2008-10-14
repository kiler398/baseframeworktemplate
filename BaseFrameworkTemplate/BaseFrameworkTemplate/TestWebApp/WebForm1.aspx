<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="TestWebApp.WebForm1" %>

<%@ Register Assembly="NickLee.Web.UI" Namespace="NickLee.Web.UI" TagPrefix="NickLee" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>

<script>
    function btnInvoke_onclick() {
        PageMethods.GetName(onSayHelloSucceeded);
    }
    function onSayHelloSucceeded(result) {

        alert(result);

    }

    function Button1_onclick() {
        PageMethods.SetSesssion(on1);
    }

    function on1(result) {
    }

</script>

<body>
    <form id="form1" runat="server">
    <div>
        <NickLee:GridSlideHeader ID="GridSlideHeader1" runat="server" />
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnablePageMethods="True">
        </asp:ScriptManager>
        <input id="btnInvoke" type="button" value="Say Hello" onclick="return btnInvoke_onclick()" />
                <input id="Button1" type="button" value="setSession" onclick="return Button1_onclick()" />
        <asp:Button ID="Button2" runat="server" onclick="Button2_Click" Text="Button" />
        <table>
        <tr>
        <td id="ssss" runat=server></td>
        </tr>
        </table>
    </div>
    </form>
</body>
</html>
