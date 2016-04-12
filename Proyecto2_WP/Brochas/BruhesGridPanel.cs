using Microsoft.Phone.Tasks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace Brochas
{
    public class BruhesGridPanel:Grid
    {
        public BruhesGridPanel()
        {
            this.Background = new SolidColorBrush(Colors.Green);
            this.Width = 480;
            this.Height = 768;
        }

        ImageBrush berriesBrush = new ImageBrush();
        VideoBrush videoBrocha = new VideoBrush();
        RadialGradientBrush radialGradient = new RadialGradientBrush();
        LinearGradientBrush myLinearGradientBrush = new LinearGradientBrush();
        SolidColorBrush solidColor = new SolidColorBrush();
        public void changeBackground(int type){
            switch (type)
            {
                case 1:
                    ChangeToLinerBrush();
                    break;
                case 2:
                    ChangeToRadiarBrush();
                    break;
                case 3:
                    ChangeToImageBrush();
                    break;
                case 4:
                    ChangeToVideoBrush();
                    break;
                case 5:
                    ChangeToSolidColorBrush();
                    break;
            }
        }

        private void ChangeToSolidColorBrush()
        {
            this.Background = new SolidColorBrush(Colors.Purple);
            
        }
        Random r = new Random();
        public void ChangeSolidColorBrush(Color _color)
        {
            this.Background=new SolidColorBrush(_color);
        }
        
        private void ChangeToVideoBrush()
        {
            this.Background = videoBrocha;
        }

        private void ChangeToImageBrush()
        {
            berriesBrush.ImageSource =
                new BitmapImage(
                    new Uri("images/face1.jpg", UriKind.Relative)
                );
            berriesBrush.Stretch = Stretch.UniformToFill;

            // Use the brush to paint the button's background.
            this.Background = berriesBrush;
        }
        public void ChangeImage()
        {
            var photoChooserTask = new PhotoChooserTask();
            photoChooserTask.Completed += new EventHandler<PhotoResult>((sender, e) => 
            {
                if (e.TaskResult == TaskResult.OK)
                {
                    var Bitma = new BitmapImage();
                    Bitma.SetSource(e.ChosenPhoto);
                    berriesBrush.ImageSource = Bitma;
                }
            });
            photoChooserTask.Show();
        }
        private void ChangeToRadiarBrush()
        {
            // Set the GradientOrigin to the center of the area being painted.
            radialGradient.GradientOrigin = new Point(0.5, 0.5);

            // Set the gradient center to the center of the area being painted.
            radialGradient.Center = new Point(0.5, 0.5);

            // Set the radius of the gradient circle so that it extends to 
            // the edges of the area being painted.
            radialGradient.RadiusX = 0.5;
            radialGradient.RadiusY = 0.5;

            // Create four gradient stops.
            radialGradient.GradientStops.Add(new GradientStop() {Color=Colors.Yellow,Offset=0.0 });//Colors.Yellow, 0.0));
            radialGradient.GradientStops.Add(new GradientStop() { Color = Colors.Red, Offset = 0.25 });
            radialGradient.GradientStops.Add(new GradientStop() { Color = Colors.Blue, Offset = 0.75 });
            radialGradient.GradientStops.Add(new GradientStop() { Color = Colors.Purple, Offset = 1.0 });

            this.Background = radialGradient;
            bool draw = false;
            this.MouseLeftButtonDown += (s, a) =>
            {
                draw = true;
            };
            this.MouseMove += (s, a) =>
            {
                if (draw)
                {
                    var grid = s as Grid;


                    //Convertir la posicion en numero validos
                    var pointX = a.GetPosition(grid).X;
                    var pointY = a.GetPosition(grid).Y;

                    double ancho = this.Width;
                    double alto = this.Height;

                    //CONVERSION
                    var positionRadiarX = (1 / ancho) * pointX;
                    var positionRadiarY = (1 / alto) * pointY;
                    radialGradient.GradientOrigin = new Point(positionRadiarX, positionRadiarY);
                }
            };
            this.MouseLeftButtonUp += (s, a) =>
            {
                draw = false;
            };
            
        }

        private void ChangeToLinerBrush()
        {
            myLinearGradientBrush.StartPoint = new Point(0, 0);
            myLinearGradientBrush.EndPoint = new Point(1, 1);

            myLinearGradientBrush.GradientStops.Add(
                new GradientStop() { Color = Colors.Yellow, Offset = 0.0 });
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop() { Color = Colors.Red, Offset = 0.25 });
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop() { Color = Colors.Blue,Offset= 0.75 });
            myLinearGradientBrush.GradientStops.Add(
                new GradientStop(){Color=Colors.Green,Offset= 1.0});

            // Use the brush to paint the rectangle.
            this.Background = myLinearGradientBrush;
            this.MouseLeftButtonDown += (s, a) =>
            {
                var grid = s as Grid;
                var pointX = a.GetPosition(grid).X;
                var pointY = a.GetPosition(grid).Y;
                double ancho = this.Width;
                double alto = this.Height;

                //CONVERSION
                var positionRadiarX = (1 / ancho) * pointX;
                var positionRadiarY = (1 / alto) * pointY;

                myLinearGradientBrush.StartPoint = new Point(positionRadiarX, positionRadiarY);
                
            };
            this.MouseLeftButtonUp += (s, a) =>
            {
                var grid = s as Grid;
                var pointX = a.GetPosition(grid).X;
                var pointY = a.GetPosition(grid).Y;
                double ancho = this.Width;
                double alto = this.Height;

                //CONVERSION
                var positionRadiarX = (1 / ancho) * pointX;
                var positionRadiarY = (1 / alto) * pointY;

                myLinearGradientBrush.EndPoint = new Point(positionRadiarX, positionRadiarY);
            };
        }

        public void setMediaElement(MediaElement bang)
        {
            videoBrocha.SetSource(bang);
        }
    }
}
