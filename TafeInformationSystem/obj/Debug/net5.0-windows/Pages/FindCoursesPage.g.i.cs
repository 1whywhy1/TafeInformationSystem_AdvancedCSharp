﻿#pragma checksum "..\..\..\..\Pages\FindCoursesPage.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "69F512471CF93F8F757D09946B0F5D9EE5D348AE"
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
    /// FindCoursesPage
    /// </summary>
    public partial class FindCoursesPage : System.Windows.Controls.Page, System.Windows.Markup.IComponentConnector {
        
        
        #line 59 "..\..\..\..\Pages\FindCoursesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox searchCriteriaText;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\..\..\Pages\FindCoursesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView coursesListView;
        
        #line default
        #line hidden
        
        
        #line 81 "..\..\..\..\Pages\FindCoursesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button searchButton;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\..\..\Pages\FindCoursesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button clearButton;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\..\..\Pages\FindCoursesPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button updateButton;
        
        #line default
        #line hidden
        
        
        #line 99 "..\..\..\..\Pages\FindCoursesPage.xaml"
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
            System.Uri resourceLocater = new System.Uri("/TafeInformationSystem;component/pages/findcoursespage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\..\Pages\FindCoursesPage.xaml"
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
            this.searchCriteriaText = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.coursesListView = ((System.Windows.Controls.ListView)(target));
            return;
            case 3:
            this.searchButton = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.clearButton = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.updateButton = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.menuButton = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
