using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemOperationDao : SystemOperationBaseDao
    {
        public SystemOperationDao()
        {
        }


        public List<SystemOperation> GetAllSystemBaseOperation()
        {
            DetachedCriteria operationCriteria = DetachedCriteria.For(typeof(SystemOperation));

            operationCriteria.Add(SystemOperationDao.PROPERTY_ISENABLE.Eq(true));

            operationCriteria.Add(SystemOperationDao.PROPERTY_ISSYSTEMOPERATION.Eq(true));

            operationCriteria.AddOrder(SystemOperationDao.PROPERTY_OPERATIONORDER.Asc());

            ISession session = this.DoGetSession(false);

            return this.FindListByDetachedCriteriaQuery(operationCriteria);

        }
    }
}
