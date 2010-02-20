using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Windows;
using DietRecorder.BusinessLeyer;
using DietRecorder.Model;
using DietRecorder.DataAccess;

namespace DietRecorder.Client
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Repository dietRepository = new Repository();
            DietLogic dietLogic = new DietLogic(dietRepository);
            DetailsListPresenter detailsListPresenter = new DetailsListPresenter(new DetailsList(), dietLogic);
            detailsListPresenter.DisplayView();
        }
    }
}
