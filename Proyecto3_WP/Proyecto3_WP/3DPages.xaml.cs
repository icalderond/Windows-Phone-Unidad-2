using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace Proyecto3_WP
{
    public partial class _3DPages : PhoneApplicationPage
    {
        Rotacion rota;
        public _3DPages()
        {
            InitializeComponent();
            rota = Application.Current.Resources["rota"] as Rotacion;
        }

        private void ApplicationBarMenuItem_Projeccion(object sender, EventArgs e)
        {
            
        }

        private void barSetX_Click(object sender, EventArgs e)
        {
            rota.Control = 1;
        }

        private void barSetY_Click(object sender, EventArgs e)
        {
            rota.Control = 2;
        }

        private void barSetZ_Click(object sender, EventArgs e)
        {
            rota.Control = 3;
        }
    }
}