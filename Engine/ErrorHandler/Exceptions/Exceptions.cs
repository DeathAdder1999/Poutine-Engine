using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Engine.ErrorHandler
{
    public enum Severity
    {
        FATAL,
        NON_FATAL
    }

    public class ExceptionBase : Exception
    {
        public Severity Severity { get; } = Severity.NON_FATAL;

        public ExceptionBase(string msg = "") : base(msg) { }

        public ExceptionBase(Severity severity, string msg = "") : this(msg)
        {
            Severity = severity;
        }
    }

#region Collections
    public class DuplicateException : ExceptionBase
    {
        public DuplicateException(Severity s, string msg = "") : base(s, msg) { }
        public DuplicateException(string msg="") : base(msg) { }
    }

    public class ElementNotFountException : ExceptionBase
    {
        public ElementNotFountException(Severity s, string msg ="") : base(s, msg) { }
        public ElementNotFountException(string msg="") : base(msg) { }
    }
    #endregion

    #region Components

    public class MissingComponentException : ExceptionBase
    {
        public MissingComponentException(string msg="") : base(msg) { }
        public MissingComponentException(Severity s, string msg="") : base(s, msg) { }
    }

    public class IllegalOperationException : ExceptionBase
    {
        public IllegalOperationException(string msg="") : base(msg) { }
        public IllegalOperationException(Severity s, string msg="") : base(s, msg) { }

    }

    #endregion

}
