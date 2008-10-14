using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using Easyasp.Framework.Core.Intergration.EventHandles;

namespace Easyasp.Framework.Core.Intergration.BaseWebPage
{
    public abstract class BaseDataViewPage<DomainType> : BaseDataManagePage<DomainType>
    {
        protected abstract string GetIDQueryStringKey();
        protected abstract string GetDataItemContextKey();
        protected abstract string GetModuleNameCn();

        protected int GetID
        {
            get
            {
                try
                {
                    return int.Parse(this.Request.QueryString[GetIDQueryStringKey()]);
                }
                catch
                {
                    return 0;
                }
            }
        }

        protected DomainType LoadDataByID(int id)
        {
            return this.SelfServiceIocID.FindById(id);
        }

        protected void DeleteDataByID(int id)
        {
            this.SelfServiceIocID.DeleteByID(id);
        }

        protected bool LoadData()
        {
            int id = GetID;
            if (id == 0)
            {
                this.OnLoadDataFailed(new MessageEventArgs(LogLevel.Error,"操作失败","无法获取ID。"));
                return false;
            }

            object obj = LoadDataByID(id);

            if (obj == null)
            {
                this.OnLoadDataFailed(new MessageEventArgs(LogLevel.Error,"操作失败","该条数据已不存在。"));
                return false;
            }
            else
            {
                this.Context.Items[GetDataItemContextKey()] = obj;
            }
            return true;
        }

        protected DomainType CurrentDataItem
        {

            get
            {
                if (this.Context.Items[GetDataItemContextKey()] == null)
                    return default(DomainType);
                else
                    return (DomainType)this.Context.Items[GetDataItemContextKey()];
            }
        }

        protected void DeleteCurrentObject()
        {
            //添加数据
            try
            {
                DeleteDataByID(this.GetID);
                this.OnOperationSuccessed(new MessageEventArgs(LogLevel.Info, "操作成功", "用户删除" + this.GetModuleNameCn() + "成功"));
            }
            catch (ThreadAbortException)
            {
            }
            catch (Exception e1)
            {
                this.OnOperationFailed(new MessageEventArgs(LogLevel.Error, "操作失败", "用户删除" + this.GetModuleNameCn() + "+失败，错误原因：" + e1.Message));
            }
        }







    }
}
