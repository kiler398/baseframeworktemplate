/*
在这里插入代码注释
*/
using System;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Domains.BaseDomain
{
	/// <summary>
	///	系统用户
	/// </summary>
	[Serializable]
	public abstract class SystemUserBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain.SystemUser";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_USERLOGINID = "UserLoginID";
		public static readonly string PROPERTY_NAME_USERNAME = "UserName";
		public static readonly string PROPERTY_NAME_USEREMAIL = "UserEmail";
		public static readonly string PROPERTY_NAME_USERPASSWORD = "UserPassword";
		public static readonly string PROPERTY_NAME_USERSTATUS = "UserStatus";
		public static readonly string PROPERTY_NAME_USERCREATEDATE = "UserCreateDate";
		public static readonly string PROPERTY_NAME_USERTYPE = "UserType";
		public static readonly string PROPERTY_NAME_DEPARTMENTID = "DepartmentID";
		public static readonly string PROPERTY_NAME_MOBILEPIN = "MobilePIN";
		public static readonly string PROPERTY_NAME_PASSWORDFORMAT = "PasswordFormat";
		public static readonly string PROPERTY_NAME_PASSWORDSALT = "PasswordSalt";
		public static readonly string PROPERTY_NAME_LOWEREDEMAIL = "LoweredEmail";
		public static readonly string PROPERTY_NAME_PASSWORDQUESTION = "PasswordQuestion";
		public static readonly string PROPERTY_NAME_PASSWORDANSWER = "PasswordAnswer";
		public static readonly string PROPERTY_NAME_COMMENTS = "Comments";
		public static readonly string PROPERTY_NAME_ISAPPROVED = "IsApproved";
		public static readonly string PROPERTY_NAME_ISLOCKEDOUT = "IsLockedOut";
		public static readonly string PROPERTY_NAME_LASTACTIVITYDATE = "LastActivityDate";
		public static readonly string PROPERTY_NAME_LASTLOGINDATE = "LastLoginDate";
		public static readonly string PROPERTY_NAME_LASTLOCKEDOUTDATE = "LastLockedOutDate";
		public static readonly string PROPERTY_NAME_LASTPASSWORDCHANGEDATE = "LastPasswordChangeDate";
		public static readonly string PROPERTY_NAME_FAILEDPWDATTEMPTCNT = "FailedPwdAttemptCnt";
		public static readonly string PROPERTY_NAME_FAILEDPWDATTEMPTWNDSTART = "FailedPwdAttemptWndStart";
		public static readonly string PROPERTY_NAME_FAILEDPWDANSATTEMPTCNT = "FailedPwdAnsAttemptCnt";
		public static readonly string PROPERTY_NAME_FAILEDPWDANSATTEMPTWNDSTART = "FailedPwdAnsAttemptWndStart";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _user_id;
		private string _user_loginid;
		private string _user_name;
		private string _user_email;
		private string _user_password;
		private string _user_status;
		private DateTime? _user_create_date;
		private string _user_type;
		private SystemDepartment _department_id;
		private string _mobilepin;
		private int _passwordformat;
		private string _passwordsalt;
		private string _loweredemail;
		private string _passwordquestion;
		private string _passwordanswer;
		private string _comments;
		private bool _isapproved;
		private bool _islockedout;
		private DateTime? _lastactivitydate;
		private DateTime? _lastlogindate;
		private DateTime? _lastlockedoutdate;
		private DateTime? _lastpasswordchangedate;
		private int _failedpwdattemptcnt;
		private DateTime? _failedpwdattemptwndstart;
		private int _failedpwdansattemptcnt;
		private DateTime? _failedpwdansattemptwndstart;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserBase()
		{
			_user_id = 0; 
			_user_loginid = String.Empty; 
			_user_name = String.Empty; 
			_user_email = String.Empty; 
			_user_password = String.Empty; 
			_user_status = String.Empty; 
			_user_create_date =  null;  
			_user_type = String.Empty; 
			_department_id =  null; 
			_mobilepin = String.Empty; 
			_passwordformat = 0; 
			_passwordsalt = String.Empty; 
			_loweredemail = String.Empty; 
			_passwordquestion = String.Empty; 
			_passwordanswer = String.Empty; 
			_comments = String.Empty; 
			_isapproved = false; 
			_islockedout = false; 
			_lastactivitydate =  null;  
			_lastlogindate =  null;  
			_lastlockedoutdate =  null;  
			_lastpasswordchangedate =  null;  
			_failedpwdattemptcnt = 0; 
			_failedpwdattemptwndstart =  null;  
			_failedpwdansattemptcnt = 0; 
			_failedpwdansattemptwndstart =  null;  
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int UserID
		{
			get { return _user_id; }
			set { _isChanged |= (_user_id != value); _user_id = value; }
		}
		/// <summary>
		/// 用户登陆名
		/// </summary>		
		public virtual string UserLoginID
		{
			get { return _user_loginid; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserLoginID", value, value.ToString());
				
				_isChanged |= (_user_loginid != value); _user_loginid = value;
			}
		}
		/// <summary>
		/// 用户名称
		/// </summary>		
		public virtual string UserName
		{
			get { return _user_name; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserName", value, value.ToString());
				
				_isChanged |= (_user_name != value); _user_name = value;
			}
		}
		/// <summary>
		/// 用户邮件
		/// </summary>		
		public virtual string UserEmail
		{
			get { return _user_email; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserEmail", value, value.ToString());
				
				_isChanged |= (_user_email != value); _user_email = value;
			}
		}
		/// <summary>
		/// 用户密码
		/// </summary>		
		public virtual string UserPassword
		{
			get { return _user_password; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserPassword", value, value.ToString());
				
				_isChanged |= (_user_password != value); _user_password = value;
			}
		}
		/// <summary>
		/// 用户状态
		/// </summary>		
		public virtual string UserStatus
		{
			get { return _user_status; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserStatus", value, value.ToString());
				
				_isChanged |= (_user_status != value); _user_status = value;
			}
		}
		/// <summary>
		/// 用户创建时间
		/// </summary>		
		public virtual DateTime? UserCreateDate
		{
			get { return _user_create_date; }
			set { _isChanged |= (_user_create_date != value); _user_create_date = value; }
		}
		/// <summary>
		/// 用户类型
		/// </summary>		
		public virtual string UserType
		{
			get { return _user_type; }
			set	
			{
				if ( value != null)
					if( value.Length > 50)
						throw new ArgumentOutOfRangeException("Invalid value for UserType", value, value.ToString());
				
				_isChanged |= (_user_type != value); _user_type = value;
			}
		}
		/// <summary>
		/// 用户部门
		/// </summary>		
		public virtual SystemDepartment DepartmentID
		{
			get { return _department_id; }
			set { _isChanged |= (_department_id != value); _department_id = value; }
		}
		/// <summary>
		/// 手机PIN码
		/// </summary>		
		public virtual string MobilePIN
		{
			get { return _mobilepin; }
			set	
			{
				if ( value != null)
					if( value.Length > 16)
						throw new ArgumentOutOfRangeException("Invalid value for MobilePIN", value, value.ToString());
				
				_isChanged |= (_mobilepin != value); _mobilepin = value;
			}
		}
		/// <summary>
		/// 密码加密方式

		/// </summary>		
		public virtual int PasswordFormat
		{
			get { return _passwordformat; }
			set { _isChanged |= (_passwordformat != value); _passwordformat = value; }
		}
		/// <summary>
		/// 密码散列
		/// </summary>		
		public virtual string PasswordSalt
		{
			get { return _passwordsalt; }
			set	
			{
				if ( value != null)
					if( value.Length > 128)
						throw new ArgumentOutOfRangeException("Invalid value for PasswordSalt", value, value.ToString());
				
				_isChanged |= (_passwordsalt != value); _passwordsalt = value;
			}
		}
		/// <summary>
		/// 小写的电子邮件地址
		/// </summary>		
		public virtual string LoweredEmail
		{
			get { return _loweredemail; }
			set	
			{
				if ( value != null)
					if( value.Length > 128)
						throw new ArgumentOutOfRangeException("Invalid value for LoweredEmail", value, value.ToString());
				
				_isChanged |= (_loweredemail != value); _loweredemail = value;
			}
		}
		/// <summary>
		/// 忘记密码问题
		/// </summary>		
		public virtual string PasswordQuestion
		{
			get { return _passwordquestion; }
			set	
			{
				if ( value != null)
					if( value.Length > 255)
						throw new ArgumentOutOfRangeException("Invalid value for PasswordQuestion", value, value.ToString());
				
				_isChanged |= (_passwordquestion != value); _passwordquestion = value;
			}
		}
		/// <summary>
		/// 忘记密码答案
		/// </summary>		
		public virtual string PasswordAnswer
		{
			get { return _passwordanswer; }
			set	
			{
				if ( value != null)
					if( value.Length > 255)
						throw new ArgumentOutOfRangeException("Invalid value for PasswordAnswer", value, value.ToString());
				
				_isChanged |= (_passwordanswer != value); _passwordanswer = value;
			}
		}
		/// <summary>
		/// 备注
		/// </summary>		
		public virtual string Comments
		{
			get { return _comments; }
			set	
			{
				if ( value != null)
					if( value.Length > 3000)
						throw new ArgumentOutOfRangeException("Invalid value for Comments", value, value.ToString());
				
				_isChanged |= (_comments != value); _comments = value;
			}
		}
		/// <summary>
		/// 是否审批生效
		/// </summary>		
		public virtual bool IsApproved
		{
			get { return _isapproved; }
			set { _isChanged |= (_isapproved != value); _isapproved = value; }
		}
		/// <summary>
		/// 是否被锁定
		/// </summary>		
		public virtual bool IsLockedOut
		{
			get { return _islockedout; }
			set { _isChanged |= (_islockedout != value); _islockedout = value; }
		}
		/// <summary>
		/// 上次激活时间
		/// </summary>		
		public virtual DateTime? LastActivityDate
		{
			get { return _lastactivitydate; }
			set { _isChanged |= (_lastactivitydate != value); _lastactivitydate = value; }
		}
		/// <summary>
		/// 上次登陆时间
		/// </summary>		
		public virtual DateTime? LastLoginDate
		{
			get { return _lastlogindate; }
			set { _isChanged |= (_lastlogindate != value); _lastlogindate = value; }
		}
		/// <summary>
		/// 上次锁定时间
		/// </summary>		
		public virtual DateTime? LastLockedOutDate
		{
			get { return _lastlockedoutdate; }
			set { _isChanged |= (_lastlockedoutdate != value); _lastlockedoutdate = value; }
		}
		/// <summary>
		/// 上次修改密码时间
		/// </summary>		
		public virtual DateTime? LastPasswordChangeDate
		{
			get { return _lastpasswordchangedate; }
			set { _isChanged |= (_lastpasswordchangedate != value); _lastpasswordchangedate = value; }
		}
		/// <summary>
		/// 密码失败尝试次数
		/// </summary>		
		public virtual int FailedPwdAttemptCnt
		{
			get { return _failedpwdattemptcnt; }
			set { _isChanged |= (_failedpwdattemptcnt != value); _failedpwdattemptcnt = value; }
		}
		/// <summary>
		/// 密码失败尝试窗口打开时间
		/// </summary>		
		public virtual DateTime? FailedPwdAttemptWndStart
		{
			get { return _failedpwdattemptwndstart; }
			set { _isChanged |= (_failedpwdattemptwndstart != value); _failedpwdattemptwndstart = value; }
		}
		/// <summary>
		/// 忘记密码尝试次数
		/// </summary>		
		public virtual int FailedPwdAnsAttemptCnt
		{
			get { return _failedpwdansattemptcnt; }
			set { _isChanged |= (_failedpwdansattemptcnt != value); _failedpwdansattemptcnt = value; }
		}
		/// <summary>
		/// 忘记密码窗口打开时间
		/// </summary>		
		public virtual DateTime? FailedPwdAnsAttemptWndStart
		{
			get { return _failedpwdansattemptwndstart; }
			set { _isChanged |= (_failedpwdansattemptwndstart != value); _failedpwdansattemptwndstart = value; }
		}
		/// <summary>
		/// 返回对象是否被改变。
		/// </summary>
		public virtual bool IsChanged
		{
			get { return _isChanged; }
		}
		
		/// <summary>
		/// Returns whether or not the object has changed it's values.
		/// </summary>
		public virtual bool IsDeleted
		{
			get { return _isDeleted; }
		}
		
		#endregion 
		
		#region 公共方法
		
		/// <summary>
		/// mark the item as deleted
		/// </summary>
		public virtual void MarkAsDeleted()
		{
			_isDeleted = true;
			_isChanged = true;
		}
		
		
		#endregion
		
		#region Equals 和 HashCode 方法覆盖
		/// <summary>
		/// local implementation of Equals based on unique value members
		/// </summary>
		public override bool Equals( object obj )
		{
			if( this == obj ) return true;
			if( ( obj == null ) || ( obj.GetType() != this.GetType() ) ) return false;
			SystemUserBase castObj = (SystemUserBase)obj; 
			return ( castObj != null ) &&
				( this._user_id == castObj.UserID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _user_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserBase obj )
		{
			obj.UserLoginID = this._user_loginid;
			obj.UserName = this._user_name;
			obj.UserEmail = this._user_email;
			obj.UserPassword = this._user_password;
			obj.UserStatus = this._user_status;
			obj.UserCreateDate = this._user_create_date;
			obj.UserType = this._user_type;
			obj.DepartmentID = this._department_id;
			obj.MobilePIN = this._mobilepin;
			obj.PasswordFormat = this._passwordformat;
			obj.PasswordSalt = this._passwordsalt;
			obj.LoweredEmail = this._loweredemail;
			obj.PasswordQuestion = this._passwordquestion;
			obj.PasswordAnswer = this._passwordanswer;
			obj.Comments = this._comments;
			obj.IsApproved = this._isapproved;
			obj.IsLockedOut = this._islockedout;
			obj.LastActivityDate = this._lastactivitydate;
			obj.LastLoginDate = this._lastlogindate;
			obj.LastLockedOutDate = this._lastlockedoutdate;
			obj.LastPasswordChangeDate = this._lastpasswordchangedate;
			obj.FailedPwdAttemptCnt = this._failedpwdattemptcnt;
			obj.FailedPwdAttemptWndStart = this._failedpwdattemptwndstart;
			obj.FailedPwdAnsAttemptCnt = this._failedpwdansattemptcnt;
			obj.FailedPwdAnsAttemptWndStart = this._failedpwdansattemptwndstart;
		}
        #endregion
	}
}
