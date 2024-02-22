using System.Configuration;
using System.Data;
using System.IO;
using System.Reflection;
using System.Windows;

namespace ContactsApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private static string databaseName = "Contacts.db";
        private static string folderPath = "Database";
        public static string databasePath = System.IO.Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), folderPath, databaseName);
    }

}
