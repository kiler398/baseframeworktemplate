using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Spring.Transaction;
using Spring.Transaction.Interceptor;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemUserGroupService : SystemUserGroupBaseService
    {
        public SystemUserGroupService()
        {

        }


        public List<int> GetUserGroupAssignedroleIDList(SystemUserGroup userGroup)
        {
            List<SystemRole> list = this.DaosContainerIocID.SystemUserGroupRoleRelationDaoInstance.GetUserGroupAssignedRole(userGroup);
            List<int> roleList = new List<int>();
            foreach (SystemRole role in list)
            {
                roleList.Add(role.RoleID);
            }
            return roleList;
        }
        [Transaction(TransactionPropagation.Required)]
        public virtual void SaveUserGroupAssignedRoleIDList(List<int> roleIDList, SystemUserGroup userGroup)
        {
            List<SystemUserGroupRoleRelation> systemUserGroupRoleRelation =
                this.DaosContainerIocID.SystemUserGroupRoleRelationDaoInstance.GetSystemUserGroupRoleRelationByUserGroup(userGroup);
            foreach (SystemUserGroupRoleRelation userGroupRoleRelation in systemUserGroupRoleRelation)
            {
                this.DaosContainerIocID.SystemUserGroupRoleRelationDaoInstance.Delete(userGroupRoleRelation);
            }
            foreach (int id in roleIDList)
            {
                SystemRole assignedRole = this.DaosContainerIocID.SystemRoleDaoInstance.Load(id);
                SystemUserGroupRoleRelation userGroupRoleRelation = new SystemUserGroupRoleRelation();
                userGroupRoleRelation.RoleID = assignedRole;
                userGroupRoleRelation.UserGroupID = userGroup;
                this.DaosContainerIocID.SystemUserGroupRoleRelationDaoInstance.Save(userGroupRoleRelation);
            }
        }

    }
}
