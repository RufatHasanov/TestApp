#region Custom Usings
using Company.TestApp.Enums;
#endregion Custom Usings

namespace Company.TestApp.ViewModels
{

    /// <summary>
    /// A view model for must be done to make second directory path like first directory path. Action List
    /// </summary>
    public sealed class DirectoryItemAndActionVM : BaseVM
    {
        #region Public Properties

        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The full path to the item
        /// </summary>
        public string FullPath { get; set; }
        /// <summary>
        /// Make second directory like first action type
        /// </summary>
        public DirectoryItemActionType ActionType { get; set; }
        /// <summary>
        /// The name of this item
        /// </summary>
        public string Name { get; set; }

        #endregion


        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="fullPath">The full path of this item</param>
        /// <param name="name">The name of this item</param>
        /// <param name="actionType">The action type of item</param>
        public DirectoryItemAndActionVM(string fullPath, string name, DirectoryItemActionType actionType)
        {  
            // Set path and Action type
            this.FullPath = fullPath;
            this.Name = name;
            this.ActionType = actionType; 
        }

        #endregion

       
    }
}
