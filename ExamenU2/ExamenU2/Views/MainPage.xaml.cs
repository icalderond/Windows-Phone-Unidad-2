using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using ExamenU2.Resources;
using System.Windows.Threading;
using ExamenU2.Logica;

namespace ExamenU2
{
    public partial class MainPage : PhoneApplicationPage
    {
        GridGame res;
        // Constructor
        public MainPage()
        {
            InitializeComponent();           
            SunAnimation.Begin();

            const double pow = (3600000.0 * 24.0) / 160000.0;
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 500);

            dispatcher.Tick += (s, a) =>
                {
                    var im = SunAnimation.GetCurrentTime().TotalMilliseconds;
                    var milliseconds = im;
                    var date = TimeSpan.FromMilliseconds(milliseconds);
                                     

                    if (controlJuego> im)
                    {
                        NavigationService.Navigate(new Uri("/Views/PuntuatioPage.xaml?value=dia", UriKind.Relative));
                        dispatcher.Stop();
                        controlJuego = 0;
                    }
                    else if (!res.Puntaje.EstaEnJuego)
                    {
                        NavigationService.Navigate(new Uri("/Views/PuntuatioPage.xaml?value=tiro", UriKind.Relative));
                        dispatcher.Stop();
                        controlJuego = 0;
                    }
                    controlJuego = im;
                };
            dispatcher.Start();


            res = Application.Current.Resources["gridGame"] as GridGame;
            res.IniciarJuego();
            // DispatcherTimer dispatcher = new DispatcherTimer();
            //dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 1);
          
            
            //dispatcher.Tick += (s, a) =>
            //{
            //    controlJuego += 1;
            //    if (controlJuego >= 16000.0)
            //    {
            //        NavigationService.Navigate(new Uri("/Views/PuntuatioPage.xaml", UriKind.Relative));
            //        dispatcher.Stop();
            //    }
               
            //};
            //dispatcher.Start();
        }
        bool EstaEnJuego = true;
        private double controlJuego;
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/Views/PuntuatioPage.xaml", UriKind.Relative));
        }
    }
}