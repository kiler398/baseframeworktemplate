using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Easyasp.Framework.Core.BaseManage.SpringBase.Services.BaseService;
using Easyasp.Framework.Core.BaseManage.SpringBase.Daos.Dao;
using Easyasp.Framework.Core.BaseManage.SpringBase.Domains.Domain;

namespace Easyasp.Framework.Core.BaseManage.SpringBase.Services.Service
{
    public class SystemMoudleService : SystemMoudleBaseService
    {
        public SystemMoudleService()
        {
            
        }

        private SortedList<string, SystemMoudle> list = new SortedList<string, SystemMoudle>(); 

        public SystemMoudle GetSystemMoudleByName(string moudleName)
        {
            if(!list.ContainsKey(moudleName))
            {
                SystemMoudle systemMoudle = this.SelfDao.FindMoudleByName(moudleName);
                if(systemMoudle!=null)
                {
                    list.Add(moudleName, systemMoudle);
                    return systemMoudle;
                }
                else
                {
                    return null; 
                }
            }
            else
            {
                return list[moudleName];
            }

        }

    }
}
