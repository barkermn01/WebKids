using System.Windows;
using ICSharpCode.AvalonEdit;
using System.Windows.Controls;
using System.IO;
using System;
using System.Windows.Input;
using WebKidzPlus.Classes;
using System.Windows.Media;

namespace WebKidzPlus
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public delegate void CallEvent();
        public class CommandManager : ICommand
        {
            CallEvent del;
            public CommandManager(CallEvent d)
            {
                del = d;
            }
            public event EventHandler CanExecuteChanged;

            public bool CanExecute(object parameter)
            {
                return true;
            }

            public void Execute(object parameter)
            {
                del.DynamicInvoke();
            }
        }
        public ICommand CloseFileCMD
        {
            get {
                return new CommandManager(delegate (){ CloseFile(this, new RoutedEventArgs()); });
            }
        }

        public ICommand SaveFileCMD
        {
            get
            {
                return new CommandManager(delegate () { SaveFile(this, new RoutedEventArgs()); });
            }
        }

        public ICommand SaveAllFilesCMD
        {
            get
            {
                return new CommandManager(delegate () { SaveAll(this, new RoutedEventArgs()); });
            }
        }

        public ICommand SaveProjectCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    SaveProject(this, new RoutedEventArgs());
                });
            }
        }

        public ICommand ImportProjectCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    ImportProject(this, new RoutedEventArgs());
                });
            }
        }

        public ICommand CloseProjectCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    CloseProject(this, new RoutedEventArgs());
                });
            }
        }

        public ICommand OpenProjectCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    OpenProject(this, new RoutedEventArgs());
                });
            }
        }

        public ICommand CopyCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
                    edit.Copy();
                });
            }
        }

        public ICommand CutCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
                    edit.Cut();
                });
            }
        }

        public ICommand PasteCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
                    edit.Paste();
                });
            }
        }

        public ICommand UndoCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
                    edit.Undo();
                });
            }
        }

        public ICommand RedoCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
                    edit.Redo();
                });
            }
        }

        public ICommand CloseAllCMD
        {
            get
            {
                return new CommandManager(delegate ()
                {
                    CloseAll(this, new RoutedEventArgs());
                });
            }
        }


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
        }

        private Classes.ProjectManager currentProject;
        
        public static String currentProjPath { get; private set; }
        
        public void ExitApp(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        public void SaveProject(object sender, RoutedEventArgs e)
        {
            if (currentProject != null)
            {
                currentProject.Save(currentProjPath);
            }
        }

        public void NewProject(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".wkproj";
            dlg.Filter = "WebKidz Project|*wkproj;*.wkp";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                currentProjPath = dlg.FileName;
                currentProject = new Classes.ProjectManager(dlg.SafeFileName.Replace(".wkproj", "").Replace(".wkp", ""));
                currentProject.BuildTreeView(ProjectList);
                currentProject.Save(currentProjPath);
                OverlayVisability(Visibility.Hidden);
            }
        }

        public void OverlayVisability(Visibility vis)
        {
            Overlay.Visibility = vis;
            OverlayBackgroud.Visibility = vis;
            OverlayText.Visibility = vis;
        }

        public void OpenProject(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".wkproj";
            dlg.Filter = "WebKidz Project|*wkproj;*.wkp";

            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();

            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                currentProject = Classes.ProjectManager.load(filename);
                currentProject.BuildTreeView(ProjectList);
                OverlayVisability(Visibility.Hidden);
            }
        }

        public void CloseProject(object sender, RoutedEventArgs e)
        {

        }

        public void SaveFile(object sender, RoutedEventArgs e)
        {
            Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
            edit.Save();
        }

        public void SaveAll(object sender, RoutedEventArgs e)
        {
            foreach(object o in tabControl.Items)
            {
                Editors.Editor edit = (Editors.Editor)o;
                edit.Save();
            }
        }

        public void CloseFile(object sender, RoutedEventArgs e)
        {
            Editors.Editor edit = ((Editors.Editor)((TabItem)tabControl.SelectedItem).Content);
            if (!edit.IsSaved)
            {
                MessageBoxResult messageBoxResult =
                    System.Windows.MessageBox.Show("Would you like to save before closing?", "File Not Saved", System.Windows.MessageBoxButton.YesNo);
                if (messageBoxResult == MessageBoxResult.Yes)
                {
                    edit.Save();
                }
            }
            tabControl.Items.Remove(tabControl.SelectedItem);
        }

        public void CloseAll(object sender, RoutedEventArgs e)
        {
            foreach (object o in tabControl.Items)
            {
                Editors.Editor edit = ((Editors.Editor)((TabItem)o).Content);
                if (!edit.IsSaved)
                {
                    tabControl.SelectedItem = o;
                    MessageBoxResult messageBoxResult =
                        System.Windows.MessageBox.Show("Would you like to save before closing?", "File Not Saved", System.Windows.MessageBoxButton.YesNo);
                    if (messageBoxResult == MessageBoxResult.Yes)
                    {
                        edit.Save();
                    }
                }
                tabControl.Items.Remove(o);
            }
        }

        public void ImportProject(object sender, RoutedEventArgs e)
        {

        }

        private void OnPreviewMouseRightButtonDown(object sender, MouseButtonEventArgs e)
        {
            TreeViewItem treeViewItem = VisualUpwardSearch(e.OriginalSource as DependencyObject);

            if (treeViewItem != null)
            {
                treeViewItem.Focus();
                e.Handled = true;
            }
        }

        static TreeViewItem VisualUpwardSearch(DependencyObject source)
        {
            while (source != null && !(source is TreeViewItem))
                source = VisualTreeHelper.GetParent(source);

            return source as TreeViewItem;
        }
    }
}
