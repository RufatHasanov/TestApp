#region System Usings
using System;
using System.Globalization;
using System.IO;
using System.Windows.Data;
using System.Windows.Media.Imaging;
#endregion System Usings

#region Custom Usings
using Company.TestApp.Enums;
#endregion Custom Usings

namespace Company.TestApp.App
{
    /// <summary>
    /// Converts a full path to a specific image type of a folder or file
    /// </summary>
    [ValueConversion(typeof(DirectoryItemType), typeof(BitmapImage))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // By default, we presume an image
            var image = "Images/file.png";

            switch ((DirectoryItemType)value)
            { 
                case DirectoryItemType.Folder:
                    image = "Images/folder.png";
                    break;
            }

            return new BitmapImage(new Uri($"pack://application:,,,/{image}"));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
