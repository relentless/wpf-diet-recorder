﻿#pragma checksum "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "BEE7DE6525AB88E654C17B87791F12E5"
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
using DietRecorder.Model;
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
    /// CustomMeasurementDefinitionView
    /// </summary>
    public partial class CustomMeasurementDefinitionView : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 26 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
        internal System.Windows.Controls.ListBox CustomMeasurementList;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
        internal System.Windows.Controls.Grid CustomMeasurementDetailsGrid;
        
        #line default
        #line hidden
        
        
        #line 64 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
        internal System.Windows.Controls.TextBox CustomMeasurementText;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
        internal System.Windows.Controls.ComboBox CustomMeasurementType;
        
        #line default
        #line hidden
        
        
        #line 78 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
        internal System.Windows.Controls.Button AddCustomMeasurementButton;
        
        #line default
        #line hidden
        
        
        #line 82 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
        internal System.Windows.Controls.Button DeleteCustomMeasurementButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DietRecorder;component/client/view/custommeasurementdefinitionview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Client\View\CustomMeasurementDefinitionView.xaml"
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
            this.CustomMeasurementList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.CustomMeasurementDetailsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.CustomMeasurementText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.CustomMeasurementType = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 5:
            this.AddCustomMeasurementButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.DeleteCustomMeasurementButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
