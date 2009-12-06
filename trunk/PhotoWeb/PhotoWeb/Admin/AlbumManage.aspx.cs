using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PhotoWeb.Appclass;

namespace PhotoWeb.Admin
{
    public partial class AlbumManage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page.IsPostBack)
                return;
            BindData();
        }

        private void BindData()
        {
            this.GridView1.DataSource = Data.SelectAllAlbum();
            this.GridView1.DataBind();
        }

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            this.Response.Redirect("AlbumAdd.aspx");
        }

        protected T FindControlInRow<T>(GridViewRow row, string controlID) where T:Control
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

                Data.UpdateAlbumShowAndSortIndex(id,name,description, isShow, sortIndex);

            }

            BindData();
        }

        protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "cmdManagePhoto":
                    this.Response.Redirect(string.Format("PhotoManage.aspx?ID={0}", e.CommandArgument.ToString()));
                    break;
                case "cmdDelete":
                    Data.DeleteAlbum(int.Parse(e.CommandArgument.ToString()));
                    break;
            }
            BindData();
        }
    }
}
