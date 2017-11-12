#region System Usings
using System.Collections.Generic;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Model;
#endregion Custom Usings

namespace Company.TestApp.Business
{
    /// <summary>
    /// IDirectoryStructure interface
    /// </summary>
    public interface IDirectoryStructure
    {
        #region Methods
        /// <summary>
        /// Get List of folder and files for compare
        /// </summary>
        /// <returns></returns>
        List<CompareDirectoryItem> GetDirectoriesContent();
        #endregion Methods
    }
}
