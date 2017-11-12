#region System Usings
using System.Collections.Generic;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Business;
using Company.TestApp.Enums;
using Company.TestApp.Model;
#endregion Custom Usings

namespace Company.TestApp.UnitTest
{
    /// <summary>
    /// Example IDirectoryStructure with equal values
    /// </summary>
    public class ListWithEqualValues : IDirectoryStructure
    {
        /// <summary>
        /// Private field with static values 
        /// </summary>
        private List<CompareDirectoryItem> items = new List<CompareDirectoryItem>() { new CompareDirectoryItem() { ComparableValue = @"App\",FirstDirectoryItem = new DirectoryItem() {Name=@"App\",FullPath= @"C:\App\" }, SecondDirectoryItem = new DirectoryItem() {Name=@"App\",FullPath= @"C:\App\" }, Type=DirectoryItemType.Folder },
                                                                                  new CompareDirectoryItem() { ComparableValue = @"App\",FirstDirectoryItem = new DirectoryItem() {Name=@"App\",FullPath= @"C:\App\" }, SecondDirectoryItem = new DirectoryItem() {Name=@"App\",FullPath= @"C:\App\" }, Type=DirectoryItemType.Folder } };
        /// <summary>
        /// Get Test List with same values
        /// </summary> 
        /// <returns></returns>
        public List<CompareDirectoryItem> GetDirectoriesContent()
        {
            return items;
        }
    }
}
