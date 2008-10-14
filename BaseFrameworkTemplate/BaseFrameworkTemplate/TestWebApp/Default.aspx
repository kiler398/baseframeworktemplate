<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebApp._Default" %>

<%@ Register Assembly="NickLee.Web.UI" Namespace="NickLee.Web.UI" TagPrefix="NickLee" %>
<%@ Register Assembly="NickLee.Web.UI" Namespace="NickLee.Web.UI.BusyBox" TagPrefix="nickleebusybox" %>
<%@ Register Assembly="NickLee.Web.UI" Namespace="NickLee.Web.UI.MuddledHyperlink"
    TagPrefix="cc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    </div>
    <nickleebusybox:BusyBoxButton ID="BusyBoxButton1" runat="server" BusyBoxToShow="BusyBox1"
        Text="Button" /><nickleebusybox:BusyBox ID="BusyBox1" runat="server" />
    </form>
</body>
</html>
