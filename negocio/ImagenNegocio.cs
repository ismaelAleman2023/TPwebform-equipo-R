using dominio;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace negocio
{
    public class ImagenNegocio
    {

        public List<Imagen> ListaImagen() {

            AccesoDatos datos= new AccesoDatos();
            List<Imagen>list= new List<Imagen>();
            try
            {
                datos.consultaSql("select id_img,idProducto_img,urlImagen from imagenes");
                datos.ejecutarLectura();

                while (datos.Lector.Read()) { 
                
                 Imagen imagen= new Imagen();

                    imagen.IdImagen = (int)datos.Lector["id_img"];
                    imagen.idProducto_img = (int)datos.Lector["idProducto_img"];
                    imagen.UrlImagen=(string)datos.Lector ["urlImagen"];

                    list.Add(imagen);
                }

                return list;



            }
            catch (Exception)
            {

                throw;
            }
            finally{

                datos.cerrarConexion(); 
            }
        
        



        }

        public List<Imagen> buscarXcodProduc(int id) {

            AccesoDatos datos   = new AccesoDatos();
            List<Imagen> list= new List<Imagen>();
            try
            {

                datos.consultaSql("select id_img,idProducto_img,urlImagen from imagenes where idProducto_img=@id");
                datos.setearParametros("@id", id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Imagen imagen = new Imagen();

                    imagen.IdImagen = (int)datos.Lector["id_img"];
                    imagen.idProducto_img = (int)datos.Lector["idProducto_img"];
                    imagen.UrlImagen = (string)datos.Lector["urlImagen"];

                    list.Add(imagen);
                }

                return list;



            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }


        
        }

        public void bajaXcodProduc(int id) {

            AccesoDatos datos=new AccesoDatos();

            try
            {
                datos.consultaSql("delete imagenes where idProducto_img=@id");
                datos.setearParametros("@id",id);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally{ datos.cerrarConexion(); }


        }

        public void eliminarImagenesXproductos(int id) {

           
            List<Imagen> list = buscarXcodProduc(id);
            try
            {
                foreach (Imagen imagen in list)
                {

                    bajaXcodProduc(imagen.idProducto_img);


                }
                
                

            }
            catch (Exception)
            {

                throw;
            }
        
        }

        public void agregarImagen(Imagen imga) { 
        
        AccesoDatos datos=new AccesoDatos();

            try
            {
                datos.consultaSql("insert into imagenes(idProducto_img,urlImagen) values (@idprodu,@url)");
                datos.setearParametros("@idprodu", imga.idProducto_img);
                datos.setearParametros("@url", imga.UrlImagen);
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
