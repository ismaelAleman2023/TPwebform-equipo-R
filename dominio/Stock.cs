using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Stock
    {

        public int IdStock { get; set; }
        public int IdProducto_stk { get; set; }

        public int Cantidad { get; set; }

        public int Estado { get; set; }

        public Stock() { 
        Estado = 1;

        
        }








    }
}
