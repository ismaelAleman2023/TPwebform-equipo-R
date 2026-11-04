namespace dominio
{
    public class TipoPago
    {
        public int IdTipoPago { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public TipoPago()
        {
            Estado = 1;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
