using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.Intergration.Springs;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService
{
    public class SystemApplicationBaseService : BaseSpringNHibernateService<SystemApplication>
    {
        public SystemApplicationDao SelfDao
        {
            get
            {
                return (SystemApplicationDao)selfDao;
            }
            set
            {
                selfDao = value;
            }
        }
		
		public DaosContainer DaosContainerIocID { set; get; }



    }
}
