using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace Proyecto4_WP.Logica
{
    public class FanControl:NotificationEnableObject
    {
        public FanControl()
        {
            TimerOscilation = new DispatcherTimer();
            TimerOscilation.Interval = new TimeSpan(0, 0, 0, 0, 10);
            TimerOscilation.Tick += TimerOscilation_Tick;
        }
        int incrementoOscilador = 1;
        void TimerOscilation_Tick(object sender, EventArgs e)
        {
            
            if (OscilationValue == 45)
            {
                incrementoOscilador = -1;
            }
            else if(OscilationValue==-45)
            {
                incrementoOscilador = 1;
            }
            OscilationValue += incrementoOscilador;
        }
        private DispatcherTimer timerOscilation;

        public DispatcherTimer TimerOscilation
        {
            get { return timerOscilation; }
            set { timerOscilation = value; }
        }
      
        private bool estaOscilando;

        public bool EstaOscilando
        {
            get { return estaOscilando; }
            set { estaOscilando = value;
            if (estaOscilando){TimerOscilation.Start();}
            else { TimerOscilation.Stop(); }
            OnPropertyChanged();
            }
        }

        private double oscilationValue;

        public double OscilationValue
        {
            get { return oscilationValue; }
            set { oscilationValue = value;
            OnPropertyChanged();
            }
        }
        private int orientationValue;

        public int OrientationValue
        {
            get { return orientationValue; }
            set { orientationValue = value;
            OnPropertyChanged();
            }
        }


    }
}
