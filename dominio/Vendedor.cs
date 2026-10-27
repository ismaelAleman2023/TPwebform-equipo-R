using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace dominio
{
    public class Vendedor : Persona
    {
        public Vendedor()
        {
            this.IdRol =2;
            this.Estado = 1;


        }
        
       
        public string Legajo { get; set; }


    }
}
