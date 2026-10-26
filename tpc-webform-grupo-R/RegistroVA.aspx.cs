using dominio;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class AgregarVA : System.Web.UI.Page
    {
        public string nombre = string.Empty;
        int valor = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack && Session["btnAgregar"]!=null)
            {
               valor=(int) Session["btnAgregar"];

                if (valor == 6)
                {
                    nombre = "Vendedor";                    
                }
                else if (valor == 7) {
                    nombre = "Administrador";
                    legajoOculto.Visible = false;
                }

            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            VendedorNegocio venN = new VendedorNegocio();

            if(Session["btnAgregar"]!=null){

                int aux = (int)Session["btnAgregar"];

                if (aux == 6)//vendedor
                {

                    Vendedor ven = new Vendedor();

                    ven.Nombre = txtNombre.Text;
                    ven.Apellido = txtApellido.Text;
                    ven.Email = txtCorreo.Text;
                    ven.Telefono = txtTelefono.Text;
                    ven.Password = txtPassword.Text;
                    ven.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                    ven.Legajo= txtLegajo.Text;
                    venN.agregarVendedor(ven);
                }
                else if (aux== 7)//administrador
                {
                
                }

            }
           
            Response.Redirect("administrar.aspx");


        }
    }
}