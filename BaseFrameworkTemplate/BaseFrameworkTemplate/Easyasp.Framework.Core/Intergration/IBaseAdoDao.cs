using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Intergration
{
    public interface IBaseAdoDao<DomainType> : IGenericDao<DomainType>
    {
        string TableName { get; }

        string KeyName { get; }

        List<DomainType> DataTableToEntity(DataTable dt);

        List<DomainType> DataReaderToEntity(DbDataReader dr);

        void SetIDValueToEntity(DomainType domainType, object id);

        DomainType DataRowToEntity(DataRow dr);

        List<DomainType> DataRecordToEntity(DbDataRecord dr);

        DbCommand GetInsertCommand(DomainType domainType);

        DbCommand GetUpdateCommand(DomainType domainType);

        DbCommand GetLoadCommand(object ids);

        DbCommand GetDeleteCommand(object ids);

        DbCommand GetSelectIDCommand();

        DbCommand GetSelectAllCommand();
    }
}