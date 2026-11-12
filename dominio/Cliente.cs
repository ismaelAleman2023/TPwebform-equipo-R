using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace dominio
{
    public class Cliente : Persona
    {
        public Cliente() {
            
            this.IdRol = 2;
            this.Estado = 1;
            CorreoOk = false;
        }

        public bool CorreoOk { get; set; }
        public string FotoPerfil { get; set; }
        public List<Direccion> direccion {get;} = new List<Direccion>();

    }
}
