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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {

            try
            {
                if (Session["usuarioActivo"] == null)
                {
                    ClienteNegocio cliN = new ClienteNegocio();

                    string correo = txtCorreoLogin.Text.Trim();
                    string pass = txtPassword.Text.Trim();
                    if (string.IsNullOrWhiteSpace(correo) || string.IsNullOrWhiteSpace(pass))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaVacios", "mostrarCartel('Ingresá tu correo y contraseña.', 'Alert');", true);
                        return;
                    }
                    int idPersona = 0;
                    int rol = 0;


                    if (!cliN.validarInicio(correo, pass, ref idPersona, ref rol))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Correo o Pasword incorrecto!', 'Alert');", true);
                        return;
                    }

                    Session["idActivo"] = idPersona;


                    if (rol == 1)
                    {
                        AdministrarNegocio adminN = new AdministrarNegocio();
                        Session["usuarioActivo"] = adminN.buscarAdministrador(idPersona);
                    }
                    else if (rol == 2)
                    {
                        Session["usuarioActivo"] = cliN.buscarCliente(idPersona);
                    }
                    else if (rol == 3)
                    {
                        VendedorNegocio venN = new VendedorNegocio();
                        Session["usuarioActivo"] = venN.buscarVendedor(idPersona);

                    }



                    Session["rolActivo"] = rol;

                    if (Session["urlVolver"] != null)
                    {
                        string url = Session["urlVolver"].ToString();
                        Session.Remove("urlVolver");
                        Response.Redirect(url, false);
                        return;

                    }
                    else
                    {
                        Response.Redirect("Default.aspx",false);
                        return;
                    }

                }



            }
            catch (Exception)
            {

                Session["error"] = "No pudimos iniciar sesión en este momento. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx",false);
                return;
            }


        }

        protected void lnkBtnRegistrarse_Click(object sender, EventArgs e)
        {
            Session["EsAgregar"] = true;
            Response.Redirect("RegistroCliente.aspx", false);
            return;
        }





    }
}