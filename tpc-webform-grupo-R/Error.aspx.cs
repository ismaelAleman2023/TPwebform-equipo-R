using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["error"] != null)
                {
                    lblError.Text = Ayudante.aTexto(Session["error"]);
                    Session.Remove("error");
                }
                else
                {
                    lblError.Text = "No se encontró ningún detalle de error.";
                }
            }




        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("Default.aspx", false);
            return;

        }
    }
}