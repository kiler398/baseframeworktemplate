using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.BaseManage;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using NHibernate.Dialect;
using Spring.Context;
using Spring.Context.Support;
using Spring.Web.Support;

namespace BaseManageFramework.Web
{
    public partial class _Default : System.Web.UI.Page
    {
        //public SystemApplicationService SystemApplicationServiceIocID { get; set; }
        //public NhibernateDeployHelper DeployHelper { get; set; }

        protected void Page_Load(object sender, EventArgs e)
        {
            //IApplicationContext ctx = ContextRegistry.GetContext();
            ////WebApplicationContext sp = this.Context as WebApplicationContext;
            //if (ctx != null)
            //    this.Response.Write(ctx.ToString());
            //SQLiteDialect dialect = new SQLiteDialect();
            //this.Response.Write(DeployHelper.GenerateSchemaCreationScript(dialect));

            //MsSql2000Dialect dialect = new MsSql2000Dialect();

            //this.Response.Write(NhibernateDeployHelper.GenerateSchemaCreationScript(dialect));
        }
    }
}
