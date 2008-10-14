using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService
{
    public class SystemResourcesBaseService : BaseSpringNHibernateService<SystemResources>
    {
        public SystemResourcesDao SelfDao
        {
            get
            {
                return (SystemResourcesDao)selfDao;
            }
            set
            {
                selfDao = value;
            }
        }
		
		public DaosContainer DaosContainerIocID { set; get; }
		
    }
}
