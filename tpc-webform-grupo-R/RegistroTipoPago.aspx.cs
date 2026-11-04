using dominio;
using negocio;
using System;

namespace tpc_webform_grupo_R
{
    public partial class RegistroTipoPago : System.Web.UI.Page
    {
        public string titulo = "Registrar Tipo de Pago";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                TipoPago tp = Session["tipoPagoAModificar"] as TipoPago;
                ViewState["modificar"] = tp != null;
                if (tp != null)
                {
                    txtDescripcionTipoPago.Text = tp.Descripcion;
                    btnRegistrarTipoPago.Text = "Guardar";
                }
            }

            if ((bool)ViewState["modificar"])
            {
                titulo = "Modificar Tipo de Pago";
            }
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

            if ((bool)ViewState["modificar"])
            {
                TipoPago tp = Session["tipoPagoAModificar"] as TipoPago;
                if (tpN.ExisteOtraDescripcion(descripcion, tp.IdTipoPago))
                {
                    lblMensajeTipoPago.Text = "Ya esta registrado un tipo de pago con esa descripcion.";
                    return;
                }
                tp.Descripcion = descripcion;
                tpN.modificarTipoPago(tp);
                Response.Redirect("Administrar.aspx");
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
