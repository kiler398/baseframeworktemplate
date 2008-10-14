using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemShortMessageBaseDao : BaseSpringNHibernateDao<SystemShortMessage>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_SHORTMESSAGEID = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGEID);
		public static readonly Property PROPERTY_SHORTMESSAGETITLE = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGETITLE);
		public static readonly Property PROPERTY_SHORTMESSAGECATEGORY = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGECATEGORY);
		public static readonly Property PROPERTY_SHORTMESSAGECONTENT = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGECONTENT);
		public static readonly Property PROPERTY_SHORTMESSAGESENDER = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGESENDER);
		public static readonly Property PROPERTY_SHORTMESSAGESENDDATE = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGESENDDATE);
		public static readonly Property PROPERTY_SHORTMESSAGERECEIVERID = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGERECEIVERID);
		public static readonly Property PROPERTY_SHORTMESSAGEISREAD = Property.ForName(SystemShortMessage.PROPERTY_NAME_SHORTMESSAGEISREAD);
      #endregion
    }
}
