using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemMoudleDao : SystemMoudleBaseDao
    {
        public SystemMoudleDao()
        {
        }


        public SystemMoudle FindMoudleByName(string moudleName)
        {
            if (moudleName == null)
                throw new ArgumentNullException("moudleName", "moudleName not allow null.");

            DetachedCriteria queryCriteria = DetachedCriteria.For(typeof(SystemMoudle));

            //最大序号的菜单
            queryCriteria.Add(SystemMoudleDao.PROPERTY_MOUDLENAMECN.Eq(moudleName));

            List<SystemMoudle> listQuery = this.FindListByDetachedCriteriaQuery(queryCriteria);

            if (listQuery.Count <= 0)
                return null;
            else
                return listQuery[0];
        }

    }
}
