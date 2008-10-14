using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemRoleMenuRelationDao : SystemRoleMenuRelationBaseDao
    {
        public SystemRoleMenuRelationDao()
        {
        }
        /// <summary>
        /// 获取角色分配的菜单
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns>分配的菜单</returns>
        public List<SystemRoleMenuRelation> GetRoleMenuRelationAssignedApplicaton(SystemRole role)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemRoleMenuRelationDao.PROPERTY_ROLEID.Eq(role));
            return this.FindAll(criterions.ToArray());
        }
    }
}
