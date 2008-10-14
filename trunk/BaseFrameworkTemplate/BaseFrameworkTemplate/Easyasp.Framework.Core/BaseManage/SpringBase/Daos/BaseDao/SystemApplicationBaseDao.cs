using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemApplicationBaseDao : BaseSpringNHibernateDao<SystemApplication>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONID = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONID);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONNAME = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONNAME);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONDESCRIPTION = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONURL = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONURL);
		public static readonly Property PROPERTY_SYSTEMAPPLICATIONISSYSTEMAPPLICATION = Property.ForName(SystemApplication.PROPERTY_NAME_SYSTEMAPPLICATIONISSYSTEMAPPLICATION);
      #endregion
    }
}
