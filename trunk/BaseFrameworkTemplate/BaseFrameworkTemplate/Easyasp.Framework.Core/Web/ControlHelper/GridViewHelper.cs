using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace Easyasp.Framework.Core.Web.ControlHelper
{
    /// <summary>
    /// GridView帮助类
    /// </summary>
    public static class GridViewHelper
    {
        /// <summary>
        /// 通过控件ID在指定行内查找指定类型的控件
        /// </summary>
        /// <typeparam name="T">控件类型</typeparam>
        /// <param name="controlid">控件ID</param>
        /// <param name="row">GridView列</param>
        /// <returns>控件</returns>
        public static T FindTypedControlInRow<T>(string controlid, GridViewRow row) where T : Control
        {
            Control c = FindControlInRow(controlid, row);
            if(c != null)
            {
                return (T)c;
            }
            return default(T);
        }
        /// <summary>
        /// 通过控件ID在指定行内查找指定类型的控件
        /// </summary>
        /// <param name="controlid">控件ID</param>
        /// <param name="row">GridView列</param>
        /// <returns>控件</returns>
        public static Control FindControlInRow(string controlid, GridViewRow row)
        {
            foreach (TableCell cell in row.Cells)
            {
                Control c = cell.FindControl(controlid);
                if (c != null)
                {
                    return (Control)c;
                }
            }
            return null;
        }

        /// <summary>
        /// 查找RowCommand事件里包含的GridView行的ID信息
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns>ID</returns>
        public static int GetDataKeyInGridViewRowCommandEvent(object sender, GridViewCommandEventArgs e)
        {
            GridView grd = (GridView)sender;
            GridViewRow row = GetRowInGridViewRowCommandEvent(sender,e);
            return int.Parse(grd.DataKeys[GetRowInGridViewRowCommandEvent(sender,e).RowIndex].Value.ToString());
        }

        /// <summary>
        /// 查找RowCommand事件里包含的GridViewRow
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static GridViewRow GetRowInGridViewRowCommandEvent(object sender, GridViewCommandEventArgs e)
        {
            GridView grd = (GridView)sender;
            return ((Control)(e.CommandSource)).Parent.Parent as GridViewRow;
        }
        /// <summary>
        /// 检查GridView里面是否含有数据列
        /// </summary>
        /// <param name="gridView">GridView实例</param>
        /// <returns></returns>
        public static bool CheckGridViewHasDataRow(GridView gridView)
        {
            if (gridView.Rows.Count == 0)
            {
                return false;
            }
            else if (gridView.Rows.Count == 1)
            {
                return
                    !((gridView.Rows[0].Cells.Count == 1) &&
                      (gridView.Rows[0].Cells[0].ColumnSpan == gridView.Columns.Count));
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 查找GridView列里面指定的控件是否包含值
        /// </summary>
        /// <param name="gridView"></param>
        /// <param name="controlID"></param>
        /// <param name="controlValue"></param>
        /// <returns></returns>
        public static GridViewRow FindRowByControlsValue(GridView gridView, string controlID, string controlValue)
        {
            //没有数据列返回空
            if (!CheckGridViewHasDataRow(gridView))
            {
                return null;
            }
            foreach (GridViewRow row in gridView.Rows)
            {
                Control c = FindControlInRow(controlID, row);

                if (c != null && controlValue.Trim() == ControlHelper.GetControlValue(c).Trim())
                    return row;
            }
            return null;
        }

        public static List<int> GetSelectRowIndexs(GridView gridView, string selectCheckBoxControlID)
        {
            List<int> selectIndex = new List<int>();
            //没有数据类直接返回。
            if (!CheckGridViewHasDataRow(gridView))
            {
                return selectIndex;
            }
            foreach (GridViewRow gridViewRow in gridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    Control chk = FindControlInRow(selectCheckBoxControlID,
                                                   gridViewRow);
                    if (chk is CheckBox)
                    {
                        CheckBox wchk = (CheckBox)chk;
                        if (wchk.Checked)
                            selectIndex.Add(gridViewRow.RowIndex);
                    }
                    else if (chk is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox hchk = (HtmlInputCheckBox)chk;
                        if (hchk.Checked)
                            selectIndex.Add(gridViewRow.RowIndex);
                    }
                }
            }
            return selectIndex;
        }

        public static List<int> GetSelectDataKeys(GridView gridView, string selectCheckBoxControlID)
        {
            List<int> selectDataKeys = new List<int>();
            //没有数据类直接返回。
            if (!CheckGridViewHasDataRow(gridView))
            {
                return selectDataKeys;
            }
            foreach (GridViewRow gridViewRow in gridView.Rows)
            {
                if (gridViewRow.RowType == DataControlRowType.DataRow)
                {
                    Control chk = FindControlInRow(selectCheckBoxControlID,
                                                   gridViewRow);
                    if (chk is CheckBox)
                    {
                        CheckBox wchk = (CheckBox)chk;
                        if (wchk.Checked)
                            selectDataKeys.Add(int.Parse(gridView.DataKeys[gridViewRow.RowIndex].ToString()));
                    }
                    else if (chk is HtmlInputCheckBox)
                    {
                        HtmlInputCheckBox hchk = (HtmlInputCheckBox)chk;
                        if (hchk.Checked)
                            selectDataKeys.Add(int.Parse(gridView.DataKeys[gridViewRow.RowIndex].ToString()));
                    }
                }
            }
            return selectDataKeys;
        }


        public static string GenerateSelectAllCheckBoxScript(string gridViewID)
        {
            string script =
                @"<script type='text/javascript'>
    function $GridViewIDCheckAll(oCheckbox)
     {
       var GridView1 = document.getElementById('$GridViewID');
           for(i = 1;i < GridView1.rows.length; i++)
           {
            GridView1.rows[i].cells[0].getElementsByTagName('INPUT')[0].checked = oCheckbox.checked & !GridView1.rows[i].cells[0].getElementsByTagName('INPUT')[0].isDisabled;
           }
      }
    </script>";

            script = script.Replace("$GridViewID", gridViewID);

            return script;
        }


        public static void RegisterGridViewSelectAllCheckBoxScript(Page page,GridView gridView,string chkSelectAllID)
        {

            if(!page.ClientScript.IsStartupScriptRegistered(page.GetType(),gridView.ClientID+"SelectAll"))
            {
                string regscript = GenerateSelectAllCheckBoxScript(gridView.ClientID);
                page.ClientScript.RegisterStartupScript(page.GetType(), gridView.ClientID + "SelectAll", regscript);

                Control chk = FindControlInRow(chkSelectAllID, gridView.HeaderRow);

                if (chk is CheckBox)
                {
                    ((CheckBox)chk).Attributes["onclick"] =
                    gridView.ClientID + "CheckAll(this)";
                }
                else if (chk is HtmlInputCheckBox)
                {
                    ((HtmlInputCheckBox)chk).Attributes["onclick"] =
                    gridView.ClientID + "CheckAll(this)";
                }
            }
        }






    }
}
