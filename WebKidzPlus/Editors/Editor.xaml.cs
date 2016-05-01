using ICSharpCode.AvalonEdit.Highlighting;
using System.Windows.Controls;

namespace WebKidzPlus.Editors
{
    /// <summary>
    /// Interaction logic for Editor.xaml
    /// </summary>
    public partial class Editor : UserControl
    {
        public string filePath;
        MainWindow parentWindow;
        public Editor(Classes.FileType ft, string filePath)
        {
            InitializeComponent();

            switch (ft)
            {
                case Classes.FileType.CSS:
                    Tabs.Items.Remove(PreviewTab);
                    TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("CSS");
                    break;
                case Classes.FileType.JS:
                    Tabs.Items.Remove(PreviewTab);
                    TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("JavaScript");
                    break;
                case Classes.FileType.HTML:
                    TextEditor.SyntaxHighlighting = HighlightingManager.Instance.GetDefinition("HTML");
                    break;
            }
            this.filePath = filePath;
            TextEditor.Load(filePath);
            TextEditor.TextChanged += TextEditor_TextChanged;
            parentWindow = (MainWindow)App.Current.MainWindow;
        }

        public bool IsSaved
        {
            get {
                string s = ((TabItem)parentWindow.tabControl.Items[parentWindow.tabControl.SelectedIndex]).Header.ToString();
                return (s[s.Length - 1] != '*');
            }
        }

        public void Save()
        {
            string s = ((TabItem)parentWindow.tabControl.Items[parentWindow.tabControl.SelectedIndex]).Header.ToString();
            if(s[s.Length-1] == '*')
            {
                TextEditor.Save(filePath);
                s = s.Substring(0, s.Length - 1);
                ((TabItem)parentWindow.tabControl.Items[parentWindow.tabControl.SelectedIndex]).Header = s;
            }
        }

        private void TextEditor_TextChanged(object sender, System.EventArgs e)
        {
            string s = ((TabItem)parentWindow.tabControl.Items[parentWindow.tabControl.SelectedIndex]).Header.ToString();
            if (s[s.Length - 1] != '*')
            {
                s += "*";
                ((TabItem)parentWindow.tabControl.Items[parentWindow.tabControl.SelectedIndex]).Header = s;
            }
        }

        public void Undo()
        {
            TextEditor.Undo();
        }

        public void Redo()
        {
            TextEditor.Redo();
        }

        public void Copy()
        {
            TextEditor.Copy();
        }

        public void Cut()
        {
            TextEditor.Cut();
        }

        public void Paste()
        {
            TextEditor.Paste();
        }

        private void Tabs_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if(Tabs.SelectedIndex == 1)
            {
                webControl.Source = new System.Uri("file://" + filePath);
            }else
            {

            }
        }
    }
}
