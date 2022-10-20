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
    /// Логика взаимодействия для EditEmission.xaml
    /// </summary>
    public partial class EditEmission : Window
    {
        ApplicationContext db;
        MainWindow mainWindow;
        public EditEmission(ApplicationContext context, MainWindow _window)
        {
            InitializeComponent();
            mainWindow = _window;
            db = context;
            foreach (var item in db.Sources)
            {
                ComboBox_location.Items.Add(item.Name);
            }
            foreach (var item in db.Emissions)
            {
                Combobox_id.Items.Add(item.Id);
            }
        }
        private void CancelEmission_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Count_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Count.Text == "")
            {
                Count.Text = "Количество";
            }
        }

        private void Count_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Count.Text == "Количество")
            {
                Count.Text = "";
            }
        }
        private void Text_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "Текст")
            {
                Text.Text = "";
            }
        }

        private void Text_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Text.Text == "")
            {
                Text.Text = "Текст";
            }
        }

        private void EditEmissionn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Emission emission = db.Emissions.Where(x => x.Id.ToString() == Combobox_id.SelectedValue).FirstOrDefault();
                emission.Text = Text.Text;
                emission.Source = db.Sources.Where(x => x.Name == ComboBox_location.SelectedValue).FirstOrDefault();
                emission.Count = float.Parse(Count.Text);
                emission.Date = DateTime.Parse(Date.Text);
                db.SaveChanges();
                mainWindow.UpdateEmission(false);
            }
            catch
            {
              MessageBox.Show(
              $"Введены не корректные данные",
              "Неверный формат",
              MessageBoxButton.OK,
              MessageBoxImage.Error
              );
            }

        }
    }
}
