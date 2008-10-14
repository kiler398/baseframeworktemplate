using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Easyasp.Framework.Core.Web.ControlHelper
{
    public static class ControlHelper
    {
        public static string GetControlValue(Control c)
        {
            if (c is TextBox)
            {
                return ((TextBox)c).Text.Trim();
            }
            if (c is HtmlInputText)
            {
                return ((HtmlInputText)c).Value.Trim();
            }
            if (c is HtmlTextArea)
            {
                return ((HtmlTextArea)c).Value.Trim();
            }
            if (c is HiddenField)
            {
                return ((HiddenField)c).Value.Trim();
            }
            if (c is Label)
            {
                return ((Label)c).Text.Trim();
            }
            if (c is HtmlInputHidden)
            {
                return ((HtmlInputHidden)c).Value.Trim();
            }
            throw new Exception("unknow control type!");
        }



    }
}
