using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Proyecto1_WP.Resources;
using System.Windows.Media;
using System.Globalization;
using System.Windows.Controls.Primitives;
using System.Windows.Shapes;

namespace Proyecto1_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        // Constructor
        public MainPage()
        {
            InitializeComponent();
            Loaded += MainPage_Loaded;
        }

        
        void MainPage_Loaded(object sender, RoutedEventArgs e)
        {
            Polyline fg;
            bool dibujar = false;
            bool nuevoPath = true;

            ContentPanel.MouseLeftButtonDown += (s, a) =>
            {    
                dibujar = true;
                nuevoPath = true;
            };

            ContentPanel.MouseLeftButtonUp += (s, a) =>
            {
                dibujar = false;
            };
            ContentPanel.MouseMove += (s, a) =>
            {
                
                if (dibujar)
                {
	if (nuevoPath)
                {
                    ContentPanel.Children.Add(new Polyline()
                    { 
                        Stroke = (Application.Current.Resources["paint"] as Paint).ColorLine,
                        StrokeThickness = (Application.Current.Resources["paint"] as Paint).WidthLine,
                    });
                    nuevoPath = false;
                }
                    var path = ContentPanel.Children.Last() as Polyline;
                    path.Points.Add(a.GetPosition(s as Grid));
                }
            };
        }
        private void barSettings_Click(object sender, EventArgs e)
        {
            PopUpSettings.IsOpen = !PopUpSettings.IsOpen;
        }

        private void barClear_Click(object sender, EventArgs e)
        {
            ContentPanel.Children.Clear();
        }
    }
}