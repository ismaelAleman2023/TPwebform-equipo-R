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
            try
            {
                string descripcion = txtDescripcionEstado.Text.Trim();
                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    lblMensajeEstado.Text = "La descripción es obligatoria.";
                    return;
                }
                if (descripcion.Length > 25)
                {
                    lblMensajeEstado.Text = "La descripción puede tener hasta 25 caracteres.";
                    return;
                }

                EstadoNegocio estadoN = new EstadoNegocio();
                Estado estadonuevo = new Estado();
                estadonuevo.Descripcion_estado = descripcion;
                bool modificar = ViewState["modificar"] != null && (bool)ViewState["modificar"];
                Estado estadoAModificar = Session["estadoAModificar"] as Estado;

                if (modificar && estadoAModificar == null)
                {
                    Session["error"] = "No se encontró el estado a modificar.";
                    Response.Redirect("Error.aspx", false);
                    return;
                }

                int idExcluido = modificar ? estadoAModificar.IdEstado : 0;
                if (estadoN.ExisteDescripcion(descripcion, idExcluido))
                {
                    lblMensajeEstado.Text = "Ya existe un estado con esa descripción.";
                    return;
                }

                if (modificar)
                {
                    estadonuevo.IdEstado = estadoAModificar.IdEstado;
                    estadoN.modificarEstado(estadonuevo);
                }
                else
                {
                    estadoN.agregarEstado(estadonuevo);
                }

                Response.Redirect("Administrar.aspx", false);
            }
            catch (Exception)
            {
                Session["error"] = "No pudimos guardar el estado. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}