using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemMenuBaseDao : BaseSpringNHibernateDao<SystemMenu>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_MENUID = Property.ForName(SystemMenu.PROPERTY_NAME_MENUID);
		public static readonly Property PROPERTY_MENUNAME = Property.ForName(SystemMenu.PROPERTY_NAME_MENUNAME);
		public static readonly Property PROPERTY_MENUDESCRIPTION = Property.ForName(SystemMenu.PROPERTY_NAME_MENUDESCRIPTION);
		public static readonly Property PROPERTY_MENUURL = Property.ForName(SystemMenu.PROPERTY_NAME_MENUURL);
		public static readonly Property PROPERTY_MENUURLTARGET = Property.ForName(SystemMenu.PROPERTY_NAME_MENUURLTARGET);
		public static readonly Property PROPERTY_MENUISCATEGORY = Property.ForName(SystemMenu.PROPERTY_NAME_MENUISCATEGORY);
		public static readonly Property PROPERTY_PARENTMENUID = Property.ForName(SystemMenu.PROPERTY_NAME_PARENTMENUID);
		public static readonly Property PROPERTY_MENUORDER = Property.ForName(SystemMenu.PROPERTY_NAME_MENUORDER);
		public static readonly Property PROPERTY_MENUTYPE = Property.ForName(SystemMenu.PROPERTY_NAME_MENUTYPE);
		public static readonly Property PROPERTY_MENUISSYSTEMMENU = Property.ForName(SystemMenu.PROPERTY_NAME_MENUISSYSTEMMENU);
		public static readonly Property PROPERTY_MENUISENABLE = Property.ForName(SystemMenu.PROPERTY_NAME_MENUISENABLE);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemMenu.PROPERTY_NAME_APPLICATIONID);
		#region applicationID字段外键查询字段
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = Property.ForName("ApplicationID.SystemApplicationID");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = Property.ForName("ApplicationID.SystemApplicationName");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName("ApplicationID.SystemApplicationDescription");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = Property.ForName("ApplicationID.SystemApplicationUrl");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = Property.ForName("ApplicationID.SystemApplicationIsSystemApplication");
		#endregion
      #endregion
    }
}
