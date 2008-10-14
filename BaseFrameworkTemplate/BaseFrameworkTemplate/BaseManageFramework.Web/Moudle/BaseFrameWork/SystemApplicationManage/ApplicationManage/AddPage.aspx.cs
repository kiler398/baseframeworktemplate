using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using Easyasp.Framework.Core.Utility;
using Easyasp.Framework.Core.Web.UI;

namespace BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class AddPage : System.Web.UI.Page
    {
        private SystemApplicationService systemApplicationServiceInstance;

        public SystemApplicationService SystemApplicationServiceInstance
        {
            set { systemApplicationServiceInstance = value; }
        }

        public LastNavigatePageInfo FormPageInfo
        {
            get
            {
                return WebUtil.GetViewStateValue<LastNavigatePageInfo>(this.ViewState, "FormPageInfo", new LastNavigatePageInfo(this.Context));
            }
            set
            {
                this.ViewState["FormPageInfo"] = value;
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;

            this.FormPageInfo = new LastNavigatePageInfo(this.Context);
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            //验证不通过返回
            if (!this.Page.IsValid)
                return;

            SystemApplication obj = new SystemApplication();
            obj.SystemApplicationName = this.txtSystemApplicationName.Text.Trim();
            obj.SystemApplicationDescription = this.txtSystemApplicationDescription.Text.Trim();
            obj.SystemApplicationUrl = this.txtSystemApplicationUrl.Text.Trim();
            obj.SystemApplicationIsSystemApplication = this.chkSystemApplicationIsSystemApplication.Checked;

            //添加数据
            try
            {
                systemApplicationServiceInstance.Create(obj);
                
                //WebMessageBox.ShowOperationOkMessage("操作成功", "用户添加系统应用成功", this.ResolveUrl("ListPage.aspx"));
            }
            catch (ThreadAbortException tae)
            {

            }
            catch (Exception e1)
            {
                //WebMessageBox.ShowOperationFailedMessageAndHistoryBack("操作失败", "添加数据失败，错误原因：" + e1.Message);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            this.Context.Items["QueryCondition"] = this.FormPageInfo.QueryCondition;
            this.Server.Transfer("ListPage.aspx");
        }

    }
}
