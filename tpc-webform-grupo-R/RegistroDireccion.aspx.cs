using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tpc_webform_grupo_R
{
    public partial class RegistroDireccion : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProvincia.DataSource = new UbicacionNegocio().listarProvincias();
                ddlProvincia.DataTextField = "Nombre";
                ddlProvincia.DataValueField = "Id";
                ddlProvincia.DataBind();
                ddlProvincia.Items.Insert(0, new ListItem("Elegi una provincia", ""));
            }
        }

        protected void ddlProvincia_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlProvincia.SelectedValue == "")
            {
                ddlLocalidad.Items.Clear();
                return;
            }
            ddlLocalidad.DataSource = new UbicacionNegocio().listarLocalidades(ddlProvincia.SelectedValue);
            ddlLocalidad.DataTextField = "Nombre";
            ddlLocalidad.DataValueField = "Id";
            ddlLocalidad.DataBind();
        }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {
            if (ddlLocalidad.SelectedItem == null)
            {
                lblErrorDireccion.Text = "Elegí una provincia y una localidad.";
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
         
            

              Response.Redirect("DireccionEnvio.aspx");      

            


        }





    }
}
