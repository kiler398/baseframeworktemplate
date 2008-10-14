/*
在这里插入代码注释
*/
using System;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Domains.BaseDomain
{
	/// <summary>
	///	
	/// </summary>
	[Serializable]
	public abstract class SystemUserProfileBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain.SystemUserProfile";
		public static readonly string PROPERTY_NAME_PROFILEID = "ProfileID";
		public static readonly string PROPERTY_NAME_USERID = "UserID";
		public static readonly string PROPERTY_NAME_PROPERTYNAMES = "PropertyNames";
		public static readonly string PROPERTY_NAME_PROPERTYVALUESSTRING = "PropertyValuesString";
		public static readonly string PROPERTY_NAME_PROPERTYVALUESBINARY = "PropertyValuesBinary";
		public static readonly string PROPERTY_NAME_LASTUPDATEDDATE = "LastUpdatedDate";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _profile_id;
		private int _userid;
		private string _propertynames;
		private string _propertyvaluesstring;
		private Byte[] _propertyvaluesbinary;
		private DateTime? _lastupdateddate;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemUserProfileBase()
		{
			_profile_id = 0; 
			_userid = 0; 
			_propertynames = String.Empty; 
			_propertyvaluesstring = String.Empty;  
			_propertyvaluesbinary = new Byte[]{}; 
			_lastupdateddate =  null;  
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int ProfileID
		{
			get { return _profile_id; }
			set { _isChanged |= (_profile_id != value); _profile_id = value; }
		}
		/// <summary>
		/// 用户ID
		/// </summary>		
		public virtual int UserID
		{
			get { return _userid; }
			set { _isChanged |= (_userid != value); _userid = value; }
		}
		/// <summary>
		/// 属性名
		/// </summary>		
		public virtual string PropertyNames
		{
			get { return _propertynames; }
			set	
			{
				if ( value != null)
					if( value.Length > 1073741823)
						throw new ArgumentOutOfRangeException("Invalid value for PropertyNames", value, value.ToString());
				
				_isChanged |= (_propertynames != value); _propertynames = value;
			}
		}
		/// <summary>
		/// 属性值
		/// </summary>		
		public virtual string PropertyValuesString
		{
			get { return _propertyvaluesstring; }
			set	
			{
				if ( value != null)
					if( value.Length > 1073741823)
						throw new ArgumentOutOfRangeException("Invalid value for PropertyValuesString", value, value.ToString());
				
				_isChanged |= (_propertyvaluesstring != value); _propertyvaluesstring = value;
			}
		}
		/// <summary>
		/// 属性二进制值
		/// </summary>		
		public virtual Byte[] PropertyValuesBinary
		{
			get { return _propertyvaluesbinary; }
			set { _isChanged |= (_propertyvaluesbinary != value); _propertyvaluesbinary = value; }
		}
		/// <summary>
		/// 上次更新时间
		/// </summary>		
		public virtual DateTime? LastUpdatedDate
		{
			get { return _lastupdateddate; }
			set { _isChanged |= (_lastupdateddate != value); _lastupdateddate = value; }
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
			SystemUserProfileBase castObj = (SystemUserProfileBase)obj; 
			return ( castObj != null ) &&
				( this._profile_id == castObj.ProfileID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _profile_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemUserProfileBase obj )
		{
			obj.UserID = this._userid;
			obj.PropertyNames = this._propertynames;
			obj.PropertyValuesString = this._propertyvaluesstring;
			obj.PropertyValuesBinary = this._propertyvaluesbinary;
			obj.LastUpdatedDate = this._lastupdateddate;
		}
        #endregion
	}
}
