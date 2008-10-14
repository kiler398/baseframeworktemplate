using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;
using Spring.Transaction;
using Spring.Transaction.Interceptor;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemRoleService : SystemRoleBaseService
    {
        public SystemRoleService()
        {

        }


        public List<SystemRole> GetAll(int firstRow, int maxRows, out int recordCount)
        {
            List<Order> orders = new List<Order>();
            orders.Add(SystemRoleDao.PROPERTY_ROLEID.Desc());
            List<ICriterion> criterions = new List<ICriterion>();
            return this.FindAll(criterions.ToArray(), orders.ToArray(), firstRow, maxRows, out recordCount);
        }


        public List<int> GetRoleAssignedApplicatonIDList(SystemRole role)
        {
            List<SystemApplication> list = this.DaosContainerIocID.SystemRoleApplicationDaoInstance.GetRoleAssignedApplicaton(role);
            List<int> applicatonIDList = new List<int>();
            foreach (SystemApplication application in list)
            {
                applicatonIDList.Add(application.SystemApplicationID);
            }
            return applicatonIDList;
        }

        [Transaction(TransactionPropagation.Required)]
        public virtual void SaveRoleAssignedApplicatonIDList(List<int> applicatonIDList, SystemRole role)
        {
            List<SystemRoleApplication> systemRoleApplications =
                this.DaosContainerIocID.SystemRoleApplicationDaoInstance.GetRoleApplicationRelationAssignedApplicaton(role);
            foreach (SystemRoleApplication roleApplication in systemRoleApplications)
            {
                this.DaosContainerIocID.SystemRoleApplicationDaoInstance.Delete(roleApplication);
            }
            foreach (int applicatonID in applicatonIDList)
            {
                SystemApplication assignedApplication = this.DaosContainerIocID.SystemApplicationDaoInstance.Load(applicatonID);
                SystemRoleApplication systemRoleApplication = new SystemRoleApplication();
                systemRoleApplication.RoleID = role;
                systemRoleApplication.ApplicationID = assignedApplication;
                this.DaosContainerIocID.SystemRoleApplicationDaoInstance.Save(systemRoleApplication);
            }
        }


        [Transaction(TransactionPropagation.Required)]
        public virtual void SaveRoleAssignedMenuIDList(List<int> menuIDList, SystemRole role)
        {
            List<SystemRoleMenuRelation> systemRoleMenuRelations =
                this.DaosContainerIocID.SystemRoleMenuRelationDaoInstance.GetRoleMenuRelationAssignedApplicaton(role);
            foreach (SystemRoleMenuRelation roleMenuRelation in systemRoleMenuRelations)
            {
                this.DaosContainerIocID.SystemRoleMenuRelationDaoInstance.Delete(roleMenuRelation);
            }
            foreach (int menuID in menuIDList)
            {
                SystemMenu assignedMenu = this.DaosContainerIocID.SystemMenuDaoInstance.Load(menuID);
                SystemRoleMenuRelation systemRoleMenuRelation = new SystemRoleMenuRelation();
                systemRoleMenuRelation.RoleID = role;
                systemRoleMenuRelation.MenuID = assignedMenu;
                this.DaosContainerIocID.SystemRoleMenuRelationDaoInstance.Save(systemRoleMenuRelation);
            }
        }


        public virtual List<string> GetRoleAssigedMenuIDs(SystemRole role)
        {
            List<string> list = new List<string>();
            List<SystemRoleMenuRelation> systemRoleMenuRelations =
    this.DaosContainerIocID.SystemRoleMenuRelationDaoInstance.GetRoleMenuRelationAssignedApplicaton(role);
            foreach (SystemRoleMenuRelation roleMenuRelation in systemRoleMenuRelations)
            {
                list.Add(roleMenuRelation.MenuID.MenuID.ToString());
            }
            return list;
        }

        public SystemRole GetRoleByName(string name)
        {
            return this.SelfDao.GetRoleByName(name);
        }
    }
}
