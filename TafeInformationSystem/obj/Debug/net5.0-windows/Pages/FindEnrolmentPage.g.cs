﻿#pragma checksum "..\..\..\..\Pages\FindEnrolmentPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "C3F92E129181D922BAF5B8B737136AD037DFCC0B"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using System.Windows.Shell;
using TafeInformationSystem.Pages;


namespace TafeInformationSystem.Pages {
    
    
    /// <summary>
    /// FindEnrolmentPage
    /// </summary>
    public partial class FindEnrolmentPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 38 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox searchBycmb;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchCriteriaText;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView enrolmentListView;
        
        #line default
        #line hidden
        
        
        #line 71 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button openButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteButton;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menuButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TafeInformationSystem;component/pages/findenrolmentpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "5.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.searchBycmb = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 2:
            this.searchCriteriaText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.enrolmentListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 4:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            
            #line 74 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
            this.searchButton.Click += new System.Windows.RoutedEventHandler(this.SearchButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 79 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.ClearButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.openButton = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
            this.openButton.Click += new System.Windows.RoutedEventHandler(this.OpenButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.deleteButton = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
            this.deleteButton.Click += new System.Windows.RoutedEventHandler(this.DeleteButton_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.menuButton = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\..\Pages\FindEnrolmentPage.xaml"
            this.menuButton.Click += new System.Windows.RoutedEventHandler(this.MenuButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

