using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemDepartmentBaseDao : BaseSpringNHibernateDao<SystemDepartment>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_DEPARTMENTID = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTID);
		public static readonly Property PROPERTY_PARENTDEPARTMENTID = Property.ForName(SystemDepartment.PROPERTY_NAME_PARENTDEPARTMENTID);
		public static readonly Property PROPERTY_DEPARTMENTNAMECN = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTNAMECN);
		public static readonly Property PROPERTY_DEPARTMENTNAMEEN = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTNAMEEN);
		public static readonly Property PROPERTY_DEPARTMENTDECRIPTION = Property.ForName(SystemDepartment.PROPERTY_NAME_DEPARTMENTDECRIPTION);
      #endregion
    }
}
