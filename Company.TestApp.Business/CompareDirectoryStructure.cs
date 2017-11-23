#region System
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
#endregion 

#region Custom Using
using Company.TestApp.Model;
using Company.TestApp.Enums;
#endregion Custom Using

namespace Company.TestApp.Business
{
    /// <summary>
    /// A class compare 2 list and prepare action list for make second directory like first directory
    /// </summary>
    public class CompareDirectoryStructure : ICompareDirectoryStructure, IDisposable
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="IDirectoryStructure">A class which retrieve a folders and files from directories</param> 
        public CompareDirectoryStructure(IDirectoryStructure directoryStructure)
        {
            if (directoryStructure != null)
                CompareDirectoriesContents(directoryStructure.GetDirectoriesContent());
            else
                throw new CustomException(Messages.TheClassDirectoryStructureIsNull);
        }
        #endregion Constructor

        #region Properties
        /// <summary>
        /// First directory and Second directory compare result
        /// </summary>
        public List<CompareDirectoryItem> CompareResult { get; private set; }
        /// <summary>
        /// Second directory like first directory action list
        /// </summary>
        public List<DirectoryItemAndAction> ActionList { get; private set; }
        #endregion

        #region Private methods

        /// <summary>
        /// Get distinct result of compare directories
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Result of compare directories</returns>
        private List<CompareDirectoryItem> GetDirectoryCompareResult(List<CompareDirectoryItem> items)
        {
            // Distinct all values and mark duplicates
            return items.GroupBy(row => new { row.ComparableValue, row.Type }).Select(group => new CompareDirectoryItem()
            {
                ComparableValue = group.Key.ComparableValue,
                FirstDirectoryItem = group.Where(s => s.FirstDirectoryItem!=null).Select(left=>left.FirstDirectoryItem).FirstOrDefault(),
                SecondDirectoryItem = group.Where(s => s.SecondDirectoryItem != null).Select(right => right.SecondDirectoryItem).FirstOrDefault(),
                Type = group.Key.Type,
              }).OrderBy(value=> value.FirstDirectoryItem!=null? value.FirstDirectoryItem.FullPath: value.SecondDirectoryItem.FullPath).ToList();
            
        }
        /// <summary>
        /// Get action list for make second like first
        /// </summary>
        /// <param name="items"></param>
        /// <returns>Get list of actions for make second directory like first </returns>
        private List<DirectoryItemAndAction> GetActionList(List<CompareDirectoryItem> items)
        {
            //Get all folders and files which must be create
            var actionItems = CompareResult.Where(x => x.SecondDirectoryItem == null).Select(row => new DirectoryItemAndAction
            {
                ActionType = DirectoryItemActionType.Create,
                DirectoryItemValue = new DirectoryFileItem()
                {
                    FullPath = row.FirstDirectoryItem.FullPath,
                    Name = row.ComparableValue,
                    Type = row.Type
                }
            }).ToList();

            //Get all folders and files which must be delete
            actionItems.AddRange(CompareResult.Where(x => x.FirstDirectoryItem == null)
                                                .Select(row => new DirectoryItemAndAction
                                                        {
                                                            ActionType = DirectoryItemActionType.Delete,
                                                            DirectoryItemValue = new DirectoryFileItem() { FullPath = row.SecondDirectoryItem.FullPath, Type = row.Type, Name = row.SecondDirectoryItem.Name }
                                                        })
                                                .OrderByDescending(row => row.DirectoryItemValue)
                                                );

            return actionItems;
        }

        /// <summary>
        /// Compare directory and prepare action for second make like first
        /// </summary> 
        private void CompareDirectoriesContents(List<CompareDirectoryItem> items)
        {
            CompareResult = GetDirectoryCompareResult(items);
            ActionList = GetActionList(CompareResult);
        }

        #endregion

        #region Dispose
        /// <summary>
        ///  Implemantation IDisposable interface dispose objects
        /// </summary>
        public void Dispose() {
            CompareResult = null;
            ActionList = null;

        }
        #endregion Dispose 
    }
}
