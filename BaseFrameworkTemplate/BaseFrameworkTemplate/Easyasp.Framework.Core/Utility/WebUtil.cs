using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;

namespace Easyasp.Framework.Core.Utility
{
    public static class WebUtil
    {
        public static string GetRefrenceUrl()
        {
            return HttpContext.Current.Request.UrlReferrer.ToString();
        }

        public static T GetViewStateValue<T>(StateBag viewState, string propertyName, T defaultValue)
        {
            if (viewState[propertyName] == null)
            {
                viewState[propertyName] = defaultValue;
            }
            return (T)viewState[propertyName];
        }

        public static T GetViewStateValue<T>(StateBag viewState, string propertyName)
        {
            return GetViewStateValue<T>(viewState,propertyName, default(T));
        }

        public static T GetSessionValue<T>(string propertyName, T defaultValue)
        {
            if (HttpContext.Current.Session[propertyName] == null)
            {
                HttpContext.Current.Session[propertyName] = defaultValue;
            }
            return (T)HttpContext.Current.Session[propertyName];
        }

        public static T GetSessionValue<T>(string propertyName)
        {
            return GetSessionValue<T>(propertyName, default(T));
        }

        //public static T GetCookiesValue<T>(string propertyName, T defaultValue)
        //{
        //    if (HttpContext.Current.Request.Cookies["propertyName"] == null)
        //    {
        //        HttpContext.Current.Request.Cookies.Add(propertyName,defaultValue.ToString());
        //    }
        //    return (T)HttpContext.Current.Request.Cookies["propertyName"];
        //}

        //public static T GetCookiesValue<T>(string propertyName)
        //{
        //    return GetCookiesValue<T>(propertyName, default(T));
        //}



    }
}
