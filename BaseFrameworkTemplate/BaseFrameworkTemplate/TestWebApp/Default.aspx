<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="TestWebApp._Default" %>

<%@ Register Assembly="Easyasp.Framework.Core" Namespace="Easyasp.Framework.Core.Web.UI.WebControls"
    TagPrefix="cc2" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
    Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

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
    <cc2:DataView ID="DataView1" runat="server" />

    </form>
</body>
</html>
