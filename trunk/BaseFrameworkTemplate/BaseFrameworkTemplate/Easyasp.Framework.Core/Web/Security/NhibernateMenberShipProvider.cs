using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using System.Text;
using System.Web.Configuration;
using System.Web.Hosting;
using System.Web.Security;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service;
using Easyasp.Framework.Core.Utility;
using Spring.Context.Support;

namespace Easyasp.Framework.Core.Web.Security
{
    public class NhibernateMenberShipProvider : MembershipProvider
    {
        private SystemApplication application = new SystemApplication();
        private bool enablePasswordReset;
        private bool enablePasswordRetrieval;
        private MachineKeySection machineKey;
        private int maxInvalidPasswordAttempts;
        private int minRequiredNonAlphanumericCharacters;
        private int minRequiredPasswordLength;
        private int passwordAttemptWindow;
        private MembershipPasswordFormat passwordFormat;
        private string passwordStrengthRegularExpression;
        private bool requiresQuestionAndAnswer;
        private bool requiresUniqueEmail;
        private readonly ServicesContainer ServicesContainerInstance = (ServicesContainer)ContextRegistry.GetContext().GetObject("ServicesContainerIocID");
        //private SystemApplicationService systemApplicationService = (SystemApplicationService)ContextRegistry.GetContext().GetObject("SystemApplicationServiceIocID");
        //private SystemUserService systemUserService = (SystemUserService)ContextRegistry.GetContext().GetObject("SystemUserServiceIocID");

        /// <summary>
        /// 应用名称
        /// </summary>
        public override string ApplicationName
        {
            get { return application.SystemApplicationName; }
            set { application.SystemApplicationName = value; }
        }
        /// <summary>
        /// 是否允许密码重置
        /// </summary>
        public override bool EnablePasswordReset
        {
            get { return enablePasswordReset; }
        }
        /// <summary>
        /// 是否允许取回密码
        /// </summary>
        public override bool EnablePasswordRetrieval
        {
            get { return enablePasswordRetrieval; }
        }
        /// <summary>
        /// 最大尝试输入密码失败数
        /// </summary>
        public override int MaxInvalidPasswordAttempts
        {
            get { return maxInvalidPasswordAttempts; }
        }
        /// <summary>
        /// 最小尝试输入密码失败数
        /// </summary>
        public override int MinRequiredNonAlphanumericCharacters
        {
            get { return minRequiredNonAlphanumericCharacters; }
        }
        /// <summary>
        /// 最小密码要求非字母数
        /// </summary>
        public override int MinRequiredPasswordLength
        {
            get { return minRequiredPasswordLength; }
        }

        public override int PasswordAttemptWindow
        {
            get { return passwordAttemptWindow; }
        }

        public override MembershipPasswordFormat PasswordFormat
        {
            get { return passwordFormat; }
        }

        public override string PasswordStrengthRegularExpression
        {
            get { return passwordStrengthRegularExpression; }
        }

        public override bool RequiresQuestionAndAnswer
        {
            get { return requiresQuestionAndAnswer; }
        }
        /// <summary>
        /// 是否要求邮件唯一性
        /// </summary>
        public override bool RequiresUniqueEmail
        {
            get { return requiresUniqueEmail; }
        }

        public override MembershipUser CreateUser(string username, string password, string email,
                                                  string passwordQuestion, string passwordAnswer, bool isApproved,
                                                  object providerUserKey, out MembershipCreateStatus status)
        {
            var e = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(e);
            if (e.Cancel)
            {
                status = MembershipCreateStatus.InvalidPassword;
                return null;
            }
            if (RequiresUniqueEmail && !string.IsNullOrEmpty(GetUserNameByEmail(email)))
            {
                status = MembershipCreateStatus.DuplicateEmail;
                return null;
            }
            if (this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username) != null)
            {
                status = MembershipCreateStatus.DuplicateUserName;
                return null;
            }

