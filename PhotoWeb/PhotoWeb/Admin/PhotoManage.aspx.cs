using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoWeb.Appclass;

namespace PhotoWeb.Admin
{
    public partial class PhotoManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;

            DataRow dr = Data.GetAlbum(int.Parse(this.Request.QueryString["ID"]));

            this.lblName.Text = dr["Name"].ToString();

            BindData();
        }

        private void BindData()
        {
            this.GridView1.DataSource = Data.SelectAllPhoto(int.Parse(this.Request.QueryString["ID"]));
            this.GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if ((this.fuPhoto.PostedFile == null) ||(this.fuPhoto.PostedFile.ContentLength==0))
            {
                this.lblMessage.Text = "请上传图片";
                return;
            }

            List<string> allowExt = new List<string> { ".JPG", ".JPEG", ".GIF", ".PNG", ".BMP" };

            if (!allowExt.Contains(Path.GetExtension(this.fuPhoto.PostedFile.FileName).ToUpper()))
            {
                this.lblMessage.Text = "请上传图片类型文件。(.JPG .JPEG .GIF .PNG .BMP)";
                return;
            }

            try
            {
                Data.AddPhoto(int.Parse(this.Request.QueryString["ID"]), this.txtName0.Text.Trim(), this.txtDescription0.Text.Trim(), chkIsShow0.Checked, this.fuPhoto.PostedFile);
            }
            catch (Exception exception)
            {
                this.lblMessage.Text = "操作失败：" + exception.Message;
            }

            BindData();
        }

        protected T FindControlInRow<T>(GridViewRow row, string controlID) where T : Control
        {
            foreach (TableCell cell in row.Cells)
            {
                if (cell.FindControl(controlID) != null)
                    return cell.FindControl(controlID) as T;
            }
            return null;
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in this.GridView1.Rows)
            {
                int id = (int)this.GridView1.DataKeys[row.DataItemIndex]["ID"];
                string name = FindControlInRow<TextBox>(row, "txtName").Text.Trim();
                string description = FindControlInRow<TextBox>(row, "txtDescription").Text.Trim();
                bool isShow = FindControlInRow<CheckBox>(row, "chkIsShow").Checked;
                int sortIndex = Convert.ToInt32(FindControlInRow<TextBox>(row, "txtSortIndex").Text.Trim());

                Data.UpdatePhotoShowAndSortIndex(id, name, description, isShow, sortIndex);

            }

            BindData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "cmdSetTitlePhoto":
                    Data.SetPhotoAsTitle(int.Parse(e.CommandArgument.ToString()), int.Parse(this.Request.QueryString["ID"]));
                    break;
                case "cmdDelete":
                    Data.DeletePhoto(int.Parse(e.CommandArgument.ToString()));
                    break;
            }
            BindData();
        }
    }
}
