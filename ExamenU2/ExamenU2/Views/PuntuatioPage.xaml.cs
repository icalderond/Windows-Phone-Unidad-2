using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace ExamenU2.Views
{
    public partial class PuntuatioPage : PhoneApplicationPage
    {
        public PuntuatioPage()
        {
            InitializeComponent();
        }
        protected override void OnNavigatedTo(System.Windows.Navigation.NavigationEventArgs e)
        {
            string value = string.Empty;
            if (NavigationContext.QueryString.TryGetValue("value", out value))
            {
                MessageBox.Show((value=="tiro"?"Se acabo la cantidad de tiros disponibles":"El dia se ha acabado"),"PUNTUACION",MessageBoxButton.OK);
            }
            base.OnNavigatedTo(e);
        }
    }
}