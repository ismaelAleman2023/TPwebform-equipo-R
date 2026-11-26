using dominio;
using Helper;
using negocio;
using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class RegistroDireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlProvincia.DataSource = new UbicacionNegocio().listarProvincias();
                    ddlProvincia.DataTextField = "Nombre";
                    ddlProvincia.DataValueField = "Id";
                    ddlProvincia.DataBind();
                    if (ddlProvincia.Items.Count == 0)
                    {
                        lblErrorDireccion.Text = "No pudimos cargar las provincias, intentá de nuevo más tarde.";
                    }
                    ddlProvincia.Items.Insert(0, new ListItem("Elegi una provincia", ""));
                }

            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;

            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {

                lblErrorDireccion.Text = "";
                if (ddlProvincia.SelectedValue == "")
                {
                    ddlLocalidad.Items.Clear();
                    return;
                }
                ddlLocalidad.DataSource = new UbicacionNegocio().listarLocalidades(ddlProvincia.SelectedValue);
                ddlLocalidad.DataTextField = "Nombre";
                ddlLocalidad.DataValueField = "Id";
                ddlLocalidad.DataBind();
                if (ddlLocalidad.Items.Count == 0)
                {
                    lblErrorDireccion.Text = "No pudimos cargar las localidades, intentá de nuevo.";
                }
            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idActivo"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCalle.Text) || string.IsNullOrWhiteSpace(txtNumero.Text) || string.IsNullOrWhiteSpace(txtCodigoPostal.Text))
                {
                    lblErrorDireccion.Text = "Completá calle, número y código postal.";
                    return;
                }
                if (txtCalle.Text.Length > 50 || txtNumero.Text.Length > 5 || txtCodigoPostal.Text.Length > 10 || txtObservacion.Text.Length > 300)
                {
                    lblErrorDireccion.Text = "Alguno de los datos es demasiado largo.";
                    return;
                }
                if (ddlLocalidad.SelectedItem == null)
                {
                    lblErrorDireccion.Text = "Elegí una provincia y una localidad.";
                    return;
                }
                if (!new UbicacionNegocio().localidadValida(ddlLocalidad.SelectedItem.Text, ddlProvincia.SelectedValue))
                {
                    lblErrorDireccion.Text = "La localidad no corresponde a la provincia elegida.";
                    return;
                }
                Direccion dir = new Direccion();
                DireccionNegocio dirN = new DireccionNegocio();
                dir.Calle = txtCalle.Text;
                dir.Numero = txtNumero.Text;
                dir.CodigoPostal = txtCodigoPostal.Text;
                dir.Localidad = ddlLocalidad.SelectedItem.Text;
                dir.Provincia = ddlProvincia.SelectedItem.Text;
                dir.Observacion = txtObservacion.Text;



                dir.IdCliente = (int)Session["idActivo"];
                dirN.agregarDireccion(dir);
                Session["direccionActivo"] = dirN.buscarDireccionCliente((int)Session["idActivo"]);
                Response.Redirect("DireccionEnvio.aspx", false);
            }
            catch (Exception)
            {
                Session["error"] = "No pudimos guardar la dirección. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
            }
        }





    }
}
