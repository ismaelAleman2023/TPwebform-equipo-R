using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class MarcaNegocio
    {

        public List<Marca> ListarMarca()
        {

            AccesoDatos datos = new AccesoDatos();
            List<Marca> ListaM = new List<Marca>();

            try
            {
                datos.consultaSql("select id_m ,descripcion_m,estado_m from marcas");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Marca Marca = new Marca();
                    Marca.IdMarca = (int)datos.Lector["id_m"];
                    Marca.Descripcion = (string)datos.Lector["descripcion_m"];
                    Marca.Estado = (int)datos.Lector["estado_m"];

                    ListaM.Add(Marca);
                }

                return ListaM;


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {

                datos.cerrarConexion();
            }
        }


        public void AgregarMarca(Marca NuevaMarca)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into marcas(descripcion_m,estado_m) values (@descripcion,@estado)");
                datos.setearParametros("@descripcion", NuevaMarca.Descripcion);
                datos.setearParametros("@estado", NuevaMarca.Estado);
                datos.ejecutarAccion();


            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();

            }
        }

        public void BajaMarca(int id)
        {

            List<Marca> lista = new List<Marca>();
            lista = ListarMarca();
            Marca Mmodificar = null;
            foreach (Marca Marca in lista)
            {

                if (Marca.IdMarca == id)
                {

                    Mmodificar = Marca;


                }


            }

            Mmodificar.Estado = 0;

            modificar(Mmodificar);




        }

        public void modificar(Marca modificado)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update marcas set descripcion_m=@descripcion ,estado_m=@estado where id_m=@id");
                datos.setearParametros("@descripcion", modificado.Descripcion);
                datos.setearParametros("@estado", modificado.Estado);
                datos.setearParametros("@id", modificado.IdMarca);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.cerrarConexion();

            }

        }

        public int EstadoMarca(int id) {
           
            List<Marca> lista = ListarMarca();

            foreach (Marca marca in lista)
            {
                if (marca.IdMarca == id)
                {
                   
                    return marca.Estado;
                }
            }

            return 0;



        }
        
        //valida si la marca que quiere modificar es la misma del id
        public bool EselMismo(string descrip , int id) {

            List<Marca> lista = ListarMarca();

            foreach (Marca marca in lista)
            {
                // Comparamos e ignoramos mayúsculas/minúsculas
                if (marca.Descripcion.Equals(descrip, StringComparison.OrdinalIgnoreCase))
                {
                   
                    if (marca.IdMarca != id)
                    {
                        return true;//si es el mismo id guarda la marca
                    }
                }
            }

            return false;//no es el mismo id por lo tanto no guarda

        }

        //Valida si se ingresa una marca ya existente
        public bool ExisteDescripcion(string descrip)
        {

            List<Marca> lista = ListarMarca();

            foreach (Marca marca in lista)
            {
                // Comparamos e ignoramos mayúsculas/minúsculas
                if (marca.Descripcion.Equals(descrip, StringComparison.OrdinalIgnoreCase))
                {

                 
                        return true;//ya existe
                    
                }
            }

            return false;//no existe

        }





    }

}