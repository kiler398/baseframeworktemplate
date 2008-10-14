using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.BaseDao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using NHibernate.Criterion;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao
{
    public class SystemUserDao : SystemUserBaseDao
    {
        public SystemUserDao()
        {
        }
        public SystemUser GetUserByLoginID(string loginID)
        {
            var criterions = new List<ICriterion> { PROPERTY_USERLOGINID.Eq(loginID) };
            List<SystemUser> users = FindAll(criterions.ToArray());
            if (users.Count >= 1)
            {
                return users[0];
            }
            return null;
        }

        public SystemUser GetUserByEmail(string email)
        {
            var criterions = new List<ICriterion> { PROPERTY_USEREMAIL.Eq(email) };
            List<SystemUser> users = FindAll(criterions.ToArray());
            if (users.Count >= 1)
            {
                return users[0];
            }
            return null;
        }

        public SystemUser GetUserByLoginIDAndPassword(string loginID, string password)
        {
            var criterions = new List<ICriterion>
                                 {
                                     PROPERTY_USERLOGINID.Eq(loginID),
                                     PROPERTY_USERPASSWORD.Eq(password)
                                 };
            List<SystemUser> users = FindAll(criterions.ToArray());
            if ((users.Count >= 1) && users[0].UserPassword.Equals(password))
            {
                return users[0];
            }
            return null;
        }

        public List<SystemUser> FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize, out int totalRecords)
        {
            var criterions = new List<ICriterion> { PROPERTY_USEREMAIL.Like(emailToMatch) };
            return FindAll(criterions.ToArray(), (pageIndex - 1) * pageSize, pageSize, out totalRecords);
        }


        public List<SystemUser> FindUsersByName(string userName, int pageIndex, int pageSize, out int totalRecords)
        {
            var criterions = new List<ICriterion> { PROPERTY_USERLOGINID.Like(userName) };
            return FindAll(criterions.ToArray(), (pageIndex - 1) * pageSize, pageSize, out totalRecords);
        }


        public List<SystemUser> FindAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            var criterions = new List<ICriterion>();
            return FindAll(criterions.ToArray(), (pageIndex - 1) * pageSize, pageSize, out totalRecords);
        }


        public int FindOnlineUsersCount(DateTime checkDate)
        {
            var criterions = new List<ICriterion> { PROPERTY_LASTACTIVITYDATE.Gt(checkDate) };
            var pjs = new List<IProjection> { Projections.RowCount() };
            return ProjectionScalarQuery<int>(pjs.ToArray(), criterions.ToArray(), null);
        }
    }
}
