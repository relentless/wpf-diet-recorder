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

        public void SetBindingForFields(Measurement measurement)
        {
            DetailsGrid.DataContext = measurement;
        }

        public void SetUserBinding(UserList userList)
        {
            UserCombo.DataContext = userList;
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddMeasurement();
        }

        public void ShowMesage(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        private void MeasurementGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.ListSelectionChanged();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.DeleteMeasurement();
        }

        private void UsersMenu_Click(object sender, RoutedEventArgs e)
        {
            presenter.ShowUserView();
        }

        private void UserCombo_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.LoadSelectedUser();
        }
    }
}