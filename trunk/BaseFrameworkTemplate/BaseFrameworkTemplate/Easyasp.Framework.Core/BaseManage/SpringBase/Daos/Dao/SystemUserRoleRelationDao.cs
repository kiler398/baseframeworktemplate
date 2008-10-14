using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemUserRoleRelationDao : SystemUserRoleRelationBaseDao
    {
        public SystemUserRoleRelationDao()
        {
        }
        public List<SystemRole> GetUserAssignRole(SystemUser user)
        {
            var criterions = new List<ICriterion> { PROPERTY_USERID.Eq(user) };
            List<SystemUserRoleRelation> listSystemUserRoleRelation = FindAll(criterions.ToArray());
            var assignRoles = new List<SystemRole>();
            foreach (SystemUserRoleRelation relation in listSystemUserRoleRelation)
            {
                this.InitializeLazyProperties(relation);
                assignRoles.Add(relation.RoleID);
            }
            return assignRoles;
        }


        public SystemUserRoleRelation GetUserRoleRelation(SystemUser user, SystemRole role)
        {
            DetachedCriteria criterions = DetachedCriteria.For(typeof(SystemUserRoleRelation));
            criterions.Add(PROPERTY_USERID.Eq(user));
            criterions.Add(PROPERTY_ROLEID.Eq(role));
            return criterions.GetExecutableCriteria(this.DoGetSession(false)).SetMaxResults(1).UniqueResult<SystemUserRoleRelation>();
        }

        public List<SystemUserRoleRelation> GetSystemUserRoleRelationByRole(SystemRole role)
        {
            DetachedCriteria criterions = DetachedCriteria.For(typeof(SystemUserRoleRelation));
            criterions.Add(SystemUserRoleRelationDao.PROPERTY_ROLEID.Eq(role));

            return this.FindListByDetachedCriteriaQuery(criterions);
        }


        public List<SystemUserRoleRelation> GetSystemUserRoleRelationByRoleUserNameSearch(SystemRole role, string userNameMatch)
        {
            DetachedCriteria criterions = DetachedCriteria.For(typeof(SystemUserRoleRelation));
            criterions.Add(SystemUserRoleRelationDao.PROPERTY_ROLEID.Eq(role));
            criterions.Add(SystemUserRoleRelationDao.PROPERTY_USERID_USERNAME.Like(userNameMatch));
            return this.FindListByDetachedCriteriaQuery(criterions);
        }
    }
}
