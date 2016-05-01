using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WebKidzPlus.Classes
{
    public static class Commands
    {
        public static RoutedCommand CloseFile = new RoutedCommand();
        public static RoutedCommand SaveFile = new RoutedCommand();
        public static RoutedCommand SaveAll = new RoutedCommand();
        public static RoutedCommand SaveProject = new RoutedCommand();
        public static RoutedCommand ImportProject = new RoutedCommand();
        public static RoutedCommand CloseProject = new RoutedCommand();
        public static RoutedCommand OpenProject = new RoutedCommand();
    }
}
