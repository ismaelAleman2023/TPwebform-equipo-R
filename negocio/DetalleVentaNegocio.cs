using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class DetalleVentaNegocio
    {
        public List<DetalleVenta> listarDetalleVenta()
        {
            List<DetalleVenta> lista = new List<DetalleVenta>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idDetalleVenta, idVenta_dv, idProducto_dv, precioUnitario_dv, subtotal_dv, cantidad_dv from detalleVentas");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    DetalleVenta aux = new DetalleVenta();
                    aux.IdDetalleVenta = (int)datos.Lector["idDetalleVenta"];
                    aux.IdVenta = (int)datos.Lector["idVenta_dv"];
                    aux.IdProducto = (int)datos.Lector["idProducto_dv"];
                    aux.PrecioUnitario = (decimal)datos.Lector["precioUnitario_dv"];
                    aux.Subtotal = (decimal)datos.Lector["subtotal_dv"];
                    aux.Cantidad = (int)datos.Lector["cantidad_dv"];
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
