using dominio;
using negocio;
using System;

namespace tpc_webform_grupo_R
{
    public partial class RegistroRol : System.Web.UI.Page
    {
        public string titulo = "Registrar Rol";

        protected void Page_Load(object sender, EventArgs e)
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

            if ((bool)ViewState["modificar"])
            {
                titulo = "Modificar Rol";
            }
        }

        protected void btnRegistrarRol_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcionRol.Text.Trim();
            RolNegocio rolN = new RolNegocio();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                lblMensajeRol.Text = "La descripcion es obligatoria.";
                return;
            }

            if ((bool)ViewState["modificar"])
            {
                Rol rol = Session["rolAModificar"] as Rol;
                if (rolN.ExisteOtraDescripcion(descripcion, rol.IdRol))
                {
                    lblMensajeRol.Text = "Ya esta registrado un rol con esa descripcion.";
                    return;
                }
                rol.Descripcion = descripcion;
                rolN.modificarRol(rol);
                Response.Redirect("Administrar.aspx");
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
    }
}
