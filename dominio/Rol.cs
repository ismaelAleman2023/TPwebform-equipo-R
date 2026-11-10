namespace dominio
{
    public class Rol
    {
        public int IdRol { get; set; }
        public string Descripcion { get; set; }
        public int Estado { get; set; }

        public Rol()
        {
            Estado = 1;
        }

        public override string ToString()
        {
            return Descripcion;
        }
    }
}
