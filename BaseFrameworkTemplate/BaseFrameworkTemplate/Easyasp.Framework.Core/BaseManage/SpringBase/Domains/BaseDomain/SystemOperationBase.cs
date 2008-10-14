/*
在这里插入代码注释
*/
using System;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Domains.BaseDomain
{
	/// <summary>
	///	系统操作
	/// </summary>
	[Serializable]
	public abstract class SystemOperationBase
	{
	
		#region 公共常量		
		public static readonly string CLASS_FULL_NAME = "Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain.SystemOperation";
		public static readonly string PROPERTY_NAME_OPERATIONID = "OperationID";
		public static readonly string PROPERTY_NAME_OPERATIONNAMECN = "OperationNameCn";
		public static readonly string PROPERTY_NAME_OPERATIONNAMEEN = "OperationNameEn";
		public static readonly string PROPERTY_NAME_OPERATIONDESCRIPTION = "OperationDescription";
		public static readonly string PROPERTY_NAME_ISSYSTEMOPERATION = "IsSystemOperation";
		public static readonly string PROPERTY_NAME_ISCANSINGLEOPERATION = "IsCanSingleOperation";
		public static readonly string PROPERTY_NAME_ISCANMUTILOPERATION = "IsCanMutilOperation";
		public static readonly string PROPERTY_NAME_ISENABLE = "IsEnable";
		public static readonly string PROPERTY_NAME_ISINLISTPAGE = "IsInListPage";
		public static readonly string PROPERTY_NAME_ISINSINGLEPAGE = "IsInSinglePage";
		public static readonly string PROPERTY_NAME_OPERATIONORDER = "OperationOrder";
		
        #endregion
	
		#region 私有成员变量
		private bool _isChanged;
		private bool _isDeleted;
		private int _operation_id;
		private string _operation_namecn;
		private string _operation_nameen;
		private string _operation_description;
		private bool _issystemoperation;
		private bool _iscansingleoperation;
		private bool _iscanmutiloperation;
		private bool _isenable;
		private bool _isinlistpage;
		private bool _isinsinglepage;
		private int _operation_order;
		#endregion
		
		#region 构造函数
		/// <summary>
		/// 默认构造函数
		/// </summary>
		public SystemOperationBase()
		{
			_operation_id = 0; 
			_operation_namecn = String.Empty; 
			_operation_nameen = String.Empty; 
			_operation_description = String.Empty; 
			_issystemoperation = false; 
			_iscansingleoperation = false; 
			_iscanmutiloperation = false; 
			_isenable = false; 
			_isinlistpage = false; 
			_isinsinglepage = false; 
			_operation_order = 0; 
		}
		#endregion
		
		#region 公共属性
			
		/// <summary>
		/// 主键
		/// </summary>		
		public virtual int OperationID
		{
			get { return _operation_id; }
			set { _isChanged |= (_operation_id != value); _operation_id = value; }
		}
		/// <summary>
		/// 操作中文名
		/// </summary>		
		public virtual string OperationNameCn
		{
			get { return _operation_namecn; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for OperationNameCn", value, value.ToString());
				
				_isChanged |= (_operation_namecn != value); _operation_namecn = value;
			}
		}
		/// <summary>
		/// 操作代号
		/// </summary>		
		public virtual string OperationNameEn
		{
			get { return _operation_nameen; }
			set	
			{
				if ( value != null)
					if( value.Length > 200)
						throw new ArgumentOutOfRangeException("Invalid value for OperationNameEn", value, value.ToString());
				
				_isChanged |= (_operation_nameen != value); _operation_nameen = value;
			}
		}
		/// <summary>
		/// 操作描述
		/// </summary>		
		public virtual string OperationDescription
		{
			get { return _operation_description; }
			set	
			{
				if ( value != null)
					if( value.Length > 2000)
						throw new ArgumentOutOfRangeException("Invalid value for OperationDescription", value, value.ToString());
				
				_isChanged |= (_operation_description != value); _operation_description = value;
			}
		}
		/// <summary>
		/// 是否为系统操作
		/// </summary>		
		public virtual bool IsSystemOperation
		{
			get { return _issystemoperation; }
			set { _isChanged |= (_issystemoperation != value); _issystemoperation = value; }
		}
		/// <summary>
		/// 是否可以单条数据操作
		/// </summary>		
		public virtual bool IsCanSingleOperation
		{
			get { return _iscansingleoperation; }
			set { _isChanged |= (_iscansingleoperation != value); _iscansingleoperation = value; }
		}
		/// <summary>
		/// 是否可以多条数据操作
		/// </summary>		
		public virtual bool IsCanMutilOperation
		{
			get { return _iscanmutiloperation; }
			set { _isChanged |= (_iscanmutiloperation != value); _iscanmutiloperation = value; }
		}
		/// <summary>
		/// 是否生效
		/// </summary>		
		public virtual bool IsEnable
		{
			get { return _isenable; }
			set { _isChanged |= (_isenable != value); _isenable = value; }
		}
		/// <summary>
		/// 是否出现在列表页面
		/// </summary>		
		public virtual bool IsInListPage
		{
			get { return _isinlistpage; }
			set { _isChanged |= (_isinlistpage != value); _isinlistpage = value; }
		}
		/// <summary>
		/// 是否出现在详细页面
		/// </summary>		
		public virtual bool IsInSinglePage
		{
			get { return _isinsinglepage; }
			set { _isChanged |= (_isinsinglepage != value); _isinsinglepage = value; }
		}
		/// <summary>
		/// 操作排序号
		/// </summary>		
		public virtual int OperationOrder
		{
			get { return _operation_order; }
			set { _isChanged |= (_operation_order != value); _operation_order = value; }
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
			SystemOperationBase castObj = (SystemOperationBase)obj; 
			return ( castObj != null ) &&
				( this._operation_id == castObj.OperationID );
		}
		
		/// <summary>
		/// local implementation of GetHashCode based on unique value members
		/// </summary>
		public override int GetHashCode()
		{
			
			int hash = 57; 
			hash = 27 * hash * _operation_id.GetHashCode();
			return hash; 
		}
		#endregion
		
		#region CopyValue 方法
		/// <summary>
		/// CopyValue 方法
		/// </summary>
		public virtual void CopyValue( SystemOperationBase obj )
		{
			obj.OperationNameCn = this._operation_namecn;
			obj.OperationNameEn = this._operation_nameen;
			obj.OperationDescription = this._operation_description;
			obj.IsSystemOperation = this._issystemoperation;
			obj.IsCanSingleOperation = this._iscansingleoperation;
			obj.IsCanMutilOperation = this._iscanmutiloperation;
			obj.IsEnable = this._isenable;
			obj.IsInListPage = this._isinlistpage;
			obj.IsInSinglePage = this._isinsinglepage;
			obj.OperationOrder = this._operation_order;
		}
        #endregion
	}
}
