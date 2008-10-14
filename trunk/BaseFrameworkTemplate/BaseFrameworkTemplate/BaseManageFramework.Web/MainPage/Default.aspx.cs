using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;

namespace BaseManageFramework.Web.MainPage
{
    public partial class Default : System.Web.UI.Page
    {
        //public SystemSettingService SystemSettingServiceInstance
        //{
        //    get;set;
        //}

        public string SystemName = "测试系统";
        public string SystemVersion = "1.0.1";
        public int MenuStyle = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            this.Head1.Title = SystemName + "-" + SystemVersion;
            this.lblWelcomeMessage.Text = string.Format("&nbsp;<b>{0}</b>&nbsp;&nbsp;&nbsp;&nbsp;<font size='2' color='#999999' face='Verdana, Arial, Helvetica, sans-serif'>{1}</font>", SystemName, SystemVersion);
            this.lblWelcomeMessage.Text += "<br/>当前登陆用户：" + this.User.Identity.Name.ToString();
            this.DataBind();
        }


        protected void lbtnLogOut_Click(object sender, EventArgs e)
        {
            UserLogOut();
            FormsAuthentication.RedirectToLoginPage();
        }
        [WebMethod]
        public static void UserLogOut()
        {
            FormsAuthentication.SignOut();
        }
    }
}
