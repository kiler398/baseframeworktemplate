using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Utility
{
    /// <summary>
    /// 安全数据读取帮助类，在处理数据读取时考虑到Null,自动将Null值转化为指定的默认值。
    /// </summary>
    public static class SafeReaderUtil
    {
        /// <summary>
        /// 安全的读取DataRow的值
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="dr">DataRow</param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>安全值</returns>
        public static T SafeReaderValueFromDataRow<T>(DataRow dr, string columnName, T defaultValue)
        {
            if (dr[columnName] == System.DBNull.Value)
                return defaultValue;
            else
                return (T)dr[columnName];
        }
        /// <summary>
        /// 安全的读取DataRow的值
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="dr">DataRow</param>
        /// <param name="columnName">列名</param>
        /// <returns>安全值</returns>
        public static T SafeReaderValueFromDataRow<T>(DataRow dr, string columnName)
        {
            return SafeReaderValueFromDataRow<T>(dr, columnName, default(T));
        }

        /// <summary>
        /// 安全读取DataReader的数据
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="dr">DbDataReader</param>
        /// <param name="columnName">列名</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>安全值</returns>
        public static T SafeReaderValueFromDataReader<T>(DbDataReader dr, string columnName, T defaultValue)
        {
            if (dr.IsDBNull(dr.GetOrdinal(columnName)))
                return defaultValue;
            else
                return (T)dr[columnName];
        }

        /// <summary>
        /// 安全读取DataReader的数据
        /// </summary>
        /// <typeparam name="T">字段类型</typeparam>
        /// <param name="dr">DbDataReader</param>
        /// <param name="columnName">列名</param>
        /// <returns>安全值</returns>
        public static T SafeReaderValueFromDataReader<T>(DbDataReader dr, string columnName)
        {
            return SafeReaderValueFromDataReader<T>(dr, columnName, default(T));
        }

        /// <summary>
        /// 安全的读取可空类型的值
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="inputValue">可空类型</param>
        /// <param name="defaultValue">默认值</param>
        /// <returns>安全值</returns>
        public static T SafeReaderValueFromEntityNullablePorperty<T>(T? inputValue, T defaultValue) where T : struct
        {
            if (inputValue==null)
                return defaultValue;
            else
                return (T)inputValue;            
        }

        /// <summary>
        /// 安全的读取可空类型的值
        /// </summary>
        /// <typeparam name="T">数据类型</typeparam>
        /// <param name="inputValue">可空类型</param>
        /// <returns>安全值</returns>
        public static T SafeReaderValueFromEntityNullablePorperty<T>(T? inputValue) where T : struct
        {
            return SafeReaderValueFromEntityNullablePorperty<T>(inputValue, default(T));
        }




    }
}
