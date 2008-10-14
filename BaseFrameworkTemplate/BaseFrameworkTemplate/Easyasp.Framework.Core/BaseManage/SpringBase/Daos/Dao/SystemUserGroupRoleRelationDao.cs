using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemUserGroupRoleRelationDao : SystemUserGroupRoleRelationBaseDao
    {
        public SystemUserGroupRoleRelationDao()
        {
        }

        public List<SystemRole> GetUserGroupAssignedRole(SystemUserGroup systemUserGroup)
        {
            List<SystemUserGroupRoleRelation> listSystemUserGroupRoleRelation =
                GetSystemUserGroupRoleRelationByUserGroup(systemUserGroup);

            List<SystemRole> assignRoles = new List<SystemRole>();
            foreach (SystemUserGroupRoleRelation relation in listSystemUserGroupRoleRelation)
            {
                assignRoles.Add(relation.RoleID);
            }

            return assignRoles;
        }

        public List<SystemUserGroupRoleRelation> GetSystemUserGroupRoleRelationByUserGroup(SystemUserGroup systemUserGroup)
        {
            List<ICriterion> criterions = new List<ICriterion>();
            criterions.Add(SystemUserGroupRoleRelationDao.PROPERTY_USERGROUPID.Eq(systemUserGroup));

            return this.FindAll(criterions.ToArray());
        }
    }
}
