using System;
using System.Globalization;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media.Imaging;

namespace WebKidzPlus
{
    #region HeaderToImageConverter

    [ValueConversion(typeof(string), typeof(bool))]
    public class HeaderToImageConverter : IValueConverter
    {
        public static HeaderToImageConverter Instance = new HeaderToImageConverter();

        public object Convert(object v, Type targetType, object parameter, CultureInfo culture)
        {
            String value = (String)v;
            String path = "pack://application:,,,/Globe.ico";
            if (value.Contains("/"))
            {
                path = "pack://application:,,,/Images/folder.png";
            }
            if (value.Substring(value.Length-5).ToLower() == ".html")
            {
                path = "pack://application:,,,/Images/HTML.png";
            }
            if (value.Substring(value.Length - 4).ToLower() == ".css")
            {
                path = "pack://application:,,,/Images/CSS.png";
            }
            if (value.Substring(value.Length - 5).ToLower() == ".tiff")
            {
                path = "pack://application:,,,/Images/image.png";
            }
            if (value.Substring(value.Length - 5).ToLower() == ".jpeg")
            {
                path = "pack://application:,,,/Images/image.png";
            }
            if (value.Substring(value.Length - 3).ToLower() == ".js")
            {
                path = "pack://application:,,,/Images/JS.png";
            }
            if (value.Substring(value.Length - 4).ToLower() == ".png")
            {
                path = "pack://application:,,,/Images/image.png";
            }
            if (value.Substring(value.Length - 4).ToLower() == ".jpg")
            {
                path = "pack://application:,,,/Images/image.png";
            }
            if (value.Substring(value.Length - 4).ToLower() == ".gif")
            {
                path = "pack://application:,,,/Images/image.png";
            }
            Uri uri = new Uri(path);
            BitmapImage source = new BitmapImage(uri);
            return source;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException("Cannot convert back");
        }
    }

    #endregion // DoubleToIntegerConverter


}