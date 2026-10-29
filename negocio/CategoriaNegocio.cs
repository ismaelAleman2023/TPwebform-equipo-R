using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using dominio;
namespace negocio
{
    public class CategoriaNegocio
    {

        public void AgregarCategoria(Categoria cateAg)
        {
            AccesoDatos datos = new AccesoDatos();


            try
            {
                datos.consultaSql("insert into categorias(descripcion_C ,estado_C) values (@descripcion,@estado)");
                datos.setearParametros("@descripcion", cateAg.Descripcion);
                datos.setearParametros("@estado", cateAg.Estado);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }


        public List<Categoria> listarCate()
        {

            AccesoDatos datos = new AccesoDatos();
            List<Categoria> Listacategorias = new List<Categoria>();


            try
            {
                datos.consultaSql("select id_C,descripcion_C,estado_C from categorias");
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {

                    Categoria cate = new Categoria();
                    cate.IdCategoria = (int)datos.Lector["id_C"];
                    cate.Descripcion = (string)datos.Lector["descripcion_C"];
                    cate.Estado = (int)datos.Lector["estado_C"];

                    Listacategorias.Add(cate);
                }

                return Listacategorias;

            }
            catch (Exception)
            {

                throw;
            }
            finally
            { datos.cerrarConexion(); }

        }

        public void bajaCategoria(int id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("update categorias set estado_C=0 where id_C=@id");
                datos.setearParametros("id_C", id);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void AltaCategoria(int id)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("update categorias set estado_C=1 where id_C=@id");
                datos.setearParametros("id_C", id);
                datos.ejecutarAccion();

            }
            catch (Exception)
            {

                throw;
            }
            finally { datos.cerrarConexion(); }
        }

        public void Modificar(Categoria modiCate)
        {

            AccesoDatos datos = new AccesoDatos();

            try
            {
                datos.consultaSql("update categorias set id_C=@id ,descripcion_C=@descripcion, estado_C=@estado");
                datos.setearParametros("@id", modiCate.IdCategoria);
                datos.setearParametros("@descripcion", modiCate.Descripcion);
                datos.setearParametros("@estado", modiCate.Estado);
                datos.ejecutarLectura();
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

        //validaciones para duplicado de categorias

        public int EstadoCategoria(int id)
        {

            List<Categoria> listCate = listarCate();

            try
            {

                foreach (Categoria c in listCate)
                {
                    if (c.IdCategoria == id)
                    {

                        return c.Estado;

                    }



                }
                return 0;

            }
            catch (Exception)
            {

                throw;
            }


        }

        public bool valiModiCate(string descri, int id) { 
        
               List<Categoria> liscate=listarCate();
            foreach (Categoria c in liscate) {

                if (c.Descripcion.Equals(descri,StringComparison.OrdinalIgnoreCase)) {

                    if (c.IdCategoria==id) {

                        return true;
                    }
                
                }
            
            }
        
            return false;
        
        }

        public bool existeCategoria(string descri) {

            List<Categoria> liscate = listarCate();
            foreach (Categoria c in liscate)
            {

                if (c.Descripcion.Equals(descri, StringComparison.OrdinalIgnoreCase))
                {

                    return true;
                }

            }

            return false;

        }



    }
}
