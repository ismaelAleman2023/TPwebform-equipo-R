using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Estado
    {
        public Estado() { }

        public int IdEstado { get; set; }
        public string Descripcion_estado { get; set; } = string.Empty;

        override public string ToString()
        {
            return Descripcion_estado;
        }


    }
}
