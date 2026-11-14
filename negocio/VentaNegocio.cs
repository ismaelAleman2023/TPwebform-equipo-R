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
                datos.consultaSql("INSERT INTO VENTAS (IdCliente_Venta, FechaVenta_Venta, Total_venta, TipoPago_Venta, Estado_Venta, estadoPedido_venta) VALUES (@IdCliente, @FechaVenta, @TotalPago, @TipoPago, @EstadoVenta, @EstadoPedido)");
                datos.setearParametros("@IdCliente", venta.IdCliente_V);
                datos.setearParametros("@FechaVenta", venta.FechaVenta_V);
                datos.setearParametros("@TotalPago", venta.TotalPago_V);
                datos.setearParametros("@TipoPago", venta.TipoPago_V);
                datos.setearParametros("@EstadoVenta", venta.Estado_V);
                datos.setearParametros("@EstadoPedido", venta.EstadoPedido_v);
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

        public int ultimoIdVenta()
        {
                AccesoDatos datos = new AccesoDatos();
            try
            {
                int ultimoId = 0;

                datos.consultaSql("select max(idVenta) from Ventas");
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    ultimoId = (int)datos.Lector[0];
                }
                return ultimoId;
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


        public List<Venta> listarVentas(int estado=2)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "SELECT IdVenta, IdCliente_Venta, FechaVenta, Total_venta, TipoPago_Venta, Estado_Venta , estadoPedido_venta FROM VENTAS";


                if(estado==0 || estado == 1)
                {
                    consulta = " where Estado_Venta = @estado";
                    datos.setearParametros("@estado", estado);
                }

                datos.consultaSql(consulta);
                datos.ejecutarLectura();
               
                List<Venta> ventas = new List<Venta>();              

                while (datos.Lector.Read())
                {
                    Venta ven = new Venta();
                    ven.IdVenta_V = (int)datos.Lector["IdVenta"];
                    ven.IdCliente_V = (int)datos.Lector["IdCliente_Venta"];
                    ven.FechaVenta_V = (DateTime)datos.Lector["FechaVenta_Venta"];
                    ven.TotalPago_V = (decimal)datos.Lector["Total_venta"];
                    ven.TipoPago_V = (int)datos.Lector["TipoPago_Venta"];
                    ven.Estado_V = (bool)datos.Lector["Estado_Venta"];
                    ven.EstadoPedido_v = (int)datos.Lector["EstadoPedido_venta"];                              

                    ventas.Add(ven);
                }              

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


        public void BajaVenta(int id)
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

        public void ReactivarVenta(int id)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update ventas set Estado_Venta = 1 where IdVenta = @id");
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





        public Venta buscarVenta(int idCliente)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                Venta ven = new Venta();
                DetalleVentaNegocio detalleNegocio = new DetalleVentaNegocio();

                List<DetalleVenta> detalleVentaslist = detalleNegocio.listarDetalleVenta();
                datos.consultaSql("SELECT IdVenta, IdCliente_Venta, FechaVenta, Total_venta, TipoPago_Venta, Estado_Venta , estadoPedido_venta FROM VENTAS WHERE IdVenta = @id");
               
                datos.setearParametros("id", idCliente);
                datos.ejecutarLectura();

                if (datos.Lector.Read())
                {
                    ven.IdVenta_V = (int)datos.Lector["IdVenta"];
                    ven.IdCliente_V = (int)datos.Lector["IdCliente_Venta"];
                    ven.FechaVenta_V = (DateTime)datos.Lector["FechaVenta_Venta"];
                    ven.TotalPago_V = (decimal)datos.Lector["Total_venta"];
                    ven.TipoPago_V = (int)datos.Lector["TipoPago_Venta"];
                    ven.Estado_V = (bool)datos.Lector["Estado_Venta"];
                    ven.EstadoPedido_v = (int)datos.Lector["EstadoPedido_venta"];
                                                 
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


        public void modificarEstadoPedido(int estadoPedido)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update ventas set estadoPedido_venta = @estadoPedido");
                datos.setearParametros("@estadoPedido", estadoPedido);
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
