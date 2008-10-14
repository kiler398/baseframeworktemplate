using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easyasp.Framework.Core.Web.UI
{
    public class GridViewIDConverter : ControlIDConverter
    {
        // Methods
        protected override bool FilterControl(Control control)
        {
            return control is GridView;
        }
    }
}
