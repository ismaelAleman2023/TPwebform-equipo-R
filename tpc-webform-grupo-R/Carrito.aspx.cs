using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class Carrito : System.Web.UI.Page
    {
        List<DetalleVenta> listaProdCarrito;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["listaCarrito"] != null)
            {
                listaProdCarrito = (List<DetalleVenta>)Session["listaCarrito"];
            }
            else
            {
                listaProdCarrito = new List<DetalleVenta>();
            }

            if (!IsPostBack)
            {

                cargarCard(listaProdCarrito);

            }

        }


        private void cargarCard(List<DetalleVenta> listaCarrito)
        {
           
            decimal subtotal = 0;
            decimal total = 0;

            reapetCarrito.DataSource = listaCarrito;
            reapetCarrito.DataBind();

            foreach (DetalleVenta item in listaCarrito)
            {
                subtotal += item.Subtotal;
            }

            total = subtotal;

            lblSubtotal.Text = subtotal.ToString("C");
            lblTotal.Text = total.ToString("C");
            lblCant.Text = listaCarrito.Count.ToString();

        }



        public string obtenerImagenProducto(int idProducto)
        {
            List<Imagen> listaImagenes = (List<Imagen>)Session["listaimg"];

            foreach (Imagen img in listaImagenes)
            {
                if (img.idProducto_img == idProducto)
                {
                    return img.UrlImagen;
                }
            }

            return "https://i.pinimg.com/736x/42/65/d9/4265d9b9ee10196f62e9ac38cafc1a24.jpg";
        }


        public string obtenerNombreProducto(int idProducto)
        {
            List<Producto> listProd = (List<Producto>)Session["listaprod"];
            string nombre = "sin nombre";
            foreach (Producto prod in listProd)
            {
                if (prod.IdProducto == idProducto)
                {
                    nombre = prod.Nombre;
                    break;
                }
            }

            return nombre;


        }

        protected void btnRestar_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idProd = int.Parse(btn.CommandArgument);
            List<DetalleVenta> listaDeta = (List<DetalleVenta>)Session["listaCarrito"];
            foreach (DetalleVenta item in listaDeta)
            {
                if (item.IdProducto == idProd)
                {
                    if (item.Cantidad > 1)
                    {
                        item.Cantidad--;
                        item.Subtotal = item.Cantidad * item.PrecioUnitario;

                    }
                }

            }

            Session["listaCarrito"] = listaDeta;
            listaProdCarrito = listaDeta;
            cargarCard(listaProdCarrito);

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            ProductoNegocio proN = new ProductoNegocio();
            StockNegocio stkN = new StockNegocio();
            Stock stk;

            Button btn = (Button)sender;
            int idProd = int.Parse(btn.CommandArgument);

            List<DetalleVenta> listaDeta = (List<DetalleVenta>)Session["listaCarrito"];
            foreach (DetalleVenta item in listaDeta)
            {
                if (item.IdProducto == idProd)
                {
                    if (!proN.onDemand(item.IdProducto))
                    {
                        stk = stkN.buscarStockProd (item.IdProducto);

                        if (item.Cantidad + 1 <= stk.Cantidad)
                        {

                            item.Cantidad++;
                            item.Subtotal = item.Cantidad * item.PrecioUnitario;
                        }

                    }
                    else
                    {

                        item.Cantidad++;
                        item.Subtotal = item.Cantidad * item.PrecioUnitario;
                    }
                }

            }

            Session["listaCarrito"] = listaDeta;
            listaProdCarrito = listaDeta; 
            cargarCard(listaProdCarrito);

        }

        protected void btnEliminarCarrito_Click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            int idProd = int.Parse(btn.CommandArgument);

            List<DetalleVenta> listaDeta = (List<DetalleVenta>)Session["listaCarrito"];

            int posi = 0;
            int contador = listaDeta.Count;

            for (int i = 0; i < contador; i++)
            {
                if(listaDeta[i].IdProducto == idProd)
                {
                    posi = i;
                    break;
                }
            }

            listaDeta.RemoveAt(posi);

            Session["listaCarrito"] = listaDeta;
            listaProdCarrito = listaDeta;
            cargarCard(listaProdCarrito);

        }

        protected void btnContinuar_Click(object sender, EventArgs e)
        {

            Response.Redirect("FinalizarCompra.aspx");


        }
    }
}