using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class ServicesContainer
    {
        public ServicesContainer()
        {
        }

      public SystemApplicationService SystemApplicationServiceInstance { set; get; }
      public SystemDepartmentService SystemDepartmentServiceInstance { set; get; }
      public SystemDictionaryService SystemDictionaryServiceInstance { set; get; }
      public SystemLogService SystemLogServiceInstance { set; get; }
      public SystemMenuService SystemMenuServiceInstance { set; get; }
      public SystemMoudleService SystemMoudleServiceInstance { set; get; }
      public SystemMoudleFieldService SystemMoudleFieldServiceInstance { set; get; }
      public SystemOperationService SystemOperationServiceInstance { set; get; }
      public SystemPrivilegeService SystemPrivilegeServiceInstance { set; get; }
      public SystemPrivilegeInRolesService SystemPrivilegeInRolesServiceInstance { set; get; }
      public SystemPrivilegeParameterService SystemPrivilegeParameterServiceInstance { set; get; }
      public SystemResourcesService SystemResourcesServiceInstance { set; get; }
      public SystemRoleService SystemRoleServiceInstance { set; get; }
      public SystemRoleApplicationService SystemRoleApplicationServiceInstance { set; get; }
      public SystemRoleMenuRelationService SystemRoleMenuRelationServiceInstance { set; get; }
      public SystemSettingService SystemSettingServiceInstance { set; get; }
      public SystemShortMessageService SystemShortMessageServiceInstance { set; get; }
      public SystemUserService SystemUserServiceInstance { set; get; }
      public SystemUserGroupService SystemUserGroupServiceInstance { set; get; }
      public SystemUserGroupRoleRelationService SystemUserGroupRoleRelationServiceInstance { set; get; }
      public SystemUserGroupUserRelationService SystemUserGroupUserRelationServiceInstance { set; get; }
      public SystemUserProfileService SystemUserProfileServiceInstance { set; get; }
      public SystemUserRoleRelationService SystemUserRoleRelationServiceInstance { set; get; }
      public SystemViewService SystemViewServiceInstance { set; get; }
      public SystemViewItemService SystemViewItemServiceInstance { set; get; }
    }
}
