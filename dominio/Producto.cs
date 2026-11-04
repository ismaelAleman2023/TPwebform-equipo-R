using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Producto
    {

        public int IdProducto { get; set; }
        public string CodigoProducto { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public int Marca { get; set; }
        public int Categoria { get; set; }
        public int Estado { get; set; }
        public decimal Precio { get; set; }
        public bool OnDemand { get; set; } 

        public List<Imagen> ListaImagen { get; set; } = new List<Imagen>();


    }
}
