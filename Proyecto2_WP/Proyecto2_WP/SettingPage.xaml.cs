using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Brochas;
using System.Windows.Media;

namespace Proyecto2_WP
{
    public partial class SettingPage : PhoneApplicationPage
    {
        public SettingPage()
        {
            InitializeComponent();
           
        }

        private void RadialBrush_Click(object sender, EventArgs e)
        {
            ApplicationBar.Buttons.Clear();
            brushesGrid.changeBackground(2);
            checkMediaElement();
        }

        private void LinearBrush_Click(object sender, EventArgs e)
        {
            ApplicationBar.Buttons.Clear();
            brushesGrid.changeBackground(1);
            MessageBox.Show("Sostenga el dedo en el punto de inicio y suelte en donde necesite el punto final", "INSTRUCCION", MessageBoxButton.OK);
            checkMediaElement();
        }

        private void ImageBrush_Click(object sender, EventArgs e)
        {
            brushesGrid.changeBackground(3);
            ApplicationBar.Buttons.Clear();

            ApplicationBarIconButton botonIzquierda = new ApplicationBarIconButton() { IsEnabled = true, Text = "foto", IconUri = new Uri("/Assets/AppBar/feature.camera.png", UriKind.Relative) };
            botonIzquierda.Click += (s, a) =>
            {
                if (MessageBox.Show("Antes de seleccionar una imagen de la biblioteca del telefono, necesita iniciar la aplicacion de fotos en el celular", "INSTRUCCION", MessageBoxButton.OK) == MessageBoxResult.OK)
                {
                    brushesGrid.ChangeImage();
                }
               
            };
            ApplicationBar.Buttons.Add(botonIzquierda);
            checkMediaElement();
        }

        private void VideoBrush_Click(object sender, EventArgs e)
        {
            brushesGrid.changeBackground(4);
            ApplicationBar.Buttons.Clear();
            bool isPlay = true;
            var brush = new VideoBrush();
            brush.SetSource(bang);
            brushesGrid.Background = brush;
            bang.Stop();
            bang.Play();
            brushesGrid.Tap += (se, i) =>
            {
                if (isPlay)
                {
                    bang.Pause();
                    isPlay = false;
                }
                else
                {
                    bang.Play();
                    isPlay = true;
                }
            };
           
            ApplicationBarIconButton botonMute = new ApplicationBarIconButton() { IsEnabled = true, Text = "mute", IconUri = new Uri("/Assets/AppBar/Volume-Speaker.png", UriKind.Relative) };
            botonMute.Click += (s, a) =>
            {
                bang.IsMuted = !bang.IsMuted;
                botonMute.IconUri = new Uri(bang.IsMuted ? "/Assets/AppBar/Volume-Mute.png" : "/Assets/AppBar/Volume-Speaker.png", UriKind.Relative);
            };
            ApplicationBar.Buttons.Add(botonMute);

            ApplicationBarIconButton botonPlay = new ApplicationBarIconButton() { IsEnabled = true, Text = "play", IconUri = new Uri("/Assets/AppBar/Volume-Speaker.png", UriKind.Relative) };
            botonPlay.Click += (s, a) =>
            {
                if (bang.CurrentState == MediaElementState.Paused)
                {
                    bang.Play();
                    botonPlay.IconUri = new Uri("/Assets/AppBar/transport.pause.png", UriKind.Relative);
                }
                else
                {
                    bang.Pause();
                    botonPlay.IconUri = new Uri("/Assets/AppBar/transport.play.png", UriKind.Relative);
                }
                
            };
            ApplicationBar.Buttons.Add(botonPlay);
            bang.CurrentStateChanged += (sende, arg) =>
            {
                botonPlay.IconUri = new Uri(bang.CurrentState == MediaElementState.Paused ? "/Assets/AppBar/transport.play.png" : "/Assets/AppBar/transport.pause.png", UriKind.Relative);
            };
        }
        private void checkMediaElement()
        {
            if (bang.CurrentState == MediaElementState.Playing)
            {
                bang.Stop();
            }
        }
        private void SolidColorBrush_Click(object sender, EventArgs e)
        { 
            brushesGrid.changeBackground(5);

            ApplicationBar.Buttons.Clear();
            ApplicationBarIconButton botonIzquierda = new ApplicationBarIconButton() { IsEnabled = true, Text = "green", IconUri = new Uri("/Assets/AppBar/check.png", UriKind.Relative) };
            botonIzquierda.Click += (s, a) =>
            {
                brushesGrid.ChangeSolidColorBrush(Colors.Green);
            };
            ApplicationBar.Buttons.Add(botonIzquierda);
            ApplicationBarIconButton botonDerecha = new ApplicationBarIconButton() { IsEnabled = true, Text = "magenta", IconUri = new Uri("/Assets/AppBar/like.png", UriKind.Relative) };
            botonDerecha.Click += (s, a) =>
            {
                brushesGrid.ChangeSolidColorBrush(Colors.Magenta);
            };
            ApplicationBar.Buttons.Add(botonDerecha);
            checkMediaElement();
        }
    }
}