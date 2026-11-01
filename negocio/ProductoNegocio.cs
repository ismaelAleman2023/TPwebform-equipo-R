using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ProductoNegocio
    {
        public void agregarProducto(Producto produ)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("insert into productos (codigoProducto_prod,nombre_prod,descripcion_prod,idMarca_prod,idCategoria_prod," +
                    "precio_prod,ondemand_prod,estado_prod) values (@codprod,@nombre,@descripcion,@idmarca,@idcate,@precio,@ondemand,@estado)");
                datos.setearParametros("@codprod", produ.CodigoProducto);
                datos.setearParametros("@nombre", produ.Nombre);
                datos.setearParametros("@descripcion", produ.Descripcion);
                datos.setearParametros("@idmarca", produ.Marca);
                datos.setearParametros("@idcate", produ.Categoria);
                datos.setearParametros("@precio", produ.Precio);
                datos.setearParametros("@ondemand", produ.OnDemand);
                datos.setearParametros("@estado", produ.Estado);
                datos.ejecutarAccion();


                //cargamos las imagenes
                foreach (Imagen img in produ.ListaImagen)
                {

                    ImagenNegocio imgneg = new ImagenNegocio();

                    imgneg.agregarImagen(img);

                }


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

        public List<Producto> listarProduc()
        {
            AccesoDatos datos = new AccesoDatos();
            ImagenNegocio img = new ImagenNegocio();
            List<Producto> listPro = new List<Producto>();

            try
            {
                datos.consultaSql("select idProducto,codigoProducto_prod,nombre_prod,descripcion_prod,idMarca_prod,idCategoria_prod," +
                    "precio_prod,ondemand_prod,estado_prod from productos");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    Producto pro = new Producto();
                    pro.IdProducto = (int)datos.Lector["idProducto"];
                    pro.CodigoProducto = (int)datos.Lector["codigoProducto_prod"];
                    pro.Nombre = (string)datos.Lector["nombre_prod"];
                    pro.Descripcion = (string)datos.Lector["descripcion_prod"];
                    pro.Marca = (int)datos.Lector["idMarca_prod"];
                    pro.Categoria = (int)datos.Lector["idCategoria_prod"];
                    pro.Precio = (decimal)datos.Lector["precio_prod"];
                    pro.OnDemand = (bool)datos.Lector["ondemand_prod"];
                    pro.Estado = (int)datos.Lector["estado_prod"];
                    pro.ListaImagen = img.buscarXcodProduc(pro.CodigoProducto);

                    listPro.Add(pro);

                }
                return listPro;

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

        public void AltaoBajaProducto(int id, int estado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("update productos set estado_prod = @estado where idProducto = @id");
                datos.setearParametros("@estado", estado);
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

        public void modificarProducto(Producto produ)
        {
            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("update productos set codigoProducto_prod = @codprod, nombre_prod = @nombre, descripcion_prod = @descripcion, idMarca_prod = @idmarca, idCategoria_prod = @idcate, precio_prod = @precio, ondemand_prod = @ondemand, estado_prod = @estado where idProducto = @id");

                datos.setearParametros("@codprod", produ.CodigoProducto);
                datos.setearParametros("@nombre", produ.Nombre);
                datos.setearParametros("@descripcion", produ.Descripcion);
                datos.setearParametros("@idmarca", produ.Marca);
                datos.setearParametros("@idcate", produ.Categoria);
                datos.setearParametros("@precio", produ.Precio);
                datos.setearParametros("@ondemand", produ.OnDemand);
                datos.setearParametros("@estado", produ.Estado);
                datos.setearParametros("@id", produ.IdProducto);

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
