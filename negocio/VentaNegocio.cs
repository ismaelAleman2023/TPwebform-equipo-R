using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    internal class VentaNegocio
    {

        public void agregar(Venta venta)
        {
			AccesoDatos datos = new AccesoDatos();
            try
			{
                datos.consultaSql("INSERT INTO VENTAS (IdCliente_Venta, FechaVenta_Venta, Total_venta, TipoPago_Venta, Estado_Venta) VALUES (@IdCliente, @FechaVenta, @TotalPago, @TipoPago, @EstadoVenta)");
                datos.setearParametros("@IdCliente", venta.IdCliente_V);
                datos.setearParametros("@FechaVenta", venta.FechaVenta_V);                      
                datos.setearParametros("@TotalPago", venta.TotalPago_V);    
                datos.setearParametros("@TipoPago", venta.TipoPago_V);
                datos.setearParametros("@EstadoVenta", venta.Estado_Venta_V); 
                datos.ejecutarAccion();
                datos.cerrarConexion();


                datos.consultaSql("select max(idVenta) from Ventas");
                datos.ejecutarLectura();

                if (datos.Lector.Read()){
                   venta.IdVenta_V = (int)datos.Lector[0];
                }
                datos.cerrarConexion();

                /* detalle venta
                 
                if (venta.DetalleVenta != null && venta.DetalleVenta.Count > 0)
                {
                    DetalleVentaNegocio detalleNegocio = new DetalleVentaNegocio();
                    foreach (DetalleVenta detalle in venta.DetalleVenta)
                    {
                        detalle.IdVenta_Detalle = obtenerUltimoIdVenta();
                        detalleNegocio.agregar(detalle);
                    }
                }
                */

            }
			catch (Exception)
			{

				throw;
			}
        }


        public List<Venta> listarVentas()
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("SELECT IdVenta, IdCliente_Venta, FechaVenta, Total_venta, TipoPago_Venta, Estado_Venta FROM VENTAS");
                datos.ejecutarLectura();

                //DetalleVentaNegocio detalleNegocio = new DetalleVentaNegocio();
                List<Venta> ventas = new List<Venta>();
                //List<DetalleVenta> detalleVentaslist = detalleNegocio.listarDetalleVenta();

                while (datos.Lector.Read())
                {
                    Venta ven = new Venta();
                    ven.IdVenta_V = (int)datos.Lector["IdVenta"];
                    ven.IdCliente_V = (int)datos.Lector["IdCliente_Venta"];
                    ven.FechaVenta_V = (DateTime)datos.Lector["FechaVenta_Venta"];
                    ven.TotalPago_V = (decimal)datos.Lector["Total_venta"];
                    ven.TipoPago_V = (int)datos.Lector["TipoPago_Venta"];
                    ven.Estado_Venta_V = (int)datos.Lector["Estado_Venta"];
                    
                    /*                 
                    
                    foreach(DetalleVenta detalle in detalleVentaslist)
                    {
                        if (detalle.IdVenta_Detalle == ven.IdVenta_V)
                        {
                            ven.DetalleVenta.Add(detalle);
                        }
                    }

                    */

                    ventas.Add(ven);
                }
                datos.cerrarConexion();

                return ventas;
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


        public void eliminarVenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update ventas set Estado_Venta = 0 where IdVenta = @id");
                datos.setearParametros("id", id);
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

        /*
        public Venta buscarVenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Venta ven = new Venta();
                DetalleVentaNegocio detalleNegocio = new DetalleVentaNegocio();

                List<DetalleVenta> detalleVentaslist = detalleNegocio.listarDetalleVenta();

                datos.consultaSql("SELECT IdVenta, IdCliente_Venta, FechaVenta, Total_venta, TipoPago_Venta, Estado_Venta FROM VENTAS WHERE IdVenta = @id");
                datos.setearParametros("id", id);
                datos.ejecutarLectura();
                if (datos.Lector.Read())
                {
                    ven.IdVenta_V = (int)datos.Lector["IdVenta"];
                    ven.IdCliente_V = (int)datos.Lector["IdCliente_Venta"];
                    ven.FechaVenta_V = (DateTime)datos.Lector["FechaVenta_Venta"];
                    ven.TotalPago_V = (decimal)datos.Lector["Total_venta"];
                    ven.TipoPago_V = (int)datos.Lector["TipoPago_Venta"];
                    ven.Estado_Venta_V = (int)datos.Lector["Estado_Venta"];


                    foreach (DetalleVenta deta in detalleVentaslist)
                    {
                        if (deta.IdVenta_Detalle == ven.IdVenta_V)
                        {
                            ven.DetalleVenta.Add(deta);
                        }

                    }
                    return ven;
                }

                return ven;

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

        */


    }
}
