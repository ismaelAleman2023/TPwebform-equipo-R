using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

namespace tpc_webform_grupo_R
{
    public partial class Contactanos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnEnviar_Click(object sender, EventArgs e)
        {
            try
            {       

                if(!( string.IsNullOrEmpty(txtCorreo.Text) &&  string.IsNullOrEmpty(txtMensaje.Text) && string.IsNullOrEmpty(txtNombre.Text))) {
                     
               
                    string correo = txtCorreo.Text;
                    string nombre = txtNombre.Text;
                    string mensaje = txtMensaje.Text;

                    EnvioEmail contactanos = new EnvioEmail();

                    contactanos.EnviarConsultaAEquipo(nombre, correo, mensaje);
                
                
                }

                Response.Redirect("Contactanos.aspx");



            }
            catch (Exception)
            {

                throw;
            }


        }
    }
}