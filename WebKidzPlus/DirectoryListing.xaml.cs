using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WebKidzPlus
{
    /// <summary>
    /// Interaction logic for DirectoryListing.xaml
    /// </summary>
    public partial class DirectoryListing : UserControl
    {
        public DirectoryListing()
        {
            InitializeComponent();
        }
        public string SelectedImagePath { get; set; }

        String path;
        public void SetPath(String p)
        {
            foldersItem.Items.Clear();
            path = p;
            string s = new DirectoryInfo(path).FullName;
            if(s[s.Length-1] == '\\') { s = s.Substring(0, s.Length - 1); }
            TreeViewItem item = new TreeViewItem();
            item.Header = "Project Files for \""+s.Substring(s.LastIndexOf("\\") + 1)+"\"";
            item.Tag = s;
            item.FontWeight = FontWeights.Normal;
            item.Items.Add(dummyNode);
            item.Expanded += new RoutedEventHandler(folder_Expanded);
            foldersItem.Items.Add(item);
        }

        TreeViewItem dummyNode = null;
        void folder_Expanded(object sender, RoutedEventArgs e)
        {
            TreeViewItem item = (TreeViewItem)sender;
            if (item.Items.Count == 1 && item.Items[0] == dummyNode)
            {
                item.Items.Clear();
                try
                {
                    foreach (string s in Directory.GetDirectories(item.Tag.ToString().Replace("{ProjectStart}", "")))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s + "/";
                        subitem.FontWeight = FontWeights.Normal;
                        subitem.Items.Add(dummyNode);
                        subitem.Expanded += new RoutedEventHandler(folder_Expanded);
                        item.Items.Add(subitem);
                    }
                    foreach (string s in Directory.GetFiles(item.Tag.ToString()))
                    {
                        TreeViewItem subitem = new TreeViewItem();
                        subitem.Header = s.Substring(s.LastIndexOf("\\") + 1);
                        subitem.Tag = s;
                        subitem.FontWeight = FontWeights.Normal;
                        item.Items.Add(subitem);
                    }
                }
                catch (Exception) { }
            }
        }

        private void Subitem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem tvi;
            try
            {
                TreeView tv = (TreeView)sender;
                tvi = (TreeViewItem)tv.SelectedItem;
            }
            catch (Exception)
            {
                tvi = (TreeViewItem)sender;
            }

            String value = tvi.Tag.ToString();
            MainWindow parentWindow = (MainWindow)Window.GetWindow(this);
            if (value.Contains("/"))
            {
                tvi.ExpandSubtree();
            }
            if (value.Substring(value.Length - 5).ToLower() == ".html")
            {
                int pos = value.LastIndexOf("\\")+1;
                TabItem editor = new TabItem() { Header = value.Substring(pos, value.Length - pos) };
                editor.Content = new Editors.Editor(Classes.FileType.HTML, value);
                parentWindow.tabControl.Items.Add(editor);
                parentWindow.tabControl.SelectedItem = editor;
            }
            if (value.Substring(value.Length - 4).ToLower() == ".css")
            {
                int pos = value.LastIndexOf("\\") + 1;
                TabItem editor = new TabItem() { Header = value.Substring(pos, value.Length - pos) };
                editor.Content = new Editors.Editor(Classes.FileType.CSS, value);
                parentWindow.tabControl.Items.Add(editor);
                parentWindow.tabControl.SelectedItem = editor;
            }
            if (value.Substring(value.Length - 3).ToLower() == ".js")
            {
                int pos = value.LastIndexOf("\\") + 1;
                TabItem editor = new TabItem() { Header = value.Substring(pos, value.Length - pos) };
                editor.Content = new Editors.Editor(Classes.FileType.JS, value);
                parentWindow.tabControl.Items.Add(editor);
                parentWindow.tabControl.SelectedItem = editor;
            }
        }

        private void TV_CM_NewDir_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = (TreeViewItem)foldersItem.SelectedItem;

            String value = tvi.Tag.ToString();
            String path = "";
            if (value.Contains("/"))
            {
                path = value.Replace("/", "\\");
            }
            else
            {
                try
                {
                    path = ((TreeViewItem)tvi.Parent).Tag.ToString().Replace("/", "\\");
                }
                catch (Exception)
                {
                    path = value + "\\";
                }
            }
            FileDialog fd = new FileDialog("Folder Name");
            if (fd.ShowDialog() == true)
            {
                Directory.CreateDirectory(path + fd.ResponseText);
                SetPath(path);
            }
        }

        private void TV_CM_NewFile_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = (TreeViewItem)foldersItem.SelectedItem;

            String value = tvi.Tag.ToString();
            String path = "";
            if (value.Contains("/"))
            {
                path = value.Replace("/", "\\");
            }
            else
            {
                try
                {
                    path = ((TreeViewItem)tvi.Parent).Tag.ToString().Replace("/", "\\");
                }
                catch (Exception)
                {
                    path = value + "\\";
                }
            }
            FileType ft = new FileType();
            if (ft.ShowDialog() == true)
            {
                File.CreateText(path + ft.FileName + "." + ft.SelectedFile.ToString().ToLower());
                SetPath(path);
            }
        }

        private void TV_CM_Delete_Click(object sender, RoutedEventArgs e)
        {
            TreeViewItem tvi = (TreeViewItem)foldersItem.SelectedItem;

            String value = tvi.Tag.ToString();
            if (value.Contains("/"))
            {
                Directory.Delete(value, true);
                SetPath(path);
            }
            else
            {
                File.Delete(value);
                SetPath(path);
            }
        }

        private void TV_CM_Import_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            
            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                TreeViewItem tvi = (TreeViewItem)foldersItem.SelectedItem;

                String value = tvi.Tag.ToString();
                String path = "";
                if (value.Contains("/"))
                {
                    path = value.Replace("/", "\\");
                }
                else
                {
                    try
                    {
                        path = ((TreeViewItem)tvi.Parent).Tag.ToString().Replace("/", "\\");
                    }
                    catch (Exception)
                    {
                        path = value + "\\";
                    }
                }
                File.Copy(filename, path + filename.Substring(filename.LastIndexOf('\\') + 1));
                SetPath(path);
            }
        }
    }
}
