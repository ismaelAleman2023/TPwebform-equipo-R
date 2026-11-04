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
    }
}
