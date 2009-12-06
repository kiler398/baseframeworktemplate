<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="PhotoWeb._Default" %>

<html>
<head runat="server">
    <title>视觉醒影像团队</title>
    <meta name="keywords" content="">
    <link rel="stylesheet" type="text/css" href="/css.css">
    <style type="text/css">
        A:link, A:visited, A:active
        {
            color: #666699;
        }
        A:hover
        {
            color: #ff6600;
        }
        BODY
        {
            background-color: #000000;
        }
        BODY, TD
        {
            color: #FF99FF;
        }
        .head
        {
            color: #FF99FF;
        }
        .headbox
        {
            background-color: #000000;
        }
        .style1
        {
            height: 22px;
        }
    </style>
    <script language="javascript" type="text/javascript" src="/js/jquery.min.js"></script>
    <script type="text/javascript" charset="ISO-8859-1" src="/js/jpop.js"></script>
    <script language="javascript" type="text/javascript" src="/js/jquery.jqpageflow.js"></\script>
    <script language="javascript" type="text/javascript" src="/js/standard.js"></script>
    <script language="javascript" type="text/javascript" src="/js/sidebar.js"></script>
    <link rel="stylesheet" type="text/css" href="/css/main_popup.css" />
    <link rel="alternate" type="application/rss+xml" title="simplestudio's photo albums"
        href="/rss/simplestudio">
    <link rel="stylesheet" type="text/css" href="/css/jqpageflow.css" />
