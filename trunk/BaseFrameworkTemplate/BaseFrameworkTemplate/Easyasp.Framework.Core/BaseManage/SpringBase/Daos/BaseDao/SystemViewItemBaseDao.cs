using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemViewItemBaseDao : BaseSpringNHibernateDao<SystemViewItem>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SYSTEMVIEWITEMID = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMID);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMNAMEEN = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMNAMEEN);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMNAMECN = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMNAMECN);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMDESCRIPTION = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMDESCRIPTION);
		public static readonly Property PROPERTY_SYSTEMVIEWITEMDISPLAYFORMAT = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWITEMDISPLAYFORMAT);
		public static readonly Property PROPERTY_SYSTEMVIEWID = Property.ForName(SystemViewItem.PROPERTY_NAME_SYSTEMVIEWID);
		#region systemViewID字段外键查询字段
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWID = Property.ForName("SystemViewID.SystemViewID");
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWNAMECN = Property.ForName("SystemViewID.SystemViewNameCn");
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWNAMEEN = Property.ForName("SystemViewID.SystemViewNameEn");
		public static readonly Property PROPERTY_SYSTEMVIEWID_APPLICATIONID = Property.ForName("SystemViewID.ApplicationID");
		public static readonly Property PROPERTY_SYSTEMVIEWID_SYSTEMVIEWDESCRIPTION = Property.ForName("SystemViewID.SystemViewDescription");
		#endregion
      #endregion
    }
}
