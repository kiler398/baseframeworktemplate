using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web.Hosting;
using System.Web.Security;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using Easyasp.Framework.Core.Utility;
using Spring.Context.Support;

namespace Easyasp.Framework.Core.Web.Security
{
    public class NhibernateRolesProvider : RoleProvider
    {
        private readonly ServicesContainer ServicesContainerInstance = (ServicesContainer)ContextRegistry.GetContext().GetObject("ServicesContainerIocID");
        private SystemApplication application = new SystemApplication();

        public override bool IsUserInRole(string username, string roleName)
        {
            bool flag = false;
            try
            {
                SystemUser user = ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
                SystemRole role = ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(roleName);
                if ((user != null) && (role != null))
                {
                    flag = ServicesContainerInstance.SystemUserServiceInstance.CheckUserRoleRelationIsExist(user, role);
                }
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToFindUserInRole, exception);
            }
            return flag;
        }

        public override string[] GetRolesForUser(string username)
        {
            try
            {
                var list = new List<string>();
                List<SystemRole> allRoles = ServicesContainerInstance.SystemUserServiceInstance.GetUserAssignedRoleByUserLoginID(username);
                foreach (var role in allRoles)
                {
                    list.Add(role.RoleName);
                }
                return list.ToArray();
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToGetRolesForUser, exception);
            }
        }

        public override void CreateRole(string roleName)
        {
            if (this.RoleExists(roleName))
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_AlreadyExists);
            }
            try
            {
                var role = new SystemRole { RoleName = roleName, RoleDescription = "", RoleIsSystemRole = false };
                ServicesContainerInstance.SystemRoleServiceInstance.SaveOrUpdate(role);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToCreate, exception);
            }
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            bool flag = false;
            if (throwOnPopulatedRole && (0 < this.GetUsersInRole(roleName).Length))
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, "role is not empty.");
            }
            try
            {
                SystemRole role = ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(roleName);
                if (role != null)
                {
                    //删除Role的级联数据
                    ServicesContainerInstance.SystemRoleServiceInstance.Delete(role);
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToDelete, exception);
            }
            return flag;
        }

        public override bool RoleExists(string roleName)
        {
            bool flag;
            try
            {
                flag = (ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(roleName) != null);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToCheckIfExists, exception);
            }
            return flag;
        }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            int length = usernames.Length;
            if (length != roleNames.Length)
            {
                throw new ArgumentOutOfRangeException(NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.Role_UserRoleParamsNotSameLength));
            }
            try
            {
                for (int i = 0; i < length; i++)
                {
                    SystemUser user = ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(usernames[i]);
                    SystemRole role = ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(roleNames[i]);
                    if (user != null && role != null && !ServicesContainerInstance.SystemUserServiceInstance.CheckUserRoleRelationIsExist(user, role))
                    {
                        var systemUserRoleRelation = new SystemUserRoleRelation
                        {
                            UserID = user,
                            RoleID = role
                        };
                        this.ServicesContainerInstance.SystemUserRoleRelationServiceInstance.Create(systemUserRoleRelation);
                    }
                }
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToAddUsersToRoles, exception);
            }
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            int length = usernames.Length;
            if (length != roleNames.Length)
            {
                throw new ArgumentOutOfRangeException(NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.Role_UserRoleParamsNotSameLength));
            }
            try
            {
                for (int i = 0; i < length; i++)
                {
                    SystemUser user = ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(usernames[i]);
                    SystemRole role = ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(roleNames[i]);
                    if (user != null && role != null)
                    {
                        var systemUserRoleRelation = this.ServicesContainerInstance.SystemUserRoleRelationServiceInstance.GetUserRoleRelation(user, role);
                        if (systemUserRoleRelation != null)
                            this.ServicesContainerInstance.SystemUserRoleRelationServiceInstance.Delete(systemUserRoleRelation);
                    }
                }
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToAddUsersToRoles, exception);
            }
        }

        public override string[] GetUsersInRole(string roleName)
        {
            try
            {
                SystemRole role = ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(roleName);
                var list = new List<string>();
                if (role == null)
                {
                    return list.ToArray();
                }
                List<SystemUser> allUsers = this.ServicesContainerInstance.SystemUserRoleRelationServiceInstance.GetRolesUser(role);
                foreach (var user in allUsers)
                {
                    list.Add(user.UserLoginID);
                }
                return list.ToArray();
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToGetUsersInRole, exception);
            }
        }

        public override string[] GetAllRoles()
        {
            try
            {
                var list = new List<string>();
                List<SystemRole> allRoles = ServicesContainerInstance.SystemRoleServiceInstance.FindAll();
                foreach (var role in allRoles)
                {
                    list.Add(role.RoleName);
                }
                return list.ToArray();
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToGetAllRoles, exception);
            }

        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            try
            {
                usernameToMatch = usernameToMatch.Replace('*', '%');
                usernameToMatch = usernameToMatch.Replace('?', '_');
                SystemRole role = ServicesContainerInstance.SystemRoleServiceInstance.GetRoleByName(usernameToMatch);
                var list = new List<string>();
                if (role == null)
                {
                    return list.ToArray();
                }
                List<SystemUser> allUsers = this.ServicesContainerInstance.SystemUserRoleRelationServiceInstance.GetRolesUserByUserNameSearch(role, usernameToMatch);
                foreach (var user in allUsers)
                {
                    list.Add(user.UserLoginID);
                }
                return list.ToArray();
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Role_UnableToFindUsersInRole, exception);
            }
        }


        public override void Initialize(string name, NameValueCollection config)
        {
            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "NHibernateRoleProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHibernate Role Provider");
            }
            base.Initialize(name, config);
            application =
                this.ServicesContainerInstance.SystemApplicationServiceInstance.CreateOrLoadApplication(
                    ConfigurationUtil.GetConfigValue(config["applicationName"],
                                                     HostingEnvironment.ApplicationVirtualPath));
        }

        public override string ApplicationName
        {
            get { return application.SystemApplicationName; }
            set { application.SystemApplicationName = value; }
        }
    }
}
