using dominio;
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
        List<Producto> listaProdCarrito;
     
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) 
            {

                if (Session[""] != null)
                {
                    listaProdCarrito = (List<Producto>)Session["listaCarrito"];

                }
                                  
            }

          
        }


        private void cargarCard(List<Producto> listaCarrito)
        {


        }




    }
}