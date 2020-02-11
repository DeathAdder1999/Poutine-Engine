using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ErrorHandler.Exceptions
{

    #region Group

   
    public class GroupDuplicateException : Exception
    {
        public GroupDuplicateException(string msg = "") : base(msg) { }

    }

    public class GroupAbsentElementException : Exception
    {
        public GroupAbsentElementException(string msg = "") : base(msg) { }
    }


    #endregion
}
