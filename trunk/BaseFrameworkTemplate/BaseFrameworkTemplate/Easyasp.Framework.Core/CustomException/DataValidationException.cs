using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Easyasp.Framework.Core.CustomException
{
    public class DataValidationException : System.Exception
    {
        public DataValidationException(string message)
            : base(message)
        {
        }
    }
}
