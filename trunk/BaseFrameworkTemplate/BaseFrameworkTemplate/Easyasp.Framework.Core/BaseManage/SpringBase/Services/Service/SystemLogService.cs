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

        public string GenerateOperationOKInfo(string userName, string operationInfo)
        {
            return string.Format("用户{0}于{1}时间进行{2}操作成功。", userName, System.DateTime.Now, operationInfo);
        }
        public string GenerateOperationFailedInfo(string userName, string operationInfo, string errorInfo)
        {
            return string.Format("用户{0}于{1}时间进行{2}操作失败，错误信息：{3}。", userName, System.DateTime.Now, operationInfo, errorInfo);
        }

        public override void Create(SystemLog obj)
        {
            base.Create(obj);
            this.Logger.Info(obj.LogDescrption);
        }
    }
}
