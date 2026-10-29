using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class StockNegocio
    {
        public void agregarStock(Stock st)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("insert into (idProducto_stk,cantidad_stk,estado_stk) values (@idProduc ,@cantidad ,@estado)");
                datos.setearParametros("@idProduc", st.CodigoProducto);
                datos.setearParametros("@cantidad", st.Cantidad);
                datos.setearParametros("@estado", st.Estado);
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


        public List<Stock> listaStock()
        {
            AccesoDatos datos = new AccesoDatos();
            List<Stock> lst = new List<Stock>();

            try
            {

                datos.consultaSql("select id_stock ,idProducto_stk,cantidad_stk,estado_stk from stocks");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Stock stock = new Stock();

                    stock.IdStock = (int)datos.Lector["id_stock"];
                    stock.CodigoProducto = (int)datos.Lector["idProducto_stk"];
                    stock.Cantidad = (int)datos.Lector["cantidad_stk"];
                    stock.Estado = (int)datos.Lector["estado_stk"];


                    lst.Add(stock);

                }


                return lst;

            }
            catch (Exception)
            {

                throw;
            }


        }


        public void modificar(Stock st) { 
        
            AccesoDatos datos=new AccesoDatos();

            try
            {

                datos.consultaSql("update stocks  set idProducto_stk=@idProduc ,cantidad_stk=@cantidad ,estado_stk=@estado where id_stock=@id ");
                datos.setearParametros("@idProduc", st.CodigoProducto);
                datos.setearParametros("@cantidad", st.Cantidad);
                datos.setearParametros("@estado", st.Estado);
                datos.setearParametros("id",st.IdStock);
                datos.ejecutarAccion();


            }
            catch (Exception)
            {

                throw;
            }
            finally { 
            datos.cerrarConexion();
            
            }
        
        
        }



        public void AltaoBajaStock(int id ,int estado)
        {

            AccesoDatos Datos = new AccesoDatos();
            try
            {
                Datos.consultaSql("update stocks set estado_stk= "+estado+" where id_stock=@id");
                Datos.setearParametros("@id", id);
                Datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { Datos.cerrarConexion(); }



        }


        public int EstadoStock(int id)
        {

            List<Stock> lista = listaStock();

            foreach (Stock st in lista)
            {
                if (st.IdStock == id)
                {

                    return st.Estado;
                }
            }

            return 0;

        }

        public bool ExisteIdprodu(int idprod)
        {

            List<Stock> lista = listaStock();

            foreach (Stock st in lista)
            {

                if (st.CodigoProducto == idprod)
                {

                    return true;

                }

            }

            return false;

        }


        public void ModificarStockCantidad(int idProducto, int cantidad, string operacion)
        { 
        AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.consultaSql("update stocks set cantidad_stk = cantidad_stk " + operacion + " @cantidad where idProducto_stk = @idProducto");
                datos.setearParametros("@cantidad", cantidad);
                datos.setearParametros("@idProducto", idProducto);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally {
                datos.cerrarConexion();
            
            }
        
        
        
        
        
        
        
        
        
        
        }





        }
}
