﻿#pragma checksum "..\..\..\..\Pages\SemesterPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "0E35182868FCF751C7A9E839C2E7290A26C08A5C"
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
    /// SemesterPage
    /// </summary>
    public partial class SemesterPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 48 "..\..\..\..\Pages\SemesterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker startDP;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\..\..\Pages\SemesterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker endDP;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\..\..\Pages\SemesterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox semesterIDTxt;
        
        #line default
        #line hidden
        
        
        #line 76 "..\..\..\..\Pages\SemesterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox semesterNameTxt;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\SemesterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button addButton;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\..\..\Pages\SemesterPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 92 "..\..\..\..\Pages\SemesterPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TafeInformationSystem;component/pages/semesterpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\SemesterPage.xaml"
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
            this.startDP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 2:
            this.endDP = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 3:
            this.semesterIDTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.semesterNameTxt = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.addButton = ((System.Windows.Controls.Button)(target));
            
            #line 84 "..\..\..\..\Pages\SemesterPage.xaml"
            this.addButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            
            #line 89 "..\..\..\..\Pages\SemesterPage.xaml"
            this.clearButton.Click += new System.Windows.RoutedEventHandler(this.AddButton_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.menuButton = ((System.Windows.Controls.Button)(target));
            
            #line 95 "..\..\..\..\Pages\SemesterPage.xaml"
            this.menuButton.Click += new System.Windows.RoutedEventHandler(this.MenuButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

