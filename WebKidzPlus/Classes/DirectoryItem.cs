using System;
using System.Windows;
using System.Xml.Serialization;

namespace WebKidzPlus.Classes
{
    [XmlInclude(typeof(Directory))]
    [XmlInclude(typeof(File))]
    [Serializable]
    public abstract class DirectoryItem
    {
        public String LocalPath { get; set; }
        public String FileName { get; set; }

        public abstract void save();
        public abstract void Directory_Expanded(object sender, RoutedEventArgs e);
    }
}
