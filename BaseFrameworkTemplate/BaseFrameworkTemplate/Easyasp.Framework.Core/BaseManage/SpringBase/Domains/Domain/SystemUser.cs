/*
在这里插入代码注释
*/
using System;
using System.Collections;
using System.Web.Security;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.BaseDomain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain
{
	/// <summary>
	///	系统用户
	/// </summary>
	[Serializable]
	public class SystemUser : SystemUserBase
	{
        public SystemUser()
        {
            UserCreateDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
            LastLockedOutDate = DateTime.Now;
            LastPasswordChangeDate = DateTime.Now;
            FailedPwdAnsAttemptWndStart = DateTime.Now;
            FailedPwdAttemptWndStart = DateTime.Now;
            Applications = new ArrayList();
        }

        public SystemUser(int id)
        {
            UserCreateDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
            LastLockedOutDate = DateTime.Now;
            LastPasswordChangeDate = DateTime.Now;
            FailedPwdAnsAttemptWndStart = DateTime.Now;
            FailedPwdAttemptWndStart = DateTime.Now;
            Applications = new ArrayList();
            UserID = id;
        }

        public SystemUser(string name) // : base(name)
        {
            UserCreateDate = DateTime.Now;
            LastActivityDate = DateTime.Now;
            LastLoginDate = DateTime.Now;
            LastLockedOutDate = DateTime.Now;
            LastPasswordChangeDate = DateTime.Now;
            FailedPwdAnsAttemptWndStart = DateTime.Now;
            FailedPwdAttemptWndStart = DateTime.Now;
            Applications = new ArrayList();
        }

        public virtual IList Applications { get; set; }


        public virtual SystemUser FromMembershipUser(MembershipUser mu)
        {
            UserID = Convert.ToInt32(mu.ProviderUserKey);
            UserLoginID = mu.UserName;
            UserEmail = mu.Email;
            PasswordQuestion = mu.PasswordQuestion;
            Comments = mu.Comment;
            IsApproved = mu.IsApproved;
            IsLockedOut = mu.IsLockedOut;
            UserCreateDate = mu.CreationDate;
            LastActivityDate = mu.LastActivityDate;
            LastLoginDate = mu.LastLoginDate;
            LastPasswordChangeDate = mu.LastPasswordChangedDate;
            LastLockedOutDate = mu.LastLockoutDate;
            return this;
        }

        public virtual MembershipUser ToMembershipUser(string providerName)
        {
            return new MembershipUser(providerName, UserLoginID, UserID, UserEmail, PasswordQuestion, Comments,
                                      IsApproved, IsLockedOut, UserCreateDate.Value, LastLoginDate.Value,
                                      LastActivityDate.Value, LastPasswordChangeDate.Value, LastLockedOutDate.Value);
        }
	}
}
