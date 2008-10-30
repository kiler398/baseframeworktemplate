using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.CustomException;
using Easyasp.Framework.Core.Utility;
using Easyasp.Framework.Core.Web.Security;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemUserService : SystemUserBaseService
    {
        public SystemUserService()
        {

        }

        protected const string DEV_USER_ID = "DeveloperAdministrator";
        protected const string SYS_USER_ID = "SystemAdministrator";




        //public void AuthenticateRequestUser()
        //{
        //    FormsAuthenticationTicket authTicket = this.GetTicket(HttpContext.Current);
        //    if (null != authTicket)
        //    {
        //        FormsIdentity id = new FormsIdentity(authTicket);
        //        Pair userData = this.GetUserData(HttpContext.Current);
        //        List<SystemRole> roles = null;
        //        SystemUser systemUser = null;
        //        if (userData != null)
        //        {
        //            roles = (List<SystemRole>)userData.Second;
        //            systemUser = (SystemUser)userData.First;
        //        }
        //        else
        //        {
        //            roles = new List<SystemRole>();
        //            systemUser = null;
        //        }
        //        HttpContext.Current.Items["Context_Key_LoginUser"] = systemUser;
        //        HttpContext.Current.Items["Context_Key_LoginUserAssignRole"] = roles;
        //        List<string> listRoleName = new List<string>();
        //        foreach (SystemRole role in roles)
        //        {
        //            listRoleName.Add(role.RoleName);
        //        }
        //        HttpContext.Current.User = new LoginPermissionPrincipal(id, listRoleName);
        //    }
        //}

        public override void Create(SystemUser obj)
        {
            if (obj.UserLoginID.Equals("DeveloperAdministrator"))
            {
                throw new DataValidationException(" Login ID ¡±DeveloperAdministrator¡° has exist¡£");
            }
            if (obj.UserLoginID.Equals("SystemAdministrator"))
            {
                throw new DataValidationException(" Login ID ¡±SystemAdministrator¡° has exist¡£");
            }
            if (base.SelfDao.GetUserByLoginID(obj.UserLoginID) != null)
            {
                throw new DataValidationException(" Login ID ¡±" + obj.UserLoginID + "¡° has exist¡£");
            }
            base.Create(obj);
        }

        public SystemUser GetCurrentLoginUser()
        {
            if (HttpContext.Current.User != null && HttpContext.Current.User.Identity != null && HttpContext.Current.User.Identity.IsAuthenticated)
            {
                if (HttpContext.Current.Session["CurrentLoginUser"] == null)
                {
                    HttpContext.Current.Session["CurrentLoginUser"] = this.GetUserByLoginID(HttpContext.Current.User.Identity.Name.ToString());
                }
                return HttpContext.Current.Session["CurrentLoginUser"] as SystemUser;
            }
            else
            {
                return null;
            }
        }

        //public List<SystemRole> GetCurrentLoginUserAssignedRole()
        //{
        //    if (HttpContext.Current.Items["Context_Key_LoginUserAssignRole"] == null)
        //    {
        //        return new List<SystemRole>();
        //    }
        //    return (List<SystemRole>)HttpContext.Current.Items["Context_Key_LoginUserAssignRole"];
        //}

        //private FormsAuthenticationTicket GetTicket(HttpContext context)
        //{
        //    string cookieName = FormsAuthentication.FormsCookieName;
        //    HttpCookie authCookie = context.Request.Cookies[cookieName];
        //    if (null == authCookie)
        //    {
        //        return null;
        //    }
        //    FormsAuthenticationTicket authTicket = null;
        //    try
        //    {
        //        authTicket = FormsAuthentication.Decrypt(authCookie.Value);
        //    }
        //    catch (Exception ex)
        //    {
        //        base.Logger.Error(ex.Message);
        //        return null;
        //    }
        //    return authTicket;
        //}

        public List<SystemRole> GetUserAssignedRoleByUserLoginID(string loginID)
        {
            SystemUser user = base.SelfDao.GetUserByLoginID(loginID);
            List<SystemRole> list = this.DaosContainerIocID.SystemUserRoleRelationDaoInstance.GetUserAssignRole(user);
            foreach (SystemRole role in list)
            {
                this.DaosContainerIocID.SystemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLEID);
                this.DaosContainerIocID.SystemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLENAME);
                this.DaosContainerIocID.SystemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLEDESCRIPTION);
                this.DaosContainerIocID.SystemRoleDaoInstance.InitializeLazyProperty(role, SystemRole.PROPERTY_NAME_ROLEISSYSTEMROLE);
            }
            return list;
        }

        public SystemUser GetUserByLoginIDAndPassword(string loginID, string password)
        {
            SystemUser findUser = base.SelfDao.GetUserByLoginIDAndPassword(loginID, password);
            if ((findUser != null) && findUser.UserPassword.Equals(password))
            {
                return findUser;
            }
            return null;
        }

        private Pair GetUserData(HttpContext context)
        {
            if (context.Request.Cookies[FormsAuthentication.FormsCookieName + "UserInfo"] == null)
            {
                return null;
            }
            return SerializableUtil.ConvertZipedBase64StringToObject<Pair>(context.Request.Cookies[FormsAuthentication.FormsCookieName + "UserInfo"].Value);
        }

        public string WebUserLoginIn(SystemUser systemUser, bool persistentUser, HttpContext context)
        {
            List<SystemRole> listRole = this.DaosContainerIocID.SystemUserRoleRelationDaoInstance.GetUserAssignRole(systemUser);
            Pair pair = new Pair(systemUser, listRole);
            string userInfo = SerializableUtil.ConvertObjectToZipedBase64String<Pair>(pair);
            HttpCookie userC = new HttpCookie(FormsAuthentication.FormsCookieName + "UserInfo", userInfo);
            context.Response.Cookies.Add(userC);
            FormsAuthenticationTicket tk = new FormsAuthenticationTicket(1, systemUser.UserLoginID.ToString(), DateTime.Now, DateTime.Now.AddMinutes(30.0), persistentUser, "", FormsAuthentication.FormsCookiePath);
            string key = FormsAuthentication.Encrypt(tk);
            HttpCookie ck = new HttpCookie(FormsAuthentication.FormsCookieName, key);
            context.Response.Cookies.Add(ck);
            return FormsAuthentication.GetRedirectUrl(systemUser.UserLoginID.ToString(), persistentUser);
        }

        public void WebUserLoginOut(HttpContext context)
        {
            FormsAuthentication.SignOut();
            FormsAuthentication.RedirectToLoginPage();
        }


        public SystemUser GetUserByLoginID(string loginID)
        {
            return this.DaosContainerIocID.SystemUserDaoInstance.GetUserByLoginID(loginID);
        }

        public SystemUser GetUserByEmail(string email)
        {
            return this.DaosContainerIocID.SystemUserDaoInstance.GetUserByEmail(email);
        }

        public bool CheckUserRoleRelationIsExist(SystemUser user, SystemRole role)
        {
            SystemUserRoleRelation systemUserRoleRelation = this.DaosContainerIocID.SystemUserRoleRelationDaoInstance.GetUserRoleRelation(user, role);
            return (systemUserRoleRelation != null);
        }

        public List<SystemUser> FindUsersByEmail(string match, int index, int size, out int records)
        {
            return this.SelfDao.FindUsersByEmail(match, index, size, out records);
        }

        internal List<SystemUser> FindAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            return this.SelfDao.FindAllUsers(pageIndex, pageSize, out totalRecords);
        }

        public int FindOnlineUsersCount(DateTime time)
        {
            return this.SelfDao.FindOnlineUsersCount(time);
        }

        public List<SystemUser> FindUsersByName(string match, int index, int size, out int records)
        {

            return this.SelfDao.FindUsersByName(match, index, size, out records);


        }

        public List<SystemPrivilege> GetUserPrivilegeByUserLoginID(SystemUser user, SystemMoudle moudle)
        {
            throw new NotImplementedException();
        }
    }
}
