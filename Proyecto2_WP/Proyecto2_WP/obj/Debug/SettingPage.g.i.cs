﻿#pragma checksum "C:\Users\Israel\documents\visual studio 2013\Projects\Proyecto2_WP\Proyecto2_WP\SettingPage.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9FD50E3DE6362AC5D402AC71248917F8"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using Brochas;
using Microsoft.Phone.Controls;
using System;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Automation.Peers;
using System.Windows.Automation.Provider;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Resources;
using System.Windows.Shapes;
using System.Windows.Threading;


namespace Proyecto2_WP {
    
    
    public partial class SettingPage : Microsoft.Phone.Controls.PhoneApplicationPage {
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal Brochas.BruhesGridPanel brushesGrid;
        
        internal System.Windows.Controls.MediaElement bang;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/Proyecto2_WP;component/SettingPage.xaml", System.UriKind.Relative));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.brushesGrid = ((Brochas.BruhesGridPanel)(this.FindName("brushesGrid")));
            this.bang = ((System.Windows.Controls.MediaElement)(this.FindName("bang")));
        }
    }
}

