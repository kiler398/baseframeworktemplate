<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UCComments.ascx.cs"
    Inherits="PhotoWeb.UserControl.UCComments" %>
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
