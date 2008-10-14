using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.BaseDomain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemRoleDao : SystemRoleBaseDao
    {
        public SystemRoleDao()
        {
        }
        /// <summary>
        /// 获取用户分配的角色
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>分配的角色</returns>
        public List<SystemRole> GetUserAssignRole(SystemUser user)
        {
            DetachedCriteria userAssignedRoleRelation = DetachedCriteria.For(typeof(SystemUserRoleRelation));
            userAssignedRoleRelation.Add(SystemUserRoleRelationBaseDao.PROPERTY_USERID.Eq(user));

            DetachedCriteria userAssignedRole = DetachedCriteria.For(typeof(SystemRole));
            userAssignedRole.Add(
                Subqueries.PropertyIn(SystemUserRoleRelationBase.PROPERTY_NAME_ROLEID, userAssignedRoleRelation));
            return ConvertToTypedList(userAssignedRole.GetExecutableCriteria(this.DoGetSession(false)).List<SystemRole>());
        }
        /// <summary>
        /// 通过角色名获取角色
        /// </summary>
        /// <param name="roleName">角色名</param>
        /// <returns>角色</returns>
        public SystemRole GetRoleByName(string roleName)
        {
            DetachedCriteria rolequery = DetachedCriteria.For(typeof(SystemRole));
            rolequery.Add(PROPERTY_ROLENAME.Eq(roleName));
            return rolequery.GetExecutableCriteria(this.DoGetSession(false)).SetMaxResults(1).UniqueResult<SystemRole>();
        }
    }
}
