using System;
using System.Windows;

namespace WebKidzPlus.Classes
{
    public enum FileType
    {
        JS,
        CSS,
        HTML,
        JPEG,
        PNG,
        GIF,
        TIFF
    }
    public class File : DirectoryItem
    {
        public FileType FileType { get; set; }

        public File(FileType ft, String Name, String BasePath)
        {
            this.FileName = Name;
            this.LocalPath = BasePath + "\\" + FileName;
            this.FileType = ft;
        }

        public File()
        {

        }
        private ICSharpCode.AvalonEdit.TextEditor Editor;

        public void create()
        {
            System.IO.File.CreateText(this.LocalPath);
        }

        public override void save()
        {
            System.IO.File.WriteAllText(this.LocalPath, Editor.Text);
        }

        public void load(ICSharpCode.AvalonEdit.TextEditor editor)
        {
            Editor = editor;
            Editor.Text = System.IO.File.ReadAllText(LocalPath);
        }

        public override void Directory_Expanded(object sender, RoutedEventArgs e)
        {
            return;
        }
    }
}
