﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemUserGroupBaseDao : BaseSpringNHibernateDao<SystemUserGroup>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_GROUPID = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPID);
		public static readonly Property PROPERTY_GROUPNAMECN = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPNAMECN);
		public static readonly Property PROPERTY_GROUPNAMEEN = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPNAMEEN);
		public static readonly Property PROPERTY_GROUPDESCRIPTION = Property.ForName(SystemUserGroup.PROPERTY_NAME_GROUPDESCRIPTION);
      #endregion
    }
}
