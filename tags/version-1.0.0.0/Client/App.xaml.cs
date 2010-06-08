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
using DietRecorder.Common;
using BlogsPrajeesh.BlogSpot.WPFControls;

namespace DietRecorder.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            try
            {
                IRepository repository = new Repository();
                MessageDisplay messageDisplay = new MessageDisplay();
                MeasurementViewModel measurementVM = new MeasurementViewModel(repository, messageDisplay, new MeasurementFactory());
                CustomMeasurementDefinitionViewModel definitionsVM = new CustomMeasurementDefinitionViewModel(messageDisplay);
                UserViewModel userVM = new UserViewModel(repository, definitionsVM, messageDisplay);
                userVM.UsersChanged += measurementVM.LoadUsersFromRepository;
                UserView userView = null;

                // open the Users screen
                measurementVM.ShowUserScreenAction += () =>
                    {
                        try
                        {
                            // ensure only one view is loaded, and the same one remains open for multiple requests
                            userView = userView ?? new UserView();

                            if (!userView.IsLoaded)
                            {
                                userView.Close();
                                userView = new UserView();
                                userView.DataContext = userVM;
                            }

                            userView.Show();

                            // I don't know why this has to be set after the view is shown,
                            // but it's the only way I can make it work
                            userView.DefinitionView.DataContext = userVM.DefinitionViewModel;
                        }
                        catch (Exception ex)
                        {
                            WPFMessageBox.Show("Error", ex.Message, ex.ToString(), WPFMessageBoxImage.Error);
                            Application.Current.Shutdown();
                        }
                    };

                MeasurementView view = new MeasurementView();
                view.DataContext = measurementVM;
                view.Show();
            }
            catch (Exception ex)
            {
                WPFMessageBox.Show("Error", ex.Message, ex.ToString(), WPFMessageBoxImage.Error);
                Application.Current.Shutdown();
            }
        }
    }
}
