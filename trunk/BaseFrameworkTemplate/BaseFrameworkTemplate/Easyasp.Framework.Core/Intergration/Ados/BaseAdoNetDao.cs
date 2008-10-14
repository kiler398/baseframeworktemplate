using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using Microsoft.Practices.EnterpriseLibrary.Data;

namespace Easyasp.Framework.Core.Intergration.Ados
{
    public abstract class BaseAdoNetDao<DomainType>
    {
        protected Database currentDataBase;

        protected abstract Database AdoDataBase
        {
            get;
        }

        protected abstract string TableName
        {
            get;
        }

        protected abstract string KeyName
        {
            get;
        }

        public abstract List<DomainType> DataTableToEntity(DataTable dt);

        public abstract void SetIDValueToEntity(DomainType domainType, object id);

        public abstract DomainType DataRowToEntity(DataRow dr);

        public abstract DbCommand GetInsertCommand(DomainType domainType);

        public abstract DbCommand GetUpdateCommand(DomainType domainType);

        public abstract DbCommand GetLoadCommand(object ids);

        public abstract DbCommand GetDeleteCommand(object ids);

        public abstract DbCommand GetSelectIDCommand();

        public abstract DbCommand GetSelectAllCommand();

        /// <summary>
        /// 增加一条数据
        /// </summary>
        public virtual void Create(DomainType domainType)
        {
            //执行SQL语句
            this.AdoDataBase.ExecuteNonQuery(GetInsertCommand(domainType));
            //查找ID
            object id = this.AdoDataBase.ExecuteScalar(GetSelectIDCommand());
            //ID的值赋给实体
            SetIDValueToEntity(domainType, id);
        }

        /// <summary>
        /// 更新一条数据
        /// </summary>
        public virtual void Update(DomainType domainType)
        {
            //执行SQL语句
            this.AdoDataBase.ExecuteNonQuery(GetUpdateCommand(domainType));
        }

        /// <summary>
        /// 删除一条数据
        /// </summary>
        public virtual void Delete(object id)
        {
            this.AdoDataBase.ExecuteNonQuery(GetDeleteCommand(id));
        }

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public virtual DomainType Load(object id)
        {
            DataSet ds = this.AdoDataBase.ExecuteDataSet(this.GetLoadCommand(id));
            List<DomainType> list = this.DataTableToEntity(ds.Tables[0]);
            if (list != null && list.Count > 0)
                return list[0];
            else
                return default(DomainType);
        }

        /// <summary>
        /// 查询出所有的数据
        /// </summary>
        /// <returns></returns>
        public virtual List<DomainType> SelectAll()
        {
            DataSet ds = this.AdoDataBase.ExecuteDataSet(this.GetSelectAllCommand());
            return this.DataTableToEntity(ds.Tables[0]);
        }

        /// <summary>
        /// 获得数据列表
        /// </summary>
        public virtual List<DomainType> GetList(int pageIndex, int pageSize, string strWhere, string orderBy, out int recordCount)
        {
            DataTable dt =
                GetPageDataSet(pageIndex, pageSize, this.KeyName, "*", this.TableName, strWhere, orderBy, out recordCount);
            List<DomainType> list = this.DataTableToEntity(dt);
            return list;
        }


        protected virtual DataTable GetPageDataSet(int pageIndex, int pageSize, string keyField, string showFieldString, string tableName, string whereString, string orderString, out int recordCount)
        {
            if (pageIndex < 1) pageIndex = 1;
            if (pageSize < 1) pageSize = 10;
            if (string.IsNullOrEmpty(showFieldString))
                whereString = " * ";
            if (string.IsNullOrEmpty(whereString))
                whereString = " ";
            if (string.IsNullOrEmpty(orderString) && !string.IsNullOrEmpty(keyField))
                orderString = " " + keyField + " desc";

            string countSql = string.Format(" SELECT COUNT(*) FROM {0} {1}", tableName, whereString);

            DbCommand cmdCount = this.AdoDataBase.GetSqlStringCommand(countSql);

            recordCount = Convert.ToInt32(this.AdoDataBase.ExecuteScalar(cmdCount));

            string selectSql = string.Format(" SELECT TOP {0} {1} FROM {2} {3} {4}", (pageIndex * pageSize).ToString(), showFieldString, tableName, whereString, orderString);

            DbCommand cmdSelectRecord = this.AdoDataBase.GetSqlStringCommand(selectSql);


            DbDataAdapter da = this.AdoDataBase.GetDataAdapter();

            cmdSelectRecord.Connection = this.AdoDataBase.CreateConnection();

            if (cmdSelectRecord.Connection.State != ConnectionState.Open)
            {
                cmdSelectRecord.Connection.Open();
            }

            da.SelectCommand = cmdSelectRecord;

            DataSet ds = new DataSet();

            da.Fill(ds, pageSize * (pageIndex - 1), pageSize, tableName);


            if (cmdSelectRecord.Connection.State == ConnectionState.Open)
            {
                cmdSelectRecord.Connection.Close();
            }

            return ds.Tables[0];

        }

