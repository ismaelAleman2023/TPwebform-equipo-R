using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dominio;


namespace Helper
{
    public static class Ayudante
    {

        public static bool ValidarNoNumero(string vali)
        {

            if (vali.Any(char.IsDigit))
            {
                return true;//contiene numero
            }

            return false;//no contiene numero
        }


        public static string idXmarca(int idMarca) {

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca mar = marcaNegocio.buscarMarca(idMarca);

            return mar.Descripcion;

        }

        public static string idxNproduc(int idProducto) {

            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto pro = productoNegocio.buscarProduc(idProducto);
            return pro.Nombre;

        }


        public static string idxCategoria(int idCategoria) {

            CategoriaNegocio cate = new CategoriaNegocio();
            Categoria categoria = cate.buscarCategoria(idCategoria);
            return categoria.Descripcion;

        }




        public static bool ExisteProduc(string CodProduco)//para validar en el agregar
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                List<Producto> listprodu = productoNegocio.listarProduc();

                foreach (Producto pro in listprodu)
                {

                    if (pro.CodigoProducto.Equals(CodProduco))
                    {

                        return true;

                    }


                }

                return false;
            }
            catch (Exception)
            {

                throw;
            }



        }

        public static bool esVacio(string valor) {

            return string.IsNullOrWhiteSpace(valor);

        }


      
    }



}