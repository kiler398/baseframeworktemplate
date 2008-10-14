using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemRoleMenuRelationBaseDao : BaseSpringNHibernateDao<SystemRoleMenuRelation>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_MENUROLEID = Property.ForName(SystemRoleMenuRelation.PROPERTY_NAME_MENUROLEID);
		public static readonly Property PROPERTY_MENUID = Property.ForName(SystemRoleMenuRelation.PROPERTY_NAME_MENUID);
		#region menuID字段外键查询字段
		public static readonly Property PROPERTY_MENUID_MENUID = Property.ForName("MenuID.MenuID");
		public static readonly Property PROPERTY_MENUID_MENUNAME = Property.ForName("MenuID.MenuName");
		public static readonly Property PROPERTY_MENUID_MENUDESCRIPTION = Property.ForName("MenuID.MenuDescription");
		public static readonly Property PROPERTY_MENUID_MENUURL = Property.ForName("MenuID.MenuUrl");
		public static readonly Property PROPERTY_MENUID_MENUURLTARGET = Property.ForName("MenuID.MenuUrlTarget");
		public static readonly Property PROPERTY_MENUID_MENUISCATEGORY = Property.ForName("MenuID.MenuIsCategory");
		public static readonly Property PROPERTY_MENUID_PARENTMENUID = Property.ForName("MenuID.ParentMenuID");
		public static readonly Property PROPERTY_MENUID_MENUORDER = Property.ForName("MenuID.MenuOrder");
		public static readonly Property PROPERTY_MENUID_MENUTYPE = Property.ForName("MenuID.MenuType");
		public static readonly Property PROPERTY_MENUID_MENUISSYSTEMMENU = Property.ForName("MenuID.MenuIsSystemMenu");
		public static readonly Property PROPERTY_MENUID_MENUISENABLE = Property.ForName("MenuID.MenuIsEnable");
		public static readonly Property PROPERTY_MENUID_APPLICATIONID = Property.ForName("MenuID.ApplicationID");
		#endregion
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemRoleMenuRelation.PROPERTY_NAME_ROLEID);
		#region roleID字段外键查询字段
		public static readonly Property PROPERTY_ROLEID_ROLEID = Property.ForName("RoleID.RoleID");
		public static readonly Property PROPERTY_ROLEID_ROLENAME = Property.ForName("RoleID.RoleName");
		public static readonly Property PROPERTY_ROLEID_ROLEDESCRIPTION = Property.ForName("RoleID.RoleDescription");
		public static readonly Property PROPERTY_ROLEID_ROLEISSYSTEMROLE = Property.ForName("RoleID.RoleIsSystemRole");
		#endregion
      #endregion
    }
}
