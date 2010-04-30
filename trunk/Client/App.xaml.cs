using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
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
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            IRepository repository = new Repository();

            MeasurementViewModel measurementVM = new MeasurementViewModel(repository);

            measurementVM.ShowUserScreen += () =>
                {
                    UserViewModel userVM = new UserViewModel(repository, new CustomMeasurementDefinitionViewModel());
                    UserView userView = new UserView();
                    userView.DataContext = userVM;
                    userView.Show();
                    // I don't know why this has to be set after the view is shown,
                    // but it's the only way I can make it work
                    userView.DefinitionView.DataContext = userVM.DefinitionViewModel;
                };

            MeasurementView view = new MeasurementView();
            view.DataContext = measurementVM;
            view.Show();
        }
    }
}
