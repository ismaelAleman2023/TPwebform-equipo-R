using dominio;
using Helper;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class AgregarVA : System.Web.UI.Page
    {
        public string nombre = string.Empty;
        //int valor = 0;


        protected void Page_Load(object sender, EventArgs e)
        {

            try
            {
                if (Session["btnAgregar"] == null)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaSesion", "mostrarCartel('No se encontró el tipo de registro. Volvé a intentarlo desde Administrar.', 'error');", true);
                    return;
                }

                int valor = (int)Session["btnAgregar"];

                if (!IsPostBack)
                {
                    bool esMod = (Session["vendedorAModificar"] != null || Session["adminAModificar"] != null);
                    ViewState["modificar"] = esMod;

                    if (esMod)
                    {
                        if (valor == 6 && Session["vendedorAModificar"] != null)
                        {
                            cargarDatosVendedor((Vendedor)Session["vendedorAModificar"]);
                            txtLegajo.ReadOnly = true;
                        }
                        else if (valor == 7 && Session["adminAModificar"] != null)
                        {
                            cargarDatosAdministrador((Administrador)Session["adminAModificar"]);
                            txtCuit.ReadOnly = true;
                        }
                        else
                        {
                            ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaDatos", "mostrarCartel('No se pudieron cargar los datos para modificar.', 'error');", true);
                            return;
                        }
                    }
                }

                bool modificarActual = false;
                if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                {
                    modificarActual = true;
                }

                cargarTexto(valor, modificarActual);


            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;


            }
        }


        private void cargarTexto(int valor, bool modificar)
        {
            if (modificar)
            {
                texto3.Visible = false;
                if (valor == 6)
                {
                    nombre = "Modificar Vendedor";
                    legajoOculto.Visible = true;
                    cuitOculto.Visible = false;
                }
                else if (valor == 7)
                {
                    nombre = "Modificar Administrador";
                    legajoOculto.Visible = false;
                    cuitOculto.Visible = true;
                }

                btnRegistrar.Text = "Guardar";

            }
            else
            {

                texto3.Visible = true;
                if (valor == 6)
                {
                    nombre = "Registrar Vendedor";
                    legajoOculto.Visible = true;
                    cuitOculto.Visible = false;
                }
                else if (valor == 7)
                {
                    nombre = "Registrar Administrador";
                    legajoOculto.Visible = false;
                    cuitOculto.Visible = true;
                }

                btnRegistrar.Text = "Registrar";

            }

        }



        private void cargarDatosVendedor(Vendedor ven)
        {
            try
            {
                txtNombre.Text = ven.Nombre;
                txtApellido.Text = ven.Apellido;
                txtCorreo.Text = ven.Email;

                if (ven.Telefono != null && ven.Telefono.StartsWith("+54"))
                {

                    txtTelefono.Text = ven.Telefono.Substring(3);

                }
                else
                {


                    txtTelefono.Text = ven.Telefono;

                }
                if (!string.IsNullOrEmpty(ven.Password))
                {
                    txtPassword.Text = ven.Password;
                    txtPassword.Attributes["value"] = txtPassword.Text;
                }
                txtFechaNacimiento.Text = ven.FechaDeNacimiento.ToString("yyyy-MM-dd");
                txtLegajo.Text = ven.Legajo;

            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        private void cargarDatosAdministrador(Administrador admin)
        {
            try
            {
                txtNombre.Text = admin.Nombre;
                txtApellido.Text = admin.Apellido;
                txtCorreo.Text = admin.Email;

                if (admin.Telefono != null && admin.Telefono.StartsWith("+54"))
                {
                    txtTelefono.Text = admin.Telefono.Substring(3);
                }
                else
                {
                    txtTelefono.Text = admin.Telefono;
                }

                if (!string.IsNullOrEmpty(admin.Password))
                {
                    txtPassword.Text = admin.Password;
                    txtPassword.Attributes["value"] = admin.Password;
                }
                txtFechaNacimiento.Text = admin.FechaDeNacimiento.ToString("yyyy-MM-dd");
                txtCuit.Text = admin.Cuil.ToString();

            }
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            try
            {

                VendedorNegocio venN = new VendedorNegocio();
                AdministrarNegocio adminN = new AdministrarNegocio();

                if (Session["btnAgregar"] != null)
                {
                    int aux = (int)Session["btnAgregar"];
                    bool esModificar = false;

                    if (ViewState["modificar"] != null && (bool)ViewState["modificar"])
                    {
                        esModificar = true;
                    }

                    if (!esModificar && string.IsNullOrWhiteSpace(txtPassword.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaPass", "mostrarCartel('¡La contraseña es obligatoria!', 'error');", true);
                        return;
                    }
                    string nombre = txtNombre.Text.Trim();
                    string apellido = txtApellido.Text.Trim();

                    if (!Ayudante.soloLetrasYEspacios(nombre) || !Ayudante.soloLetrasYEspacios(apellido))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaLetras", "mostrarCartel('Nombre y apellido solo pueden contener letras', 'error');", true);
                        return;
                    }

                    string telIngresado = txtTelefono.Text.Trim();
                    string numTele = telIngresado;
                    
                    
                    
                    
                    if (!telIngresado.StartsWith("+54"))
                    {
                        numTele = "+54" + telIngresado;
                    }

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

                    if (aux == 6) // vendedor
                    {
                        Vendedor ven;

                        if (esModificar)
                        {
                            ven = (Vendedor)Session["vendedorAModificar"];
                            if (ven == null)
                            {
                                return;
                            }

                            if (correo != ven.Email && Helper.Ayudante.validarCorreo(correo))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
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

                            string legajo = txtLegajo.Text.Trim();
                            if (string.IsNullOrWhiteSpace(legajo))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaLegajo", "mostrarCartel('El legajo es obligatorio', 'error');", true);
                                return;
                            }

                            bool legajoRepetido = false;
                            foreach (Vendedor item in venN.listarVendedores(2))
                            {
                                if (item.Legajo != null && item.Legajo.Trim().ToLower() == legajo.ToLower())
                                {
                                    legajoRepetido = true;
                                    break;
                                }
                            }

                            if (legajoRepetido)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaLegajoRep", "mostrarCartel('El legajo ingresado ya se encuentra registrado', 'error');", true);
                                return;
                            }

                            ven = new Vendedor();
                            ven.Legajo = legajo;
                        }

                        ven.Nombre = txtNombre.Text.Trim();
                        ven.Apellido = txtApellido.Text.Trim();
                        ven.Email = correo;
                        ven.Telefono = numTele;
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            ven.Password = txtPassword.Text;
                        }
                        ven.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                        if (esModificar)
                        {
                            venN.modificarVendedor(ven, ven.IdPersona);
                            Session.Remove("vendedorAModificar");
                        }
                        else
                        {
                            venN.agregarVendedor(ven);
                        }
                    }
                    else if (aux == 7) // administrador
                    {
                        Administrador admin;

                        if (esModificar)
                        {
                            admin = (Administrador)Session["adminAModificar"];
                            if (admin == null)
                            {
                                return;
                            }

                            if (correo != admin.Email && Helper.Ayudante.validarCorreo(correo))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCorreo", "mostrarCartel('El correo que ingreso ya se encuentra registrado', 'error');", true);
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

                            string cuil = txtCuit.Text.Trim();
                            if (string.IsNullOrWhiteSpace(cuil))
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCuil", "mostrarCartel('El CUIL es obligatorio', 'error');", true);
                                return;
                            }

                            bool cuilRepetido = false;
                            foreach (Administrador item in adminN.listarAdministradores(2))
                            {
                                if (item.Cuil != null && item.Cuil.Trim().ToLower() == cuil.ToLower())
                                {
                                    cuilRepetido = true;
                                    break;
                                }
                            }

                            if (cuilRepetido)
                            {
                                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCuilRep", "mostrarCartel('El CUIL ingresado ya se encuentra registrado', 'error');", true);
                                return;
                            }

                            admin = new Administrador();
                            admin.Cuil = cuil;
                        }

                        admin.Nombre = txtNombre.Text.Trim();
                        admin.Apellido = txtApellido.Text.Trim();
                        admin.Email = correo;
                        admin.Telefono = numTele;
                        if (!string.IsNullOrWhiteSpace(txtPassword.Text))
                        {
                            admin.Password = txtPassword.Text;
                        }
                        admin.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);

                        if (esModificar)
                        {
                            adminN.modificarAdministrador(admin, admin.IdPersona);
                            Session.Remove("adminAModificar");
                        }
                        else
                        {
                            adminN.agregarAdministrador(admin);
                        }
                    }
                }

                Response.Redirect("administrar.aspx",false);
                return;

            }
            catch (Exception ex) {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;

            }
           
        }


        private bool validarTelefono(string numTele)
        {
            bool esValido = numTele != null && numTele.Length == 13 && numTele[0] == '+';

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