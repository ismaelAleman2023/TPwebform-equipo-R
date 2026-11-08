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
                    aux.IdVenta_Detalle = (int)datos.Lector["idVenta_dv"];
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

        public void agregar(DetalleVenta detalle)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("insert into detalleVentas(idVenta_dv, idProducto_dv, precioUnitario_dv, subtotal_dv, cantidad_dv) values(@idVenta, @idProducto, @precioUnitario, @subtotal, @cantidad)");
                datos.setearParametros("@idVenta", detalle.IdVenta_Detalle);
                datos.setearParametros("@idProducto", detalle.IdProducto);
                datos.setearParametros("@precioUnitario", detalle.PrecioUnitario);
                datos.setearParametros("@subtotal", detalle.Subtotal);
                datos.setearParametros("@cantidad", detalle.Cantidad);
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

        public DetalleVenta buscarDetalleVenta(int id)
        {
            DetalleVenta detalle = new DetalleVenta();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idDetalleVenta, idVenta_dv, idProducto_dv, precioUnitario_dv, subtotal_dv, cantidad_dv from detalleVentas where idDetalleVenta = @id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    detalle.IdDetalleVenta = (int)datos.Lector["idDetalleVenta"];
                    detalle.IdVenta_Detalle = (int)datos.Lector["idVenta_dv"];
                    detalle.IdProducto = (int)datos.Lector["idProducto_dv"];
                    detalle.PrecioUnitario = (decimal)datos.Lector["precioUnitario_dv"];
                    detalle.Subtotal = (decimal)datos.Lector["subtotal_dv"];
                    detalle.Cantidad = (int)datos.Lector["cantidad_dv"];
                }
                return detalle;
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

        public void modificarDetalleVenta(DetalleVenta detalle)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update detalleVentas set idProducto_dv = @idProducto, precioUnitario_dv = @precioUnitario, subtotal_dv = @subtotal, cantidad_dv = @cantidad where idDetalleVenta = @id");
                datos.setearParametros("@idProducto", detalle.IdProducto);
                datos.setearParametros("@precioUnitario", detalle.PrecioUnitario);
                datos.setearParametros("@subtotal", detalle.Subtotal);
                datos.setearParametros("@cantidad", detalle.Cantidad);
                datos.setearParametros("@id", detalle.IdDetalleVenta);
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

        public void eliminarDetalleVenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("delete from detalleVentas where idDetalleVenta = @id");
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
