#region System Usings
using System.Linq;
using System.Windows.Input;
using System.Collections.ObjectModel;
#endregion  System Using

#region Custom Usings
using Company.TestApp.Enums; 
using Company.TestApp.Business;
using Company.TestApp.Model;
#endregion Custom Usings

namespace Company.TestApp.ViewModels
{

    /// <summary>
    /// A view model for compare directory items
    /// </summary>
    public sealed class CompareDirectoryItemVM : BaseVM
    {
        #region Public Properties
        
        /// <summary>
        /// The Panel Color, 
        /// </summary>
        public string PanelColor
        {
            get
            {
                return (this.CompareDirectory.FirstDirectoryItem != null && this.CompareDirectory.SecondDirectoryItem != null) ? "White" :
                       (this.CompareDirectory.FirstDirectoryItem != null ? "#F3E6D8" : "#DDDDDD");//"#D1E8CF"
            }
        }

        /// <summary>
        /// Compare directory item
        /// </summary>
        public CompareDirectoryItem CompareDirectory { get; set; }


        #endregion Public Properties


        #region Constructor

        public CompareDirectoryItemVM(CompareDirectoryItem compareDirectoryItem)
        {
            
            // Set path and type
            this.CompareDirectory = compareDirectoryItem; 
        }

        #endregion Constructor



    }
}
