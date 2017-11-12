#region System Usings
using System;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Enums;
#endregion Custom Usings

namespace Company.TestApp.Business
{
    /// <summary>
    /// Custom Exception class
    /// </summary>
    #region CustomException
    public class CustomException : ApplicationException
    {
        public CustomException() { }
        public CustomException(string message) : base(message) { }
        public CustomException(string message, Exception innerException) : base(message, innerException) { }
    }
    #endregion CustomException
}
