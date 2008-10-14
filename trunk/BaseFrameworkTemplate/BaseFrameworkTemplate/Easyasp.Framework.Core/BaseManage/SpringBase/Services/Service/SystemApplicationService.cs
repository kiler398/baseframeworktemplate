using System;
using System.Collections.Generic;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate;
using NHibernate.Criterion;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemApplicationService : SystemApplicationBaseService
    {
        public SystemApplicationService()
        {
        }

        public List<SystemApplication> GetAll(int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(SystemApplicationDao.PROPERTY_SYSTEMAPPLICATIONID.Desc());
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }

        [Transaction(TransactionPropagation.Required)]
        public SystemApplication CreateOrLoadApplication(string s)
        {
            List<SystemApplication> listApplication = this.SelfDao.FindedApplicationsByName(s);
            if (listApplication.Count > 0)
                return listApplication[0];
            else
            {
                SystemApplication app = new SystemApplication()
                                            {
                                                SystemApplicationName = s,
                                                SystemApplicationDescription = s,
                                                SystemApplicationUrl = "#",
                                                SystemApplicationIsSystemApplication = true
                                            };
                this.selfDao.Save(app);
                return app;
            }
        
        }
    }
}