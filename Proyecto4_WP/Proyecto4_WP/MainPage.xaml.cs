using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Proyecto4_WP.Resources;
using System.Windows.Media.Animation;
using Proyecto4_WP.Logica;

namespace Proyecto4_WP
{
    public partial class MainPage : PhoneApplicationPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, EventArgs e)
        {
            EncenderStoryBoarding(1);
        }
        private void Button_Click_2(object sender, EventArgs e)
        {
            EncenderStoryBoarding(2);
        }

        private void Button_Click_3(object sender, EventArgs e)
        {
            EncenderStoryBoarding(3);
        }
        private void EncenderStoryBoarding(int p)
        {
            ApagarSB();

            switch (p)
            {
                case 1:
                    StoryBoard_Giro1.Begin();
                    break;
                case 2:
                    StoryBoard_Giro2.Begin();
                    break;
                case 3:
                    StoryBoard_Giro3.Begin();
                    break;
            }

        }

        private void ApagarSB()
        {
            if (StoryBoard_Giro1.GetCurrentState() == ClockState.Active)
            {
                StoryBoard_Giro1.Stop();
            }
            else if (StoryBoard_Giro2.GetCurrentState() == ClockState.Active)
            {
                StoryBoard_Giro2.Stop();
            }
            else if (StoryBoard_Giro3.GetCurrentState() == ClockState.Active)
            {
                StoryBoard_Giro3.Stop();
            }
        }

        private void Button_Click(object sender, EventArgs e)
        {
            ApagarSB();
        }
        FanControl fan ;//= new FanControl();
        private void ApplicationBarMenuItem_Click(object sender, EventArgs e)
        {
            fan = Application.Current.Resources["fanControl"] as FanControl;
            fan.EstaOscilando = !fan.EstaOscilando;
        }
    }
}