﻿#region System Usings
using System;
using System.Linq;
using System.Collections.ObjectModel;
using SystemWindows = System.Windows;
using System.Windows.Forms;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Business;
using Company.TestApp.Enums;
#endregion Custom Usings

namespace Company.TestApp.ViewModels
{
    /// <summary>
    /// The view model for the application 
    /// </summary>
    public sealed class CompareDirectoryStructureVM : BaseVM
    {

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary> 
        public CompareDirectoryStructureVM()
        {
            CompareDirectoryCommand = new RelayCommand(arg => StartCompareDirectoryCommand());

            ChooseFirstDirectoryCommand = new RelayCommand(arg => FirstDirectory = OpenFolderBrowser(FirstDirectory));

            ChooseSecondDirectoryCommand = new RelayCommand(arg => SecondDirectory = OpenFolderBrowser(SecondDirectory));

        }

        #endregion Constructor

        #region Public Properties

        /// <summary>
        /// A list of compare all directories and files from right and left path
        /// </summary>
        public ObservableCollection<CompareDirectoryItemVM> Items { get; set; }

        string firstDirectory = string.Empty;
        /// <summary>
        /// First directory path
        /// </summary>
        public string FirstDirectory
        {
            get { return firstDirectory; }
            set
            {
                firstDirectory = value;
                OnPropertyChanged("FirstDirectory");
            }
        }

        string secondDirectory = string.Empty;
        /// <summary>
        /// Second directory path
        /// </summary>
        public string SecondDirectory
        {
            get { return secondDirectory; }
            set
            {
                secondDirectory = value;
                OnPropertyChanged("SecondDirectory");
            }
        }
        /// <summary>
        /// Action list make second like first
        /// </summary>
        public ObservableCollection<DirectoryItemAndActionVM> DirectoryAndActionItems { get; set; }

        #endregion Public Properties

        #region Commands
        /// <summary>
        /// Command for compare directory
        /// </summary>
        public RelayCommand CompareDirectoryCommand { get; set; }
        /// <summary>
        /// Command Folder Browser for first directory
        /// </summary>
        public RelayCommand ChooseFirstDirectoryCommand { get; set; }
        /// <summary>
        /// Command Folder Browser for second directory
        /// </summary>
        public RelayCommand ChooseSecondDirectoryCommand { get; set; }
        #endregion Commands

        #region Public methods
        /// <summary>
        /// Open Folder Browser Command
        /// </summary>
        /// <param name="selectedDirectoryPath"></param>
        public string OpenFolderBrowser(string selectedDirectoryPath)
        { 
            using (var myDialog = new FolderBrowserDialog())
            {
                if (!string.IsNullOrEmpty(selectedDirectoryPath))
                {
                    myDialog.SelectedPath = selectedDirectoryPath;
                }
                myDialog.ShowDialog();
                selectedDirectoryPath = myDialog.SelectedPath;
                
            }
            return selectedDirectoryPath;
        }
        /// <summary>
        /// Start compare directories
        /// </summary>
        public void StartCompareDirectoryCommand()
        {
            try
            {
                // Get the all directories and files from first and second Path
                using (var compareDirectoryStructure = new CompareDirectoryStructure(new DirectoryStructure(FirstDirectory, SecondDirectory)))
                {
                    var children = compareDirectoryStructure.CompareResult;

                    //Clear child items
                    this.DirectoryAndActionItems = null;
                    
                    // Create the view models from the data
                    this.Items = new ObservableCollection<CompareDirectoryItemVM>(
                        children.Select(value => new CompareDirectoryItemVM(value)));
                    
                    //Check Action list items count
                    if (compareDirectoryStructure.ActionList.Count() > 0)
                        this.DirectoryAndActionItems = new ObservableCollection<DirectoryItemAndActionVM>(
                            compareDirectoryStructure.ActionList.Select(value => new DirectoryItemAndActionVM(
                                value.DirectoryItemValue.FullPath, value.DirectoryItemValue.Name, value.ActionType)));
                    else
                    { 
                        //Show information when Action list is empty
                        ShowMessageBox(Messages.DirectoriesstructureAreSame , "Info", SystemWindows.MessageBoxImage.Information);
                    }
                }
                
                //Set property change "Items"
                OnPropertyChanged("Items");
                
                //Set property cnage "DirectoryAndActionItems"
                OnPropertyChanged("DirectoryAndActionItems");
            }
            catch (CustomException customException)
            {
                //Show Detail information about exception
                ShowMessageBox(customException.Message, "Error", SystemWindows.MessageBoxImage.Error);
            }
            catch (Exception ex)
            {
                //Show Detail information about exception
                ShowMessageBox(String.Format(Messages.ErrorDetailDetails,ex.Message), "Error occurred", SystemWindows.MessageBoxImage.Error);
            }
        }
        #endregion Public methods

        #region Private Methods
        /// <summary>
        /// Show messagebox
        /// </summary> 
        /// <param name="message"></param>
        /// <param name="caption"></param>
        /// <param name="messageBoxImage"></param>
        private void ShowMessageBox(string message, string caption, SystemWindows.MessageBoxImage messageBoxImage)
        {
            SystemWindows.MessageBox.Show(message, caption, SystemWindows.MessageBoxButton.OK, messageBoxImage);
        }
        #endregion Private Methods
    }
}
