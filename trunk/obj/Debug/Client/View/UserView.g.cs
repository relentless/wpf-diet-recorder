﻿#pragma checksum "..\..\..\..\Client\View\UserView.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "45ADD575F513C43D0B11AB16763B9F51"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.4927
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using DietRecorder.Client.View;
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
    /// UserView
    /// </summary>
    public partial class UserView : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 18 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.ListBox Users;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.Grid UserGrid;
        
        #line default
        #line hidden
        
        
        #line 38 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.TextBox NameText;
        
        #line default
        #line hidden
        
        
        #line 41 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.Button NewUserButton;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.Button AddUserButton;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.Button CancelUserButton;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\..\Client\View\UserView.xaml"
        internal System.Windows.Controls.Button DeleteUserButton;
        
        #line default
        #line hidden
        
        
        #line 49 "..\..\..\..\Client\View\UserView.xaml"
        internal DietRecorder.Client.View.CustomMeasurementDefinitionView DefinitionView;
        
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
            System.Uri resourceLocater = new System.Uri("/DietRecorder;component/client/view/userview.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Client\View\UserView.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal System.Delegate _CreateDelegate(System.Type delegateType, string handler) {
            return System.Delegate.CreateDelegate(delegateType, this, handler);
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Users = ((System.Windows.Controls.ListBox)(target));
            return;
            case 2:
            this.UserGrid = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.NameText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.NewUserButton = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.AddUserButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.CancelUserButton = ((System.Windows.Controls.Button)(target));
            return;
            case 7:
            this.DeleteUserButton = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.DefinitionView = ((DietRecorder.Client.View.CustomMeasurementDefinitionView)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
