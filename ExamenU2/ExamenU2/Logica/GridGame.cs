using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ExamenU2.Logica
{
    public class GridGame:NotificationEnableObject
    {
        private int numeroTiros;

        public int NumeroTiros
        {
            get { return numeroTiros; }
            set { numeroTiros = value;
            OnPropertyChanged();
            }
        }
        private string operacionAritmetica;

        public string OperacionAritmetica
        {
            get { return operacionAritmetica; }
            set { operacionAritmetica = value;
            OnPropertyChanged();
            }
        }

        private int numeroUno;

        public int NumeroUno
        {
            get { return numeroUno; }
            set { numeroUno = value;
            OnPropertyChanged();
            }
        }
        private int numeroDos;

        public int NumeroDos
        {
            get { return numeroDos; }
            set { numeroDos = value;
            OnPropertyChanged();
            }
        }
        private int numeroRespuesta;

        public int NumeroRespuesta
        {
            get { return numeroRespuesta; }
            set { numeroRespuesta = value;
            OnPropertyChanged();
            }
        }

        private ObservableCollection<int> listaNumerosAleatorios;

        public ObservableCollection<int> ListaNumerosAleatorios
        {
            get {
                if (listaNumerosAleatorios == null)
                {
                    listaNumerosAleatorios = new ObservableCollection<int>();
                    if (DesignerProperties.IsInDesignTool)
                    {
                        for (int i = 0; i < 12; i++)
                        {
                            ListaNumerosAleatorios.Add(r.Next(40,100));
                        }
                    }
                }
                return listaNumerosAleatorios; }
            set { listaNumerosAleatorios = value;
            OnPropertyChanged();
            }
        }

        public void IniciarJuego()
        {
            Puntaje = new Puntuacion(NumeroTiros);
            GenerarPartida();
        }
        private Puntuacion puntaje;

        public Puntuacion Puntaje
        {
            get { return puntaje; }
            set { puntaje = value;
            OnPropertyChanged();
            }
        }

        Random r = new Random();
        private void GenerarPartida()
        {
            NumeroUno = r.Next(1, 6);
            NumeroDos = r.Next(1, 6);

            switch (operacionAritmetica)
            {
                case "Suma"://SUMA
                    NumeroRespuesta = numeroUno + numeroDos;
                    break;
                case "Resta"://RESTA
                    NumeroRespuesta = numeroUno - numeroDos;
                    break;
                case "Multiplicacion"://MULTIPLICACION
                    NumeroRespuesta = numeroUno * numeroDos;
                    break;
            }
            int rangoI = numeroRespuesta - 10;
            int rangoF = numeroRespuesta + 10;

            int posicion = r.Next(0, 11);

            ListaNumerosAleatorios.Clear();
            for (int i = 0; i < 12; i++)
            {
                ListaNumerosAleatorios.Add(posicion != i ? r.Next(rangoI, rangoF) : NumeroRespuesta);
            }
        }
        private int getCurrentSelcted;

        public int GetCurrentSelected
        {
            get { return getCurrentSelcted; }
            set { getCurrentSelcted = value;
            OnPropertyChanged();
            ActiveDado = true;
            Puntaje.addPuntuacion(getCurrentSelcted == numeroRespuesta);
            GenerarPartida();            
            }
        }

        private string mensaje;

        public string Mensaje
        {
            get { return mensaje; }
            set { mensaje = value;
            OnPropertyChanged();
            }
        }

        private bool activeDado;

        public bool ActiveDado
        {
            get { return activeDado; }
            set { activeDado = value;
            OnPropertyChanged();
            }
        }
        


    }
}
