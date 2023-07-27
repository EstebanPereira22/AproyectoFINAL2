using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinal
{
    public class Logica
    {
        private List<Compania> colCompania;
        private List<Viajes> colViajes;
        private List<Terminal> colTerminal;

        public Logica()
        {
            colCompania = new List<Compania>();
            colViajes = new List<Viajes>();
            colTerminal = new List<Terminal>(); // va a guardar terminal o derivados de terminal

        }

        #region Mantenimiento Companias HECHO
        public Compania BuscarCompania(string aNom)
        {
            foreach (Compania compania in colCompania)
            {
                if (compania.Nombre == aNom)
                {
                    return compania;
                }
            }

            return null;
        }


        public bool AgregarCompania(Compania aComp)
        {
            if (BuscarCompania(aComp.Nombre) == null)
            {
                colCompania.Add(aComp);
                return true;
            }
            return false;
        }

        private bool EstaEnUsoCompania(Compania aComp)
        {
            foreach (Viajes viaje in colViajes)
            {
                if (viaje.ViajeCompania.Nombre == aComp.Nombre)
                    return true;
            }
            return false;
        }

        public bool EliminarCompania(Compania aComp)
        {
            if (EstaEnUsoCompania(aComp))
                throw new Exception("La Compania tiene un viaje asociado. No se puede eliminar");

            for (int indice = 0; indice < colCompania.Count; indice++)
            {
                if (colCompania[indice].Nombre == aComp.Nombre)
                {
                    colCompania.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        #endregion
        #region Mantenimiento Terminal Nacional e Internacional HECHO
        public Terminal BuscarTerminal(string aTerm)
        {
            foreach (Terminal terminal in colTerminal)
            {
                if (terminal.Codigo == aTerm)
                {
                    return terminal;
                }
            }
            return null;
        }


        public bool AgregarTerminal(Terminal aTerm)
        {
            if (BuscarTerminal(aTerm.Codigo) == null)
            {
                colTerminal.Add(aTerm);
                return true;
            }
            return false;
        }

        public bool EstaEnUsoTerminal(Terminal aTerm)
        {
            foreach (Viajes viaje in colViajes)
            {
                if (viaje.ViajeTerminal.Codigo == aTerm.Codigo)
                    return true;
            }
            return false;
        }

        public bool EliminarTerminal(Terminal aTerm)
        {
            if (EstaEnUsoTerminal(aTerm))
                throw new Exception("El codigo esta en uso. No se puede eliminar");

            for (int indice = 0; indice < colTerminal.Count; indice++)
            {
                if (colTerminal[indice].Codigo == aTerm.Codigo)
                {
                    colTerminal.RemoveAt(indice);
                    return true;
                }
            }
            return false;
        }

        #endregion
        #region Agregar Viaje HECHO
        public bool AgregarViaje(Viajes viaje)
        {
            colViajes.Add(viaje);
            return true;
        }

        #endregion
        #region Listado de todas las companias HECHO
        public List<Compania> Listado()
        {
            return colCompania;
        }

        #endregion
        #region Listado terminales

        public List<TerminalNacional> ListaNacional()
        {
            List<TerminalNacional> coleccion = new List<TerminalNacional>();
            foreach (Terminal terminalNac in colTerminal)
            {
                if (terminalNac is TerminalNacional)
                {
                    coleccion.Add((TerminalNacional)terminalNac);
                }

            }

            return coleccion;
        }

        public List<TerminalInternacional> ListaInternacional()
        {
            List<TerminalInternacional> coleccion = new List<TerminalInternacional>();
            foreach (Terminal terminalInt in colTerminal)
            {
                if (terminalInt is TerminalInternacional)
                {
                    coleccion.Add((TerminalInternacional)terminalInt);
                }
            }

            return coleccion;
        }

        #endregion
        #region Listado Viaje por fecha HECHO
        public List<Viajes> ListarPorfecha(DateTime fFecha1, DateTime fFecha2)
        {
            List<Viajes> coleccion = new List<Viajes>();

            foreach (Viajes viaje in colViajes)
            {
                if (viaje.FechayHoraSalida >= fFecha1 && viaje.FechayHoraSalida <= fFecha2)
                {
                    coleccion.Add(viaje);
                }
            }
            return coleccion;
        }

        #endregion
        #region Listado Viaje Terminal Mes Anio HECHO
        public List<Viajes> ListarPorMesyAnio(Terminal tTerminal, int fFechaMes, int fFechaAnio)
        {
            List<Viajes> coleccion = new List<Viajes>();

            foreach (Viajes viaje in colViajes)
            {
                if (viaje.ViajeTerminal == tTerminal)
                {
                    if (viaje.FechayHoraSalida.Month == fFechaMes)
                    {
                        if (viaje.FechayHoraSalida.Year == fFechaAnio)
                        {
                            coleccion.Add(viaje);
                        }
                    }

                }
            }
            return coleccion;
        }

        #endregion
        #region Contador de viajes
        public int ContarViajes(Terminal terminal) 
        {
            int contador = 0;
            foreach (Viajes viaje in colViajes) 
            {
                if (viaje.ViajeTerminal.Codigo == terminal.Codigo)
                    contador++;
            }
            return contador;
        }
        #endregion
        #region ListadoViajesTERMA
        public List<Viajes> ListadoViajesTerminalMesAño(Terminal terminal, int mes, int año)
        {
            List<Viajes> coleccion = new List<Viajes>();

            foreach (Viajes viaje in colViajes)
            {
                if (viaje.FechayHoraSalida.Month == mes && viaje.FechayHoraSalida.Year == año && viaje.ViajeTerminal == terminal)
                {
                    coleccion.Add(viaje);
                }
            }

            return coleccion;
        }
        #endregion


    }
}
