using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
    public class Venta
    {
        public int IdVenta_V { get; set; }
        public int IdCliente_V { get; set; }
        public DateTime FechaVenta_V { get; set; }
        public decimal TotalPago_V { get; set; }
        public int TipoPago_V { get; set; }
        
        public bool Estado_V { get; set; }

        public int EstadoPedido_v {  get; set; }


    }
}
