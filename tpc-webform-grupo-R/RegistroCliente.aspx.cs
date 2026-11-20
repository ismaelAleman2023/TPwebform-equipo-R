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
        Cliente clieActivo = null;
        public string UrlVolver = null;
        public string textInicio = null;
        public string textFinal = null;
        public RegistroCliente()
        {

        }


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["clienteAModificar"]!=null) { 
                
                Cli = (Cliente)Session["clienteAModificar"];
                }
                else {
                clieActivo = (Cliente)Session["usuarioActivo"];
                
                }

                if (Session["EsAgregar"] != null &&(bool)Session["EsAgregar"])
                {

                    ViewState["modificar"] = false;
                    tipo.InnerText = "Registrarse";
                    btnRegistrar.Text = "Registrarse";
                    subtitulo.InnerText = "Creá tu cuenta en V.DorregoDesign, completa los Datos";

                    textInicio = "<--- Volver a ";
                    textFinal = "Admistrador";
                    UrlVolver = "Administrar.aspx";

                }
                else if (Cli != null)
                {
                    cargarDatosCliente();
                    ViewState["modificar"] = true;
                    tipo.InnerText = "Modificar Cliente";
                    btnRegistrar.Text = "Guardar";
                    subtitulo.InnerText = "Modifique los datos y haga click en 'Guardar' .";
                    
                    textInicio = "<--- Volver a ";
                    textFinal = "Admistrador";
                    UrlVolver = "Administrar.aspx";

                }
                else if (clieActivo != null)
                {
                    cargarDatosCliente();
                    ViewState["modificar"] = true;
                    tipo.InnerText = "Modificar perfil";
                    btnRegistrar.Text = "Guardar";
                    subtitulo.InnerText = "Modifique los datos y haga click en 'Guardar' .";
                    txtPassword.ReadOnly = true;
                    UrlVolver = (string)Session["VolverPerfil"];
                    textInicio = "<--- Volver a ";
                    textFinal = "Perfil";
                }



            }
        }

        private void cargarDatosCliente()
        {

            if (Session["clienteAModificar"] != null)
            {

                Cli = (Cliente)Session["clienteAModificar"];
            }
            else
            {
                clieActivo = (Cliente)Session["usuarioActivo"];

            }
            if (Cli != null)
            {

                txtNombre.Text = Cli.Nombre;
                txtApellido.Text = Cli.Apellido;
                txtCorreo.Text = Cli.Email;
                txtTelefono.Text = Cli.Telefono;
                if (Cli.Password != null)
                {
                    txtPassword.Text = Cli.Password;
                    txtPassword.Attributes["value"] = Cli.Password;
                }

                txtFechaNacimiento.Text = Cli.FechaDeNacimiento.ToString("yyyy-MM-dd");

            }
            else if (clieActivo != null)
            {

                txtNombre.Text = clieActivo.Nombre;
                txtApellido.Text = clieActivo.Apellido;
                txtCorreo.Text = clieActivo.Email;
                txtTelefono.Text = clieActivo.Telefono;

                if (clieActivo.Password != null)
                {
                    txtPassword.Text = clieActivo.Password;
                    txtPassword.Attributes["value"] = clieActivo.Password;
                }
                txtFechaNacimiento.Text = clieActivo.FechaDeNacimiento.ToString("yyyy-MM-dd");

            }
        }

        protected System.Web.UI.WebControls.Button btnRegistrar;



        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {
                ClienteNegocio cliN = new ClienteNegocio();
                bool esModificar = false;

                if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                {
                    esModificar = true;
                }

                if (string.IsNullOrWhiteSpace(txtPassword.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaPass", "mostrarCartel('¡La contraseña es obligatoria!', 'error');", true);
                    return;
                }

                string numTele ="+54"+ txtTelefono.Text.Trim();
                if (!validarTelefono(numTele))
                {
                    return;
                }

                string correo = txtCorreo.Text.Trim();

                int estadoFecha = validarFechaNacimiento(txtFechaNacimiento.Text);
                if (estadoFecha == 1)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaMenorEdad", "mostrarCartel('Debe ser mayor de 18 años', 'error');", true);
                    return;
                }
                else if (estadoFecha == 0)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaFechaNac", "mostrarCartel('Fecha de nacimiento inválida', 'error');", true);
                    return;
                }
                else if (estadoFecha == 3)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaFechaFutura", "mostrarCartel('La fecha de nacimiento no puede ser mayor a la actual', 'error');", true);
                    return;
                }

                if (esModificar)
                {
                    Cli = (Cliente)Session["clienteAModificar"];
                    clieActivo = (Cliente)Session["usuarioActivo"];

                    if (Cli != null)
                    {
                        if (correo != Cli.Email && Helper.Ayudante.validarCorreo(correo))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
                            return;
                        }

                        Cli.Nombre = txtNombre.Text;
                        Cli.Apellido = txtApellido.Text;
                        Cli.Email = correo;
                        Cli.Telefono = numTele;
                        Cli.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            Cli.Password = txtPassword.Text;
                        }

                        cliN.modificarCliente(Cli, Cli.IdPersona);
                        Session["IdCliente"] = Cli.IdPersona;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente modificado correctamente!', 'success');", true);
                        Response.Redirect("Administrar.aspx");
                        return;
                    }

                    if (clieActivo != null)
                    {
                        if (correo != clieActivo.Email && Helper.Ayudante.validarCorreo(correo))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
                            return;
                        }

                        clieActivo.Nombre = txtNombre.Text;
                        clieActivo.Apellido = txtApellido.Text;
                        clieActivo.Email = correo;
                        clieActivo.Telefono = numTele;
                        clieActivo.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            clieActivo.Password = txtPassword.Text;
                        }

                        cliN.modificarCliente(clieActivo, clieActivo.IdPersona);
                        Session["IdCliente"] = clieActivo.IdPersona;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente modificado correctamente!', 'success');", true);
                        Response.Redirect("Perfil.aspx");
                        return;
                    }
                }
                else
                {
                    if (Helper.Ayudante.validarCorreo(correo))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
                        return;
                    }

                    Cliente cli1 = new Cliente();
                    cli1.Nombre = txtNombre.Text;
                    cli1.Apellido = txtApellido.Text;
                    cli1.Email = correo;
                    cli1.Telefono = numTele;
                    cli1.Password = txtPassword.Text;
                    cli1.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                    cliN.AgregarCliente(cli1);
                    Session["IdCliente"] = cli1.IdPersona;
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente agregado correctamente!', 'success');", true);
                    Response.Redirect("Administrar.aspx");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




        private bool validarTelefono(string numTele)
        {
            bool esValido = numTele != null && numTele.Length == 10 && numTele[0] == '+';

            for (int i = 1; i < numTele.Length && esValido; i++)
            {
                if (!char.IsDigit(numTele[i]))
                {
                    esValido = false;
                }
            }

            if (!esValido)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaTel", "mostrarCartel('El teléfono debe tener un + y 12 números', 'error');", true);
            }

            return esValido;
        }


        private int validarFechaNacimiento(string fechanacim) {

            DateTime fechaNac;

            if (!DateTime.TryParse(fechanacim, out fechaNac))
            {
                return 0;//invalida fecha
            }

            fechaNac = fechaNac.Date;
            DateTime hoy = DateTime.Today;
           
            if (fechaNac > hoy)
            {
                return 3; // Fecha futura (mayor a la actual)
            }


            int edad = hoy.Year - fechaNac.Year;

            if (hoy.Month < fechaNac.Month || (hoy.Month == fechaNac.Month && hoy.Day < fechaNac.Day))
            {
                edad--;
            }

            if (edad < 18)
            {
               
                return 1;//menor de edad
            }

            return 2;//es mayor de edad y esta bien la fecha

        }

    }
}