        public virtual List<DomainType> GetList(string whereString, string orderString)
        {
            string sql = string.Format(" SELECT * FROM {0} {1} {2}", this.TableName, whereString, orderString);
            DbCommand cmdSelectRecord = this.AdoDataBase.GetSqlStringCommand(sql);
            DataSet ds = new DataSet();
            this.AdoDataBase.LoadDataSet(cmdSelectRecord, ds, this.TableName);
            List<DomainType> list = this.DataTableToEntity(ds.Tables[0]);
            return list;
        }

        public virtual void UpdatePartProperty(DomainType outdomain, object id, string[] partPropertyNameList)
        {
            DomainType domain = Load(id);
            Type t = typeof(DomainType);
            foreach (string propertyName in partPropertyNameList)
            {
                PropertyInfo setPropertyInfo = t.GetProperty(propertyName);
                setPropertyInfo.SetValue(domain, setPropertyInfo.GetValue(outdomain, null), null);
            }
            Update(domain);
        }


        /// <summary>
        /// 查询数据
        /// </summary>
        public virtual DataSet GetDataSet(string sql)
        {

            return GetDataSet(sql, GetNewDataParameterList());
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        public virtual DataSet GetDataSet(string sql, List<IDbDataParameter> parameters)
        {

            return this.AdoDataBase.ExecuteDataSet(GetCommandBySqlAndParameterList(sql, parameters));
        }
        /// <summary>
        /// 分页查询数据表
        /// </summary>
        public virtual DataSet GetDataSet(int pageSize, int pageIndex, string tableName, string sql)
        {
            return GetDataSet(pageSize, pageIndex, tableName, sql, GetNewDataParameterList());
        }

        /// <summary>
        /// 分页查询数据表
        /// </summary>
        public virtual DataSet GetDataSet(int pageSize, int pageIndex, string tableName, string sql, List<IDbDataParameter> parameters)
        {
            DbCommand cmdSelectRecord = GetCommandBySqlAndParameterList(sql, parameters);

            DbDataAdapter da = this.AdoDataBase.GetDataAdapter();

            DataSet ds = new DataSet();

            da.Fill(ds, pageSize * (pageIndex - 1), pageSize, tableName);

            return ds;
        }


        /// <summary>
        /// 检索单个值
        /// </summary>
        public virtual object GetScalarData(string sql)
        {
            return GetScalarData(sql, GetNewDataParameterList());
        }


        /// <summary>
        /// 检索单个值
        /// </summary>
        public virtual object GetScalarData(string sql, List<IDbDataParameter> parameters)
        {
            return this.AdoDataBase.ExecuteScalar(GetCommandBySqlAndParameterList(sql, parameters));
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        public virtual void ExcuteSql(string sql)
        {
            ExcuteSql(sql, GetNewDataParameterList());
        }

        /// <summary>
        /// 执行SQL语句
        /// </summary>
        public virtual void ExcuteSql(string sql, List<IDbDataParameter> parameters)
        {
            this.AdoDataBase.ExecuteNonQuery(GetCommandBySqlAndParameterList(sql, parameters));
        }

        /// <summary>
        /// 执行存储过程
        /// </summary>
        /// <param name="procName"></param>
        /// <param name="parameters"></param>
        public virtual void ExcuteProc(string procName, params object[] parameters)
        {
            this.AdoDataBase.ExecuteNonQuery(procName, parameters);
        }

        protected void AddParameterToCmmand(DbCommand cmd, IDbDataParameter parameter)
        {
            this.AdoDataBase.AddParameter(cmd, parameter.ParameterName, parameter.DbType, parameter.Size, parameter.Direction, parameter.IsNullable, parameter.Precision, parameter.Scale, parameter.SourceColumn, parameter.SourceVersion, parameter.Value);
        }
        protected DbCommand GetCommandBySqlAndParameterList(string sql, List<IDbDataParameter> parameters)
        {
            DbCommand cmd = this.AdoDataBase.GetSqlStringCommand(sql);
            foreach (IDbDataParameter parameter in parameters)
            {
                AddParameterToCmmand(cmd, parameter);
            }
            return cmd;
        }


        protected DomainType GetSingleEntityFromDataSet(DataSet ds)
        {
            if (ds.Tables[0].Rows.Count == 0)
                return default(DomainType);
            else
                return this.DataRowToEntity(ds.Tables[0].Rows[0]);
        }

        protected List<IDbDataParameter> GetNewDataParameterList()
        {
            List<IDbDataParameter> list = new List<IDbDataParameter>();
            return list;
        }
    }
}
