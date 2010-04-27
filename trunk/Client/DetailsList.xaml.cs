using System;
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
            //MeasurementGrid.DataContext = measurements;
        }

        public void SetBindingForFields(Measurement measurement)
        {
            //DetailsGrid.DataContext = measurement;
        }

        //public void SetUserBinding(UserList userList)
        //{
        //    UserCombo.DataContext = userList;
        //}

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddMeasurement();
        }

        public void ShowMessage(string title, string message)
        {
            MessageBox.Show(message, title);
        }

        private void MeasurementGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            presenter.ShowMeasurement();
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

        public void AddCustomMeasurementControl(CustomMeasurementDefinition definition)
        {
            Grid controlGrid = CreateControlGrid();

            TextBlock controlName = new TextBlock();
            controlName.Text = definition.Name;
            controlGrid.Children.Add(controlName);
            controlGrid.DataContext = definition;

            TextBox controlValue = new TextBox();
            controlGrid.Children.Add(controlValue);
            Grid.SetColumn(controlValue, 1);
           // CustomMeasurementsPanel.Children.Add(controlGrid);
        }

        private Grid CreateControlGrid()
        {
            Grid controlGrid = new Grid();
            ColumnDefinition labelDefinition = new ColumnDefinition();
            labelDefinition.Width = GridLength.Auto;
            controlGrid.ColumnDefinitions.Add(labelDefinition);
            controlGrid.ColumnDefinitions.Add(new ColumnDefinition());
            return controlGrid;
        }

        public void ShowCustomMeasurements(List<CustomMeasurement> measurements)
        {
            if (measurements.Count > 0)
            {
                //foreach (Grid controlGrid in CustomMeasurementsPanel.Children)
                //{
                //    if (controlGrid.DataContext != null)
                //    {
                //        CustomMeasurement matchingMeasurement = (from measurement in measurements
                //                                                 where measurement.Definition == (CustomMeasurementDefinition)controlGrid.DataContext
                //                                                 select measurement).First();

                //        ((TextBox)controlGrid.Children[1]).Text = matchingMeasurement.Value;
                //    }
                //}
            }
        }

        public List<CustomMeasurement> GetCustomMeasurements()
        {
            List<CustomMeasurement> returnList = new List<CustomMeasurement>();

            //foreach (Grid controlGrid in CustomMeasurementsPanel.Children)
            //{
            //    if (controlGrid.DataContext != null)
            //    {
            //        CustomMeasurement returnMeasurement = new CustomMeasurement();
            //        returnMeasurement.Definition = (CustomMeasurementDefinition)controlGrid.DataContext;
            //        returnMeasurement.Value = ((TextBox)controlGrid.Children[1]).Text;

            //        returnList.Add(returnMeasurement);
            //    }
            //}

            return returnList;
        }

        public void ClearCustomMeasurements()
        {
            //foreach (Grid controlGrid in CustomMeasurementsPanel.Children)
            //{
            //    ((TextBox)controlGrid.Children[1]).Text = string.Empty;
            //}
        }
    }
}
