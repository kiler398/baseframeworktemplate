using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemOperationBaseDao : BaseSpringNHibernateDao<SystemOperation>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_OPERATIONID = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONID);
		public static readonly Property PROPERTY_OPERATIONNAMECN = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONNAMECN);
		public static readonly Property PROPERTY_OPERATIONNAMEEN = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONNAMEEN);
		public static readonly Property PROPERTY_OPERATIONDESCRIPTION = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONDESCRIPTION);
		public static readonly Property PROPERTY_ISSYSTEMOPERATION = Property.ForName(SystemOperation.PROPERTY_NAME_ISSYSTEMOPERATION);
		public static readonly Property PROPERTY_ISCANSINGLEOPERATION = Property.ForName(SystemOperation.PROPERTY_NAME_ISCANSINGLEOPERATION);
		public static readonly Property PROPERTY_ISCANMUTILOPERATION = Property.ForName(SystemOperation.PROPERTY_NAME_ISCANMUTILOPERATION);
		public static readonly Property PROPERTY_ISENABLE = Property.ForName(SystemOperation.PROPERTY_NAME_ISENABLE);
		public static readonly Property PROPERTY_ISINLISTPAGE = Property.ForName(SystemOperation.PROPERTY_NAME_ISINLISTPAGE);
		public static readonly Property PROPERTY_ISINSINGLEPAGE = Property.ForName(SystemOperation.PROPERTY_NAME_ISINSINGLEPAGE);
		public static readonly Property PROPERTY_OPERATIONORDER = Property.ForName(SystemOperation.PROPERTY_NAME_OPERATIONORDER);
      #endregion
    }
}
