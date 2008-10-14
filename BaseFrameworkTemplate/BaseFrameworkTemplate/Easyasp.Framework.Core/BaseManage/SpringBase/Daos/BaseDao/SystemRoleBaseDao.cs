using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemRoleBaseDao : BaseSpringNHibernateDao<SystemRole>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemRole.PROPERTY_NAME_ROLEID);
		public static readonly Property PROPERTY_ROLENAME = Property.ForName(SystemRole.PROPERTY_NAME_ROLENAME);
		public static readonly Property PROPERTY_ROLEDESCRIPTION = Property.ForName(SystemRole.PROPERTY_NAME_ROLEDESCRIPTION);
		public static readonly Property PROPERTY_ROLEISSYSTEMROLE = Property.ForName(SystemRole.PROPERTY_NAME_ROLEISSYSTEMROLE);
      #endregion
    }
}
