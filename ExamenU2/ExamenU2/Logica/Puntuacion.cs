using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace ExamenU2.Logica
{
    public class Puntuacion
    {
        public Puntuacion(int numeroTiros)
        {
            DispatcherTimer dispatcher = new DispatcherTimer();
            dispatcher.Interval = new TimeSpan(0, 0, 0, 0, 1);
            dispatcher.Start();
            EstaEnJuego = true;
            dispatcher.Tick += (s, a) =>
            {
                if (!EstaEnJuego)
                {
                    dispatcher.Stop();
                }
                {
                    ControlJuego += 1;
                    EstaEnJuego = !(ControlJuego >= 160000.0);
                }
                controlMilisegundo += 1; ;
            };
            this.NumTiros = numeroTiros;

        }
        private double controlMilisegundo { get; set; }
        private double controlJuego;

        public double ControlJuego
        {
            get { return controlJuego; }
            set { controlJuego = value; }

        }
        
        private bool estaEnJuego;

        public bool EstaEnJuego
        {
            get { return estaEnJuego; }
            set { estaEnJuego = value; }
        }
        private int numTiros;

        public int NumTiros
        {
            get { return numTiros; }
            set { numTiros = value; }
        }

        private ObservableCollection<Tiro> listaTiros;

        public ObservableCollection<Tiro> ListaTiros
        {
            get {
                if (listaTiros == null)
                {
                    listaTiros = new ObservableCollection<Tiro>();
                    if (DesignerProperties.IsInDesignTool)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            ListaTiros.Add(new Tiro() {EsCorrecto=true,Milisegundo=12761386287,TiempoReal=new TimeSpan(0,0,0,0,18798)});
                        }
                    }
                }
                return listaTiros; }
            set { listaTiros = value; }
        }

        public void addPuntuacion(bool isCorrect)
        {
            ListaTiros.Add(new Tiro() {Milisegundo= controlMilisegundo,EsCorrecto=isCorrect,TiempoReal=getTiempoReal(controlMilisegundo)});
            int pReal = 0;
            double pEscala = 0;
            foreach (var item in ListaTiros)
            {
                pReal += Convert.ToInt32(item.TiempoReal.TotalMilliseconds);
                pEscala += item.Milisegundo;
            }
            PromedioEscala = pEscala / ListaTiros.Count;
            PromedioReal = new TimeSpan(0,0,0,0,(pReal / ListaTiros.Count));
            //EstaEnJuego = (ListaTiros.Count< NumTiros);
            if (ListaTiros.Count >= NumTiros)
            {
                EstaEnJuego = (ListaTiros.Count < NumTiros);
            }
            controlMilisegundo = 0;
        }

        private TimeSpan getTiempoReal(double controlMilisegundo)
        {
            const double pow = (3600000.0 * 24.0) / 160000.0;
            var milliseconds = pow * controlMilisegundo;
            var date = TimeSpan.FromMilliseconds(milliseconds);
            return date;
        }
          

        private TimeSpan promedioReal;

        public TimeSpan PromedioReal
        {
            get { return promedioReal; }
            set { promedioReal = value; }
        }

        private double promedioEscala;

        public double PromedioEscala
        {
            get { return promedioEscala; }
            set { promedioEscala = value; }
        }
        
        

       
    }
}
