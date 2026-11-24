using dominio;
using Helper;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
            try
            {
                if (!IsPostBack)
                {
                    if (Session["clienteAModificar"] != null)
                    {

                        Cli = (Cliente)Session["clienteAModificar"];
                    }
                    else
                    {
                        clieActivo = (Cliente)Session["usuarioActivo"];

                    }

                    if (Session["EsAgregar"] != null && (bool)Session["EsAgregar"])
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
                        if (Session["VolverPerfil"] != null)
                        {
                            UrlVolver = Session["VolverPerfil"].ToString();
                        }

                        textInicio = "<--- Volver a ";
                        textFinal = "Perfil";
                    }



                }

            }
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;

            }
        }

        private void cargarDatosCliente()
        {
            try
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
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
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

                string numTele = "+54" + txtTelefono.Text.Trim();
                if (!validarTelefono(numTele))
                {
                    return;
                }

                string nombre = txtNombre.Text.Trim();
                string apellido = txtApellido.Text.Trim();
                string correo = txtCorreo.Text.Trim();

                if (string.IsNullOrWhiteSpace(nombre) || string.IsNullOrWhiteSpace(apellido) || string.IsNullOrWhiteSpace(correo))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCampos", "mostrarCartel('Complete nombre, apellido y correo', 'error');", true);
                    return;
                }

                DateTime fechaNac;
                if (!DateTime.TryParse(txtFechaNacimiento.Text, out fechaNac))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaFechaParse", "mostrarCartel('Fecha de nacimiento inválida', 'error');", true);
                    return;
                }

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

                    if (Cli == null && clieActivo == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaSesionCliente", "mostrarCartel('No se encontraron los datos del cliente a modificar', 'error');", true);
                        return;
                    }

                    if (Cli != null)
                    {
                        if (correo != Cli.Email && Helper.Ayudante.validarCorreo(correo))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
                            return;
                        }

                        Cli.Nombre = nombre;
                        Cli.Apellido = apellido;
                        Cli.Email = correo;
                        Cli.Telefono = numTele;
                        Cli.FechaDeNacimiento = fechaNac;

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            Cli.Password = txtPassword.Text;
                        }

                        cliN.modificarCliente(Cli, Cli.IdPersona);
                        Session["IdCliente"] = Cli.IdPersona;
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente modificado correctamente!', 'success');", true);
                        Response.Redirect("Administrar.aspx", false);
                        return;
                    }

                    if (clieActivo != null)
                    {
                        if (correo != clieActivo.Email && Helper.Ayudante.validarCorreo(correo))
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
                            return;
                        }

                        clieActivo.Nombre = nombre;
                        clieActivo.Apellido = apellido;
                        clieActivo.Email = correo;
                        clieActivo.Telefono = numTele;
                        clieActivo.FechaDeNacimiento = fechaNac;

                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            clieActivo.Password = txtPassword.Text;
                        }

                        cliN.modificarCliente(clieActivo, clieActivo.IdPersona);
                        Session["IdCliente"] = clieActivo.IdPersona;
                        Response.Redirect("Perfil.aspx", false);
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
                    cli1.Nombre = nombre;
                    cli1.Apellido = apellido;
                    cli1.Email = correo;
                    cli1.Telefono = numTele;
                    cli1.Password = txtPassword.Text;
                    cli1.FechaDeNacimiento = fechaNac;

                    cliN.AgregarCliente(cli1);
                    Session["IdCliente"] = cli1.IdPersona;
                    Response.Redirect("Administrar.aspx", false);
                    return;
                }
            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }




        private bool validarTelefono(string numTele)
        {
            bool esValido = !string.IsNullOrEmpty(numTele) && numTele.Length == 13 && numTele[0] == '+';

            for (int i = 1; i < numTele.Length && esValido; i++)
            {
                if (!char.IsDigit(numTele[i]))
                {
                    esValido = false;
                }
            }

            if (!esValido)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaTel", "mostrarCartel('El teléfono debe tener +54 y 10 números', 'error');", true);
            }

            return esValido;
        }


        private int validarFechaNacimiento(string fechanacim)
        {

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
