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

namespace DietRecorder.Client
{
    public partial class UserListView : Window
    {
        private UserListPresenter presenter;

        public UserListView()
        {
            InitializeComponent();
        }

        public UserListPresenter Presenter
        {
            set
            {
                presenter = value;
            }
        }

        public void SetListBinding(ObservableCollection<User> users)
        {
            UserList.DataContext = users;
        }

        public string UserName
        {
            get { return NameText.Text; }
            set { NameText.Text = value; }
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.AddUser();
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            presenter.DeleteUser();
        }
    }
}
