using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using BaseManageFramework.Web.UC;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using Easyasp.Framework.Core.Web.UI;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace BaseManageFramework.Web.MainPage
{
    public partial class Login : System.Web.UI.Page
    {
        public SystemSettingService SystemSettingServiceInstance { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;

            SystemSetting systemSetting = SystemSettingServiceInstance.GetCurrentSystemSetting();
            this.Page.Header.Title = this.Page.Header.Title.Replace("{$SystemName}",systemSetting.SystemName);
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            if (Membership.ValidateUser(this.txtLoginUserName.Text.Trim(), this.txtPassword.Text.Trim()))
            {
                this.UCMessage1.ShowOkMessage(MessageType.Ok, "操作成功", "成功登陆系统！", "AuthenticationUser");
            }
            else
            {
                this.UCMessage1.ShowOkMessage(MessageType.Warnning,"操作失败", "用户登陆系统失败,请重新输入用户名密码！");
            }
        }

        public void AuthenticationUser()
        {
            FormsAuthentication.RedirectFromLoginPage(this.txtLoginUserName.Text.Trim(),
                                                                      this.chkAutoLogin.Checked);
        }

        protected void ddlLanguage_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

    }
}