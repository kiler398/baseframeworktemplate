using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemResourcesBaseDao : BaseSpringNHibernateDao<SystemResources>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_RESOURCESID = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESID);
		public static readonly Property PROPERTY_RESOURCESNAMECN = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESNAMECN);
		public static readonly Property PROPERTY_RESOURCESNAMEEN = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESNAMEEN);
		public static readonly Property PROPERTY_RESOURCESDESCRIPTION = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESDESCRIPTION);
		public static readonly Property PROPERTY_RESOURCESTYPE = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESTYPE);
		public static readonly Property PROPERTY_RESOURCESLIMITEXPRESSION = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESLIMITEXPRESSION);
		public static readonly Property PROPERTY_RESOURCESISRELATEUSER = Property.ForName(SystemResources.PROPERTY_NAME_RESOURCESISRELATEUSER);
		public static readonly Property PROPERTY_MOUDLEID = Property.ForName(SystemResources.PROPERTY_NAME_MOUDLEID);
		#region moudleID字段外键查询字段
		public static readonly Property PROPERTY_MOUDLEID_MOUDLEID = Property.ForName("MoudleID.MoudleID");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLENAMECN = Property.ForName("MoudleID.MoudleNameCn");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLENAMEEN = Property.ForName("MoudleID.MoudleNameEn");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLENAMEDB = Property.ForName("MoudleID.MoudleNameDb");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLEDESCRIPTION = Property.ForName("MoudleID.MoudleDescription");
		public static readonly Property PROPERTY_MOUDLEID_APPLICATIONID = Property.ForName("MoudleID.ApplicationID");
		public static readonly Property PROPERTY_MOUDLEID_MOUDLEISSYSTEMMOUDLE = Property.ForName("MoudleID.MoudleIsSystemMoudle");
		#endregion
      #endregion
    }
}
