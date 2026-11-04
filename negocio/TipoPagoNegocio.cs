using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class TipoPagoNegocio
    {
        public List<TipoPago> ListarTipoPago()
        {
            List<TipoPago> lista = new List<TipoPago>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idTipoPago, descripcion_tipo, estado_tipo from tipoPagos");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    TipoPago aux = new TipoPago();
                    aux.IdTipoPago = (int)datos.Lector["idTipoPago"];
                    aux.Descripcion = (string)datos.Lector["descripcion_tipo"];
                    aux.Estado = (int)datos.Lector["estado_tipo"];
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

        public void AgregarTipoPago(TipoPago nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into tipoPagos(descripcion_tipo, estado_tipo) values (@descripcion, @estado)");
                datos.setearParametros("@descripcion", nuevo.Descripcion);
                datos.setearParametros("@estado", nuevo.Estado);
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

        public bool ExisteDescripcion(string descrip)
        {
            foreach (TipoPago tp in ListarTipoPago())
            {
                if (tp.Descripcion.Equals(descrip, StringComparison.OrdinalIgnoreCase))
                {
                    return true;
                }
            }
            return false;
        }

        public void BajaTipoPago(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update tipoPagos set estado_tipo = 0 where idTipoPago = @id");
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

        public void AltaTipoPago(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update tipoPagos set estado_tipo = 1 where idTipoPago = @id");
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
    }
}
