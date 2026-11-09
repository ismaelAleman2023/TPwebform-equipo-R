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

        Cliente Cli = null;
        public RegistroCliente()
        {
            
        }

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cli = (Cliente)Session["clienteAModificar"];

                if (Cli != null)
                {                   
                    cargarDatosCliente();
                    ViewState["modificar"] = true;
                    tipo.InnerText = "Modificar Cliente";
                    btnRegistrar.Text = "Guardar";
                    subtitulo.InnerText = "Modifique los datos y haga click en 'Guardar' .";
                }
                else
                {
                    ViewState["modificar"] = false;
                    tipo.InnerText = "Registrarse";
                    btnRegistrar.Text = "Registrarse";
                    subtitulo.InnerText = "Creá tu cuenta en V.DorregoDesign, completa los Datos";
                }
            }
        }

        private void cargarDatosCliente()
        {            
                txtNombre.Text = Cli.Nombre;
                txtApellido.Text = Cli.Apellido;
                txtCorreo.Text = Cli.Email;
                txtTelefono.Text = Cli.Telefono;
                txtPassword.Text = Cli.Password;
                txtFechaNacimiento.Text = Cli.FechaDeNacimiento.ToString("yyyy-MM-dd");
        }

        protected System.Web.UI.WebControls.Button btnRegistrar;

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio cliN = new ClienteNegocio();
               

                if ((bool)ViewState["modificar"])
                {
                    Cli = Session["clienteAModificar"] as Cliente;

                    if (Cli != null)
                    {
                        Cli.Nombre = txtNombre.Text;
                        Cli.Apellido = txtApellido.Text;
                        Cli.Email = txtCorreo.Text;
                        Cli.Telefono = txtTelefono.Text;
                        Cli.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            Cli.Password = txtPassword.Text;
                        }


                        cliN.modificarCliente(Cli, Cli.IdPersona);
                        Session["IdCliente"] = Cli.IdPersona;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente modificado correctamente!', 'success');", true);
                    }
                }
                else

                {

                    if (string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡La contraseña es obligatoria!', 'error');", true);

                        return;
                    }

                    Cliente cli1 = new Cliente();

                    cli1.Nombre = txtNombre.Text;
                    cli1.Apellido = txtApellido.Text;
                    cli1.Email = txtCorreo.Text;
                    cli1.Telefono = txtTelefono.Text;

                    cli1.Password = txtPassword.Text;
                    cli1.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                    cliN.AgregarCliente(cli1);
                    Session["IdCliente"] = cli1.IdPersona;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente agregado correctamente!', 'success');", true);

                }

                Response.Redirect("Administrar.aspx");
            }
            catch (Exception)
            {
                throw;
            }

        }

    }
}
