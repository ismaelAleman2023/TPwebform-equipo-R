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
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

        }


        protected void btnLogin_Click(object sender, EventArgs e)
        {
            ClienteNegocio cliN = new ClienteNegocio();

            string correo = txtCorreoLogin.Text;
            string pass = txtPassLogin.Text;
            int idPersona = 0;
            int rol = 0;

            
            if (!cliN.validarInicio(correo, pass, ref idPersona, ref rol))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Correo o Pasword incorrecto!', 'Alert');", true);
                return;
            }
                       

                         
            if(rol == 1)
            {
                AdministrarNegocio adminN = new AdministrarNegocio();
                Session["usuarioActivo"] = adminN.buscarAdministrador(idPersona);
            }
            else if (rol == 2)
            {    
                Session["usuarioActivo"] = cliN.buscarCliente(idPersona);
                Session["idActivo"] = idPersona;
            }
            else if (rol==3)
            {
                VendedorNegocio venN = new VendedorNegocio();
                Session["usuarioActivo"] = venN.buscarVendedor(idPersona);
                
            }


            
            Session["rolActivo"] = rol;

            if (Session["urlVolver"]!= null)
            {                
                Response.Redirect((string)Session["urlVolver"]);
            }
            else
            {
                Response.Redirect("Default.aspx");

            }


        }







    }
}