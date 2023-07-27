using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProyectoFinal
{
    public class TerminalNacional : Terminal
    {
        private bool taxis;


        public bool Taxis
        {
            get { return taxis; }
            set { taxis = value; }
        }


        public TerminalNacional(string dDestino, string cCodigo, bool tTaxis)
            : base(dDestino, cCodigo)
        {

            Taxis = tTaxis;
        }

        public override string ToString()
        {
            return base.ToString() + "\nTaxis: " + (Taxis ? " SI" : "NO");

        }


    }
}


