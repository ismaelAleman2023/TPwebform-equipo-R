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
                    Marca.Estado = (bool)datos.Lector["estado_m"];

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
                datos.consultaSql("insert into marcas(id_m,descripcion_m,estado_m) values (@id,@descripcion,@estado)");
                datos.setearParametros("@id", NuevaMarca.IdMarca);
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

            Mmodificar.Estado = false;

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

        public bool EstadoMarca(int id) {
           
            List<Marca> lista = ListarMarca();

            foreach (Marca marca in lista)
            {
                if (marca.IdMarca == id)
                {
                    // Si el estado es false (dado de baja), devuelve TRUE. 
                    // Si el estado es true (activo), devuelve FALSE.
                    return !marca.Estado;
                }
            }

            return false;



        }

        public bool ExisteDescripcion(string descrip , int id) {

            List<Marca> lista = ListarMarca();

            foreach (Marca marca in lista)
            {
                // Comparamos e ignoramos mayúsculas/minúsculas
                if (marca.Descripcion.Equals(descrip, StringComparison.OrdinalIgnoreCase))
                {
                   
                    if (marca.IdMarca != id)
                    {
                        return true;
                    }
                }
            }

            return false;

        }

        



    }

}