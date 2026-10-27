namespace dominio
{
    public class Direccion
    {
        public int IdDireccion { get; set; }
        public int IdCliente { get; set; }
        public string Calle { get; set; } = string.Empty;
        public string Numero { get; set; } = string.Empty;
        public string CodigoPostal { get; set; } = string.Empty;
        public string Localidad { get; set; } = string.Empty;
        public string Provincia { get; set; } = string.Empty;
        public string Observacion { get; set; } = string.Empty;
    }
}
