using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DietRecorder.BusinessLayer;
using DietRecorder.Model;
using DietRecorder.DataAccess;
using DietRecorder.Client.View;
using DietRecorder.Client.ViewModel;
using System.Collections.ObjectModel;
using DietRecorder.Client.Common;

namespace DietRecorder.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IDietLogic businessLogic = new DietLogic(new Repository());

        private void Application_Startup(object sender, StartupEventArgs e)
        {
        //    CustomMeasurementDefinitionViewModel definitionViewModel = new CustomMeasurementDefinitionViewModel();
        //    definitionViewModel.MeasurementDefinitions = new ObservableCollection<CustomMeasurementDefinition>();

        //    UserViewModel userViewModel = new UserViewModel(definitionViewModel);
        //    userViewModel.DefinitionViewModel = definitionViewModel;

        //    userViewModel.Users = businessLogic.LoadUserList().ToObservableCollection<User>();

        //    userViewModel.UsersUpdated += () =>
        //    {
        //        IList<User> userList = new List<User>();
        //        foreach (User user in userViewModel.Users)
        //        {
        //            userList.Add(user);
        //        }
        //        businessLogic.SaveUserList(userList);
        //    };

        //    userViewModel.UserDeleted += (user) =>
        //    {
        //        businessLogic.Delete(user);
        //    };

        //    UserView view = new UserView();
        //    view.DataContext = userViewModel;

        //    view.Show();
        //    view.DefinitionView.DataContext = userViewModel.DefinitionViewModel;

            MeasurementViewModel measurementVM = new MeasurementViewModel();
            measurementVM.Users = businessLogic.LoadUserList().ToObservableCollection<User>();

            measurementVM.MeasurementAdded += () =>
                {
                    businessLogic.SaveUserList(measurementVM.Users);
                };

            measurementVM.MeasurementRemoved += (removedMeasurement) =>
                {
                    businessLogic.Delete(removedMeasurement);
                };

            MeasurementView view = new MeasurementView();
            view.DataContext = measurementVM;
            view.Show();
        }
    }
}
