using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace ProyectoFinal
{
    public abstract class Terminal
    {
        private string destino;
        private string codigo;


        public string Destino
        {
            get { return destino; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El nombre no puede estar vacío");
                }

                else if (value.Trim().Length > 50)
                {
                    throw new Exception("El nombre no puede exceder los 50 caracteres");
                }

                else destino = value;
            }
        }
        public string Codigo
        {
            get { return codigo; }
            set
            {
                if (!Regex.IsMatch(value, "^[a-zA-Z]{6}$"))
                {
                    throw new Exception("El codigo debe tener 6 letras vuelva a ingresarlo");
                }
                else codigo = value;

            }

        }

        public Terminal(string dDestino, string cCodigo)
        {
            Destino = dDestino;
            Codigo = cCodigo;
        }

        public override string ToString()
        {
            return ("Destino " + Destino + "\nCodigo " + Codigo);
        }
    }

}