﻿#pragma checksum "..\..\..\..\Pages\CourseLocationPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "F277B66D224D45BAB6BE33825E0E9D24E88E3922"
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
    /// CourseLocationPage
    /// </summary>
    public partial class CourseLocationPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\Pages\CourseLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox courseText;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\CourseLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox locationText;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\..\..\Pages\CourseLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button assignButton;
        
        #line default
        #line hidden
        
        
        #line 85 "..\..\..\..\Pages\CourseLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button unassignButton;
        
        #line default
        #line hidden
        
        
        #line 90 "..\..\..\..\Pages\CourseLocationPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button menuButton;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/TafeInformationSystem;component/pages/courselocationpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\CourseLocationPage.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.4.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.courseText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.locationText = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 3:
            this.assignButton = ((System.Windows.Controls.Button)(target));
            
            #line 83 "..\..\..\..\Pages\CourseLocationPage.xaml"
            this.assignButton.Click += new System.Windows.RoutedEventHandler(this.AssignButton_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.unassignButton = ((System.Windows.Controls.Button)(target));
            
            #line 88 "..\..\..\..\Pages\CourseLocationPage.xaml"
            this.unassignButton.Click += new System.Windows.RoutedEventHandler(this.DeassignButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.menuButton = ((System.Windows.Controls.Button)(target));
            
            #line 93 "..\..\..\..\Pages\CourseLocationPage.xaml"
            this.menuButton.Click += new System.Windows.RoutedEventHandler(this.MenuButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

