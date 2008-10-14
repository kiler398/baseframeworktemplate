using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using NHibernate.Criterion;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;


namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao
{
    public abstract class SystemUserRoleRelationBaseDao : BaseSpringNHibernateDao<SystemUserRoleRelation>
    {
		#region Expression Query Property (标准查询字段)
		public static readonly Property PROPERTY_USERROLEID = Property.ForName(SystemUserRoleRelation.PROPERTY_NAME_USERROLEID);
		public static readonly Property PROPERTY_USERID = Property.ForName(SystemUserRoleRelation.PROPERTY_NAME_USERID);
		#region userID字段外键查询字段
		public static readonly Property PROPERTY_USERID_USERID = Property.ForName("UserID.UserID");
		public static readonly Property PROPERTY_USERID_USERLOGINID = Property.ForName("UserID.UserLoginID");
		public static readonly Property PROPERTY_USERID_USERNAME = Property.ForName("UserID.UserName");
		public static readonly Property PROPERTY_USERID_USEREMAIL = Property.ForName("UserID.UserEmail");
		public static readonly Property PROPERTY_USERID_USERPASSWORD = Property.ForName("UserID.UserPassword");
		public static readonly Property PROPERTY_USERID_USERSTATUS = Property.ForName("UserID.UserStatus");
		public static readonly Property PROPERTY_USERID_USERCREATEDATE = Property.ForName("UserID.UserCreateDate");
		public static readonly Property PROPERTY_USERID_USERTYPE = Property.ForName("UserID.UserType");
		public static readonly Property PROPERTY_USERID_DEPARTMENTID = Property.ForName("UserID.DepartmentID");
		public static readonly Property PROPERTY_USERID_MOBILEPIN = Property.ForName("UserID.MobilePIN");
		public static readonly Property PROPERTY_USERID_PASSWORDFORMAT = Property.ForName("UserID.PasswordFormat");
		public static readonly Property PROPERTY_USERID_PASSWORDSALT = Property.ForName("UserID.PasswordSalt");
		public static readonly Property PROPERTY_USERID_LOWEREDEMAIL = Property.ForName("UserID.LoweredEmail");
		public static readonly Property PROPERTY_USERID_PASSWORDQUESTION = Property.ForName("UserID.PasswordQuestion");
		public static readonly Property PROPERTY_USERID_PASSWORDANSWER = Property.ForName("UserID.PasswordAnswer");
		public static readonly Property PROPERTY_USERID_COMMENTS = Property.ForName("UserID.Comments");
		public static readonly Property PROPERTY_USERID_ISAPPROVED = Property.ForName("UserID.IsApproved");
		public static readonly Property PROPERTY_USERID_ISLOCKEDOUT = Property.ForName("UserID.IsLockedOut");
		public static readonly Property PROPERTY_USERID_LASTACTIVITYDATE = Property.ForName("UserID.LastActivityDate");
		public static readonly Property PROPERTY_USERID_LASTLOGINDATE = Property.ForName("UserID.LastLoginDate");
		public static readonly Property PROPERTY_USERID_LASTLOCKEDOUTDATE = Property.ForName("UserID.LastLockedOutDate");
		public static readonly Property PROPERTY_USERID_LASTPASSWORDCHANGEDATE = Property.ForName("UserID.LastPasswordChangeDate");
		public static readonly Property PROPERTY_USERID_FAILEDPWDATTEMPTCNT = Property.ForName("UserID.FailedPwdAttemptCnt");
		public static readonly Property PROPERTY_USERID_FAILEDPWDATTEMPTWNDSTART = Property.ForName("UserID.FailedPwdAttemptWndStart");
		public static readonly Property PROPERTY_USERID_FAILEDPWDANSATTEMPTCNT = Property.ForName("UserID.FailedPwdAnsAttemptCnt");
		public static readonly Property PROPERTY_USERID_FAILEDPWDANSATTEMPTWNDSTART = Property.ForName("UserID.FailedPwdAnsAttemptWndStart");
		#endregion
		public static readonly Property PROPERTY_ROLEID = Property.ForName(SystemUserRoleRelation.PROPERTY_NAME_ROLEID);
		#region roleID字段外键查询字段
		public static readonly Property PROPERTY_ROLEID_ROLEID = Property.ForName("RoleID.RoleID");
		public static readonly Property PROPERTY_ROLEID_ROLENAME = Property.ForName("RoleID.RoleName");
		public static readonly Property PROPERTY_ROLEID_ROLEDESCRIPTION = Property.ForName("RoleID.RoleDescription");
		public static readonly Property PROPERTY_ROLEID_ROLEISSYSTEMROLE = Property.ForName("RoleID.RoleIsSystemRole");
		#endregion
      #endregion
    }
}
