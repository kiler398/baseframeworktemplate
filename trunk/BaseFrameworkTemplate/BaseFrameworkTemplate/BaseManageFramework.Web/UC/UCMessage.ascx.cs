using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.Utility;
using Easyasp.Framework.Core.Web.UI;

namespace BaseManageFramework.Web.UC
{
    public delegate void OkProcess();

    public partial class UCMessage : System.Web.UI.UserControl
    {

        public string Title { get; set; }
        public string Message { get; set; }
        private string OkMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "OkMethodName");
            }
            set
            {
                this.ViewState["OkMethodName"] = value;
            }
        }
        private string YesMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "YesMethodName");
            }
            set
            {
                this.ViewState["YesMethodName"] = value;
            }
        }
        private string NoMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "NoMethodName");
            }
            set
            {
                this.ViewState["NoMethodName"] = value;
            }
        }
        private string AbortMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "AbortMethodName");
            }
            set
            {
                this.ViewState["AbortMethodName"] = value;
            }
        }
        private string CancelMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "CancelMethodName");
            }
            set
            {
                this.ViewState["CancelMethodName"] = value;
            }
        }
        private string IgnoreMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "IgnoreMethodName");
            }
            set
            {
                this.ViewState["IgnoreMethodName"] = value;
            }
        }
        private string RetryMethodName
        {
            get
            {
                return WebUtil.GetViewStateValue<string>(this.ViewState, "RetryMethodName");
            }
            set
            {
                this.ViewState["RetryMethodName"] = value;
            }
        }

        public WebMessageBoxButtons ButtonStyle{ get; set; }

        public Button OkButton
        {
            get
            {
                return this.btnOk;
            }
        }
        public string CallBackParentPageMethodName { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            if(this.Page.IsPostBack)
                return;
            this.btnAbort.Visible = false;
            this.btnCancel.Visible = false;
            this.btnIgnore.Visible = false;
            this.btnNo.Visible = false;
            this.btnOk.Visible = false;
            this.btnRetry.Visible = false;
            this.btnYes.Visible = false;
            switch (ButtonStyle)
            {
                case WebMessageBoxButtons.YesNo:
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    break;
                case WebMessageBoxButtons.YesNoCancel:
                    this.btnYes.Visible = true;
                    this.btnNo.Visible = true;
                    this.btnCancel.Visible = true;
                    break;
                case WebMessageBoxButtons.OK:
                    this.btnOk.Visible = true;
                    break;
                case WebMessageBoxButtons.OKCancel:
                    this.btnOk.Visible = true;
                    this.btnCancel.Visible = true;
                    break;
                case WebMessageBoxButtons.AbortRetryIgnore:
                    this.btnAbort.Visible = true;
                    this.btnCancel.Visible = true;
                    this.btnIgnore.Visible = true;
                    break;
                case WebMessageBoxButtons.RetryCancel:
                    this.btnRetry.Visible = true;
                    this.btnCancel.Visible = true;
                    break;
            }
            //MessageBox.Show()
        }

        public void ShowOkMessage(MessageType messageType,string title, string message, string okMethodName)
        {
            ShowMessage();
            switch(messageType)
            {
                case MessageType.Question:
                    this.imgMessageIcon.Src = this.ResolveUrl("~/images/BaseFramework/MessageIcon/icon-question.gif");
                    break;
                case MessageType.Error:
                    this.imgMessageIcon.Src = this.ResolveUrl("~/images/BaseFramework/MessageIcon/icon-error.gif");
                    break;
                case MessageType.Info:
                    this.imgMessageIcon.Src = this.ResolveUrl("~/images/BaseFramework/MessageIcon/icon-info.gif");
                    break;
                case MessageType.Ok:
                    this.imgMessageIcon.Src = this.ResolveUrl("~/images/BaseFramework/MessageIcon/MessageOk.gif");
                    break;
                case MessageType.Warnning:
                    this.imgMessageIcon.Src = this.ResolveUrl("~/images/BaseFramework/MessageIcon/icon-warning.gif");
                    break;
            }
            this.Title = title;
            this.Message = message;
            this.tdHead.InnerHtml = title;
            this.tdMessageBody.InnerHtml = message;
            this.OkMethodName = okMethodName;
        }

        public void ShowOkMessage(MessageType messageType, string title, string message)
        {
            ShowOkMessage(messageType, title, message);
        }

        //public void ShowOkMessage(string title,string message,string okMethodName)
        //{
        //    ShowMessage();
        //    this.Title = title;
        //    this.Message = message;
        //    this.tdHead.InnerHtml = title;
        //    this.tdMessageBody.InnerHtml = message;
        //    this.OkMethodName = okMethodName;
        //}

        public void ShowMessage()
        {
            this.pagedimmer.Style["display"] = "";
            this.msgbox.Style["display"] = "";
        }
        public void HideMessage()
        {
            this.pagedimmer.Style["display"] = "none";
            this.msgbox.Style["display"] = "none";
        }

        protected void btnOk_OnClick(object sender, EventArgs e)
        {
            if (this.OkMethodName != "")
                this.Page.GetType().GetMethod(this.OkMethodName).Invoke(this.Page, null);
            else
                HideMessage();
        }
    }
}