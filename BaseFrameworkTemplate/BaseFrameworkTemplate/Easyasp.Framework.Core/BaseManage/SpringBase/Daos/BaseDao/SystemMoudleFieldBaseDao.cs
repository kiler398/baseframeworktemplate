using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemMoudleFieldBaseDao : BaseSpringNHibernateDao<SystemMoudleField>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDID = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDID);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDNAMEEN = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEEN);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDNAMECN = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMECN);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDNAMEDB = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDNAMEDB);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDTYPE = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDTYPE);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDISREQUIRED = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDISREQUIRED);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDDEFAULTVALUE = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDDEFAULTVALUE);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDISKEYFIELD = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDISKEYFIELD);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDSIZE = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDSIZE);
		public static readonly Property PROPERTY_SYSTEMMOUDLEFIELDDESCRIPTION = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEFIELDDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMMOUDLEID = Property.ForName(SystemMoudleField.PROPERTY_NAME_SYSTEMMOUDLEID);
		#region systemMoudleID字段外键查询字段
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_MOUDLEID = Property.ForName("SystemMoudleID.MoudleID");
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_MOUDLENAMECN = Property.ForName("SystemMoudleID.MoudleNameCn");
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_MOUDLENAMEEN = Property.ForName("SystemMoudleID.MoudleNameEn");
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_MOUDLENAMEDB = Property.ForName("SystemMoudleID.MoudleNameDb");
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_MOUDLEDESCRIPTION = Property.ForName("SystemMoudleID.MoudleDescription");
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_APPLICATIONID = Property.ForName("SystemMoudleID.ApplicationID");
		public static readonly Property PROPERTY_SYSTEMMOUDLEID_MOUDLEISSYSTEMMOUDLE = Property.ForName("SystemMoudleID.MoudleIsSystemMoudle");
		#endregion
      #endregion
    }
}
