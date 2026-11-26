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
                datos.consultaSql("select idDetalleVenta, idVenta_dv, idProducto_dv, precioUnitario_dv, subtotal_dv, cantidad_dv from detalleVentas where idVenta_dv = @id");
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

        public List<DetalleVenta> buscarDetalleVentas(int idVenta)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select idDetalleVenta, idVenta_dv, idProducto_dv, precioUnitario_dv, subtotal_dv, cantidad_dv from detalleVentas where idVenta_dv = @id");
                datos.setearParametros("@id", idVenta);
                datos.ejecutarLectura();

                List<DetalleVenta> listdeta= new List<DetalleVenta>();
                while (datos.Lector.Read())
                {
                    DetalleVenta detalle = new DetalleVenta();
                    detalle.IdDetalleVenta = (int)datos.Lector["idDetalleVenta"];
                    detalle.IdVenta_Detalle = (int)datos.Lector["idVenta_dv"];
                    detalle.IdProducto = (int)datos.Lector["idProducto_dv"];
                    detalle.PrecioUnitario = (decimal)datos.Lector["precioUnitario_dv"];
                    detalle.Subtotal = (decimal)datos.Lector["subtotal_dv"];
                    detalle.Cantidad = (int)datos.Lector["cantidad_dv"];
                    listdeta.Add(detalle);
                }
                return listdeta;
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


        public List<string> MasVendidos()
        {

            List<string> listaMasVendidos= new List<string>();

            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("SELECT TOP 5 vta.idProducto_dv AS idProducto_img, img.urlImagen, vta.UnidadesVendidas " +
                    "FROM (SELECT dv.idProducto_dv,SUM(dv.cantidad_dv) AS UnidadesVendidas,MAX(v.idVenta) AS ultimoIdVenta " +
                    "FROM detalleVentas dv INNER JOIN Ventas v ON v.idVenta = dv.idVenta_dv " +
                    "WHERE v.fechaVenta >= DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1) " +
                    "AND v.fechaVenta < DATEADD(MONTH, 1, DATEFROMPARTS(YEAR(GETDATE()), MONTH(GETDATE()), 1)) " +
                    "AND v.estadoPedido_venta NOT IN (0, 2, 9, 10)" +
                    "GROUP BY dv.idProducto_dv) AS vta CROSS APPLY ( SELECT TOP 1 i.urlImagen FROM Imagenes i " +
                    "WHERE i.idProducto_img = vta.idProducto_dv ORDER BY i.id_Img ASC ) AS img " +
                    "ORDER BY vta.UnidadesVendidas DESC, vta.ultimoIdVenta DESC ");

                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    string url = datos.Lector["urlImagen"].ToString();
                   
                    listaMasVendidos.Add(url);

                }

                return listaMasVendidos;    
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
