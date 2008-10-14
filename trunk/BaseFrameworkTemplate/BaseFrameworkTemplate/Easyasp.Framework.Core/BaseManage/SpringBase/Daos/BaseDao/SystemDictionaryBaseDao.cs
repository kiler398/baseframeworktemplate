using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemDictionaryBaseDao : BaseSpringNHibernateDao<SystemDictionary>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMDICTIONARYID = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYID);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYCATEGORYID = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYCATEGORYID);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYKEY = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYKEY);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYVALUE = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYVALUE);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYDESCIPTION = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYDESCIPTION);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYORDER = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYORDER);
		public static readonly Property PROPERTY_SYSTEMDICTIONARYISENABLE = Property.ForName(SystemDictionary.PROPERTY_NAME_SYSTEMDICTIONARYISENABLE);
      #endregion
    }
}
