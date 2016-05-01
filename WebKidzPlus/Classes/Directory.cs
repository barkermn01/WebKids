using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace WebKidzPlus.Classes
{
    public class Directory : DirectoryItem
    {
        public List<DirectoryItem> items = new List<DirectoryItem>();

        public Directory(String name, String BasePath)
        {
            this.FileName = name;
            this.LocalPath = BasePath + "\\" + FileName;
            System.IO.Directory.CreateDirectory(this.LocalPath);
        }

        public Directory()
        {

        }

        public override void save()
        {
            System.IO.Directory.CreateDirectory(LocalPath);
            foreach(DirectoryItem di in items)
            {
                di.save();
            }
        }

        public override void Directory_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem TVI = (TreeViewItem)sender;
            //TVI.Tag
        }

        public void AddFile(String fileName, FileType ft)
        {
            switch (ft)
            {
                case FileType.CSS:
                    fileName += ".css";
                    break;

                case FileType.HTML:
                    fileName += ".html";
                    break;

                case FileType.JS:
                    fileName += ".js";
                    break;
            }
            File file = new File(ft, fileName, this.LocalPath);
            file.create();
            items.Add(file);
        }

        public void addDirectory(String name)
        {
            items.Add(new Directory(name, LocalPath));
        }
    }
}
