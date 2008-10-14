using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class DaosContainer
    {
        public DaosContainer()
        {
        }

      public SystemApplicationDao SystemApplicationDaoInstance { set; get; }
      public SystemDepartmentDao SystemDepartmentDaoInstance { set; get; }
      public SystemDictionaryDao SystemDictionaryDaoInstance { set; get; }
      public SystemLogDao SystemLogDaoInstance { set; get; }
      public SystemMenuDao SystemMenuDaoInstance { set; get; }
      public SystemMoudleDao SystemMoudleDaoInstance { set; get; }
      public SystemMoudleFieldDao SystemMoudleFieldDaoInstance { set; get; }
      public SystemOperationDao SystemOperationDaoInstance { set; get; }
      public SystemPrivilegeDao SystemPrivilegeDaoInstance { set; get; }
      public SystemPrivilegeInRolesDao SystemPrivilegeInRolesDaoInstance { set; get; }
      public SystemPrivilegeParameterDao SystemPrivilegeParameterDaoInstance { set; get; }
      public SystemResourcesDao SystemResourcesDaoInstance { set; get; }
      public SystemRoleDao SystemRoleDaoInstance { set; get; }
      public SystemRoleApplicationDao SystemRoleApplicationDaoInstance { set; get; }
      public SystemRoleMenuRelationDao SystemRoleMenuRelationDaoInstance { set; get; }
      public SystemSettingDao SystemSettingDaoInstance { set; get; }
      public SystemShortMessageDao SystemShortMessageDaoInstance { set; get; }
      public SystemUserDao SystemUserDaoInstance { set; get; }
      public SystemUserGroupDao SystemUserGroupDaoInstance { set; get; }
      public SystemUserGroupRoleRelationDao SystemUserGroupRoleRelationDaoInstance { set; get; }
      public SystemUserGroupUserRelationDao SystemUserGroupUserRelationDaoInstance { set; get; }
      public SystemUserProfileDao SystemUserProfileDaoInstance { set; get; }
      public SystemUserRoleRelationDao SystemUserRoleRelationDaoInstance { set; get; }
      public SystemViewDao SystemViewDaoInstance { set; get; }
      public SystemViewItemDao SystemViewItemDaoInstance { set; get; }
    }
}
