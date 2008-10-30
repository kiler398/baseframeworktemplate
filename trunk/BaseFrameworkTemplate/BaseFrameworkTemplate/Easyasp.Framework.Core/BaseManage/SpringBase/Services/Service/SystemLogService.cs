using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemLogService : SystemLogBaseService
    {
        public SystemLogService()
        {

        }

        public enum SecurityVisitOperation { LoginOk, LoginFailed, LogOut, LoginTimeOut, HasNoPermissionToVisit }
        public enum LogLevel { Info, Warning, Debug, Error }
        public enum LogType { SecurityVisit, Authorization, BussnessOperation }

        //public string GenerateOperationOKInfo(string userName, string operationInfo)
        //{
        //    return string.Format("用户{0}于{1}时间进行{2}操作成功。", userName, System.DateTime.Now, operationInfo);
        //}
        //public string GenerateOperationFailedInfo(string userName, string operationInfo, string errorInfo)
        //{
        //    return string.Format("用户{0}于{1}时间进行{2}操作失败，错误信息：{3}。", userName, System.DateTime.Now, operationInfo, errorInfo);
        //}

        public string GenerateOperationAddOKInfo(SystemUser systemUser,string moudleName,string recordName,int relateID)
        {
            return string.Format("用户{0}于{1}时间添加了一个名为“{2}”的{3}成功。(id:{4},userID:{5})", systemUser.UserName, System.DateTime.Now, recordName, moudleName, relateID, systemUser.UserID);
        }

        public void LogOperationAddOKInfo(SystemUser systemUser, SystemMoudle systemMoudle, string recordName, int relateID,string source,string requestInfo)
        {
            SystemLog log = new SystemLog();
            log.LogDate = System.DateTime.Now;
            log.LogDescrption = GenerateOperationAddOKInfo(systemUser, systemMoudle.MoudleNameCn, recordName, relateID);
            log.LogLevel = LogLevel.Info.ToString();
            log.LogType = LogType.BussnessOperation.ToString();
            log.LogRelateDateTime = null;
            log.LogRelateMoudleDataID = relateID;
            log.LogRelateMoudleDataID = systemMoudle.MoudleID;
            log.LogRelateUserID = systemUser.UserID;
            log.LogUser = systemUser.UserName;
            log.LogSource = source;
            log.LogRequestInfo = requestInfo;
            this.Create(log);
        }

        public string GenerateOperationAddFailedInfo(SystemUser systemUser, string moudleName, string recordName,string errorMessage)
        {
            return string.Format("用户{0}于{1}时间添加了一个名为“{2}”的{3}失败。错误原因：{4}(userID:{5})。", systemUser.UserName, System.DateTime.Now, recordName, moudleName, errorMessage, systemUser.UserID);
        }



        public override void Create(SystemLog obj)
        {
            base.Create(obj);
            this.Logger.Info(obj.LogDescrption);
        }
    }
}
