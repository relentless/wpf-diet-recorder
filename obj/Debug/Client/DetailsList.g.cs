﻿#pragma checksum "..\..\..\Client\DetailsList.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AE5B343021B98676C6810978D602CB0D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace DietRecorder.Client {
    
    
    /// <summary>
    /// DetailsList
    /// </summary>
    public partial class DetailsList : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Client\DetailsList.xaml"
        internal System.Windows.Controls.ListView MeasurementGrid;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\Client\DetailsList.xaml"
        internal System.Windows.Controls.Grid DetailsGrid;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Client\DetailsList.xaml"
        internal System.Windows.Controls.TextBox NameText;
        
        #line default
        #line hidden
        
        
        #line 32 "..\..\..\Client\DetailsList.xaml"
        internal System.Windows.Controls.TextBox DateText;
        
        #line default
        #line hidden
        
        
        #line 36 "..\..\..\Client\DetailsList.xaml"
        internal System.Windows.Controls.TextBox WeightText;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\Client\DetailsList.xaml"
        internal System.Windows.Controls.Button AddButton;
        
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
            System.Uri resourceLocater = new System.Uri("/DietRecorder;component/client/detailslist.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Client\DetailsList.xaml"
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
            this.MeasurementGrid = ((System.Windows.Controls.ListView)(target));
            return;
            case 2:
            this.DetailsGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.NameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.DateText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.WeightText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AddButton = ((System.Windows.Controls.Button)(target));
            
            #line 38 "..\..\..\Client\DetailsList.xaml"
            this.AddButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
