﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DietRecorder.Model;
using DietRecorder.BusinessLeyer;

namespace DietRecorder.Client
{
    public class DetailsListPresenter
    {
        private DetailsList view;
        private IDietLogic dietLogic;
        private MeasurementList measurements;

        public DetailsListPresenter(DetailsList view, IDietLogic logic)
        {
            this.view = view;
            view.Presenter = this;
            this.dietLogic = logic;
        }

        public MeasurementList Measurements
        {
            get
            {
                return measurements;
            }
        }

        public void DisplayView()
        {
            measurements = dietLogic.LoadMeasurementList();
            view.Show();
        }

        public void AddMeasurement()
        {
            string name = view.Name;
            DateTime date = Convert.ToDateTime(view.Date);
            double weight = Convert.ToDouble(view.Weight);

            Measurement newMeasurement = new Measurement(name, date, weight);
            measurements.Add(newMeasurement);

            ClearViewFields();
        }

        private void ClearViewFields()
        {
            view.Name = string.Empty;
            view.Date = string.Empty;
            view.Weight = string.Empty;
        }
    }
}