using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Proyecto3_WP.Resources;
using System.Windows.Media;
using Windows.UI.Input;
using System.Windows.Input;
using System.Windows.Shapes;

namespace Proyecto3_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        private TranslateTransform move = new TranslateTransform();
        private ScaleTransform resize = new ScaleTransform();
        private RotateTransform rotate = new RotateTransform();
        private SkewTransform skew = new SkewTransform();
        private TransformGroup rectangleTransforms = new TransformGroup();

        string electionMove = "no";
        // Constructor
        Grid resetGrid;
        public MainPage()
        {
            InitializeComponent();
            resetGrid = new Grid();
            resetGrid = LayoutRoot;
            rectangleTransforms.Children.Add(move);
            rectangleTransforms.Children.Add(resize);
            rectangleTransforms.Children.Add(rotate);
            rectangleTransforms.Children.Add(skew);

            rectangle.RenderTransform = rectangleTransforms;

            rectangle.ManipulationDelta += rectangle_ManipulationDelta;
            rectangle.ManipulationStarted += rectangle_ManipulationStarted;


            
        }
        void rectangle_ManipulationStarted(object sender, System.Windows.Input.ManipulationStartedEventArgs e)
        {
            if (electionMove == "center")
            {
                rotate.CenterX=e.ManipulationOrigin.X;
                rotate.CenterY=e.ManipulationOrigin.Y;
                
                Ellipse ell = new Ellipse()
                {
                    Width=5,Height=5,Fill=new SolidColorBrush(Colors.Red)
                };
                Canvas.SetLeft(ell, rotate.CenterX);
                Canvas.SetTop(ell, rotate.CenterY );
                MessageBox.Show(rotate.CenterX + "====" + rotate.CenterY);
                rectangle.Children.Add(ell);
            electionMove = "rota";
            }
        }

        void rectangle_ManipulationDelta(object sender, ManipulationDeltaEventArgs e)
        {
            switch (electionMove)
            {
                case "tras":
                    mover(sender, e);
                    break;
                case "rota":
                    rotate.CenterX=0;
                rotate.CenterY=0;
                rotate.Angle= e.DeltaManipulation.Translation.Y;;
                    break;
                case "skew":
                    skew.AngleX = e.DeltaManipulation.Translation.X;
                    skew.AngleY = e.DeltaManipulation.Translation.Y;
                    break;
            }
            
        }

        private void crearControlesEscala()
        {
            double range = 0.1;
            ApplicationBar.Buttons.Clear();

            ApplicationBarIconButton botonIzquierda = new ApplicationBarIconButton() 
            { IsEnabled = true, Text = "left",IconUri=new Uri("/Assets/AppBar/back.png",UriKind.Relative)};
            botonIzquierda.Click += (s, a) => 
                {
                    resize.ScaleX += -range;
                };
            ApplicationBar.Buttons.Add(botonIzquierda);

            ApplicationBarIconButton botonDerecha = new ApplicationBarIconButton() 
            { IsEnabled = true, Text = "rigth", IconUri = new Uri("/Assets/AppBar/next.png", UriKind.Relative) };
            botonDerecha.Click += (s, a) =>
                {
                    resize.ScaleX += range;
                };
            ApplicationBar.Buttons.Add(botonDerecha);

            ApplicationBarIconButton botonArriba = new ApplicationBarIconButton() 
            { IsEnabled = true, Text = "up", IconUri = new Uri("/Assets/AppBar/upload.png", UriKind.Relative) };
            botonArriba.Click += (s, a) =>
                {
                    resize.ScaleY += -range;
                };
            ApplicationBar.Buttons.Add(botonArriba);

            ApplicationBarIconButton botonAbajo = new ApplicationBarIconButton() 
            { IsEnabled = true, Text = "down", IconUri = new Uri("/Assets/AppBar/download.png", UriKind.Relative) };
            botonAbajo.Click += (s, a) =>
                {
                    resize.ScaleY += range;
                };
            ApplicationBar.Buttons.Add(botonAbajo);
        }
        private void crearControlesRotacion()
        {
            double range = 5;
            ApplicationBar.Buttons.Clear();

            ApplicationBarIconButton botonIzquierda = new ApplicationBarIconButton() { IsEnabled = true, Text = "more", IconUri = new Uri("/Assets/AppBar/back.png", UriKind.Relative) };
            botonIzquierda.Click += (s, a) =>
            {
                rotate.Angle = rotate.Angle + 5 == 365 ? 0 : rotate.Angle+range;
            };
            ApplicationBar.Buttons.Add(botonIzquierda);

            ApplicationBarIconButton botonCenter = new ApplicationBarIconButton() { IsEnabled = true, Text = "center", IconUri = new Uri("/Assets/AppBar/check.png", UriKind.Relative) };
            botonCenter.Click += (s, a) =>
            {
                electionMove = "center";
            };
            ApplicationBar.Buttons.Add(botonCenter);

            ApplicationBarIconButton botonDerecha = new ApplicationBarIconButton() { IsEnabled = true, Text = "minus", IconUri = new Uri("/Assets/AppBar/next.png", UriKind.Relative) };
            botonDerecha.Click += (s, a) =>
            {
                rotate.Angle = rotate.Angle - 5 == 0 ? 365 : rotate.Angle-range;
            };
            ApplicationBar.Buttons.Add(botonDerecha);
        }

        private void crearControlesSkew()
        {
            double range = 5;
            ApplicationBar.Buttons.Clear();

            ApplicationBarIconButton botonIzquierda = new ApplicationBarIconButton() { IsEnabled = true, Text = "left", IconUri = new Uri("/Assets/AppBar/back.png", UriKind.Relative) };
            botonIzquierda.Click += (s, a) =>
            {
                skew.AngleX += -range;
            };
            ApplicationBar.Buttons.Add(botonIzquierda);

            ApplicationBarIconButton botonDerecha = new ApplicationBarIconButton() { IsEnabled = true, Text = "rigth", IconUri = new Uri("/Assets/AppBar/next.png", UriKind.Relative) };
            botonDerecha.Click += (s, a) =>
            {
                skew.AngleX += range;
            };
            ApplicationBar.Buttons.Add(botonDerecha);

            ApplicationBarIconButton botonArriba = new ApplicationBarIconButton() { IsEnabled = true, Text = "up", IconUri = new Uri("/Assets/AppBar/upload.png", UriKind.Relative) };
            botonArriba.Click += (s, a) =>
            {
                skew.AngleY += -range;
            };
            ApplicationBar.Buttons.Add(botonArriba);

            ApplicationBarIconButton botonAbajo = new ApplicationBarIconButton() { IsEnabled = true, Text = "down", IconUri = new Uri("/Assets/AppBar/download.png", UriKind.Relative) };
            botonAbajo.Click += (s, a) =>
            {
                skew.AngleY += range;
            };
            ApplicationBar.Buttons.Add(botonAbajo);
            
        }
        private void mover(object sender, ManipulationDeltaEventArgs e)
        {
            // Move the rectangle.
            move.X += e.DeltaManipulation.Translation.X;
            move.Y += e.DeltaManipulation.Translation.Y;

            //// Resize the rectangle.
            //if (e.DeltaManipulation.Scale.X > 0 && e.DeltaManipulation.Scale.Y > 0)
            //{
            //    // Scale the rectangle.
            //    resize.ScaleX *= e.DeltaManipulation.Scale.X;
            //    resize.ScaleY *= e.DeltaManipulation.Scale.Y;
            //}
        }       
        private void ApplicationBarMenuItem_Escala(object sender, EventArgs e)
        {
            crearControlesEscala();
        }

        private void ApplicationBarMenuItem_Translacion(object sender, EventArgs e)
        {
            LayoutRoot = resetGrid;
            electionMove = "tras";
        }

        private void ApplicationBarMenuItem_Rotacion(object sender, EventArgs e)
        {
            LayoutRoot = resetGrid;
            electionMove = "rota";
            crearControlesRotacion();
        }
        private void ApplicationBarMenuItem_Sesgado(object sender, EventArgs e)
        {
            LayoutRoot = resetGrid;
            crearControlesSkew();
            electionMove = "skew";
        }

        private void ApplicationBarMenuItem_Projeccion(object sender, EventArgs e)
        {
            NavigationService.Navigate(new Uri("/3DPages.xaml", UriKind.Relative));
        }
    }
}