using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemUserBaseDao : BaseSpringNHibernateDao<SystemUser>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUser.PROPERTY_NAME_USERID);
		public static readonly Property PROPERTY_USERLOGINID = Property.ForName(SystemUser.PROPERTY_NAME_USERLOGINID);
		public static readonly Property PROPERTY_USERNAME = Property.ForName(SystemUser.PROPERTY_NAME_USERNAME);
		public static readonly Property PROPERTY_USEREMAIL = Property.ForName(SystemUser.PROPERTY_NAME_USEREMAIL);
		public static readonly Property PROPERTY_USERPASSWORD = Property.ForName(SystemUser.PROPERTY_NAME_USERPASSWORD);
		public static readonly Property PROPERTY_USERSTATUS = Property.ForName(SystemUser.PROPERTY_NAME_USERSTATUS);
		public static readonly Property PROPERTY_USERCREATEDATE = Property.ForName(SystemUser.PROPERTY_NAME_USERCREATEDATE);
		public static readonly Property PROPERTY_USERTYPE = Property.ForName(SystemUser.PROPERTY_NAME_USERTYPE);
		public static readonly Property PROPERTY_DEPARTMENTID = Property.ForName(SystemUser.PROPERTY_NAME_DEPARTMENTID);
		#region departmentID字段外键查询字段
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTID = Property.ForName("DepartmentID.DepartmentID");
		public static readonly Property PROPERTY_DEPARTMENTID_PARENTDEPARTMENTID = Property.ForName("DepartmentID.ParentDepartmentID");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTNAMECN = Property.ForName("DepartmentID.DepartmentNameCn");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTNAMEEN = Property.ForName("DepartmentID.DepartmentNameEn");
		public static readonly Property PROPERTY_DEPARTMENTID_DEPARTMENTDECRIPTION = Property.ForName("DepartmentID.DepartmentDecription");
		#endregion
		public static readonly Property PROPERTY_MOBILEPIN = Property.ForName(SystemUser.PROPERTY_NAME_MOBILEPIN);
		public static readonly Property PROPERTY_PASSWORDFORMAT = Property.ForName(SystemUser.PROPERTY_NAME_PASSWORDFORMAT);
		public static readonly Property PROPERTY_PASSWORDSALT = Property.ForName(SystemUser.PROPERTY_NAME_PASSWORDSALT);
		public static readonly Property PROPERTY_LOWEREDEMAIL = Property.ForName(SystemUser.PROPERTY_NAME_LOWEREDEMAIL);
		public static readonly Property PROPERTY_PASSWORDQUESTION = Property.ForName(SystemUser.PROPERTY_NAME_PASSWORDQUESTION);
		public static readonly Property PROPERTY_PASSWORDANSWER = Property.ForName(SystemUser.PROPERTY_NAME_PASSWORDANSWER);
		public static readonly Property PROPERTY_COMMENTS = Property.ForName(SystemUser.PROPERTY_NAME_COMMENTS);
		public static readonly Property PROPERTY_ISAPPROVED = Property.ForName(SystemUser.PROPERTY_NAME_ISAPPROVED);
		public static readonly Property PROPERTY_ISLOCKEDOUT = Property.ForName(SystemUser.PROPERTY_NAME_ISLOCKEDOUT);
		public static readonly Property PROPERTY_LASTACTIVITYDATE = Property.ForName(SystemUser.PROPERTY_NAME_LASTACTIVITYDATE);
		public static readonly Property PROPERTY_LASTLOGINDATE = Property.ForName(SystemUser.PROPERTY_NAME_LASTLOGINDATE);
		public static readonly Property PROPERTY_LASTLOCKEDOUTDATE = Property.ForName(SystemUser.PROPERTY_NAME_LASTLOCKEDOUTDATE);
		public static readonly Property PROPERTY_LASTPASSWORDCHANGEDATE = Property.ForName(SystemUser.PROPERTY_NAME_LASTPASSWORDCHANGEDATE);
		public static readonly Property PROPERTY_FAILEDPWDATTEMPTCNT = Property.ForName(SystemUser.PROPERTY_NAME_FAILEDPWDATTEMPTCNT);
		public static readonly Property PROPERTY_FAILEDPWDATTEMPTWNDSTART = Property.ForName(SystemUser.PROPERTY_NAME_FAILEDPWDATTEMPTWNDSTART);
		public static readonly Property PROPERTY_FAILEDPWDANSATTEMPTCNT = Property.ForName(SystemUser.PROPERTY_NAME_FAILEDPWDANSATTEMPTCNT);
		public static readonly Property PROPERTY_FAILEDPWDANSATTEMPTWNDSTART = Property.ForName(SystemUser.PROPERTY_NAME_FAILEDPWDANSATTEMPTWNDSTART);
      #endregion
    }
}
