﻿#pragma checksum "..\..\DirectoryListing.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "4A9AFA716493D04CEFCC2CC4C6DDAACE"
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
using WebKidzPlus;


namespace WebKidzPlus {
    
    
    /// <summary>
    /// DirectoryListing
    /// </summary>
    public partial class DirectoryListing : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\DirectoryListing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TreeView foldersItem;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\DirectoryListing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem TV_CM_NewDir;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\DirectoryListing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem TV_CM_NewFile;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DirectoryListing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem TV_CM_Import;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\DirectoryListing.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.MenuItem TV_CM_Delete;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WebKidzPlus;component/directorylisting.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DirectoryListing.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.foldersItem = ((System.Windows.Controls.TreeView)(target));
            
            #line 10 "..\..\DirectoryListing.xaml"
            this.foldersItem.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.Subitem_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 2:
            this.TV_CM_NewDir = ((System.Windows.Controls.MenuItem)(target));
            
            #line 13 "..\..\DirectoryListing.xaml"
            this.TV_CM_NewDir.Click += new System.Windows.RoutedEventHandler(this.TV_CM_NewDir_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.TV_CM_NewFile = ((System.Windows.Controls.MenuItem)(target));
            
            #line 15 "..\..\DirectoryListing.xaml"
            this.TV_CM_NewFile.Click += new System.Windows.RoutedEventHandler(this.TV_CM_NewFile_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.TV_CM_Import = ((System.Windows.Controls.MenuItem)(target));
            
            #line 17 "..\..\DirectoryListing.xaml"
            this.TV_CM_Import.Click += new System.Windows.RoutedEventHandler(this.TV_CM_Import_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.TV_CM_Delete = ((System.Windows.Controls.MenuItem)(target));
            
            #line 19 "..\..\DirectoryListing.xaml"
            this.TV_CM_Delete.Click += new System.Windows.RoutedEventHandler(this.TV_CM_Delete_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

