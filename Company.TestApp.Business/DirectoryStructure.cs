#region System Usings
using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Enums;
using Company.TestApp.Model;
#endregion Custom Usings


namespace Company.TestApp.Business
{
    /// <summary>
    /// Directory Structure check and retrive directories folders and files information for comparison
    /// </summary>
    public class DirectoryStructure: IDirectoryStructure
    {
        #region Private Fields
        public string firstFullPath;

        public string secondFullPath { get; set; }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="firstFullPath"></param>
        /// <param name="secondFullPath"></param>
        public DirectoryStructure(string firstFullPath, string secondFullPath)
        {

            if (CheckDirectory(firstFullPath, DirectoryItemSide.First) &&
                CheckDirectory(secondFullPath, DirectoryItemSide.Second))
            {
                this.firstFullPath = $"{firstFullPath}{(firstFullPath.Last().ToString() != @"\" ? @"\" : "")}";
                this.secondFullPath = $"{secondFullPath}{(secondFullPath.Last().ToString() != @"\" ? @"\" : "")}";
            }
        }
        #endregion Constructor

        #region Public methods
        /// <summary>
        /// Get list of directories folders and files from both path
        /// </summary> 
        /// <returns></returns>
        public List<CompareDirectoryItem> GetDirectoriesContent()
        {
            // Get all folders from first full path
            var items = GetDirectoriesList(Directory.GetDirectories, firstFullPath, DirectoryItemSide.First, DirectoryItemType.Folder);
            // Get all folders from second full path
            items.AddRange(GetDirectoriesList(Directory.GetDirectories, secondFullPath, DirectoryItemSide.Second, DirectoryItemType.Folder));
            // Get all files from first full path
            items.AddRange(GetDirectoriesList(Directory.GetFiles, firstFullPath, DirectoryItemSide.First, DirectoryItemType.File));
            // Get all files from second full path
            items.AddRange(GetDirectoriesList(Directory.GetFiles, secondFullPath, DirectoryItemSide.Second, DirectoryItemType.File));
            return items;
        }
        #endregion Public Methods

        #region Private methods

        #region GetDirectories delegate
        /// <summary>
        /// Get list Folders and files directories delegate
        /// </summary>
        /// <param name="path"></param>
        /// <param name="searchPattern"></param>
        /// <param name="searchOption"></param>
        /// <returns></returns>
        private delegate string[] GetDirectories(string path, string searchPattern, SearchOption searchOption);
        #endregion GetDirectories delegate

        #region Get Directories List
        /// <summary>
        /// Get Directories
        /// </summary>
        /// <param name="items"></param>
        /// <param name="fullPath"></param>
        /// <param name="side"></param>
        /// <returns>Get Directories List</returns>
        private List<CompareDirectoryItem> GetDirectoriesList(GetDirectories getDirectories, string fullPath, DirectoryItemSide side, DirectoryItemType directoryItemType)
        {
            // Create empty list
            var items = new List<CompareDirectoryItem>();
            // Try and get directories from the dir
            // ignoring any issues doing so
            try
            {
                var dirs = getDirectories(fullPath, "*.*", SearchOption.AllDirectories);

                if (dirs.Length > 0)
                    items.AddRange(dirs.Select(dir => new CompareDirectoryItem
                    {
                        FirstDirectoryItem = (side == DirectoryItemSide.First ? new DirectoryItem()
                        {
                            FullPath = dir,
                            Name = dir.Substring(fullPath.Length),
                            Type = directoryItemType
                        } :
                        null),
                        SecondDirectoryItem = (side == DirectoryItemSide.Second ? new DirectoryItem()
                        {
                            FullPath = dir,
                            Name = dir.Substring(fullPath.Length),
                            Type = directoryItemType
                        } :
                        null),
                        ComparableValue = dir.Substring(fullPath.Length),
                        Type = directoryItemType
                    }));
            }
            catch (Exception ex)
            {
                throw new CustomException(String.Format(Messages.DirectoryException,side == DirectoryItemSide.First ? Messages.TheFirst : Messages.TheSecond, ex.Message));
            }

            return items;
        }

        #endregion Get Directories List



        #region Check Directory
        /// <summary>
        /// Check directory
        /// </summary>
        /// <param name="fullPath"></param>
        /// <param name="directoryItemSide"></param>
        /// <returns>True if fullpath have value and directory exists, else throw exception</returns>
        private bool CheckDirectory(string fullPath, DirectoryItemSide directoryItemSide)
        {
            //Check fullpath have value 
            if (fullPath == "")
                throw new CustomException(String.Format(Messages.DirectoryWithoutValue,directoryItemSide == DirectoryItemSide.First ? Messages.TheFirst: Messages.TheSecond));

            //Check folder exists
            if (!Directory.Exists(fullPath))
                throw new CustomException(String.Format(Messages.DirectoryDoesNotExists, directoryItemSide == DirectoryItemSide.First ? Messages.TheFirst : Messages.TheSecond));

            return true;
        }
        #endregion Check Directory

        #endregion Private methods
    }
}
