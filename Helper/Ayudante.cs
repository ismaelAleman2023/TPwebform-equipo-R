using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using negocio;
using dominio;
using System.Runtime.InteropServices;


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


        public static string idXmarca(int idMarca)
        {

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            Marca mar = marcaNegocio.buscarMarca(idMarca);

            return mar.Descripcion;

        }

        public static string idxNproduc(int idProducto)
        {

            ProductoNegocio productoNegocio = new ProductoNegocio();
            Producto pro = productoNegocio.buscarProduc(idProducto);
            return pro.Nombre;

        }


        public static string idxCategoria(int idCategoria)
        {

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
        public static bool ExisteOtroProduc(string CodProduco, int idprodu)//para validar en el agregar
        {
            ProductoNegocio productoNegocio = new ProductoNegocio();

            try
            {
                List<Producto> listprodu = productoNegocio.listarProduc();

                foreach (Producto pro in listprodu)
                {

                    if (pro.CodigoProducto.Equals(CodProduco) && idprodu != pro.IdProducto)
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

        public static bool esVacio(string valor)
        {

            return string.IsNullOrWhiteSpace(valor);

        }




        public static bool validadStock(int cantidad)
        {

            if (cantidad == 0)
            {
                return true;
            }

            return false;

        }

        public static void cambiarEstadoProducto(int idproducto, string AlBj)
        {

            ProductoNegocio proN = new ProductoNegocio();
            Producto pro = proN.buscarProduc(idproducto);

            if (AlBj.Equals("alta"))
            {
                if (pro.Estado == 0)
                {
                    proN.AltaoBajaProducto(pro.IdProducto, 1);

                }
            }
            else if (AlBj.Equals("baja"))
            {

                if (pro.Estado == 1)
                {
                    proN.AltaoBajaProducto(pro.IdProducto, 0);

                }


            }

        }


        public static bool validarCorreo(string correo)
        {

            ClienteNegocio clieN = new ClienteNegocio();
            VendedorNegocio venN = new VendedorNegocio();
            AdministrarNegocio admN = new AdministrarNegocio();
            List<Cliente> listClie = clieN.listarClientes(2);
            List<Vendedor> listVen = venN.listarVendedores(2);
            List<Administrador> listAdmin = admN.listarAdministradores(2);

            string correoBuscar = correo.ToLower();

            foreach (Cliente cliente in listClie)
            {

                if (cliente.Email != null && cliente.Email.ToLower() == correoBuscar)
                {


                    return true;

                }

            }

            foreach (Vendedor ven in listVen)
            {


                if (ven.Email != null && ven.Email.ToLower() == correoBuscar)
                {

                    return true;


                }


            }

            foreach (Administrador adm in listAdmin) {

                if (adm.Email  != null && adm.Email.ToLower() == correoBuscar) {

                    return true;
                
                
                }

            
            }

            return false;


        }



    }



}