</head>
<body>

    <script language="javascript1.2">
  // <!--
  function menuChoice(selected_select) {
	  var sel_index = selected_select.selectedIndex;
	  var sel_value = selected_select.options[sel_index].value;
	  selected_select.options[0].selected = true;
   	  popup_show(sel_value, '', 'screen-corner', 100,30,450,550);
  } 
  // --> 

    </script>

    <table class="screen" border="0">
        <tr>
            <td>

            </td>
        </tr>
        <a href="/simplestudio/xelo"></a>
        <tr>
            <td valign="top">
                <table class="menubox" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="4" bgcolor="black">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1" alt="" />
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="black" width="1" height="18">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1" alt="" />
                        </td>
                        <td align="right" valign="middle" width="100%" height="18">
                            &nbsp; <span class="menutext"><a href="/simplestudio/profile">[个人档案]</a>&nbsp;<a
                                href="/main.php?mod=albumtree&set_albumName=simplestudio&set_ownerName=simplestudio">[目录]</a>&nbsp;<a
                                    href="/simplestudio/pjournal">[photo journal]</a>&nbsp;<a id="popuplink_1" target="Edit"
                                        href='/login.php' onclick="javascript:nw=window.open(document.getElementById('popuplink_1').href,'Edit','height=500,width=500,location=no,scrollbars=yes,menubars=no,toolbars=no,resizable=yes');nw.opener=self;return false;"><nobr>[登入]</nobr></a><a
                                            href="#" onclick="popup_show('/popup.php?cmd=subscribe&set_ownerName=simplestudio&set_albumName=simplestudio', 'Subscribe', 'mouse-left', 0,0,250,300);return false;" /><img
                                                src="/images/notify.png" align="absmiddle" title="subscribe" /></a>&nbsp<a href="#"
                                                    onclick="popup_show('/popup.php?cmd=rss_feed', 'RSS Feeds', 'mouse-left', 0,0,250,300);return false;" /><img
                                                        src="/images/rss.gif" align="absmiddle" title="rss" /></a></span>&nbsp;
                        </td>
                        <td bgcolor="black" width="1" height="18">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1" alt="" />
                        </td>
                    </tr>
                </table>
                <a href="/simplestudio/Image_s"></a>
                <!-- top nav -->
                <table class="breadcrumb" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="3" bgcolor="black">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="black" width="1" height="18">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="right" width="3000" height="18">
                            <span class="bread"><a class="parents" href="http://www.snaapa.com">www.snaapa.com</a>
                                <img src="http://s0.snaapa.com/images/nav_home.gif" width="13" height="11">&nbsp;
                            </span>
                        </td>
                        <td bgcolor="black" width="1" height="18">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                </table>
                <table class="nav" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="11" bgcolor="black" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="black" width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="27" height="18">
                            &nbsp;
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="72" height="18">
                            &nbsp;
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="3000" height="18">
                        </td>
                        <td align="center" width="72" height="18">
                            &nbsp;
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="27" height="18">
                            &nbsp;
                        </td>
                        <td align="right" bgcolor="black" width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11" bgcolor="black" class="style1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                </table>
                <center>
                </center>
                <!-- image grid table -->
                <div id="thumbs">
                    <table class="thumbs" cellspacing="0" cellpadding="7">
                        <tr>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/wedding">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/Justin_and_Sherry/IMG_0090.thumb.jpg"
                                                    width="150" height="75" border="0" title="" alt="IMG_0090" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/nuptial">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/Stephonie_and_Tonie/KML_2179.thumb.jpg"
                                                    width="150" height="75" border="0" title="" alt="KML_2179" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/mirror">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/VIVIAN/IMG_2328.thumb.jpg" width="150"
                                                    height="96" border="0" title="" alt="IMG_2328" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/baby">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/Caiyuchen2/DPP_0112.thumb.jpg"
                                                    width="150" height="100" border="0" title="" alt="DPP_0112" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/exhibition">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/AUTO_Shanghai_2009/KML_0519.thumb.jpg"
                                                    width="150" height="75" border="0" title="" alt="KML_0519" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 简约婚礼摄影</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Oct 14, 2009.
                                                    <br>
                                                    Contains: 10 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 婉约婚纱摄影</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Mar 12, 2009.
                                                    <br>
                                                    Contains: 2 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 婉约个性写真</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Feb 09, 2009.
                                                    <br>
                                                    Contains: 2 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 母孕婴儿写真</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Jun 10, 2008.
                                                    <br>
                                                    Contains: 2 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 展会、会议</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Apr 23, 2009.
                                                    <br>
                                                    Contains: 3 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/magazine">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/dazhong/0806_G.thumb.jpg" width="150"
                                                    height="95" border="0" title="" alt="0806_G" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/member">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/Denny/IMG_3168_1.thumb.jpg" width="150"
                                                    height="98" border="0" title="" alt="IMG_3168-1" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/view">
                                                <img src="http://s0.snaapa.com/images/empty.gif"></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/snap">
                                                <img src="http://s0.snaapa.com/images/empty.gif"></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/pet">
                                                <img src="http://s0.snaapa.com/images/empty.gif"></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 杂志封面</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Nov 03, 2008.
                                                    <br>
                                                    Contains: 2 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 成员简介</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Nov 11, 2008.
                                                    <br>
                                                    Contains: 7 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 风光</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Mar 05, 2009.
                                                    <br>
                                                    Contains: no items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 人文纪实</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Jan 10, 2008.
                                                    <br>
                                                    Contains: no items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 宠物写真</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Jan 07, 2008.
                                                    <br>
                                                    Contains: no items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/news">
                                                <img src="http://s0.snaapa.com/images/empty.gif"></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/travel">
                                                <img src="http://s0.snaapa.com/images/empty.gif"></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/architecture">
                                                <img src="http://s0.snaapa.com/images/empty.gif"></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" align="center" valign="middle">
                                <table width="1" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/TL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/TT.gif)">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/TR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="100" background="http://s0.snaapa.com/images/album/LL.gif">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                                        </td>
                                        <td>
                                            <a href="/simplestudio/MP3">
                                                <img src="http://a0.snaapa.com/albums2/simplestudio/MP3/let_s_start_from_here_i_love_you_mp3.thumb.jpg"
                                                    width="100" height="84" border="0" title="" alt="let_s_start_from_here_i_love_you.mp3" /></a>
                                        </td>
                                        <td height="100" style="background-image: url(http://s0.snaapa.com/images/album/RR.gif)">
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="30" height="14">
                                            <img src="http://s0.snaapa.com/images/album/BL.gif" border="0" width="30" height="14"
                                                alt="FRAME">
                                        </td>
                                        <td height="14" style="background-image: url(http://s0.snaapa.com/images/album/BB.gif)">
                                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" border="0" width="1" height="1"
                                                alt="FRAME">
                                        </td>
                                        <td>
                                            <img src="http://s0.snaapa.com/images/album/BR.gif" border="0" width="15" height="14"
                                                alt="FRAME">
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 新闻纪实</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Apr 22, 2009.
                                                    <br>
                                                    Contains: no items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 旅游</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Jan 07, 2008.
                                                    <br>
                                                    Contains: no items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: 建筑装饰</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Jun 12, 2008.
                                                    <br>
                                                    Contains: 2 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td width="20%" valign="top" align="center">
                                <table width="border=0" cellpadding="0" cellspacing="4">
                                    <tr>
                                        <td>
                                            <span class="caption"><b>Album: MP3</b><br>
                                                <br>
                                                <br>
                                                <span class="details">Changed: Apr 22, 2009.
                                                    <br>
                                                    Contains: 4 items.<br>
                                                </span></span>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                        <tr>
                        </tr>
                    </table>
                </div>
                <table class="comments">
                    <!-- comments -->
                    <span class="caption">
                        <tr align="center">
                            <td colspan="3">
                                <span class="editlink"><a href="#" onclick="popup_show('/popup.php?set_albumName=simplestudio&set_ownerName=simplestudio&cmd=add_album_comment', 'leave message', 'screen-corner', 100, 30, 500, 400);return false;">
                                    [leave message]</a>&nbsp<a href="#" onclick="popup_show('/popup.php?set_albumName=simplestudio&set_ownerName=simplestudio&cmd=email_album', 'Email to friend', 'screen-corner', 100, 30, 500, 500);return false;">[email
                                        album]</a></span><br>
                                <br>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div id="comments-container">
                                </div>
                            </td>
                        </tr>

                        <script type="text/javascript">
                            $(document).ready(function() {

                                $("body").flexiPagination({
                                    url: "/get_comment.php?d=albums2&w=&set_ownerName=simplestudio&set_albumName=simplestudio",
                                    currentPage: 0,
                                    totalResults: 2,
                                    perPage: 1,
                                    container: "#comments-container",
                                    pagerVar: "p",
                                    loaderImgPath: "/images/loader.gif",
                                    debug: 0
                                });
                            });
                        </script>

                    </span>
                </table>
                <br>
                <br>
                <!-- bottom nav -->
                <table class="nav" cellspacing="0" cellpadding="0">
                    <tr>
                        <td colspan="11" bgcolor="black" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td bgcolor="black" width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="27" height="18">
                            &nbsp;
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="72" height="18">
                            &nbsp;
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="3000" height="18">
                        </td>
                        <td align="center" width="72" height="18">
                            &nbsp;
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="center" width="27" height="18">
                            &nbsp;
                        </td>
                        <td align="right" bgcolor="black" width="1" height="1">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="11" bgcolor="black">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                </table>
                <table class="breadcrumb" cellspacing="0" cellpadding="0">
                    <tr>
                        <td bgcolor="black" width="1" height="18">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                        <td align="right" width="3000" height="18">
                            <span class="bread"><a class="parents" href="Default.aspx">www.snaapa.com</a>
                                <img src="http://s0.snaapa.com/images/nav_home.gif" width="13" height="11">&nbsp;
                            </span>
                        </td>
                        <td bgcolor="black" width="1" height="18">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3" height="1" bgcolor="black">
                            <img src="http://s0.snaapa.com/images/pixel_trans.gif" width="1" height="1">
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    9 0.0556499958038<br />
</body>
</html>
