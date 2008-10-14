using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemSettingBaseDao : BaseSpringNHibernateDao<SystemSetting>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ID = Property.ForName(SystemSetting.PROPERTY_NAME_ID);
		public static readonly Property PROPERTY_SYSTEMNAME = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMNAME);
		public static readonly Property PROPERTY_SYSTEMDESCRIPTION = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMURL = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMURL);
		public static readonly Property PROPERTY_SYSTEMVERSION = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMVERSION);
		public static readonly Property PROPERTY_SYSTEMLISENCE = Property.ForName(SystemSetting.PROPERTY_NAME_SYSTEMLISENCE);
      #endregion
    }
}
