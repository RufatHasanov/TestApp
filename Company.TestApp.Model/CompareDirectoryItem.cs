#region System Usings
using System;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Enums;
#endregion Custom Usings
/// <summary>
/// Information about a compared directory items
/// </summary>
namespace Company.TestApp.Model
{
    /// <summary>
    /// Comparable directories folders and files fullpath model
    /// </summary>
    public class CompareDirectoryItem : IComparable<CompareDirectoryItem>
    {
        #region Properties
        /// <summary>
        /// The item of first directory
        /// </summary>
        public DirectoryFileItem FirstDirectoryItem { get; set; }

        /// <summary>
        /// The item of second directory
        /// </summary>
        public DirectoryFileItem SecondDirectoryItem { get; set; }

        /// <summary>
        /// Path part after searched dir
        /// </summary>
        public string ComparableValue { get; set; }

        /// <summary>
        /// The type of item
        /// </summary>
        public DirectoryItemType Type { get; set; }
        #endregion Properties

        #region Public methods
        /// <summary>
        /// Compare object
        /// </summary>
        /// <param name="other"></param>
        /// <returns></returns>
        public int CompareTo(CompareDirectoryItem other)
        {
            // If other is not a valid object reference, this instance is greater.
            if (other == null) return 1;

            return this.ComparableValue.CompareTo(other.ComparableValue);
        }
        #endregion  Public methods
    }
}