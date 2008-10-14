using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;

namespace BaseManageFramework.Web.UC
{
    public class ToolbarItem
    {
        public string ID { get; set; }
        public string PrivilegeID { get; set; }
        public string Text { get; set; }
        public string CommandName { get; set; }
        public string ImageUrl { get; set; }
        public string ClientScript { get; set; }
    }


    public partial class UCToolBar : System.Web.UI.UserControl
    {
        public event EventHandler<RepeaterCommandEventArgs> RaiseEvent;

        public void BindData(List<ToolbarItem> al)
        {
            this.rptToolBar.DataSource = al;
            this.rptToolBar.DataBind();
        }


        public virtual void OnRaiseCustomEvent(object sender, RepeaterCommandEventArgs e)
        {
            EventHandler<RepeaterCommandEventArgs> handler = RaiseEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.IsPostBack)
                return;
        }

        protected void rptToolBar_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                HtmlTableCell cell = (HtmlTableCell) e.Item.FindControl("tdItem");
                ImageButton btnOperationItem = (ImageButton) cell.FindControl("btnOperationItem");
                cell.Attributes["onclick"] = string.Format("document.getElementById('{0}').click();",
                                                           btnOperationItem.ClientID);
            }
        }

        protected void rptToolBar_ItemCommand(object source, RepeaterCommandEventArgs e)
        {
            OnRaiseCustomEvent(source, e);
        }
    }
}