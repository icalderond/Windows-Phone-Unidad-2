using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExamenU2.Logica
{
    public class Tiro
    {
        private double milisegundo;

        public double Milisegundo
        {
            get { return milisegundo; }
            set { milisegundo = value; }
        }
        private TimeSpan tiempoReal;

        public TimeSpan TiempoReal
        {
            get { return tiempoReal; }
            set { tiempoReal = value; }
        }

        private bool esCorrecto;

        public bool EsCorrecto
        {
            get { return esCorrecto; }
            set { esCorrecto = value; }
        }

    }
}
