using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dominio
{
   public static class Ayudante
    {

      public static bool ValidarNoNumero(string vali) {

            if (vali.Any(char.IsDigit)) { 
            
                return true;//contiene numero

            
            }

            return false;//no contiene numero
        
        }









    }
}
