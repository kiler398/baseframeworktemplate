using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using Easyasp.Framework.Core.Intergration.EventHandles;
using Easyasp.Framework.Core.Intergration.Springs;
using Easyasp.Framework.Core.Web.ControlHelper;

namespace Easyasp.Framework.Core.Intergration.BaseWebPage
{
    public abstract class BaseDataManagePage<DomainType> : System.Web.UI.Page
    {
        public event LoadDataFailedEventHandler LoadDataFailed;
        public event OperationFailedEventHandler OperationFailed;
        public event OperationSuccessedEventHandler OperationSuccessed;
        public event OperationSingleSelectDataEventHandler OperationSingleSelectData;
        public event OperationMultiSelectDataEventHandler OperationMultiSelectData;
        public event OperationSingleSelectDataEventHandler GridViewRowCommand;
        public event OperationSingleSelectDataEventHandler ButtonCommand;

        protected virtual void OnLoadDataFailed(MessageEventArgs e)
        {
            if (LoadDataFailed != null)
            {
                LoadDataFailed(this, e);
            }
        }

        protected virtual void OnOperationFailed(MessageEventArgs e)
        {
            if (OperationFailed != null)
            {
                OperationFailed(this, e);
            }
        }

        protected virtual void OnOperationSuccessed(MessageEventArgs e)
        {
            if (OperationSuccessed != null)
            {
                OperationSuccessed(this, e);
            }
        }

        protected virtual void OnOperationSingleSelectData(SelectDataEventArgs e)
        {
            if (OperationSingleSelectData != null)
            {
                OperationSingleSelectData(this, e);
            }
        }

        protected virtual void OnOperationMultiSelectData(SelectDataEventArgs e)
        {
            if (OperationMultiSelectData != null)
            {
                OperationMultiSelectData(this, e);
            }
        }


        protected virtual void GridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (GridViewRowCommand != null)
            {
                SelectDataEventArgs se = new SelectDataEventArgs();
                se.CommandName = e.CommandName;
                List<int> ids = new List<int>();
                ids.Add(GridViewHelper.GetDataKeyInGridViewRowCommandEvent(sender, e));
                se.SelectIDs = new List<int>();
                GridViewRowCommand(this, se);
            }
        }

        //protected void CommandButton_Click(object sender, EventArgs e)
        //{
        //    if (sender is Button)
        //    {
        //        CommandButtonEventArgs<int> cbe = new CommandButtonEventArgs<int>();
        //        cbe.CommandName = ((Button)sender).CommandName;
        //        ButtonCommand(sender, cbe);

        //    }
        //    else if (sender is HtmlInputButton)
        //    {

        //    }
        //}


        public BaseSpringNHibernateService<DomainType> SelfServiceIocID { get; set; }
    }
}
