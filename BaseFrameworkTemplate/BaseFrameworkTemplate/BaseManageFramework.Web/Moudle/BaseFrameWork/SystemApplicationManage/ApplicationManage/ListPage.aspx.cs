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
using Easyasp.Framework.Core.Web.ControlHelper;
using CommandEventArgs=BaseManageFramework.Web.UC.CommandEventArgs;

namespace BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class ListPage : System.Web.UI.Page
    {
        public SystemApplicationService SystemApplicationServiceInstance { set; get; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
                return;
            if (this.Context.Items["QueryCondition"] != null)
                QueryCondition = (Hashtable) this.Context.Items["QueryCondition"];
            ListBind();
        }


        protected Hashtable QueryCondition
        {
            get { return WebUtil.GetViewStateValue(this.ViewState, "QueryCondition", new Hashtable()); }
            set { this.ViewState["QueryCondition"] = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.UCMenuHead1.RaiseComandEvent += new EventHandler<CommandEventArgs>(UCMenuHead1_OnRaiseComandEvent);
        }

        private void UCMenuHead1_OnRaiseComandEvent(object sender, CommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case SystemOperationService.Operation_Add:
                    this.Context.Items["QueryCondition"] = this.QueryCondition;
                    this.Server.Transfer("AddPage.aspx");
                    break;
                case SystemOperationService.Operation_Edit:
                    this.Server.Transfer("EditPage.aspx");
                    break;
                case SystemOperationService.Operation_View:
                    this.Server.Transfer("EditPage.aspx");
                    break;
                case SystemOperationService.Operation_Delete:
                    break;
            }
            ListBind();
        }

        private void ListBind()
        {
            int record = 0;
            List<SystemApplication> list =
                SystemApplicationServiceInstance.GetQueryPageList(this.Pager.StartRecordIndex - 1, this.Pager.PageSize,
                                                                  this.QueryCondition, "", true, out record);
            DataBindHelper.BindListDataToGridView<SystemApplication>(this.GridView1, list);
            this.Pager.RecordCount = record;
            GridViewHelper.RegisterGridViewSelectAllCheckBoxScript(this, this.GridView1, "chkSelectAll");
            this.UCMenuHead1.BindData();
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
    }
}