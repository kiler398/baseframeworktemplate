using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace Easyasp.Framework.Core.Web.UI
{
    [Serializable]
    public class LastNavigatePageInfo
    {
        private string lastNavigateUrl;
        private string orderByField;
        private bool orderByFieldIsDec;
        private Hashtable queryCondition;

        public LastNavigatePageInfo(HttpContext context)
        {
            this.lastNavigateUrl = context.Request.UrlReferrer.ToString();
            if (context.Items["QueryCondition"]!=null)
                queryCondition = (Hashtable)context.Items["QueryCondition"];
            if (context.Items["OrderByField"] != null)
                orderByField = (string)context.Items["OrderByField"];
            if (context.Items["OrderByFieldIsDec"] != null)
                orderByFieldIsDec = (bool)context.Items["OrderByFieldIsDec"];
        }

        public string LastNavigateUrl
        {
            get { return lastNavigateUrl; }
            set { lastNavigateUrl = value; }
        }

        public string OrderByField
        {
            get { return orderByField; }
            set { orderByField = value; }
        }

        public bool OrderByFieldIsDec
        {
            get { return orderByFieldIsDec; }
            set { orderByFieldIsDec = value; }
        }

        public Hashtable QueryCondition
        {
            get { return queryCondition; }
            set { queryCondition = value; }
        }
    }
}
