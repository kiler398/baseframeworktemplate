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


        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.Page.IsPostBack)
                return;
            this.lblMoudleName.Text = this.moudleName;
            this.lblOperationName.Text = this.operationName;
        }
    }
}