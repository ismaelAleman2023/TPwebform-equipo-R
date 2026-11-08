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
       
        private List<Producto> carritoCompra; 
        
        
      
        protected void Page_Load(object sender, EventArgs e)
        {                                     
            ProductoNegocio negocio = new ProductoNegocio();
            List<Producto>listaProductos = negocio.listarProduc();

            if (!IsPostBack)
            {
                Session["listaprod"] = listaProductos;

                cargarGrillaCard();

                if (Session["listaCarrito"] == null)
                {
                    Session["listaCarrito"] = new List<Producto>();

                }
            }

            carritoCompra = (List<Producto>)Session["listaCarrito"];

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
           
            Producto prod = negocioP.buscarProduc(valor);    
            Marca marca = negocioM.buscarMarca(prod.Marca);
            Categoria categoria = negocioC.buscarCategoria(prod.Categoria);

            btnAgregarModal.CommandArgument = valor.ToString() ;
            lblModalCategoria.Text = categoria.Descripcion;
            lblModalMarca.Text = marca.Descripcion; 
            lblModalNombre.Text = prod.Nombre;
            lblModalDescripcion.Text = prod.Descripcion;
            lblModalPrecio.Text = prod.Precio.ToString("C");

            UpdatePanelModal.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "var myModal = new bootstrap.Modal(document.getElementById('productoModal')); myModal.show();", true);
        }

        protected void btnAgregar_Click(object sender, EventArgs e)
        {

            Button btn = (Button)sender;
            int seleccionProd = int.Parse(btn.CommandArgument);

            agregarProducto(seleccionProd);

            cargarGrillaCard();

         }


        private Producto buscarProducto(int id)
        {
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

        protected void btnAgregarModal_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            int idSeleccion = int.Parse(btn.CommandArgument);
            agregarProducto(idSeleccion);
            
            cargarGrillaCard();
            UpdatePanelModal.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "CerrarModal", "bootstrap.Modal.getInstance(document.getElementById('productoModal')).hide();", true);
        }
            
        



        private void agregarProducto(int seleccionProd)
        {
            carritoCompra = (List<Producto>)Session["listaCarrito"];

            carritoCompra.Add(buscarProducto(seleccionProd));

            Session["listaCarrito"] = carritoCompra;

            int totalActual = carritoCompra.Count;


            // Forzamos la actualización mediante el ScriptManager 
            string idControl = Master.ObtenerIdContador();
            string script = $"document.getElementById('{idControl}').innerText = '{totalActual}';";

            ScriptManager.RegisterStartupScript(this, this.GetType(), "ActualizarBadgeKey", script, true);

        }



    }

}

