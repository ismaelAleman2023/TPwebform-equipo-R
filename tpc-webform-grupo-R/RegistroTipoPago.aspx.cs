using dominio;
using Helper;
using negocio;
using System;

namespace tpc_webform_grupo_R
{
    public partial class RegistroTipoPago : System.Web.UI.Page
    {
        public string titulo = "Registrar Tipo de Pago";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
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

                if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                {
                    titulo = "Modificar Tipo de Pago";
                }

            }
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnRegistrarTipoPago_Click(object sender, EventArgs e)
        {
            try
            {
                string descripcion = txtDescripcionTipoPago.Text.Trim();
                TipoPagoNegocio tpN = new TipoPagoNegocio();

                if (string.IsNullOrWhiteSpace(descripcion))
                {
                    lblMensajeTipoPago.Text = "La descripcion es obligatoria.";
                    return;
                }

                if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                {
                    TipoPago tp = Session["tipoPagoAModificar"] as TipoPago;

                    if (tp == null)
                    {
                        Session["error"] = "No se encontró el tipo de pago a modificar. Volvé a intentarlo.";
                        Response.Redirect("Error.aspx", false);
                        return;
                    }

                    if (tpN.ExisteOtraDescripcion(descripcion, tp.IdTipoPago))
                    {
                        lblMensajeTipoPago.Text = "Ya esta registrado un tipo de pago con esa descripcion.";
                        return;
                    }
                    tp.Descripcion = descripcion;
                    tpN.modificarTipoPago(tp);
                    Session.Remove("tipoPagoAModificar");
                    Response.Redirect("Administrar.aspx",false);
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
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

    }
}