            var user = new SystemUser
            {
                UserName = username,
                UserLoginID = username,
                UserPassword = EncodePassword(password, machineKey.ValidationKey),
                PasswordFormat = ((int)PasswordFormat),
                PasswordSalt = machineKey.ValidationKey,
                UserEmail = email,
                PasswordQuestion = passwordQuestion,
                PasswordAnswer = passwordAnswer,
                IsApproved = isApproved
            };
            user.Applications.Add(application);
            try
            {
                this.ServicesContainerInstance.SystemUserServiceInstance.Create(user);
                status = MembershipCreateStatus.Success;
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToCreate,
                                                                                     exception);
            }
            return GetUser(username, false);
        }

        public override bool ChangePasswordQuestionAndAnswer(string username, string password,
                                                             string newPasswordQuestion, string newPasswordAnswer)
        {
            bool flag = false;
            if (ValidateUser(username, password))
            {
                SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
                if (user == null)
                {
                    return flag;
                }
                try
                {
                    user.PasswordQuestion = newPasswordQuestion;
                    user.PasswordAnswer = EncodePassword(newPasswordAnswer, user.PasswordSalt);
                    user.LastActivityDate = DateTime.Now;
                    this.ServicesContainerInstance.SystemUserServiceInstance.Update(user);
                    flag = true;
                }
                catch
                {
                    throw new MembershipPasswordException(
                        NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this,
                                                                                         SR.Pwd_UnableToChangeQandA));
                }
            }
            return flag;
        }

        public override string GetPassword(string username, string answer)
        {
            string password = null;
            if (!EnablePasswordRetrieval)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Pwd_RetrievalNotEnabled);
            }
            if (MembershipPasswordFormat.Hashed == PasswordFormat)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Pwd_CannotRetrieveHashed);
            }
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
            if (user != null)
            {
                if (RequiresQuestionAndAnswer && !CheckPassword(answer, user.PasswordAnswer, user.PasswordSalt))
                {
                    UpdateFailureCount(username, FailureType.PasswordAnswer);
                    throw new MembershipPasswordException(
                        NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.Pwd_IncorrectAnswer));
                }
                if (MembershipPasswordFormat.Encrypted == PasswordFormat)
                {
                    password = UnencodePassword(password);
                }
            }
            return password;
        }

        public override bool ChangePassword(string username, string oldPassword, string newPassword)
        {
            bool flag = false;
            if (ValidateUser(username, oldPassword))
            {
                var e = new ValidatePasswordEventArgs(username, newPassword, true);
                OnValidatingPassword(e);
                if (e.Cancel)
                {
                    if (e.FailureInformation != null)
                    {
                        throw e.FailureInformation;
                    }
                    throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this,
                                                                                         SR.
                                                                                             Pwd_ChangeCancelledDueToNewPassword);
                }
                SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
                if (user == null)
                {
                    return flag;
                }
                try
                {
                    user.UserPassword = EncodePassword(newPassword, user.PasswordSalt);
                    user.LastPasswordChangeDate = DateTime.Now;
                    user.LastActivityDate = DateTime.Now;
                    this.ServicesContainerInstance.SystemUserServiceInstance.Update(user);
                    flag = true;
                }
                catch
                {
                    throw new MembershipPasswordException(
                        NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this,
                                                                                         SR.
                                                                                             Pwd_OpCancelledDueToAccountLocked));
                }
            }
            return flag;
        }

        public override string ResetPassword(string username, string answer)
        {
            if (!EnablePasswordReset)
            {
                throw new MembershipPasswordException(
                    NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.Pwd_ResetNotEnabled));
            }
            if ((answer == null) && RequiresQuestionAndAnswer)
            {
                UpdateFailureCount(username, FailureType.PasswordAnswer);
                throw new MembershipPasswordException(
                    NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.Pwd_AnswerRequiredForReset));
            }
            string password = Membership.GeneratePassword(minRequiredPasswordLength,
                                                          MinRequiredNonAlphanumericCharacters);
            var e = new ValidatePasswordEventArgs(username, password, true);
            OnValidatingPassword(e);
            if (e.Cancel)
            {
                if (e.FailureInformation != null)
                {
                    throw e.FailureInformation;
                }
                throw new MembershipPasswordException(
                    NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this,
                                                                                     SR.
                                                                                         Pwd_ResetCancelledDueToNewPassword));
            }
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
            if (user != null)
            {
                if (user.IsLockedOut)
                {
                    throw new MembershipPasswordException(
                        NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.User_IsLockedOut));
                }
                if (RequiresQuestionAndAnswer && !CheckPassword(answer, user.PasswordAnswer, user.PasswordSalt))
                {
                    UpdateFailureCount(username, FailureType.PasswordAnswer);
                    throw new MembershipPasswordException(
                        NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this, SR.Pwd_IncorrectAnswer));
                }
                try
                {
                    user.UserPassword = EncodePassword(password, user.PasswordSalt);
                    user.LastPasswordChangeDate = DateTime.Now;
                    user.LastActivityDate = DateTime.Now;
                    this.ServicesContainerInstance.SystemUserServiceInstance.SaveOrUpdate(user);
                }
                catch
                {
                    throw new MembershipPasswordException(
                        NhibernateMembershipProviderExceptionUtil.FormatExceptionMessage(this,
                                                                                         SR.
                                                                                             Pwd_OpCancelledDueToAccountLocked));
                }
            }
            return password;
        }

        public override void UpdateUser(MembershipUser user)
        {
            try
            {
                this.ServicesContainerInstance.SystemUserServiceInstance.SaveOrUpdate(this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(user.UserName).FromMembershipUser(user));
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToUpdate,
                                                                                     exception);
            }
        }

        public override bool ValidateUser(string username, string password)
        {
            bool flag = false;
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
            if (user != null)
            {
                if (CheckPassword(password, user.UserPassword, user.PasswordSalt))
                {
                    if (user.IsApproved)
                    {
                        flag = true;
                        UpdateLastLoginDate(username);
                    }
                    return flag;
                }
                UpdateFailureCount(username, FailureType.Password);
            }
            return flag;
        }

        public override bool UnlockUser(string userName)
        {
            bool flag = false;
            try
            {
                SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(userName);
                if (user != null)
                {
                    user.IsLockedOut = false;
                    user.LastLockedOutDate = DateTime.Now;
                    user.LastActivityDate = DateTime.Now;
                    this.ServicesContainerInstance.SystemUserServiceInstance.SaveOrUpdate(user);
                    flag = true;
                }
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToUnlock,
                                                                                     exception);
            }
            return flag;
        }

        public override MembershipUser GetUser(object providerUserKey, bool userIsOnline)
        {
            if (providerUserKey == null)
            {
                throw new ArgumentNullException("providerUserKey");
            }
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.FindById(providerUserKey);

            if (user == null)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToGet);
            }

            if (userIsOnline)
            {
                UpdateLastActivityDate(user.UserName);
            }

            return user.ToMembershipUser(Name);
        }

        public override MembershipUser GetUser(string username, bool userIsOnline)
        {
            if (username == null)
            {
                throw new ArgumentNullException("username");
            }

            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);

            if (user == null)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToGet);
            }

            if (userIsOnline)
            {
                UpdateLastActivityDate(user.UserName);
            }

            return user.ToMembershipUser(Name);
        }

        public override string GetUserNameByEmail(string email)
        {
            if (email == null)
            {
                throw new ArgumentNullException("email");
            }

            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByEmail(email);

            if (user == null)
            {
                //throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToGet);
                return null;
            }
            else
            {
                return user.UserLoginID;
            }


        }

        public override bool DeleteUser(string username, bool deleteAllRelatedData)
        {
            bool flag;
            try
            {
                SystemUser user = ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
                if (user != null)
                {
                    //级联删除用户相关数据。
                    ServicesContainerInstance.SystemUserServiceInstance.Delete(user);
                }
                flag = true;
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.User_UnableToDelete,
                                                                                     exception);
            }
            return flag;
        }

        public override MembershipUserCollection GetAllUsers(int pageIndex, int pageSize, out int totalRecords)
        {
            List<SystemUser> users = ServicesContainerInstance.SystemUserServiceInstance.FindAllUsers(pageIndex, pageSize, out totalRecords);
            var mc = new MembershipUserCollection();
            foreach (SystemUser systemUser in users)
            {
                mc.Add(systemUser.ToMembershipUser(Name));
            }
            return mc;
        }

        public override int GetNumberOfUsersOnline()
        {
            int num;
            try
            {
                var span = new TimeSpan(0, Membership.UserIsOnlineTimeWindow, 0);
                DateTime time = DateTime.Now.Subtract(span);
                num = this.ServicesContainerInstance.SystemUserServiceInstance.FindOnlineUsersCount(time);
            }
            catch (Exception exception)
            {
                throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this,
                                                                                     SR.User_UnableToGetOnlineNumber,
                                                                                     exception);
            }
            return num;
        }

        public override MembershipUserCollection FindUsersByName(string usernameToMatch, int pageIndex, int pageSize,
                                                                 out int totalRecords)
        {
            usernameToMatch = usernameToMatch.Replace('*', '%');
            usernameToMatch = usernameToMatch.Replace('?', '_');
            List<SystemUser> users = this.ServicesContainerInstance.SystemUserServiceInstance.FindUsersByName(usernameToMatch, pageIndex, pageSize,
                                                                       out totalRecords);
            var mc = new MembershipUserCollection();
            foreach (SystemUser systemUser in users)
            {
                mc.Add(systemUser.ToMembershipUser(Name));
            }
            return mc;
        }

        public override MembershipUserCollection FindUsersByEmail(string emailToMatch, int pageIndex, int pageSize,
                                                                  out int totalRecords)
        {
            emailToMatch = emailToMatch.Replace('*', '%');
            emailToMatch = emailToMatch.Replace('?', '_');
            List<SystemUser> users = ServicesContainerInstance.SystemUserServiceInstance.FindUsersByEmail(emailToMatch, pageIndex, pageSize,
                                                                        out totalRecords);
            var mc = new MembershipUserCollection();
            foreach (SystemUser systemUser in users)
            {
                mc.Add(systemUser.ToMembershipUser(Name));
            }
            return mc;
        }

        public override void Initialize(string name, NameValueCollection config)
        {

            if (config == null)
            {
                throw new ArgumentNullException("config");
            }
            if (string.IsNullOrEmpty(name))
            {
                name = "NHibernateMembershipProvider";
            }
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "NHibernate Membership Provider");
            }
            base.Initialize(name, config);
            application =
                this.ServicesContainerInstance.SystemApplicationServiceInstance.CreateOrLoadApplication(
                    ConfigurationUtil.GetConfigValue(config["applicationName"],
                                                     HostingEnvironment.ApplicationVirtualPath));
            requiresQuestionAndAnswer =
                Convert.ToBoolean(ConfigurationUtil.GetConfigValue(config["requiresQuestionAndAnswer"], "False"));
            requiresUniqueEmail =
                Convert.ToBoolean(ConfigurationUtil.GetConfigValue(config["requiresUniqueEmail"], "True"));
            enablePasswordRetrieval =
                Convert.ToBoolean(ConfigurationUtil.GetConfigValue(config["enablePasswordRetrieval"], "True"));
            enablePasswordReset =
                Convert.ToBoolean(ConfigurationUtil.GetConfigValue(config["enablePasswordReset"], "True"));
            maxInvalidPasswordAttempts =
                Convert.ToInt32(ConfigurationUtil.GetConfigValue(config["maxInvalidPasswordAttempts"], "5"));
            passwordAttemptWindow =
                Convert.ToInt32(ConfigurationUtil.GetConfigValue(config["passwordAttemptWindow"], "10"));
            minRequiredPasswordLength =
                Convert.ToInt32(ConfigurationUtil.GetConfigValue(config["minRequiredPasswordLength"], "7"));
            minRequiredNonAlphanumericCharacters =
                Convert.ToInt32(ConfigurationUtil.GetConfigValue(config["minRequiredAlphaNumericCharacters"], "1"));
            passwordStrengthRegularExpression =
                Convert.ToString(ConfigurationUtil.GetConfigValue(config["passwordStrengthRegularExpression"],
                                                                  string.Empty));
            string configValue = ConfigurationUtil.GetConfigValue(config["passwordFormat"], "Hashed");
            if (configValue != null)
            {
                if (!(configValue == "Hashed"))
                {
                    if (configValue == "Encrypted")
                    {
                        passwordFormat = MembershipPasswordFormat.Encrypted;
                        goto Label_01FB;
                    }
                    if (configValue == "Clear")
                    {
                        passwordFormat = MembershipPasswordFormat.Clear;
                        goto Label_01FB;
                    }
                }
                else
                {
                    passwordFormat = MembershipPasswordFormat.Hashed;
                    goto Label_01FB;
                }
            }
            throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, "password format not supported");
        Label_01FB:
            System.Configuration.Configuration configuration = WebConfigurationManager.OpenWebConfiguration(HostingEnvironment.ApplicationVirtualPath);
            machineKey = (MachineKeySection)configuration.GetSection("system.web/machineKey");
            if ("Auto".Equals(machineKey.Decryption))
            {
                machineKey.DecryptionKey = CryptographyUtil.CreateKey(0x18);
                machineKey.ValidationKey = CryptographyUtil.CreateKey(0x40);
            }
        }


        private static byte[] HexToByte(string hexString)
        {
            var buffer = new byte[(hexString.Length / 2) + 1];
            for (int i = 0; i <= ((hexString.Length / 2) - 1); i++)
            {
                buffer[i] = Convert.ToByte(hexString.Substring(i * 2, 2), 0x10);
            }
            return buffer;
        }

        private bool CheckPassword(string password1, string password2, string validationKey)
        {
            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Hashed:
                    password1 = EncodePassword(password1, validationKey);
                    break;

                case MembershipPasswordFormat.Encrypted:
                    password2 = UnencodePassword(password2);
                    break;
            }
            return (password1 == password2);
        }


        /// <summary>
        /// 解密密码
        /// </summary>
        /// <param name="password">密码</param>
        /// <returns>解密后结果</returns>
        private string UnencodePassword(string password)
        {
            string s = password;
            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    return s;

                case MembershipPasswordFormat.Hashed:
                    throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this,
                                                                                         SR.Pwd_CannotUnencodeHashed);

                case MembershipPasswordFormat.Encrypted:
                    return Encoding.Unicode.GetString(DecryptPassword(Convert.FromBase64String(s)));
            }
            throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Pwd_UnsupportedFormat);
        }

        private string EncodePassword(string password, string validationKey)
        {
            string str = password;
            switch (PasswordFormat)
            {
                case MembershipPasswordFormat.Clear:
                    return str;

                case MembershipPasswordFormat.Hashed:
                    {
                        if (string.IsNullOrEmpty(validationKey))
                        {
                            validationKey = machineKey.ValidationKey;
                        }
                        var hmacsha = new HMACSHA1 { Key = HexToByte(validationKey) };
                        return Convert.ToBase64String(hmacsha.ComputeHash(Encoding.Unicode.GetBytes(password)));
                    }
                case MembershipPasswordFormat.Encrypted:
                    return Convert.ToBase64String(EncryptPassword(Encoding.Unicode.GetBytes(password)));
            }
            throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this, SR.Pwd_UnsupportedFormat);
        }

        private void UpdateLastActivityDate(string username)
        {
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
            if (user != null)
            {
                try
                {
                    user.LastActivityDate = DateTime.Now;
                    this.ServicesContainerInstance.SystemUserServiceInstance.SaveOrUpdate(user);
                }
                catch (Exception exception)
                {
                    throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this,
                                                                                         SR.
                                                                                             User_UnableToUpdateLastActivityDate,
                                                                                         exception);
                }
            }
        }

        private void UpdateLastLoginDate(string username)
        {
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
            if (user != null)
            {
                try
                {
                    user.LastLoginDate = DateTime.Now;
                    this.ServicesContainerInstance.SystemUserServiceInstance.SaveOrUpdate(user);
                }
                catch (Exception exception)
                {
                    throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this,
                                                                                         SR.
                                                                                             User_UnableToUpdateLastLoginDate,
                                                                                         exception);
                }
            }
        }

        private void UpdateFailureCount(string username, FailureType failureType)
        {
            SystemUser user = this.ServicesContainerInstance.SystemUserServiceInstance.GetUserByLoginID(username);
            if (user != null)
            {
                DateTime now = DateTime.Now;
                int failedPasswordAttemptCount = 0;
                try
                {
                    switch (failureType)
                    {
                        case FailureType.Password:
                            now = user.FailedPwdAttemptWndStart.Value;
                            failedPasswordAttemptCount = user.FailedPwdAttemptCnt;
                            break;

                        case FailureType.PasswordAnswer:
                            now = user.FailedPwdAnsAttemptWndStart.Value;
                            failedPasswordAttemptCount = user.FailedPwdAnsAttemptCnt;
                            break;
                    }
                    DateTime time2 = now.AddMinutes(PasswordAttemptWindow);
                    if ((failedPasswordAttemptCount == 0) || (DateTime.Now > time2))
                    {
                        switch (failureType)
                        {
                            case FailureType.Password:
                                user.FailedPwdAttemptWndStart = DateTime.Now;
                                user.FailedPwdAttemptCnt = 1;
                                goto Label_00E7;

                            case FailureType.PasswordAnswer:
                                user.FailedPwdAnsAttemptWndStart = DateTime.Now;
                                user.FailedPwdAnsAttemptCnt = 1;
                                goto Label_00E7;
                        }
                    }
                    else
                    {
                        failedPasswordAttemptCount++;
                        if (failedPasswordAttemptCount >= MaxInvalidPasswordAttempts)
                        {
                            user.IsLockedOut = true;
                            user.LastLockedOutDate = DateTime.Now;
                        }
                        else
                        {
                            switch (failureType)
                            {
                                case FailureType.Password:
                                    user.FailedPwdAttemptCnt = failedPasswordAttemptCount;
                                    goto Label_00E7;

                                case FailureType.PasswordAnswer:
                                    user.FailedPwdAnsAttemptCnt = failedPasswordAttemptCount;
                                    goto Label_00E7;
                            }
                        }
                    }
                Label_00E7:
                    this.ServicesContainerInstance.SystemUserServiceInstance.SaveOrUpdate(user);
                }
                catch (Exception exception)
                {
                    throw NhibernateMembershipProviderExceptionUtil.NewProviderException(this,
                                                                                         SR.
                                                                                             User_UnableToUpdateFailureCount,
                                                                                         exception);
                }
            }
        }

        #region Nested type: FailureType

        private enum FailureType
        {
            Password,
            PasswordAnswer
        }

        #endregion
    }
}
