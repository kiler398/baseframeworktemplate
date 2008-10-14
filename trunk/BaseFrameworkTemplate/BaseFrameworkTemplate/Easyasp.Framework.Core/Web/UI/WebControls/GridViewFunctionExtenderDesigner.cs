using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.Design;

namespace Easyasp.Framework.Core.Web.UI.WebControls
{
    /// <summary>
    /// Designer for <see cref="GridViewFunctionExtender"/>.
    /// </summary>
    public class GridViewFunctionExtenderDesigner : ControlDesigner
    {
        public override string GetDesignTimeHtml()
        {
            return "<div style=\"background-color: #C8C8C8; border: groove 2 Gray;\"><b>GridViewFunctionExtender</b> - " + this.Component.Site.Name + "</div>";
        }
    }
}
