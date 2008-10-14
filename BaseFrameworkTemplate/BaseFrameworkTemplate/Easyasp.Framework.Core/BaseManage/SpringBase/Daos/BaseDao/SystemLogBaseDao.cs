using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemLogBaseDao : BaseSpringNHibernateDao<SystemLog>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_LOGID = Property.ForName(SystemLog.PROPERTY_NAME_LOGID);
		public static readonly Property PROPERTY_LOGLEVEL = Property.ForName(SystemLog.PROPERTY_NAME_LOGLEVEL);
		public static readonly Property PROPERTY_LOGTYPE = Property.ForName(SystemLog.PROPERTY_NAME_LOGTYPE);
		public static readonly Property PROPERTY_LOGDATE = Property.ForName(SystemLog.PROPERTY_NAME_LOGDATE);
		public static readonly Property PROPERTY_LOGSOURCE = Property.ForName(SystemLog.PROPERTY_NAME_LOGSOURCE);
		public static readonly Property PROPERTY_LOGUSER = Property.ForName(SystemLog.PROPERTY_NAME_LOGUSER);
		public static readonly Property PROPERTY_LOGDESCRPTION = Property.ForName(SystemLog.PROPERTY_NAME_LOGDESCRPTION);
		public static readonly Property PROPERTY_LOGREQUESTINFO = Property.ForName(SystemLog.PROPERTY_NAME_LOGREQUESTINFO);
		public static readonly Property PROPERTY_LOGRELATEMOUDLEID = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEMOUDLEID);
		public static readonly Property PROPERTY_LOGRELATEMOUDLEDATAID = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEMOUDLEDATAID);
		public static readonly Property PROPERTY_LOGRELATEUSERID = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEUSERID);
		public static readonly Property PROPERTY_LOGRELATEDATETIME = Property.ForName(SystemLog.PROPERTY_NAME_LOGRELATEDATETIME);
      #endregion
    }
}
