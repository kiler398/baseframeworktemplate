using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Utility
{
    /// <summary>
    /// DataSet帮助类
    /// </summary>
    public static class DataSetUtil
    {
        public static string DataSetToExcelString(DataSet ds)
        {
            return "";
        }
        /// <summary>
        /// 将DataSet转化为CVS格式内容
        /// </summary>
        /// <param name="ds">DataSet</param>
        /// <returns>CVS格式内容</returns>
        public static string DataSetToCVSString(DataSet ds)
        {
            StringBuilder stringBuilderCVSString = new StringBuilder();
            //输出列头
            foreach (DataColumn dataColumn in ds.Tables[0].Rows)
            {
                stringBuilderCVSString.AppendFormat("{0}\t", dataColumn.ColumnName);
            }
            stringBuilderCVSString.Append("\n");
            //输出数据内容
            foreach (DataRow dataRow in ds.Tables[0].Rows)
            {
                foreach (DataColumn dataColumn in ds.Tables[0].Rows)
                {
                    stringBuilderCVSString.AppendFormat("{0}\t", dataRow[dataColumn.ColumnName]);
                }
            }
            return stringBuilderCVSString.ToString();
        }
        public static void DataSetClearNullData(ref DataSet ds)
        {
            return;
        }
    }
}
