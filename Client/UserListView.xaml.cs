using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Collections.ObjectModel;
using DietRecorder.Model;
using DietRecorder.Client.Common;

namespace DietRecorder.Client
{
    public partial class UserListView : Window
    {
        //private UserListPresenter presenter;

        public UserListView()
        {
            InitializeComponent();
        }

        //public UserListPresenter Presenter
        //{
        //    set
        //    {
        //        presenter = value;
        //    }
        //}

        //public void SetUserListBinding(ObservableCollection<User> users)
        //{
        //    UserList.DataContext = users;
        //}

        //public void SetCustomMeasurementListBinding(ObservableCollection<CustomMeasurementDefinition> customDefinitions)
        //{
        //    CustomMeasurementList.DataContext = customDefinitions;
        //}

        //public string UserName
        //{
        //    get { return NameText.Text; }
        //    set { NameText.Text = value; }
        //}

        //public string MeasurementName
        //{
        //    get { return CustomMeasurementText.Text; }
        //    set { CustomMeasurementText.Text = value; }
        //}

        //private void AddUserButton_Click(object sender, RoutedEventArgs e)
        //{
        //    presenter.AddUser();
        //}

        //private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        //{
        //    presenter.DeleteUser();
        //}

        //private void AddCustomMeasurementButton_Click(object sender, RoutedEventArgs e)
        //{
        //    presenter.AddMeasurementDefinition();
        //}

        //private void DeleteCustomMeasurementButton_Click(object sender, RoutedEventArgs e)
        //{
        //    presenter.DeleteMeasurementDefinition();
        //}

        //public void ShowMessage(string title, string message)
        //{
        //    MessageBox.Show(message, title);
        //}

        //private void UserList_SelectionChanged(object sender, SelectionChangedEventArgs e)
        //{
        //    presenter.DisplayUser();
        //}

        //public void SetCustomMeasurementDefinitionBinding(CustomMeasurementDefinition definition)
        //{
        //    CustomMeasurementDetailsGrid.DataContext = definition;
        //}

        //public void SetUserBinding(User user)
        //{
        //    UserGrid.DataContext = user;
        //}

        //private void NewUserButton_Click(object sender, RoutedEventArgs e)
        //{
        //    presenter.NewUser();
        //}

        //public void SetMode(ViewMode mode)
        //{
        //    if (mode == ViewMode.View)
        //    {
        //        NewUserButton.Visibility = Visibility.Visible;
        //        AddUserButton.Visibility = Visibility.Hidden;
        //        DeleteUserButton.Visibility = Visibility.Visible;
        //        CancelUserButton.Visibility = Visibility.Hidden;
        //        NameText.IsEnabled = false;
        //    }
        //    else
        //    {
        //        NewUserButton.Visibility = Visibility.Hidden;
        //        AddUserButton.Visibility = Visibility.Visible;
        //        DeleteUserButton.Visibility = Visibility.Hidden;
        //        CancelUserButton.Visibility = Visibility.Visible;
        //        NameText.IsEnabled = true;
        //    }
        //}

        //private void CancelUserButton_Click(object sender, RoutedEventArgs e)
        //{
        //    presenter.CancelAddingUser();
        //}
    }
}
