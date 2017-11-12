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
    /// Example IDirectoryStructure with different values
    /// </summary>
    public class ListWithDiffValues : IDirectoryStructure
    {

        /// <summary>
        /// Get Test List 
        /// </summary> 
        /// <returns></returns>
        public List<CompareDirectoryItem> GetDirectoriesContent()
        {
            // Get all folders from first fullpath and general to list
            return new List<CompareDirectoryItem>() { new CompareDirectoryItem() { ComparableValue = @"App\",FirstDirectoryItem = new DirectoryItem() {Name=@"App\",FullPath= @"C:\App\" , Type=DirectoryItemType.Folder}, Type=DirectoryItemType.Folder },
                                                                                  new CompareDirectoryItem() { ComparableValue = @"App2\",SecondDirectoryItem = new DirectoryItem() {Name=@"App2\",FullPath= @"C:\App2\", Type=DirectoryItemType.Folder }, Type=DirectoryItemType.Folder } };
            
        }

        public List<DirectoryItemAndAction> GetFakeClassRightActionList()
        {
            return new List<DirectoryItemAndAction>() { new DirectoryItemAndAction() { ActionType=DirectoryItemActionType.Create, DirectoryItemValue=  new DirectoryItem() { Name = @"App\", FullPath = @"C:\App\", Type = DirectoryItemType.Folder } },
                                                        new DirectoryItemAndAction() { ActionType=DirectoryItemActionType.Delete, DirectoryItemValue=  new DirectoryItem() { Name = @"App2\", FullPath = @"C:\App2\", Type = DirectoryItemType.Folder }} } ;
        }

        public List<DirectoryItemAndAction> GetFakeClassWrongActionList()
        {
            return new List<DirectoryItemAndAction>() { new DirectoryItemAndAction() { ActionType=DirectoryItemActionType.Create, DirectoryItemValue=  new DirectoryItem() { Name = @"App2\", FullPath = @"C:\App2\", Type = DirectoryItemType.Folder } },
                                                        new DirectoryItemAndAction() { ActionType=DirectoryItemActionType.Delete, DirectoryItemValue=  new DirectoryItem() { Name = @"App1\", FullPath = @"C:\App1\", Type = DirectoryItemType.Folder }} };
        }
    }
}

 