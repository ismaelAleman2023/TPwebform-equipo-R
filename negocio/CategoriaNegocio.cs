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
                string consulta="select id_C,descripcion_C,estado_C from categorias";

                datos.consultaSql(consulta);
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
                datos.setearParametros("@id", id);
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
                datos.consultaSql("update categorias set descripcion_C = @descripcion, estado_C = @estado where id_C = @id");
                datos.setearParametros("@id", modiCate.IdCategoria);
                datos.setearParametros("@descripcion", modiCate.Descripcion);
                datos.setearParametros("@estado", modiCate.Estado);
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

        public Categoria buscarCategoria(int id) { 

            AccesoDatos datos =new AccesoDatos();
            Categoria cate=new Categoria();
            try
            {
                datos.consultaSql("select id_C,descripcion_C,estado_c from categorias where id_C=@id");
                datos.setearParametros("@id",id);
                datos.ejecutarLectura();

                while (datos.Lector.Read())
                {
                    cate.IdCategoria = (int)datos.Lector["id_C"];
                    cate.Descripcion = (string)datos.Lector["descripcion_C"];
                    cate.Estado = (int)datos.Lector["estado_c"];

                
                }
                    
                    
                    return cate;

            }
            catch (Exception)
            {

                throw;
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

        public bool existeOtraCategoria(string descri, int idActual)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.consultaSql("select id_C from categorias where descripcion_C = @descripcion and id_C != @id");
                datos.setearParametros("@descripcion", descri);
                datos.setearParametros("@id", idActual);
                datos.ejecutarLectura();

                
                if (datos.Lector.Read())
                {
                    return true; 
                }

                return false; 
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
