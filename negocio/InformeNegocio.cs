using dominio;
using System;
using System.Collections.Generic;

namespace negocio
{
    public class InformeNegocio
    {
        private const string ESTADOS_NO_PAGADOS = "(0, 2, 9, 10)";

        public List<ResumenInforme> ventasPorFormaDePago()
        {
            List<ResumenInforme> lista = new List<ResumenInforme>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select t.descripcion_tipo, count(*) as cantidad, sum(v.total_venta) as total from ventas v inner join tipoPagos t on t.idTipoPago = v.tipoPago_venta where v.estadoPedido_venta not in " + ESTADOS_NO_PAGADOS + " group by t.descripcion_tipo");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ResumenInforme aux = new ResumenInforme();
                    aux.Descripcion = (string)datos.Lector["descripcion_tipo"];
                    aux.Cantidad = (int)datos.Lector["cantidad"];
                    aux.Total = (decimal)datos.Lector["total"];
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

        public List<ResumenInforme> mejoresClientes()
        {
            List<ResumenInforme> lista = new List<ResumenInforme>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select top 10 p.nombre_per + ' ' + p.apellido_per as descripcion, count(*) as cantidad, sum(v.total_venta) as total from ventas v inner join personas p on p.idPersona = v.idCliente_venta where v.estadoPedido_venta not in " + ESTADOS_NO_PAGADOS + " group by p.idPersona, p.nombre_per, p.apellido_per order by total desc");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ResumenInforme aux = new ResumenInforme();
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Cantidad = (int)datos.Lector["cantidad"];
                    aux.Total = (decimal)datos.Lector["total"];
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

        public List<ResumenInforme> productosMasVendidos()
        {
            List<ResumenInforme> lista = new List<ResumenInforme>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select top 10 pr.nombre_prod as descripcion, sum(d.cantidad_dv) as cantidad, sum(d.subtotal_dv) as total from detalleVentas d inner join ventas v on v.idVenta = d.idVenta_dv inner join productos pr on pr.idProducto = d.idProducto_dv where v.estadoPedido_venta not in " + ESTADOS_NO_PAGADOS + " group by pr.idProducto, pr.nombre_prod order by cantidad desc");
                datos.ejecutarLectura();
                while (datos.Lector.Read())
                {
                    ResumenInforme aux = new ResumenInforme();
                    aux.Descripcion = (string)datos.Lector["descripcion"];
                    aux.Cantidad = (int)datos.Lector["cantidad"];
                    aux.Total = (decimal)datos.Lector["total"];
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
