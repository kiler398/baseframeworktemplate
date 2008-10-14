using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;

namespace BaseManageFramework.Web.MainPage
{
    public partial class Left : System.Web.UI.Page
    {


        public SystemMenuService SystemMenuServiceInstance
        { set; get;
        }



            protected void Page_Load(object sender, EventArgs e)
            {
                if (this.Page.IsPostBack)
                    return;
                BindMenu();
            }


            /// <summary>
            /// 绑定主菜单
            /// </summary>
            private void BindMenu()
            {
                LeftMenu.DataSource = SystemMenuServiceInstance.GetTopMenu();
                LeftMenu.DataBind();
            }


            protected void LeftMenu_ItemDataBound(object sender, RepeaterItemEventArgs e)
            {
                if(e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
                {
                    SystemMenu mainMenu = (SystemMenu)e.Item.DataItem;
                    Repeater LeftSubID = (Repeater)e.Item.FindControl("LeftMenu_Sub");
                    LeftSubID.DataSource = SystemMenuServiceInstance.GetSubMenu(mainMenu);
                    LeftSubID.DataBind();
                }
            }
        }
    }

