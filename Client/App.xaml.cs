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

namespace DietRecorder.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            //Repository dietRepository = new Repository();
            //DietLogic dietLogic = new DietLogic(dietRepository);
            //DetailsListPresenter detailsListPresenter = new DetailsListPresenter(new DetailsList(), dietLogic);
            //detailsListPresenter.DisplayView();

            CustomMeasurementDefinitionViewModel viewModel = new CustomMeasurementDefinitionViewModel();
            viewModel.MeasurementDefinitions = new ObservableCollection<CustomMeasurementDefinition>();
            UserView view = new UserView();
            view.DataContext = viewModel;

            view.Show();
            
        }
    }
}
