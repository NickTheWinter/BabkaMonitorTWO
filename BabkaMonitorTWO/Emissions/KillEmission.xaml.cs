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

namespace BabkaMonitorTWO.Emissions
{
    /// <summary>
    /// Логика взаимодействия для KillEmission.xaml
    /// </summary>
    public partial class KillEmission : Window
    {
        ApplicationContext db;
        MainWindow mainWindow;
        public KillEmission(ApplicationContext context, MainWindow _window)
        {
            InitializeComponent();
            mainWindow = _window;
            db = context;
        }
        private void Name_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "Название выброса")
            {
                Name.Text = "";
            }
        }

        private void Name_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Name.Text == "")
            {
                Name.Text = "Название выброса";
            }
        }
        private void CancelEmission_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KillEmission_Click(object sender, RoutedEventArgs e)
        {
            BabkaMonitorTWO.DB_classes.Source source = db.Sources.Where(x => x.Name == Name.Text).FirstOrDefault();
            db.Sources.Remove(source);
            db.SaveChanges();
            mainWindow.UpdateSource(false);
        }
    }
}
