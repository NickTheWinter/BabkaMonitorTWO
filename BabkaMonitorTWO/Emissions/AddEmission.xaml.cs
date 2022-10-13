﻿using BabkaMonitorTWO.DB_classes;
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
    public partial class AddEmission : Window
    {
        ApplicationContext db;
        MainWindow mainWindow;
        public AddEmission(ApplicationContext context,MainWindow _window)
        {
            InitializeComponent();
            mainWindow = _window;
            db = context;
        }

        private void CancelEmission_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SourceName_GotFocus(object sender, RoutedEventArgs e)
        {
            if (SourceName.Text == "Название источника")
            {
                SourceName.Text = "";
            }
        }

        private void SourceName_LostFocus(object sender, RoutedEventArgs e)
        {
            if (SourceName.Text == "")
            {
                SourceName.Text = "Название источника";
            }
        }

        private void Count_LostFocus(object sender, RoutedEventArgs e)
        {
            if (Count.Text == "")
            {
                Count.Text = "Адрес";
            }
        }

        private void Count_GotFocus(object sender, RoutedEventArgs e)
        {
            if (Count.Text == "Адрес")
            {
                Count.Text = "";
            }
        }

        private void AddEmissionn_Click(object sender, RoutedEventArgs e)
        {
            BabkaMonitorTWO.DB_classes.Source source = db.Sources.Where(x => x.Name == SourceName.Text).FirstOrDefault();
            Emission emission = new Emission(source, Count.Text, Text.Text, DateTime.Parse(Date.Text));
            db.Emissions.Add(emission);
            db.SaveChanges();
            mainWindow.UpdateEmission(true);
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
    }
}
