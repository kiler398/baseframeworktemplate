using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    /// <summary>
    /// 系统部门数据访问类
    /// </summary>
    public class SystemDepartmentDao : SystemDepartmentBaseDao
    {
        public SystemDepartmentDao()
        {
        }

        /// <summary>
        /// 查找指定部门下面的子部门
        /// </summary>
        /// <param name="parentDepartment">负部门类：null代表最上层</param>
        /// <returns>父部门下的所有子部门</returns>
        public List<SystemDepartment> GetSubDepartmentByParentDepartment(SystemDepartment parentDepartment)
        {
            DetachedCriteria departmentCriteria = DetachedCriteria.For(typeof(SystemDepartment));
            if (parentDepartment == null)
                departmentCriteria.Add(SystemDepartmentDao.PROPERTY_PARENTDEPARTMENTID.IsNull());
            else
                departmentCriteria.Add(SystemDepartmentDao.PROPERTY_PARENTDEPARTMENTID.Eq(parentDepartment));
            return this.FindListByDetachedCriteriaQuery(departmentCriteria);
        }
    }
}
