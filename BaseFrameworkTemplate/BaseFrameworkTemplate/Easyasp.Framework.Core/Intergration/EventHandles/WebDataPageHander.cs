using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Intergration.EventHandles
{
    public delegate void LoadDataFailedEventHandler(object sender, MessageEventArgs e);

    public delegate void OperationFailedEventHandler(object sender, MessageEventArgs e);

    public delegate void OperationSuccessedEventHandler(object sender, MessageEventArgs e);

    public delegate void OperationSingleSelectDataEventHandler(object sender, SelectDataEventArgs e);

    public delegate void OperationMultiSelectDataEventHandler(object sender, SelectDataEventArgs e);
}
