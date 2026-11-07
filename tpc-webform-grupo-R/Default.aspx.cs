using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;



namespace tpc_webform_grupo_R
{
    public partial class Default : System.Web.UI.Page
    {
        public List<Producto> listaProductos;
      
        protected void Page_Load(object sender, EventArgs e)
        {

            ProductoNegocio negocio = new ProductoNegocio();
                           
            listaProductos = negocio.listarProduc();
          
            
            Session.Add("listaProductos", listaProductos);
            
            if (!IsPostBack)
            {               
                reapet.DataSource = listaProductos;
                reapet.DataBind();
            }



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

            lblModalCategoria.Text = categoria.Descripcion;
            lblModalMarca.Text = marca.Descripcion; 
            lblModalNombre.Text = prod.Nombre;
            lblModalDescripcion.Text = prod.Descripcion;
            lblModalPrecio.Text = prod.Precio.ToString("C");

            UpdatePanel1.Update();

            ScriptManager.RegisterStartupScript(this, this.GetType(), "Pop", "var myModal = new bootstrap.Modal(document.getElementById('productoModal')); myModal.show();", true);
        }
    }

}

