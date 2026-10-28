using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Categoria
    {

         public int IdCategoria{ get; set; }

        public string Descripcion { get; set; }

        public int Estado { get; set; }


        public Categoria() {

            Estado = 1;

        
        }
        public override string ToString()
        {
            return Descripcion;
        }
    }
}
