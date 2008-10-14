using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemUserRoleRelationService : SystemUserRoleRelationBaseService
    {
        public SystemUserRoleRelationService()
        {

        }

        public List<SystemUser> GetRolesUser(SystemRole role)
        {
            List<SystemUserRoleRelation> listRelation = this.SelfDao.GetSystemUserRoleRelationByRole(role);
            List<SystemUser> listUser = new List<SystemUser>();
            foreach (SystemUserRoleRelation relation in listRelation)
            {
                listUser.Add(relation.UserID);
            }
            return listUser;
        }

        public SystemUserRoleRelation GetUserRoleRelation(SystemUser user, SystemRole role)
        {
            return SelfDao.GetUserRoleRelation(user, role);
        }

        public List<SystemUser> GetRolesUserByUserNameSearch(SystemRole role, string match)
        {
            List<SystemUserRoleRelation> listRelation = this.SelfDao.GetSystemUserRoleRelationByRoleUserNameSearch(role, match);
            List<SystemUser> listUser = new List<SystemUser>();
            foreach (SystemUserRoleRelation relation in listRelation)
            {
                listUser.Add(relation.UserID);
            }
            return listUser;
        }
    }
}
