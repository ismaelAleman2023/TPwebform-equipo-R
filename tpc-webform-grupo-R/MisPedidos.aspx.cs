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
    public partial class MisPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            Cliente cli = (Cliente)Session["usuarioActivo"];
            if (Session["usuarioActivo"] != null)
            {
                VentaNegocio ventN = new VentaNegocio();
                List<Venta> listVen = ventN.buscarVentasXCliente(cli.IdPersona);
                repPedidos.DataSource = listVen;
                repPedidos.DataBind();
            }
            else {

                lblSinPedidos.Text = "No tiene ningun pedido";
            
            
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {

        }
    }
}