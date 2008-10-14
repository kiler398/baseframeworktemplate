using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemRoleApplicationDao : SystemRoleApplicationBaseDao
    {
        public SystemRoleApplicationDao()
        {
        }

        /// <summary>
        /// 获取应用程序下面分配的角色
        /// </summary>
        /// <param name="application">应用程序</param>
        /// <returns>分配的角色</returns>
        public List<SystemRole> GetApplicationAssignRole(SystemApplication application)
        {
            List<ICriterion> criterions = new List<ICriterion>();

            criterions.Add(SystemRoleApplicationDao.PROPERTY_APPLICATIONID.Eq(application));

            List<SystemRoleApplication> listSystemRoleApplication = this.FindAll(criterions.ToArray());

            List<SystemRole> assignRoles = new List<SystemRole>();

            foreach (SystemRoleApplication relation in listSystemRoleApplication)
            {
                assignRoles.Add(relation.RoleID);
            }

            return assignRoles;
        }
        /// <summary>
        /// 获取角色下面分配的应用程序
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns>分配的应用程序</returns>
        public List<SystemApplication> GetRoleAssignedApplicaton(SystemRole role)
        {
            List<ICriterion> criterions = new List<ICriterion>();

            criterions.Add(SystemRoleApplicationDao.PROPERTY_ROLEID.Eq(role));

            List<SystemRoleApplication> listSystemRoleApplication = this.FindAll(criterions.ToArray());

            List<SystemApplication> assignRoles = new List<SystemApplication>();

            foreach (SystemRoleApplication relation in listSystemRoleApplication)
            {
                assignRoles.Add(relation.ApplicationID);
            }

            return assignRoles;
        }
        /// <summary>
        /// 根据角色获取角色应用程序对应关系
        /// </summary>
        /// <param name="role">角色</param>
        /// <returns>角色应用程序对应关系</returns>
        public List<SystemRoleApplication> GetRoleApplicationRelationAssignedApplicaton(SystemRole role)
        {
            List<ICriterion> criterions = new List<ICriterion>();

            criterions.Add(SystemRoleApplicationDao.PROPERTY_ROLEID.Eq(role));

            return this.FindAll(criterions.ToArray());
        }
        /// <summary>
        /// 检查角色和应用程序是否对应
        /// </summary>
        /// <param name="role">角色</param>
        /// <param name="application">应用程序</param>
        /// <returns>角色和应用程序是否对应</returns>
        public bool RoleAndApplicationHasRelation(SystemRole role, SystemApplication application)
        {
            List<ICriterion> criterions = new List<ICriterion>();

            criterions.Add(SystemRoleApplicationDao.PROPERTY_ROLEID.Eq(role));

            criterions.Add(SystemRoleApplicationDao.PROPERTY_APPLICATIONID.Eq(application));

            return (this.FindAll(criterions.ToArray()).Count > 0);
        }
    }
}
