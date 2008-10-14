using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TestWebApp
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        [WebMethod]
        public static string GetName()
        {
            return System.DateTime.Now.ToString();
        }

        [WebMethod]
        public static void SetSesssion()
        {
            HttpContext.Current.Session["aaaa"] = "1111";
        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            this.Response.Write(Session["aaaa"]);
        }
    }
}
