using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinal
{
    public class Viajes
    {
        private static int numero = 1;
        private int numeroInterno;
        private DateTime fechayhorasalida;
        private DateTime fechayhorallegada;
        private int precio;
        private int anden;
        private int pasajero;
        //atributos de asociacion
        private Compania viajeCompania;
        private Terminal viajeTerminal;



        public DateTime FechayHoraSalida
        {
            get { return fechayhorasalida; }
            set
            {
                if (value < DateTime.Now)
                {
                    throw new Exception("La fecha no puede ser anterior al dia de hoy");
                }
                else
                {
                    fechayhorasalida = value;
                }
            }

        }
        public DateTime FechayHoraLlegada
        {
            get { return fechayhorallegada; }
            set
            {
                if (value <= fechayhorasalida)
                {
                    throw new Exception("La fecha no puede ser anterior al dia y hora que salis");
                }
                else
                {
                    fechayhorallegada = value;
                }
            }

        }

        public int Precio
        {
            get { return precio; }
            set
            {
                if (value <= 0)
                {
                    throw new Exception("El precio no puede ser menor a 0");
                }

                else if (value >= 15000)
                {
                    throw new Exception("El precio no puede ser superior a 15000");
                }

                else
                {
                    precio = value;
                }
            }
        }

        public int Anden
        {
            get { return anden; }

            set
            {
                if ((value < 0) || (value > 35))
                {
                    throw new Exception("Ingrese un anden correcto, tenemos desde el anden 0 al 35");
                }

                else
                {
                    anden = value;
                }
            }
        }

        public int Pasajero
        {
            get { return pasajero; }

            set
            {
                if ((value < 0) || (value > 50))
                {
                    throw new Exception("Cantidad de pasajeros incorrecta, un coche no puede salir sin pasajeros y recuerde que su capacidad maxima es de 50 pasajeros");
                }

                else
                {
                    pasajero = value;
                }
            }
        }


        public int NumeroInterno
        {
            get { return numeroInterno; }
        }

        public Compania ViajeCompania
        {
            get { return viajeCompania; }

            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar el nombre de la compania");

                viajeCompania = value;
            }
        }

        public Terminal ViajeTerminal
        {
            get { return viajeTerminal; }

            set
            {
                if (value == null)
                    throw new Exception("Debe ingresar el codigo de la terminal");

                viajeTerminal = value;
            }
        }

        public Viajes(DateTime fFechayhorasalida, DateTime fFechayhorallegada, int pPrecio, int aAnden, int pPasajero, Compania compania, Terminal terminal)
        {
            FechayHoraLlegada = fFechayhorallegada;
            FechayHoraSalida = fFechayhorasalida;
            Precio = pPrecio;
            Pasajero = pPasajero;
            Anden = aAnden;
            numeroInterno = numero;
            numero++;
            ViajeTerminal = terminal;
            viajeCompania = compania;

        }

        public override string ToString()
        {
            return ("Fecha y hora de salida: " + FechayHoraSalida + "\nAnden:  " + Anden + "\nPrecio: " + Precio + "\nCantidad de Pasajeros: " + Pasajero +
                "\nFecha y hora de llegada: " + FechayHoraLlegada + "\nCompania:  " + viajeCompania.Nombre + "\nDestino: " + viajeTerminal.Destino);
        }


    }
}


