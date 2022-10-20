using BabkaMonitorTWO.DB_classes;
using BabkaMonitorTWO.Emissions;
using BabkaMonitorTWO.Source;
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
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BabkaMonitorTWO
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        List<BabkaMonitorTWO.DB_classes.Source> listSources = new List<BabkaMonitorTWO.DB_classes.Source>();
        List<Emission> listEmissions = new List<Emission>();
        public MainWindow()
        {
            InitializeComponent();
            db = new ApplicationContext();
            UpdateSource(false);
            listEmissions = db.Emissions.ToList();
            ListEmissions.ItemsSource = listEmissions;
    }

        public void UpdateSource(bool last)
        {
            if (!last)
            {
                listSources = db.Sources.ToList();
                ListSources.ItemsSource = listSources;
            }
            else
            {
                listSources.Add(db.Sources.OrderBy(t => t.Id).Last());
                ListSources.Items.Refresh();
            }
        }
        public void UpdateEmission(bool last)
        {
            if (!last)
            {
                listEmissions = db.Emissions.ToList();
                ListEmissions.ItemsSource = listEmissions;
            }
            else
            {
                listEmissions.Add(db.Emissions.OrderBy(t => t.Id).Last());
                ListEmissions.Items.Refresh();
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            AddSourse source = new AddSourse(db,this);
            source.Show();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            AddEmission emission = new AddEmission(db, this)  ;
            emission.Show();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            KillSource killSource = new KillSource(db, this) ;
            killSource.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            EditSource editSource = new EditSource(db, this);
            editSource.Show();
        }

        private void Button_Click_4(object sender, RoutedEventArgs e)
        {
            KillEmission killEmission = new KillEmission(db, this);
            killEmission.Show();
        }

        private void Button_Click_5(object sender, RoutedEventArgs e)
        {
            EditEmission editEmission = new EditEmission(db, this);
            editEmission.Show();
        }

        private void Button_Click_6(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"Мин.выбросы = {db.Emissions.Min(x=>x.Count)}",
                "Минимальные выбросы",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void Button_Click_7(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"Ср.выбросы = {db.Emissions.Average(x => x.Count)}",
                "Средние выбросы",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }

        private void Button_Click_8(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(
                $"Макс.выбросы = {db.Emissions.Max(x => x.Count)}",
                "Максимальные выбросы",
                MessageBoxButton.OK,
                MessageBoxImage.Information
                );
        }
        private void DGExpand_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            DataGrid grid = (DataGrid)sender;
            grid.SelectedItems.Clear();
        }

    }
}
