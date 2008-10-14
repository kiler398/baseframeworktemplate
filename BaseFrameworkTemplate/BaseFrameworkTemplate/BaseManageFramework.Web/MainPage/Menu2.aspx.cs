using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;

namespace BaseManageFramework.Web.MainPage
{
    public partial class Menu2 : System.Web.UI.Page
    {
        public StringBuilder sb_TopHTMLSrc = new StringBuilder();
        public StringBuilder sb_TopHTMLSrc2 = new StringBuilder();
        public StringBuilder sb_DownHTMLSrc = new StringBuilder();
        public int TopMenuCount = 0;

        public SystemMenuService SystemMenuServiceInstance
        {
            set;
            get;
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                OnStart();
            }
        }




        private void OnStart()
        {
            List<SystemMenu> mainList = SystemMenuServiceInstance.GetTopMenu();
            int i = 1;
            int j;
            foreach (var menu in mainList)
            {
                List<SystemMenu> subList = SystemMenuServiceInstance.GetSubMenu(menu);
                if (subList.Count > 0)
                {
                    sb_TopHTMLSrc.AppendFormat("<td width='90' align='center' valign='bottom' OnMouseOver={1}javascript:ImageOverOROut('menu_{0}','v'){1} OnMouseOut={1}javascript:ImageOverOROut('menu_{0}','o'){1} class='topmenuoff' id='menu_{0}' OnClick={1}javascript:NowShow('menu_',{0}){1}>{2}</td><td valign='bottom' align='center'><img border='0' src='../images/BaseFramework/index/top-2-2.gif' width='3' height='20'></td>", i, "\"", menu.MenuName);
                    sb_TopHTMLSrc2.AppendFormat("<td height='7' align='center'><img border='0' src='../images/BaseFramework/index/top-b-1.gif' id='menu_{0}i'></td><td height='7'></td>", i);

                    sb_DownHTMLSrc.AppendFormat("<table border='0' cellpadding='0' cellspacing='0' style={0}display:'none';position: absolute;left: 117px{0} align='left' id='menu_{1}_table'><tr><td align='right'><img border='0' src='../images/BaseFramework/index/top-b4-1.gif' width='5'></td>", "\"", i);

                    j = 1;
                    foreach (var submenu in subList)
                    {
                        sb_DownHTMLSrc.AppendFormat("<td background={0}../images/BaseFramework/index/top-b4-b.gif{0} align={0}center{0} width={0}100{0} class={0}topmenuoff2{0} id={0}menu_{1}_{2}{0} OnMouseOver={0}javascript:xImageOverOROut('menu_{1}_{2}','v'){0} OnMouseOut={0}javascript:xImageOverOROut('menu_{1}_{2}','o'){0} OnClick={0}javascript:xNowShow('menu_{1}_{2}','{3}'){0}>&nbsp;&nbsp;{4}&nbsp;&nbsp;</td>", "\"", i, j, this.ResolveUrl(submenu.MenuUrl.Replace("\\", "\\\\")), submenu.MenuName);
                        sb_DownHTMLSrc.Append("\n");
                        if (j != subList.Count)
                            sb_DownHTMLSrc.AppendFormat("<td background={0}../images/BaseFramework/index/top-b4-b.gif{0}><img border={0}0{0} src={0}../images/BaseFramework/index/top-b4-c.gif{0} width={0}1{0} height={0}19{0}></td>", "\"");
                        j++;
                    }
                    if (j < i)
                    {
                        sb_DownHTMLSrc.AppendFormat("<td background={0}../images/BaseFramework/index/top-b4-b.gif{0}><img border={0}0{0} src={0}../images/BaseFramework/index/top-b4-c.gif{0} width={0}1{0} height={0}19{0}></td>", "\"");
                        for (int x = -1; x < i - j; x++)
                        {
                            sb_DownHTMLSrc.AppendFormat("<td background={0}../images/BaseFramework/index/top-b4-b.gif{0} width={0}1{0}></td><td background={0}../images/BaseFramework/index/top-b4-b.gif{0} align={0}center{0} width={0}92{0} class={0}topmenuoff2{0}>&nbsp;&nbsp;&nbsp;&nbsp;</td>", "\"");
                        }
                    }
                    sb_DownHTMLSrc.Append("<td><img border='0' src='../images/BaseFramework/index/top-b4-2.gif' width='5'></td><td></td></tr></table>");
                    i++;
                    TopMenuCount++;
                }
            }

        }
    }
}
