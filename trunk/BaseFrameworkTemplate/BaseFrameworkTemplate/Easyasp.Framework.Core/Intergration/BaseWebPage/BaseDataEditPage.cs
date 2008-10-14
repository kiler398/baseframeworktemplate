using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using Common.Logging;
using Easyasp.Framework.Core.Intergration.EventHandles;

namespace Easyasp.Framework.Core.Intergration.BaseWebPage
{
    public abstract class BaseDataEditPage<DomainType> : BaseDataViewPage<DomainType>
    {
        protected void UpdateData(DomainType obj)
        {
            this.SelfServiceIocID.Update(obj);
        }

        protected void UpdateCurrentData(DomainType domain)
        {
            try
            {
                UpdateData(domain);
                this.OnOperationSuccessed(new MessageEventArgs(LogLevel.Info, "操作成功", "用户修改" + this.GetModuleNameCn() + "成功"));
            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception e1)
            {
                this.OnOperationFailed(new MessageEventArgs(LogLevel.Error, "操作失败", "更新" + GetModuleNameCn() + "失败，错误原因：" + e1.Message));
            }
        }
    }
}
