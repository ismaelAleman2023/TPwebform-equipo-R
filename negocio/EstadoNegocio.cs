using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
   public class EstadoNegocio
    {

        public void agregarEstado(Estado estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into estados(descripcion_estado) values(@descripcion)");
                datos.setearParametros("@descripcion", estado.Descripcion_estado);
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


        public List<Estado> listarEstados()
        {

            List<Estado> lista = new List<Estado>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idEstado, descripcion_estado from estados");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    Estado aux = new Estado();
                    aux.IdEstado = (int)datos.Lector["idEstado"];
                    aux.Descripcion_estado = (string)datos.Lector["descripcion_estado"];
                    lista.Add(aux);
                }
                return lista;
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

        public void bajaEstado(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update estados set activo = 0 where idEstado = @id");
                datos.setearParametros("@id", id);
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

        public void reactivarEstado(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update estados set activo = 1 where idEstado = @id");
                datos.setearParametros("@id", id);
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

        public void eliminarEstado (int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("delete from estados where idEstado = @id");
                datos.setearParametros("@id", id);
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


        public Estado buscarEstado(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            Estado aux = new Estado();
            try
            {
                datos.consultaSql("select idEstado, descripcion_estado from estados where idEstado = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {                    
                    aux.IdEstado = (int)datos.Lector["idEstado"];
                    aux.Descripcion_estado = (string)datos.Lector["descripcion_estado"];
                    return aux;
                }

                return aux;
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


        public void modificarEstado(Estado estado)
        {

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update estados set descripcion_estado = @descripcion where idEstado = @id");
                datos.setearParametros("@descripcion", estado.Descripcion_estado);
                datos.setearParametros("@id", estado.IdEstado);
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



    }
}
