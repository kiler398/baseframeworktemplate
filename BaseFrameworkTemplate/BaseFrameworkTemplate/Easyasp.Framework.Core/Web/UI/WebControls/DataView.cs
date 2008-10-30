using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using Wuqi.Webdiyer;

namespace Easyasp.Framework.Core.Web.UI.WebControls
{
    public class DataView : CompositeControl
    {
        private GridView masterTableView;
        private AspNetPager dataPager;

        [Browsable(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public GridView MasterTableView
        {
            get { return masterTableView; }
            set { masterTableView = value; }
        }
        [Browsable(true)]
        [TypeConverter(typeof(ExpandableObjectConverter))]
        [NotifyParentProperty(true)]
        public AspNetPager DataPager
        {
            get { return dataPager; }
            set { dataPager = value; }
        }

        protected override void CreateChildControls()
        {
            masterTableView = new GridView();
            dataPager = new AspNetPager();
            base.CreateChildControls();
        }
    }
}
