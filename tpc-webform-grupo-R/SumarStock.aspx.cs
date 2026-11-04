using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class SumarStock : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack) { 
            if (Session["NombreProducto"] != null && !string.IsNullOrEmpty(Session["NombreProducto"].ToString()))
            {
                lblNombreProducto.Text = Session["NombreProducto"].ToString();
            }
            else
            {
                lblNombreProducto.Text = "Producto sin nombre";
            }
            
            
            }
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {

        }
    }
}