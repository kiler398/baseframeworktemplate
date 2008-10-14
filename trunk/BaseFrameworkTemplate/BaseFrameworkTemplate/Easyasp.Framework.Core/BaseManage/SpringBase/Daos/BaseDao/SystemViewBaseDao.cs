using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemViewBaseDao : BaseSpringNHibernateDao<SystemView>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMVIEWID = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWID);
		public static readonly Property PROPERTY_SYSTEMVIEWNAMECN = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWNAMECN);
		public static readonly Property PROPERTY_SYSTEMVIEWNAMEEN = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWNAMEEN);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemView.PROPERTY_NAME_APPLICATIONID);
		#region applicationID字段外键查询字段
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = Property.ForName("ApplicationID.SystemApplicationID");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = Property.ForName("ApplicationID.SystemApplicationName");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName("ApplicationID.SystemApplicationDescription");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = Property.ForName("ApplicationID.SystemApplicationUrl");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = Property.ForName("ApplicationID.SystemApplicationIsSystemApplication");
		#endregion
		public static readonly Property PROPERTY_SYSTEMVIEWDESCRIPTION = Property.ForName(SystemView.PROPERTY_NAME_SYSTEMVIEWDESCRIPTION);
      #endregion
    }
}
