using System;
using System.Collections;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Web;

namespace PhotoWeb.Appclass
{
    public class AdoDataBase
    {
        private static readonly SortedList<string,AdoDataBase> dataBases;

        public static SortedList<string, AdoDataBase> DataBases
        {
            get { return dataBases; }
        }

        static AdoDataBase()
        {
            dataBases = new SortedList<string,AdoDataBase>();
            foreach (ConnectionStringSettings connectionStringSetting in ConfigurationManager.ConnectionStrings)
            {
                dataBases.Add(connectionStringSetting.Name, new AdoDataBase(connectionStringSetting.ConnectionString, connectionStringSetting.ProviderName));
            }
        }

        private string connectionstring;
        private string ProviderName;
        private DbProviderFactory dbFactory;


        public string Connectionstring
        {
            get { return connectionstring; }
        }

        public string ProviderName1
        {
            get { return ProviderName; }
        }

        public DbProviderFactory DbFactory
        {
            get { return dbFactory; }
        }

        public AdoDataBase(string connectionstring, string providerName)
        {
            this.connectionstring = connectionstring;
            ProviderName = providerName;
            dbFactory = DbProviderFactories.GetFactory(providerName); 
        }

        public DbParameter CreateDbParameter(string name,DbType type,ParameterDirection direction,int size,object value)
        {
            DbParameter dbParameter = dbFactory.CreateParameter();
            dbParameter.ParameterName = name;
            dbParameter.DbType = type;
            dbParameter.Direction = direction;
            if(size!=int.MinValue)
                dbParameter.Size = size;
            if (value!=null)
                dbParameter.Value = value;
            return dbParameter;
        }

        public DbParameter CreateDbParameter(string name, DbType type, int size, object value)
        {
            return CreateDbParameter(name, type, ParameterDirection.Input, size, value);
        }

        public DbParameter CreateInDbParameter(string name, DbType type, object value)
        {
            return CreateDbParameter(name, type, ParameterDirection.Input, int.MinValue, value);
        }

        public DbParameter CreateInDbParameter(string name, object value)
        {
            return CreateDbParameter(name, DbType.String, ParameterDirection.Input, int.MinValue, value);
        }

        public DbParameter CreateOutDbParameter(string name, DbType type)
        {
            return CreateDbParameter(name, type, ParameterDirection.Output, int.MinValue, null);
        }

        public void ExecuteNonQuery(string commandText, CommandType commandType, List<DbParameter> dbParameters)
        {
            using(DbConnection dbConnection = dbFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionstring;
                dbConnection.Open();
                using (DbCommand cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = dbConnection;
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(dbParameters.ToArray());
                    cmd.ExecuteNonQuery();
                }
                dbConnection.Close();
            }
        }

        public DataSet ExecuteDataSet(string commandText, CommandType commandType, List<DbParameter> dbParameters)
        {
            DataSet ds = new DataSet();
            using (DbConnection dbConnection = dbFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionstring;
                dbConnection.Open();
                using (DbCommand cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = dbConnection;
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(dbParameters.ToArray());
                    using(DbDataAdapter dbDataAdapter = dbFactory.CreateDataAdapter())
                    {
                        dbDataAdapter.SelectCommand = cmd;
                        dbDataAdapter.Fill(ds);
                    }
                }
                dbConnection.Close();
            }
            return ds;
        }

        public DataSet ExecutePageDataSet(string commandText, CommandType commandType, int startIndex, int maxRecrod, List<DbParameter> dbParameters)
        {
            DataSet ds = new DataSet();
            using (DbConnection dbConnection = dbFactory.CreateConnection())
            {
                dbConnection.ConnectionString = connectionstring;
                dbConnection.Open();
                using (DbCommand cmd = dbFactory.CreateCommand())
                {
                    cmd.Connection = dbConnection;
                    cmd.CommandText = commandText;
                    cmd.CommandType = commandType;
                    cmd.Parameters.AddRange(dbParameters.ToArray());
                    using (DbDataAdapter dbDataAdapter = dbFactory.CreateDataAdapter())
                    {
                        dbDataAdapter.SelectCommand = cmd;
                        dbDataAdapter.Fill(ds,startIndex,maxRecrod,"result");
                    }
                }
                dbConnection.Close();
            }
            return ds;
        }







    }
}
