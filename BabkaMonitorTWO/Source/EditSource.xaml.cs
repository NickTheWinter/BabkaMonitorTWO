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
    /// Логика взаимодействия для EditSource.xaml
    /// </summary>
    public partial class EditSource : Window
    {
        ApplicationContext db;
        MainWindow mainWindow;
        public EditSource(ApplicationContext context, MainWindow _window)
        {
            InitializeComponent();
            mainWindow = _window;
            db = context;
            foreach (var item in db.Sources)
            {
                StartName.Items.Add(item.Name);
            }
        }

        private void CancelSource_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SaveSource_Click(object sender, RoutedEventArgs e)
        {
            DB_classes.Source source = db.Sources.Where(x => x.Name == StartName.Text).FirstOrDefault();
            source.Name = Name.Text;
            source.Address = Address.Text;
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

        private void Address_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Address.Text == "")
            {
                Address.Text = "Адрес";
            }
        }

        private void Address_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Address.Text == "Адрес")
            {
                Address.Text = "";
            }
        }
    }
}
