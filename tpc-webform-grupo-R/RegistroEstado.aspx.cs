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
    public partial class RegistrarEstado : System.Web.UI.Page
    {
        public string titulo = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["estadoAModificar"] != null)
                {
                    Estado estadoAModificar = (Estado)Session["estadoAModificar"];
                    txtDescripcionEstado.Text = estadoAModificar.Descripcion_estado;
                    ViewState["modificar"] = true;
                    titulo= "Modificar Estado";
                    btnRegistrarEstado.Text = "Guardar";
                }
                else
                {
                    ViewState["modificar"] = false;
                    titulo= "Registrar Estado";
                    btnRegistrarEstado.Text = "Registrar ";
                }

                    
            }


        }

        protected void btnRegistrarEstado_Click(object sender, EventArgs e)
        {
            EstadoNegocio estadoN = new EstadoNegocio();
            Estado estadonuevo = new Estado();
            estadonuevo.Descripcion_estado = txtDescripcionEstado.Text;

            if ((bool)ViewState["modificar"])
            {
                Estado estadoAModificar = (Estado)Session["estadoAModificar"];
                estadonuevo.IdEstado = estadoAModificar.IdEstado;
                estadoN.modificarEstado(estadonuevo);
            }
            else
            {
                estadoN.agregarEstado(estadonuevo);

            }
           
            Response.Redirect("Administrar.aspx");

        }
    }
}