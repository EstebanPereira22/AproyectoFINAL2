using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinal
{
    public class TerminalInternacional : Terminal
    {
        private string pais;

        public string Pais
        {
            get { return pais; }
            set
            {
                if (value.Trim() == "")
                {
                    throw new Exception("El nombre del pais no puede estar vacío");
                }

                else if (value.Trim().Length > 50)
                {
                    throw new Exception("El nombre no puede exceder los 50 caracteres");
                }

                else pais = value;
            }
        }



        public TerminalInternacional(string dDestino, string cCodigo, string pPais)
            : base(dDestino, cCodigo)
        {

            Pais = pPais;
        }

        public override string ToString()
        {
            return base.ToString() + "\nPais: " + Pais;

        }

    }
}
