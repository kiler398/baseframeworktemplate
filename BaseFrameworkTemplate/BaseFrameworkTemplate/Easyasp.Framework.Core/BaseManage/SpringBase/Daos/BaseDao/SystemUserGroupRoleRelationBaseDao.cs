using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemUserGroupRoleRelationBaseDao : BaseSpringNHibernateDao<SystemUserGroupRoleRelation>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_USERGROUPROLEID = Property.ForName(SystemUserGroupRoleRelation.PROPERTY_NAME_USERGROUPROLEID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemUserGroupRoleRelation.PROPERTY_NAME_ROLEID);
		#region roleID字段外键查询字段
		public static readonly Property PROPERTY_ROLEID_ROLEID = Property.ForName("RoleID.RoleID");
		public static readonly Property PROPERTY_ROLEID_ROLENAME = Property.ForName("RoleID.RoleName");
		public static readonly Property PROPERTY_ROLEID_ROLEDESCRIPTION = Property.ForName("RoleID.RoleDescription");
		public static readonly Property PROPERTY_ROLEID_ROLEISSYSTEMROLE = Property.ForName("RoleID.RoleIsSystemRole");
		#endregion
		public static readonly Property PROPERTY_USERGROUPID = Property.ForName(SystemUserGroupRoleRelation.PROPERTY_NAME_USERGROUPID);
		#region userGroupID字段外键查询字段
		public static readonly Property PROPERTY_USERGROUPID_GROUPID = Property.ForName("UserGroupID.GroupID");
		public static readonly Property PROPERTY_USERGROUPID_GROUPNAMECN = Property.ForName("UserGroupID.GroupNameCn");
		public static readonly Property PROPERTY_USERGROUPID_GROUPNAMEEN = Property.ForName("UserGroupID.GroupNameEn");
		public static readonly Property PROPERTY_USERGROUPID_GROUPDESCRIPTION = Property.ForName("UserGroupID.GroupDescription");
		#endregion
      #endregion
    }
}
