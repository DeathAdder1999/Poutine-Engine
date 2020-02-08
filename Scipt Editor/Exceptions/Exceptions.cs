using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Scipt_Editor.Exceptions
{
    public class ExtensionNotSupportedException : Exception
    {
        public ExtensionNotSupportedException(string msg) : base(msg)
        {
        }

    }

    

}
