using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;

namespace Easyasp.Framework.Core.BaseManage
{
    public class BaseWebPage : System.Web.UI.Page
    {
        public SystemUserService SystemUserServiceInstance
        {
            get;
            set;
        }

        //public SystemUser CurrentLoginUser
        //{
        //    get
        //    {
        //        if(this.Context.User == null)
        //            return null;
        //        else
        //        {
        //            if(this.Session["CurrentLoginUser"]==null)
        //            {
        //                this.Session["CurrentLoginUser"]=SystemUserServiceInstance.GetUserByLoginID()
        //            }
        //        }
        //    }
        //}

    }
}
