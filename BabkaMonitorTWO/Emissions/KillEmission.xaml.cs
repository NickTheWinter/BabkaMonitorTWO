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
                ComboBox_source.Items.Add(item.Source.Name);
            }
            foreach (var item in db.Emissions)
            {
                ComboBox_count.Items.Add(item.Count);
            }
            foreach (var item in db.Emissions)
            {
                ComboBox_text.Items.Add(item.Text);
            }
            foreach (var item in db.Emissions)
            {
                ComboBox_date.Items.Add(item.Date);
            }
        }
        private void CancelEmission_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void KillButtonEmission_Click(object sender, RoutedEventArgs e)
        {
            //BabkaMonitorTWO.DB_classes.Emission emission = db.Sources.Where(x => x.Name == Name.Text).FirstOrDefault();
            //db.Sources.Remove(emission);
            //db.SaveChanges();
            //mainWindow.UpdateSource(false);
        }

        private void KillEmissionn_Click(object sender, RoutedEventArgs e)
        {
            float selectedValue = float.Parse(ComboBox_count.SelectedValue.ToString());
            Emission emission = db.Emissions.Where(x => x.Source.Name == ComboBox_source.SelectedValue).Where(x=> x.Count == selectedValue).Where( 
            x=> x.Text == ComboBox_text.SelectedValue).FirstOrDefault();
            db.Remove(emission);
            db.SaveChanges();
            mainWindow.UpdateEmission(false);
        }
    }
}
