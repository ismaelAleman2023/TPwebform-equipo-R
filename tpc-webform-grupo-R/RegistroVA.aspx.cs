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
        //int valor = 0;
        

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                
                if (Session["vendedorAModificar"] != null || Session["adminAModificar"] != null)
                {
                    ViewState["modificar"] = true;

                    if (Session["btnAgregar"] != null)
                    {
                        int valor = (int)Session["btnAgregar"];
                        cargarTexto(valor, true);
                                               
                        if (valor == 6 && Session["vendedorAModificar"] != null)
                        {
                            cargarDatosVendedor((Vendedor)Session["vendedorAModificar"]);
                        }
                        else if (valor == 7 && Session["adminAModificar"] != null)
                        {
                            cargarDatosAdministrador((Administrador)Session["adminAModificar"]);
                        }
                    }
                }
                else
                {
                  
                    ViewState["modificar"] = false;

                    if (Session["btnAgregar"] != null)
                    {
                        int valor = (int)Session["btnAgregar"];
                        cargarTexto(valor, false);
                    }
                }
            }
        

        }


        private void cargarTexto(int valor , bool modificar)
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
            else {

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
            txtNombre.Text = ven.Nombre;
            txtApellido.Text = ven.Apellido;
            txtCorreo.Text = ven.Email;
            txtTelefono.Text = ven.Telefono;
            txtPassword.Text = ven.Password;
            txtFechaNacimiento.Text = ven.FechaDeNacimiento.ToString("yyyy-MM-dd");
            txtLegajo.Text = ven.Legajo;
        }

        private void cargarDatosAdministrador(Administrador admin)
        {
            txtNombre.Text = admin.Nombre;
            txtApellido.Text = admin.Apellido;
            txtCorreo.Text = admin.Email;
            txtTelefono.Text = admin.Telefono;
            txtPassword.Text = admin.Password;
            txtFechaNacimiento.Text = admin.FechaDeNacimiento.ToString("yyyy-MM-dd");
            txtCuit.Text = admin.Cuil.ToString();
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            VendedorNegocio venN = new VendedorNegocio();
            AdministrarNegocio adminN = new AdministrarNegocio();

            if (Session["btnAgregar"]!=null){

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
                    Administrador admin = new Administrador();
                    admin.Nombre = txtNombre.Text;
                    admin.Apellido = txtApellido.Text;
                    admin.Email = txtCorreo.Text;
                    admin.Telefono = txtTelefono.Text;
                    admin.Password = txtPassword.Text;
                    admin.FechaDeNacimiento = DateTime.Parse(txtFechaNacimiento.Text);
                    admin.Cuil = txtCuit.Text;  
                    adminN.agregarAdministrador(admin);

                }

            }
           
            Response.Redirect("administrar.aspx");


        }
    }
}