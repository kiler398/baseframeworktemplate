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
using Easyasp.Framework.Core.Web;
using Easyasp.Framework.Core.Web.UI;
using Spring.Context.Support;

namespace BaseManageFramework.Web.Moudle.BaseFrameWork.SystemApplicationManage.ApplicationManage
{
    public partial class AddPage : System.Web.UI.Page
    {
        


        private readonly ServicesContainer ServicesContainerInstance = (ServicesContainer)ContextRegistry.GetContext().GetObject("ServicesContainerIocID");

        //public NavigateListPageStatusInfo FormListPageStatusInfo
        //{
        //    get
        //    {
        //        return WebUtil.GetViewStateValue<NavigateListPageStatusInfo>(this.ViewState, "FormListPageStatusInfo", null);
        //    }
        //    set
        //    {
        //        this.ViewState["FormListPageStatusInfo"] = value;
        //    }
        //}


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            //if (this.Context.Items["LastPageStatus"]!=null)
            //    this.FormListPageStatusInfo = (NavigateListPageStatusInfo)this.Context.Items["LastPageStatus"];
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
                ServicesContainerInstance.SystemApplicationServiceInstance.Create(obj);
                ServicesContainerInstance.SystemLogServiceInstance.LogOperationAddOKInfo(ServicesContainerInstance.SystemUserServiceInstance.GetCurrentLoginUser(), ServicesContainerInstance.SystemMoudleServiceInstance.GetSystemMoudleByName("系统应用程序"), "系统应用程序", obj.SystemApplicationID,"管理后台程序",WebUtil.GetRequestInfo());
                //this.Context.Items["LastPageStatus"] = this.FormListPageStatusInfo;
                this.Server.Transfer("ListPage.aspx");

                
                //WebMessageBox.ShowOperationOkMessage("操作成功", "用户添加系统应用成功", this.ResolveUrl("ListPage.aspx"));
            }
            catch (ThreadAbortException tae)
            {

            }
            catch (Exception e1)
            {
                this.lblMessage.Text = "添加数据失败，错误原因：" + e1.Message;
                //WebMessageBox.ShowOperationFailedMessageAndHistoryBack("操作失败", "添加数据失败，错误原因：" + e1.Message);
            }
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            //this.Context.Items["LastPageStatus"] = this.FormListPageStatusInfo;
            this.Server.Transfer("ListPage.aspx");
        }

    }
}
