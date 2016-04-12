using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Windows.Threading;
using ExamenU2.Logica;
using System.Windows.Shapes;
using System.Windows.Media;

namespace ExamenU2.Views
{
    public partial class Dados : UserControl
    {
        private bool actve;

        public bool Active
        {
            get { return actve; }
            set { actve = value; }
        }

        public Dados()
        {
            InitializeComponent();
            Loaded += Dados_Loaded;
            MueveDatos.Completed += MueveDatos_Completed;
           i= Application.Current.Resources["gridGame"] as GridGame;
           LlenarCubo();
            //MueveDatos.Begin();
        }

        void MueveDatos_Completed(object sender, EventArgs e)
        {
            dispatcher.Start();
            LlenarCubo();
        }

        private void LlenarCubo()
        {
           switch (i.NumeroDos)
           {
               case 1:
                   ponerElipse(5, 2);
                   break;
               case 2:
                   ponerElipse(4, 2);
                   ponerElipse(6, 2);
                   break;
               case 3:
                   ponerElipse(2, 2);
                   ponerElipse(5, 2);
                   ponerElipse(8, 2);
                   break;
               case 4:
                   ponerElipse(1, 2);
                   ponerElipse(3, 2);
                   ponerElipse(7, 2);
                   ponerElipse(9, 2);
                   break;
               case 5:
                   ponerElipse(1, 2);
                   ponerElipse(3, 2);
                   ponerElipse(7, 2);
                   ponerElipse(9, 2);
                   ponerElipse(5, 2);
                   break;
               case 6:
                   ponerElipse(1, 2);
                   ponerElipse(3, 2);
                   ponerElipse(4, 2);
                   ponerElipse(9, 2);
                   ponerElipse(4, 2);
                   ponerElipse(6, 2);
                   break;
           }

           switch (i.NumeroUno)
           {
               case 1:
                   ponerElipse(5, 1);
                   break;
               case 2:
                   ponerElipse(4, 1);
                   ponerElipse(6, 1);
                   break;
               case 3:
                   ponerElipse(2, 1);
                   ponerElipse(5, 1);
                   ponerElipse(8, 1);
                   break;
               case 4:
                   ponerElipse(1, 1);
                   ponerElipse(3, 1);
                   ponerElipse(7, 1);
                   ponerElipse(9, 1);
                   break;
               case 5:
                   ponerElipse(1, 1);
                   ponerElipse(3, 1);
                   ponerElipse(7, 1);
                   ponerElipse(9, 1);
                   ponerElipse(5, 1);
                   break;
               case 6:
                   ponerElipse(1, 1);
                   ponerElipse(3, 1);
                   ponerElipse(4, 1);
                   ponerElipse(9, 1);
                   ponerElipse(4, 1);
                   ponerElipse(6, 1);
                   break;
           }
        }

        Ellipse el;
        private void ponerElipse(int numero,int cubo)
        {
            
             switch (numero)
           {
                 case 1:
                     el = new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 0);
                    Grid.SetRow(el, 0);
                    break;
                 case 2:
                     el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 0);
                    Grid.SetRow(el, 1);
                    break;
                 case 3:
                      el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 0);
                    Grid.SetRow(el, 2);
                    break;
                 case 4:
                      el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 1);
                    Grid.SetRow(el, 0);
                    break;
                 case 5:
                      el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 1);
                    Grid.SetRow(el, 1);
                    break;
                 case 6:
                      el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 1);
                    Grid.SetRow(el, 2);
                    break;
                 case 7:  el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 2);
                    Grid.SetRow(el, 0);
                    break;
                 case 8:
                      el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 2);
                    Grid.SetRow(el, 1);
                    break;
                 case 9:
                      el= new Ellipse() { Width = 20, Height = 20, Fill = new SolidColorBrush(Colors.Black) };
                    Grid.SetColumn(el, 2);
                    Grid.SetRow(el, 2);
                    break;
               
           }
             if (cubo == 1)
             {
                 cuadro1.Children.Add(el);
             }
             else
             {
                 cuadro2.Children.Add(el);
             }
            
        }


        DispatcherTimer dispatcher = new DispatcherTimer();
        void Dados_Loaded(object sender, RoutedEventArgs e)
        {
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 500);
            dispatcher.Tick += dispatcher_Tick;
            dispatcher.Start();

            i.ActiveDado = true;
        }
        GridGame i;
        void dispatcher_Tick(object sender, EventArgs e)
        {
            if (i.ActiveDado)
            {
                cuadro1.Children.Clear();
                cuadro2.Children.Clear();
                MueveDatos.Begin();
                i.ActiveDado = false;
            }
        }
    }
}
