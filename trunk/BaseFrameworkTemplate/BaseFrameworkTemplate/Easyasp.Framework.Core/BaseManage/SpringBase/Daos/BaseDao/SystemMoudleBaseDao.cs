using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemMoudleBaseDao : BaseSpringNHibernateDao<SystemMoudle>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_MOUDLEID = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLEID);
		public static readonly Property PROPERTY_MOUDLENAMECN = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLENAMECN);
		public static readonly Property PROPERTY_MOUDLENAMEEN = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLENAMEEN);
		public static readonly Property PROPERTY_MOUDLENAMEDB = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLENAMEDB);
		public static readonly Property PROPERTY_MOUDLEDESCRIPTION = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLEDESCRIPTION);
		public static readonly Property PROPERTY_APPLICATIONID = Property.ForName(SystemMoudle.PROPERTY_NAME_APPLICATIONID);
		#region applicationID字段外键查询字段
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONID = Property.ForName("ApplicationID.SystemApplicationID");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONNAME = Property.ForName("ApplicationID.SystemApplicationName");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName("ApplicationID.SystemApplicationDescription");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONURL = Property.ForName("ApplicationID.SystemApplicationUrl");
		public static readonly Property PROPERTY_APPLICATIONID_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = Property.ForName("ApplicationID.SystemApplicationIsSystemApplication");
		#endregion
		public static readonly Property PROPERTY_MOUDLEISSYSTEMMOUDLE = Property.ForName(SystemMoudle.PROPERTY_NAME_MOUDLEISSYSTEMMOUDLE);
      #endregion
    }
}
