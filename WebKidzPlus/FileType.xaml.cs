using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace WebKidzPlus
{
    /// <summary>
    /// Interaction logic for FileType.xaml
    /// </summary>
    public partial class FileType : Window
    {
        public Classes.FileType SelectedFile { get; private set; } = Classes.FileType.HTML;

        public FileType()
        {
            InitializeComponent();
            HTMLImage.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x2E, 0x6E, 0xAB));
        }

        public String FileName {
            get
            {
                return FileNameText.Text;
            }
            private set
            {
                FileNameText.Text = value;
            }
       }

        private void Submit_Click(object sender, RoutedEventArgs e)
        {
            if (FileNameText.Text != "")
            {
                DialogResult = true;
            }else
            {
                MessageBox.Show("You must enter a name for this file");
            }
        }

        private void CSSImage_Click(object sender, RoutedEventArgs e)
        {
            CSSImage.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x2E, 0x6E, 0xAB));
            HTMLImage.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            JSImage.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SelectedFile = Classes.FileType.CSS;
        }

        private void HTMLImage_Click(object sender, RoutedEventArgs e)
        {
            HTMLImage.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x2E, 0x6E, 0xAB));
            CSSImage.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            JSImage.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SelectedFile = Classes.FileType.HTML;
        }

        private void JSImage_Click(object sender, RoutedEventArgs e)
        {
            JSImage.Background = new SolidColorBrush(Color.FromArgb(0xFF, 0x2E, 0x6E, 0xAB));
            CSSImage.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            HTMLImage.Background = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            SelectedFile = Classes.FileType.JS;
        }
    }
}
