#region System Usings
using System.Collections.Generic;
#endregion System Usings

#region Custon Usings
using Company.TestApp.Model;
#endregion Custom Usings

namespace Company.TestApp.Business
{
    /// <summary>
    /// IDirectory interface for class DirectoryStructure
    /// </summary>
    public interface ICompareDirectoryStructure
    {
        #region Properties
        /// <summary>
        /// Compare directories result
        /// </summary>
        List<CompareDirectoryItem> CompareResult { get;  }
        /// <summary>
        /// List of action for make second like first directory
        /// </summary>
        List<DirectoryItemAndAction> ActionList { get;  }

        #endregion Properties
    }
}
