using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemPrivilegeBaseDao : BaseSpringNHibernateDao<SystemPrivilege>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_PRIVILEGEID = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGEID);
		public static readonly Property PROPERTY_OPERATIONID = Property.ForName(SystemPrivilege.PROPERTY_NAME_OPERATIONID);
		#region operationID字段外键查询字段
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONID = Property.ForName("OperationID.OperationID");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONNAMECN = Property.ForName("OperationID.OperationNameCn");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONNAMEEN = Property.ForName("OperationID.OperationNameEn");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONDESCRIPTION = Property.ForName("OperationID.OperationDescription");
		public static readonly Property PROPERTY_OPERATIONID_ISSYSTEMOPERATION = Property.ForName("OperationID.IsSystemOperation");
		public static readonly Property PROPERTY_OPERATIONID_ISCANSINGLEOPERATION = Property.ForName("OperationID.IsCanSingleOperation");
		public static readonly Property PROPERTY_OPERATIONID_ISCANMUTILOPERATION = Property.ForName("OperationID.IsCanMutilOperation");
		public static readonly Property PROPERTY_OPERATIONID_ISENABLE = Property.ForName("OperationID.IsEnable");
		public static readonly Property PROPERTY_OPERATIONID_ISINLISTPAGE = Property.ForName("OperationID.IsInListPage");
		public static readonly Property PROPERTY_OPERATIONID_ISINSINGLEPAGE = Property.ForName("OperationID.IsInSinglePage");
		public static readonly Property PROPERTY_OPERATIONID_OPERATIONORDER = Property.ForName("OperationID.OperationOrder");
		#endregion
		public static readonly Property PROPERTY_RESOURCESID = Property.ForName(SystemPrivilege.PROPERTY_NAME_RESOURCESID);
		#region resourcesID字段外键查询字段
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESID = Property.ForName("ResourcesID.ResourcesID");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESNAMECN = Property.ForName("ResourcesID.ResourcesNameCn");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESNAMEEN = Property.ForName("ResourcesID.ResourcesNameEn");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESDESCRIPTION = Property.ForName("ResourcesID.ResourcesDescription");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESTYPE = Property.ForName("ResourcesID.ResourcesType");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESLIMITEXPRESSION = Property.ForName("ResourcesID.ResourcesLimitExpression");
		public static readonly Property PROPERTY_RESOURCESID_RESOURCESISRELATEUSER = Property.ForName("ResourcesID.ResourcesIsRelateUser");
		public static readonly Property PROPERTY_RESOURCESID_MOUDLEID = Property.ForName("ResourcesID.MoudleID");
		#endregion
		public static readonly Property PROPERTY_PRIVILEGECNNAME = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGECNNAME);
		public static readonly Property PROPERTY_PRIVILEGEENNAME = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGEENNAME);
		public static readonly Property PROPERTY_DEFAULTVALUE = Property.ForName(SystemPrivilege.PROPERTY_NAME_DEFAULTVALUE);
		public static readonly Property PROPERTY_DESCRIPTION = Property.ForName(SystemPrivilege.PROPERTY_NAME_DESCRIPTION);
		public static readonly Property PROPERTY_PRIVILEGEORDER = Property.ForName(SystemPrivilege.PROPERTY_NAME_PRIVILEGEORDER);
      #endregion
    }
}
