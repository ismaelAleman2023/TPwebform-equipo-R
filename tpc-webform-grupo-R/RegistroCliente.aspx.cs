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
    public partial class RegistroCliente : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }


        protected System.Web.UI.WebControls.Button btnRegistrar;

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                Cliente cli1 = new Cliente();
                ClienteNegocio cliN = new ClienteNegocio();

                cli1.Nombre = txtNombre.Text;
                cli1.Apellido = txtApellido.Text;
                cli1.Email = txtCorreo.Text;
                cli1.Telefono = txtTelefono.Text;
                cli1.Password = txtPassword.Text;
                cli1.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);


                cliN.AgregarCliente(cli1);

               
                ///agregar cartel de exito de registro 

                Response.Redirect("Administrar.aspx");

            }
            catch (Exception)
            {

                throw;
            }

        }

    }
    }
