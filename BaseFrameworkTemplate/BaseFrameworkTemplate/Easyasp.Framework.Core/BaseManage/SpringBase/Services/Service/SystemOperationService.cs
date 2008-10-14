using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemOperationService : SystemOperationBaseService
    {
        public SystemOperationService()
        {

        }

        public const string Operation_Add = "Add";
        public const string Operation_Delete = "Delete";
        public const string Operation_Edit = "Edit";
        public const string Operation_Export = "Export";
        public const string Operation_Print = "Print";
        public const string Operation_Refresh = "Refresh";
        public const string Operation_View = "View";  
  
    }
}
