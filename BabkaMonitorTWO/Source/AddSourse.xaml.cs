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

namespace BabkaMonitorTWO
{
    /// <summary>
    /// Логика взаимодействия для AddSourse.xaml
    /// </summary>
    public partial class AddSourse : Window
    {
        ApplicationContext db;
        MainWindow mainWindow;
        public AddSourse(ApplicationContext context,MainWindow _window)
        {
            InitializeComponent();
            mainWindow = _window;
            db = context;
        }

        private void CancelSource_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
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

        private void AddSouce_Click(object sender, RoutedEventArgs e)
        {
            Source source = new Source(Name.Text, Address.Text);
            db.Sources.Add(source);
            db.SaveChanges();
            mainWindow.UpdateSource(true);
        }
    }
}
