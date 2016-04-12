using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Proyecto3_WP
{
    public class Rotacion:NotificationEnableObject
    {
        DispatcherTimer dispatcher = new DispatcherTimer();
        public Rotacion()
        {
            string i = "";
            String o = "";
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 20);
            dispatcher.Start();
            dispatcher.Tick += dispatcher_Tick;
        }

        void dispatcher_Tick(object sender, EventArgs e)
        {
            int countIncremento = 1;
            switch (Control)
            {
                case 1:
                    if ((AxisX + countIncremento) == 360)
                    {
                        AxisX = -countIncremento;
                    }
                    AxisX += countIncremento;
                    break;
                case 2:
                    if ((AxisY + countIncremento) == 360)
                    {
                        AxisY = -countIncremento;
                    }
                    AxisY += countIncremento;
                    break;
                case 3:
                    if ((AxisZ + countIncremento) == 360)
                    {
                        AxisZ = -countIncremento;
                    }
                    AxisZ += countIncremento;
                    break;
            }
            
        }
        private int control;

        public int Control
        {
            get { return control; }
            set { control = value;
            OnPropertyChanged();
            }
        }


        private int axisX;

        public int AxisX
        {
            get { return axisX; }
            set { axisX = value;
            OnPropertyChanged();
            }
        }
        private int axisY;

        public int AxisY
        {
            get { return axisY; }
            set { axisY = value;
            OnPropertyChanged();
            }
        }

        private int axisZ;

        public int AxisZ
        {
            get { return axisZ; }
            set { axisZ = value;
            OnPropertyChanged();
            }
        }

        
    }
}
