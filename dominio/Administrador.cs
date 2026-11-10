using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public  class Administrador : Persona
    {
        public Administrador() {
            this.IdRol = 1;
            this.Estado = 1;
        }

        public String Cuil { get; set; }

        override public string ToString()
        {
            return Cuil;        }
    }
}
