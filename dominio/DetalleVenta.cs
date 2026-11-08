namespace dominio
{
    public class DetalleVenta
    {
        public int IdDetalleVenta { get; set; }
        public int IdVenta_Detalle { get; set; }
        public int IdProducto { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
        public int Cantidad { get; set; }
    }
}
