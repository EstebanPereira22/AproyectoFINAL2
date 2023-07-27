using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace ProyectoFinal
{
    public class Compania
    {
        private string nombre;
        private string direccion;
        private int telefono;



        public string Nombre
        {
            get { return nombre; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("La casilla nombre no puede estar vacia");
                }

                else if (value.Trim().Length > 50)
                {
                    throw new Exception("El nombre no puede exceder los 50 caracteres");
                }

                else nombre = value;
            }
        }

        public string Direccion
        {
            get { return direccion; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("La direccion no puede estar vacía");
                }

                else if (value.Trim().Length > 100)
                {
                    throw new Exception("El nombre no puede exceder los 100 caracteres");
                }

                else direccion = value;
            }
        }

        public int Telefono
        {
            get { return telefono; }
            set
            {
                if (value < 089999999)
                {
                    throw new Exception("El formato del numero es incorrecto");
                }

                else if (value > 099999999)
                {
                    throw new Exception("El formato del numero es incorrecto");
                }

                else telefono = value;
            }
        }

        public Compania(string pNombre, string pDireccion, int pTelefono)
        {
            Nombre = pNombre;
            Direccion = pDireccion;
            Telefono = pTelefono;
        }

        public override string ToString()
        {
            return ("Nombre " + Nombre + "\nDireccion: " + Direccion + "\nTelefono: " + Telefono);
        }



    }
}
