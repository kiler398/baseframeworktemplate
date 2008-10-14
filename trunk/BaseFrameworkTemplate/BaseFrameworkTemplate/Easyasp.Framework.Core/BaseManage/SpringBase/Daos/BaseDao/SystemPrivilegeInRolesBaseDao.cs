using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemPrivilegeInRolesBaseDao : BaseSpringNHibernateDao<SystemPrivilegeInRoles>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_PRIVILEGEROLEID = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_PRIVILEGEROLEID);
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_ROLEID);
		#region roleID字段外键查询字段
		public static readonly Property PROPERTY_ROLEID_ROLEID = Property.ForName("RoleID.RoleID");
		public static readonly Property PROPERTY_ROLEID_ROLENAME = Property.ForName("RoleID.RoleName");
		public static readonly Property PROPERTY_ROLEID_ROLEDESCRIPTION = Property.ForName("RoleID.RoleDescription");
		public static readonly Property PROPERTY_ROLEID_ROLEISSYSTEMROLE = Property.ForName("RoleID.RoleIsSystemRole");
		#endregion
		public static readonly Property PROPERTY_PRIVILEGEID = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_PRIVILEGEID);
		#region privilegeID字段外键查询字段
		public static readonly Property PROPERTY_PRIVILEGEID_PRIVILEGEID = Property.ForName("PrivilegeID.PrivilegeID");
		public static readonly Property PROPERTY_PRIVILEGEID_OPERATIONID = Property.ForName("PrivilegeID.OperationID");
		public static readonly Property PROPERTY_PRIVILEGEID_RESOURCESID = Property.ForName("PrivilegeID.ResourcesID");
		public static readonly Property PROPERTY_PRIVILEGEID_PRIVILEGECNNAME = Property.ForName("PrivilegeID.PrivilegeCnName");
		public static readonly Property PROPERTY_PRIVILEGEID_PRIVILEGEENNAME = Property.ForName("PrivilegeID.PrivilegeEnName");
		public static readonly Property PROPERTY_PRIVILEGEID_DEFAULTVALUE = Property.ForName("PrivilegeID.DefaultValue");
		public static readonly Property PROPERTY_PRIVILEGEID_DESCRIPTION = Property.ForName("PrivilegeID.Description");
		public static readonly Property PROPERTY_PRIVILEGEID_PRIVILEGEORDER = Property.ForName("PrivilegeID.PrivilegeOrder");
		#endregion
		public static readonly Property PROPERTY_PRIVILEGEROLEVALUE = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_PRIVILEGEROLEVALUE);
		public static readonly Property PROPERTY_ENABLETYPE = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_ENABLETYPE);
		public static readonly Property PROPERTY_CREATETIME = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_CREATETIME);
		public static readonly Property PROPERTY_UPDATETIME = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_UPDATETIME);
		public static readonly Property PROPERTY_EXPIRYTIME = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_EXPIRYTIME);
		public static readonly Property PROPERTY_ENABLEPARAMETER = Property.ForName(SystemPrivilegeInRoles.PROPERTY_NAME_ENABLEPARAMETER);
      #endregion
    }
}
