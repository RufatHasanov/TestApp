#region Custom Using
using Company.TestApp.Enums;
#endregion Custom Using

namespace Company.TestApp.Model
{
    /// <summary>
    /// The model which store the directoryItem and action needed make the second directory identical to the one of the first directory
    /// </summary>
    public class DirectoryItemAndAction 
    {
        #region Properties
        /// <summary>
        /// Directory Item
        /// </summary>
        public DirectoryItem DirectoryItemValue { get; set; }

        /// <summary>
        /// Action related with directory 
        /// </summary>
        public DirectoryItemActionType ActionType { get; set; }
        #endregion Properties
    }
}
