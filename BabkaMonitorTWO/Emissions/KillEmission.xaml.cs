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

            foreach (var item in db.Emissions)
            {
                Combobox_id.Items.Add(item.Id);
            }
        }
        private void CancelEmission_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KillButtonEmission_Click(object sender, RoutedEventArgs e)
        {
            Emission emission = db.Emissions.Where(x => x.Id.ToString() == Combobox_id.SelectedValue).FirstOrDefault();
            db.Emissions.Remove(emission);
            db.SaveChanges();
            mainWindow.UpdateSource(false);
        }
    }
}
