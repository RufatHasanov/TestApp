#region System Usings
using System.Windows;
#endregion System Using

#region Custom Usings
using Company.TestApp.ViewModels;
#endregion Custom Usings

namespace Company.TestApp.App
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        /// <summary>
        /// Main constructor
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
            
            this.DataContext = new CompareDirectoryStructureVM();
        }


       
 
    }
}
