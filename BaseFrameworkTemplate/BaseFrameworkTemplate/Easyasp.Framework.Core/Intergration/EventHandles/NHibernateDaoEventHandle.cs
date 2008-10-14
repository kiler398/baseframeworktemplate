using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Intergration.EventHandles
{
    #region 委托的定义

    /// <summary>
    /// 数据变更事件
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataChangedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 数据创建委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataCreatedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 数据更新委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataUpdatedEventHandler(object sender, EventArgs e);

    /// <summary>
    /// 数据删除委托
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    public delegate void DataDeletedEventHandler(object sender, EventArgs e);

    #endregion
}
