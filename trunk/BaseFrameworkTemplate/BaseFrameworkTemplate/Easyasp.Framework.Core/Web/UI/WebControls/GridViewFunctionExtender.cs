using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Easyasp.Framework.Core.Web.UI.WebControls
{
    public class GridViewFunctionExtender : Control
    {
        /// <summary>
        /// The GridView that is extended.
        /// </summary>
        [DefaultValue("")]
        [IDReferenceProperty(typeof(GridView))]
        [TypeConverter(typeof(GridViewIDConverter))]
        [Description("The GridView that is extended.")]
        public string ExtendedID
        {
            get { return this.ViewState["ExtendedID"] != null ? (string)this.ViewState["Extendee"] : ""; }
            set { this.ViewState["ExtendedID"] = value; }
        }

        private GridView extendedGirdView;


        protected override void OnInit(EventArgs e)
        {
            extendedGirdView = (GridView)this.Page.FindControl("ExtendedID");
            base.OnInit(e);
        }
    }
}
