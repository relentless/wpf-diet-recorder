﻿#pragma checksum "..\..\..\..\Client\View\MeasurementView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "44A53467D632232A3EC7F9A6CF637EB4"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DietRecorder.Client.Common;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace DietRecorder.Client.View {
    
    
    /// <summary>
    /// MeasurementView
    /// </summary>
    public partial class MeasurementView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 13 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.MenuItem UsersMenu;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.ComboBox UserCombo;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.ListView MeasurementGrid;
        
        #line default
        #line hidden
        
        
        #line 37 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.Grid DetailsGrid;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.TextBox DateText;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.TextBox WeightText;
        
        #line default
        #line hidden
        
        
        #line 59 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.TextBox NotesText;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.Button NewButton;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.Button DeleteButton;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.Button AddButton;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.Button CancelButton;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\..\Client\View\MeasurementView.xaml"
        internal System.Windows.Controls.StackPanel CustomMeasurementsPanel;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/DietRecorder;component/client/view/measurementview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Client\View\MeasurementView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.UsersMenu = ((System.Windows.Controls.MenuItem)(target));
            return;
            case 2:
            this.UserCombo = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.MeasurementGrid = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.DetailsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 5:
            this.DateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.WeightText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.NotesText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 8:
            this.NewButton = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.DeleteButton = ((System.Windows.Controls.Button)(target));
            return;
            case 10:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            return;
            case 11:
            this.CancelButton = ((System.Windows.Controls.Button)(target));
            return;
            case 12:
            this.CustomMeasurementsPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
