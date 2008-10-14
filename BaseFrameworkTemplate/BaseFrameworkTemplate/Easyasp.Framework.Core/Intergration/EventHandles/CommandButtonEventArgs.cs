using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Intergration.EventHandles
{
    public class CommandButtonEventArgs<T> : EventArgs
    {
        public string CommandName { get; set; }
        public List<T> CommandArguments { get; set; }  
    }
}
