using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;

namespace Easyasp.Framework.Core.Intergration.EventHandles
{
    public class MessageEventArgs : EventArgs
    {
        public LogLevel MessageLevel { get; set; }
        public string MessageTitle { get; set; }
        public string MessageContent { get; set; }

        public MessageEventArgs()
        {
        }

        public MessageEventArgs(LogLevel messageLevel, string messageTitle, string messageContent)
        {
            MessageLevel = messageLevel;
            MessageTitle = messageTitle;
            MessageContent = messageContent;
        }
    }
}
