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
    public class SystemApplicationDao : SystemApplicationBaseDao
    {
        public SystemApplicationDao()
        {
        }

        public List<SystemApplication> FindedApplicationsByName(string name)
        {

            var criterions = new List<ICriterion> { SystemApplicationDao.PROPERTY_SYSTEMAPPLICATIONNAME.Eq(name) };
            List<SystemApplication> applications = FindAll(criterions.ToArray());
 
                return applications;
 
            
        }
    }
}
