using dominio;
using negocio;
using System;

namespace tpc_webform_grupo_R
{
    public partial class RegistroTipoPago : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegistrarTipoPago_Click(object sender, EventArgs e)
        {
            string descripcion = txtDescripcionTipoPago.Text.Trim();
            TipoPagoNegocio tpN = new TipoPagoNegocio();

            if (string.IsNullOrWhiteSpace(descripcion))
            {
                lblMensajeTipoPago.Text = "La descripcion es obligatoria.";
                return;
            }

            if (tpN.ExisteDescripcion(descripcion))
            {
                lblMensajeTipoPago.Text = "Ya esta registrado un tipo de pago con esa descripcion.";
                return;
            }

            TipoPago nuevo = new TipoPago();
            nuevo.Descripcion = descripcion;

            tpN.AgregarTipoPago(nuevo);
            lblMensajeTipoPago.Text = "Tipo de pago agregado correctamente.";
            txtDescripcionTipoPago.Text = string.Empty;
        }
    }
}
