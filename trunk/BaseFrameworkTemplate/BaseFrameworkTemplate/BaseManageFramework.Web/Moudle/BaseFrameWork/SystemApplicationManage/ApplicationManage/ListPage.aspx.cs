using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseManageFramework.Web.UC;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using Easyasp.Framework.Core.Utility;
using Easyasp.Framework.Core.Web;
using Easyasp.Framework.Core.Web.ControlHelper;
using Easyasp.Framework.Core.Web.UI;
using Spring.Context.Support;
using CommandEventArgs=BaseManageFramework.Web.UC.CommandEventArgs;

namespace BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class ListPage : System.Web.UI.Page
    {
        public ServicesContainer ServicesContainerInstance { get; set;}

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            ListBind();
        }

        protected Hashtable QueryCondition
        {
            get { return WebUtil.GetViewStateValue(this.ViewState, "QueryCondition", new Hashtable()); }
            set { this.ViewState["QueryCondition"] = value; }
        }

        private void ListBind()
        {
            int record = 0;
            List<SystemApplication> list =
                ServicesContainerInstance.SystemApplicationServiceInstance.GetQueryPageList(this.Pager.StartRecordIndex - 1, this.Pager.PageSize,
                                                                  this.QueryCondition, "", true, out record);
            DataBindHelper.BindListDataToGridView<SystemApplication>(this.grdSystemApplicationList, list);
            this.Pager.RecordCount = record;
            GridViewHelper.RegisterGridViewSelectAllCheckBoxScript(this, this.grdSystemApplicationList, "chkSelectAll");
        }


        protected void Pager_PageChanged(object sender, EventArgs e)
        {
            ListBind();
        }


        protected void btnQuery_Click(object sender, EventArgs e)
        {
            this.Pager.CurrentPageIndex = 1;
            Hashtable hb = new Hashtable();
            hb.Add("SystemApplicationName$LikeAny", this.txtSearchSystemApplicationName.Text.Trim());
            this.QueryCondition = hb;
            ListBind();
            this.tabList.ActiveTabIndex = 0;
        }

        protected void btnClearQuery_Click(object sender, EventArgs e)
        {
            this.Response.Redirect(this.Request.RawUrl);
        }

        protected void btnClick(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            switch(btn.CommandName)
            {
                case "cmdAdd":
                    this.Server.Transfer("AddPage.aspx");
                    break;
                case "cmdDelete":
                    try
                    {
                        this.ServicesContainerInstance.SystemApplicationServiceInstance.PatchDeleteByTypedIDs<int>(GridViewHelper.GetSelectDataKeys(this.grdSystemApplicationList, "chkSelect").ToArray());
                        this.lblMessage.Text = "批量删除应用程序成功。";
                    }
                    catch (Exception e1)
                    {
                        this.lblMessage.Text = "批量删除应用程序失败，错误原因：" + e1.Message;
                    }
                    this.ListBind();
                    break;
            }
        }

        protected void grdSystemApplicationList_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int id = GridViewHelper.GetDataKeyInGridViewRowCommandEvent(sender,e);
            switch (e.CommandName)
            {
                case "cmdView":
                    this.Server.Transfer("ViewPage.aspx?ID="+id.ToString());
                    break;
                case "cmdEdit":
                    this.Server.Transfer("EditPage.aspx?ID="+id.ToString());
                    break;
            }

        }
    }
}