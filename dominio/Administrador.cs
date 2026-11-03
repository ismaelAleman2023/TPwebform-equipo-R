using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public  class Administrador : Persona
    {
        public Administrador() { }

        public String Cuil { get; set; }

        override public string ToString()
        {
            return Cuil;        }
    }
}
