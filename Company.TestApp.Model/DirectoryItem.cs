
#region System Usings
using System;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Enums; 
#endregion Custom Usings
/// <summary>
/// Information about a directory item such as a file or a folder
/// </summary>
namespace Company.TestApp.Model
{
    public class DirectoryItem : IComparable<DirectoryItem>
    {
        #region Properties
        /// <summary>
        /// The type of this item
        /// </summary>
        public DirectoryItemType Type { get; set; }

        /// <summary>
        /// The absolute path to this item directory
        /// </summary>
        public string FullPath { get; set; }


        /// <summary>
        /// The Name of this item directory 
        /// </summary>
        public string Name { get; set; }
        #endregion Properties

        #region Public methods
        // Alphabetic sort by directory item name - [A to Z]
        public int CompareTo(DirectoryItem other)
        {

            int result = this.Name.CompareTo(other.Name);
            return result;
        }
        #endregion Public methods

    }
}