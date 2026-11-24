using dominio;
using Helper;
using negocio;
using System;

namespace tpc_webform_grupo_R
{
    public partial class RegistroRol : System.Web.UI.Page
    {
        public string titulo = "Registrar Rol";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    Rol rol = Session["rolAModificar"] as Rol;
                    ViewState["modificar"] = rol != null;
                    if (rol != null)
                    {
                        txtDescripcionRol.Text = rol.Descripcion;
                        btnRegistrarRol.Text = "Guardar";
                    }
                }

                if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                {
                    titulo = "Modificar Rol";
                }

            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnRegistrarRol_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtDescripcionRol.Text.Trim();
                RolNegocio rolN = new RolNegocio();

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    lblMensajeRol.Text = "La descripcion es obligatoria.";
                    return;
                }

                if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                {
                    Rol rol = Session["rolAModificar"] as Rol;
                    if (rol == null)
                    {

                        Session["error"] = "No se encontró el rol a modificar.";
                        Response.Redirect("Error.aspx", false);
                        return;

                    }


                    if (rolN.ExisteOtraDescripcion(descripcion, rol.IdRol))
                    {
                        lblMensajeRol.Text = "Ya esta registrado un rol con esa descripcion.";
                        return;
                    }
                    rol.Descripcion = descripcion;
                    rolN.modificarRol(rol);
                    Session.Remove("rolAModificar");
                    Response.Redirect("Administrar.aspx", false);
                    return;
                }

                if (rolN.ExisteDescripcion(descripcion))
                {
                    lblMensajeRol.Text = "Ya esta registrado un rol con esa descripcion.";
                    return;
                }

                Rol nuevo = new Rol();
                nuevo.Descripcion = descripcion;

                rolN.AgregarRol(nuevo);
                lblMensajeRol.Text = "Rol agregado correctamente.";
                txtDescripcionRol.Text = string.Empty;

            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }
    }

}
