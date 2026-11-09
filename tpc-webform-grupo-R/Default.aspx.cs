using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.UI;
using System.Web.UI.WebControls;



namespace tpc_webform_grupo_R
{
    public partial class Default : System.Web.UI.Page
    {
       
        private List<DetalleVenta> carritoCompra; 
        
        
      
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                ProductoNegocio negocio = new ProductoNegocio();
                ImagenNegocio imgN = new ImagenNegocio();
                List<Producto> listaProductos = negocio.listarProduc();
                List<Imagen> listaImagen = imgN.ListaImagen();
                Session["listaprod"] = listaProductos;
                Session["listaimg"] = listaImagen;

                cargarGrillaCard();

                if (Session["listaCarrito"] == null)
                {
                    Session["listaCarrito"] = new List<DetalleVenta>();

                }

            }

            carritoCompra = (List<DetalleVenta>)Session["listaCarrito"];

            Master.actualizarContador(carritoCompra.Count);

          
            string script = $"document.getElementById('{Master.FindControl("lblContadorCarrito").ClientID}').innerText = '{carritoCompra.Count}';";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "ActualizarBadge", script, true);
        }

        protected void btnDetalle_Click(object sender, EventArgs e)
        {
           int valor = int.Parse(((Button)sender).CommandArgument);

           ProductoNegocio negocioP = new ProductoNegocio();
           MarcaNegocio negocioM = new MarcaNegocio();
           CategoriaNegocio negocioC = new CategoriaNegocio();
           StockNegocio negocioStk = new StockNegocio();
           
            Producto prod = negocioP.buscarProduc(valor);    
            Marca marca = negocioM.buscarMarca(prod.Marca);
            Categoria categoria = negocioC.buscarCategoria(prod.Categoria);
            

            btnAgregarModal.CommandArgument = valor.ToString() ;
            lblModalCategoria.Text = categoria.Descripcion;
            lblModalMarca.Text = marca.Descripcion; 
            lblModalNombre.Text = prod.Nombre;
            lblModalDescripcion.Text = prod.Descripcion;
            lblModalPrecio.Text = prod.Precio.ToString("C");
            if (prod.OnDemand)
            {
                LblModalDisponibles.Text ="OnDemand";
            }
            else
            {
                Stock stk = negocioStk.buscarStock(valor);
                if (stk != null && stk.Cantidad > 0) {
                     LblModalDisponibles.Text = stk.Cantidad.ToString();
                }
                else
                {
                    LblModalDisponibles.Text ="Sin stock";
                }

            }

                UpdatePanelModal.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "var myModal = new bootstrap.Modal(document.getElementById('productoModal')); myModal.show();", true);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int seleccionProd = int.Parse(btn.CommandArgument);

            agregarProducto(seleccionProd);

            aplicarFiltroActual();

         }


        private Producto buscarProducto(int id)
        {
            DetalleVenta detaven =null;
            Producto prod = null;
            List<Producto> listaProd = (List < Producto > )Session["listaprod"];

            foreach (Producto item in listaProd)
            {
                if (id == item.IdProducto)
                {
                    prod = item;
                    return prod;
                }
            }
            return prod;
        }


        private void cargarGrillaCard()
        {
            reapet.DataSource = Session["listaprod"];
            reapet.DataBind();
        }

      
        public string ObtenerImagenProducto(int idProducto)
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

        protected void btnAgregarModal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idSeleccion = int.Parse(btn.CommandArgument);
            agregarProducto(idSeleccion);
            
            aplicarFiltroActual();
            UpdatePanelModal.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarModal", "bootstrap.Modal.getInstance(document.getElementById('productoModal')).hide();", true);
        }



        private void aplicarFiltroActual()
        {
            if (ViewState["filtroActual"] != null)
            {
                int filtro = (int)ViewState["filtroActual"];
                cargaFiltrada(filtro);
            }
            else
            {
                cargarGrillaCard();
            }
        }


        private void agregarProducto(int seleccionProd)
        {

            carritoCompra = (List<DetalleVenta>)Session["listaCarrito"];

            DetalleVenta detaven = new DetalleVenta();
            Producto pro = buscarProducto(seleccionProd);
            bool enlista = false;

            foreach ( DetalleVenta item in carritoCompra)
            {
                if(item.IdProducto == pro.IdProducto)
                {
                    enlista = true;
                    item.Cantidad++;
                    item.Subtotal = item.Cantidad * item.PrecioUnitario;
                    break;
                }
            }


            if(!enlista) 
             {
                detaven.IdProducto = pro.IdProducto;
                detaven.PrecioUnitario = pro.Precio;
                detaven.Cantidad = 1;
                detaven.Subtotal = pro.Precio * detaven.Cantidad;
                carritoCompra.Add(detaven);

             }


            Session["listaCarrito"] = carritoCompra;

            int totalActual = carritoCompra.Count;


            // Forzamos la actualización mediante el ScriptManager 
            string idControl = Master.ObtenerIdContador();
            string script = $"document.getElementById('{idControl}').innerText = '{totalActual}';";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ActualizarBadgeKey", script, true);

        }

        protected void btnFiltroTodo_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            int filtro = int.Parse(btn.CommandArgument);
            ViewState["filtroActual"] = filtro;
            cargaFiltrada(filtro);

        }



        private void cargaFiltrada(int filtro)
        {

            if (filtro > 0 && filtro <7)
            {
                List<Producto> listaP = (List<Producto>)Session["listaprod"];
                List<Producto> listAux = new List<Producto>();
                foreach (Producto prod in listaP)
                {
                    if (prod.IdProducto == filtro)
                    {
                        listAux.Add(prod);
                    }
                }

                reapet.DataSource = listAux;
                reapet.DataBind();
            }
            else
            {
                cargarGrillaCard();
            }


        }



    }

}

