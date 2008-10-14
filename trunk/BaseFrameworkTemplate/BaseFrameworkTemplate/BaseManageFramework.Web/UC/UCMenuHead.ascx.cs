using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using Microsoft.Web.UI.WebControls;

namespace BaseManageFramework.Web.UC
{
    public class CommandEventArgs : EventArgs
    {
        public string commandName;

        public string CommandName
        {
            get { return commandName; }
            set { commandName = value; }
        }
    }


    [Description("头部菜单web控件")]
    public partial class UCMenuHead : System.Web.UI.UserControl
    {
        public SystemUserService SystemUserServiceInstance { set; get; }

        public SystemPrivilegeService SystemPrivilegeServiceInstance { set; get; }

        public event EventHandler<CommandEventArgs> RaiseComandEvent;

        public virtual void OnRaiseCustomEvent(object sender, CommandEventArgs e)
        {
            EventHandler<CommandEventArgs> handler = RaiseComandEvent;

            if (handler != null)
            {
                handler(this, e);
            }
        }

        private string moudleName = "";
        private string operationName = "";

        public string MoudleName
        {
            get { return moudleName; }
            set { moudleName = value; }
        }

        public string OperationName
        {
            get { return operationName; }
            set { operationName = value; }
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            this.UCToolBar1.RaiseEvent += new EventHandler<RepeaterCommandEventArgs>(UCToolBar1_OnCommand);
        }

        private void UCToolBar1_OnCommand(object sender, RepeaterCommandEventArgs e)
        {
            CommandEventArgs commandEventArgs = new CommandEventArgs();
            commandEventArgs.CommandName = e.CommandName;
            OnRaiseCustomEvent(sender, commandEventArgs);
        }

        public void BindData()
        {
            List<ToolbarItem> al = new List<ToolbarItem>();
            SystemMoudle moudle = new SystemMoudle();
            moudle.MoudleIsSystemMoudle = true;
            moudle.MoudleNameEn = "SystemApplication";
            moudle.MoudleNameCn = "系统应用";
            List<SystemPrivilege> listSystemPrivilege =
                SystemUserServiceInstance.GetUserPrivilegeByUserLoginID(
                    SystemUserServiceInstance.GetCurrentLoginUser(), moudle);
            foreach (SystemPrivilege privilege in listSystemPrivilege)
            {
                ToolbarItem item = new ToolbarItem();
                item.ID = privilege.PrivilegeID.ToString();
                item.ImageUrl = string.Format("~/images/BaseFramework/OperationIcon/op{0}.gif",
                                              privilege.OperationID.OperationNameEn);
                item.Text = privilege.OperationID.OperationNameCn;
                item.CommandName = privilege.OperationID.OperationNameEn;
                switch (privilege.OperationID.OperationNameEn)
                {
                    case SystemOperationService.Operation_Add:
                        item.ClientScript = "";
                        break;
                    case SystemOperationService.Operation_Delete:
                        item.ClientScript = "";
                        break;
                    case SystemOperationService.Operation_Edit:
                        item.ClientScript = "";
                        break;
                    case SystemOperationService.Operation_Export:
                        item.ClientScript = "";
                        break;
                    case SystemOperationService.Operation_Print:
                        item.ClientScript = "";
                        break;
                    case SystemOperationService.Operation_Refresh:
                        item.ClientScript = "";
                        break;
                    case SystemOperationService.Operation_View:
                        item.ClientScript = "";
                        break;
                }
                item.ClientScript = "";
                al.Add(item);
            }
            this.UCToolBar1.BindData(al);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.lblMoudleName.Text = this.moudleName;
            this.lblOperationName.Text = this.operationName;
        }
    }
}