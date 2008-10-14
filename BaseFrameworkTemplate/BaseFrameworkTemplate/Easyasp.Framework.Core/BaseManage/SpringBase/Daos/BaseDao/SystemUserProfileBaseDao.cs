using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemUserProfileBaseDao : BaseSpringNHibernateDao<SystemUserProfile>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_PROFILEID = Property.ForName(SystemUserProfile.PROPERTY_NAME_PROFILEID);
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUserProfile.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_PROPERTYNAMES = Property.ForName(SystemUserProfile.PROPERTY_NAME_PROPERTYNAMES);
		public static readonly Property PROPERTY_PROPERTYVALUESSTRING = Property.ForName(SystemUserProfile.PROPERTY_NAME_PROPERTYVALUESSTRING);
		public static readonly Property PROPERTY_PROPERTYVALUESBINARY = Property.ForName(SystemUserProfile.PROPERTY_NAME_PROPERTYVALUESBINARY);
		public static readonly Property PROPERTY_LASTUPDATEDDATE = Property.ForName(SystemUserProfile.PROPERTY_NAME_LASTUPDATEDDATE);
      #endregion
    }
}
