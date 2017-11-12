#region System Usings
using System.ComponentModel;
#endregion System Usings
 
namespace Company.TestApp.ViewModels
{
    /// <summary>
    /// A base view model that fires Property Changed events as needed
    /// </summary>
    public class BaseVM : INotifyPropertyChanged
    {
        #region Events
        /// <summary>
        /// The event that is fired when any child property changes its value
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion Events

        #region Public methods
        /// <summary>
        /// Create the OnPropertyChanged method to raise the event
        /// </summary>
        /// <param name="propname"></param>
        public void OnPropertyChanged(string propname)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propname));
            }

        }
        #endregion Public methods
    }
}