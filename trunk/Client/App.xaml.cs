using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DietRecorder.BusinessLeyer;
using DietRecorder.Model;

namespace DietRecorder.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            DetailsListPresenter detailsListPresenter = new DetailsListPresenter(new DetailsList(), new DietLogic());
            detailsListPresenter.DisplayView();
        }
    }
}
