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
            MeasurementViewModel measurementVM = new MeasurementViewModel(businessLogic);

            measurementVM.ShowUserScreen += () =>
                {
                    UserViewModel userVM = new UserViewModel(businessLogic, new CustomMeasurementDefinitionViewModel());
                    UserView userView = new UserView();
                    userView.DataContext = userVM;
                    userView.Show();
                    userView.DefinitionView.DataContext = userVM.DefinitionViewModel;
                };

            MeasurementView view = new MeasurementView();
            view.DataContext = measurementVM;
            view.Show();
        }
    }
}
