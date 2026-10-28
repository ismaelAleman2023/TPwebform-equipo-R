using System;
using dominio;
using negocio;

namespace tpc_webform_grupo_R
{
    public partial class RegistroDireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            Direccion dir = new Direccion();
            DireccionNegocio dirN = new DireccionNegocio();
            dir.Calle = txtCalle.Text;
            dir.Numero = txtNumero.Text;
            dir.CodigoPostal = txtCodigoPostal.Text;
            dir.Localidad = txtLocalidad.Text;
            dir.Provincia = txtProvincia.Text;
            dir.Observacion = txtObservacion.Text;

            if (Session["IdCliente"] == null)
            {
                Response.Redirect("RegistroCliente.aspx");
                return;
            }

            dir.IdCliente = (int)Session["IdCliente"];
            dirN.agregarDireccion(dir);
            Response.Redirect("Default.aspx");
        }
    }
}
