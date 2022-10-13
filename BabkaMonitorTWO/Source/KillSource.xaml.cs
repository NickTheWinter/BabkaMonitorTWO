using BabkaMonitorTWO.DB_classes;
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

namespace BabkaMonitorTWO.Source
{
    /// <summary>
    /// Логика взаимодействия для KillSource.xaml
    /// </summary>
    public partial class KillSource : Window
    {
        ApplicationContext db;
        MainWindow mainWindow;
        public KillSource(ApplicationContext context, MainWindow _window)
        {
            InitializeComponent();
            mainWindow = _window;
            db = context;
        }

        private void CancelSource_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KillSouce_Click(object sender, RoutedEventArgs e)
        {
            BabkaMonitorTWO.DB_classes.Source source = db.Sources.Where(x => x.Name == Name.Text).FirstOrDefault();
            db.Sources.Remove(source);
            db.SaveChanges();
            mainWindow.UpdateSource(false);
        }

        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "Название источника")
            {
                Name.Text = "";
            }
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Название источника";
            }
        }
    }
}
