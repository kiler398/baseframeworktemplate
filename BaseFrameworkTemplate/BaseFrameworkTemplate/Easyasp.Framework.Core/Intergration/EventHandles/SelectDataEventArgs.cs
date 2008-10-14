using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.Intergration.EventHandles
{
    public class SelectDataEventArgs : EventArgs
    {
        public SelectDataEventArgs(List<int> selectIDs, string commandName)
        {
            SelectIDs = selectIDs;
            CommandName = commandName;
        }

        public SelectDataEventArgs()
        {
        }

        public List<int> SelectIDs { get; set; }
        public string CommandName { get; set; }


    }
}
