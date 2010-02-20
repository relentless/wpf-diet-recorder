﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

using DietRecorder.Model;

namespace DietRecorder.Client
{
    /// <summary>
    /// Interaction logic for DetailsList.xaml
    /// </summary>
    public partial class DetailsList : Window
    {
        private DetailsListPresenter presenter;


        public DetailsList()
        {
            InitializeComponent();
        }

        public DetailsListPresenter Presenter
        {
            set
            {
                presenter = value;
            }
        }

        public void SetGridBinding(ObservableCollection<Measurement> measurements)
        {
            MeasurementGrid.DataContext = measurements;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddMeasurement();
        }

        public void ShowMesage(string message)
        {
            MessageBox.Show(message);
        }

        public string Name
        {
            get
            {
                return NameText.Text;
            }
            set
            {
                NameText.Text = value;
            }
        }

        public string Date
        {
            get
            {
                return DateText.Text;
            }
            set
            {
                DateText.Text = value;
            }
        }

        public string Weight
        {
            get
            {
                return WeightText.Text;
            }
            set
            {
                WeightText.Text = value;
            }
        }
    }
}
