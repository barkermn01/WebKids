using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;
using System.Xml.Serialization;

namespace WebKidzPlus.Classes
{
    public class ProjectManager
    {
        public static ProjectManager load(String path)
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(ProjectManager));
            TextReader reader = new StreamReader(path);
            object obj = deserializer.Deserialize(reader);
            ProjectManager XmlData = (ProjectManager)obj;
            reader.Close();
            return XmlData;
        }

        public void Save(String path)
        {
            XmlSerializer serializer = new XmlSerializer(typeof(ProjectManager));
            using (TextWriter writer = new StreamWriter(path))
            {
                serializer.Serialize(writer, this);
            }
        }

        public ProjectManager(String name)
        {
            this.Name = name;
            String path = WebKidzPlus.MainWindow.currentProjPath.Replace("\\" + name + ".wkproj", "").Replace("\\" + name + ".wkp", "");
            ProjectFiles = new Directory(this.Name, path);
            ProjectFiles.AddFile("index", FileType.HTML);
        }

        private ProjectManager() { }

        public String Name{ get; set; }

        public Directory ProjectFiles;

        private object dummyNode = null;


        TreeView Tree;
        public void BuildTreeView(DirectoryListing ProjectList)
        {
            ProjectList.SetPath(ProjectFiles.LocalPath);
        }
    }
}
