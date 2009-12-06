using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoWeb.Appclass;

namespace PhotoWeb.Admin
{
    public partial class AlbumAdd : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                Data.AddAlbum(this.txtName.Text.Trim(),this.txtDescription.Text.Trim(),chkIsShow.Checked);
                this.Response.Redirect("AlbumManage.aspx");
            }
            catch (Exception exception)
            {
                this.lblMessage.Text = "操作失败：" + exception.Message;
            }
        }
    }
}
