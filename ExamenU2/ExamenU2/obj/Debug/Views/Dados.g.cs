﻿#pragma checksum "C:\Users\Israel\Documents\Visual Studio 2013\Projects\ExamenU2\ExamenU2\Views\Dados.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "D16919906ADCC82ADA07A18BB0F86F1A"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34011
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

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


namespace ExamenU2.Views {
    
    
    public partial class Dados : System.Windows.Controls.UserControl {
        
        internal System.Windows.Media.Animation.Storyboard MueveDatos;
        
        internal System.Windows.Controls.Grid LayoutRoot;
        
        internal System.Windows.Controls.Grid cuadro1;
        
        internal System.Windows.Controls.Grid cuadro2;
        
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
            System.Windows.Application.LoadComponent(this, new System.Uri("/ExamenU2;component/Views/Dados.xaml", System.UriKind.Relative));
            this.MueveDatos = ((System.Windows.Media.Animation.Storyboard)(this.FindName("MueveDatos")));
            this.LayoutRoot = ((System.Windows.Controls.Grid)(this.FindName("LayoutRoot")));
            this.cuadro1 = ((System.Windows.Controls.Grid)(this.FindName("cuadro1")));
            this.cuadro2 = ((System.Windows.Controls.Grid)(this.FindName("cuadro2")));
        }
    }
}

