using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using negocio;

namespace tpc_webform_grupo_R
{
    public partial class DireccionEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    cargarCard();
                }
            }
            catch (Exception)
            {
                Session["error"] = "No pudimos cargar las direcciones. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }

        }

        protected void btnAgregarDire_Click(object sender, EventArgs e)
        {           
            Response.Redirect("RegistroDireccion.aspx", false);
            return;
        }

        protected void btnGuardarDireccion_Click(object sender, EventArgs e)
        {

            try
            {
                if (Session["idActivo"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                int idDire = idDireSeleccionado();
                if (!esDireccionPropia(idDire))
                {
                    lblErrorDireccionEnvio.Text = "Elegí una de tus direcciones.";
                    return;
                }

                actualizarEleccion(idDire);

                if (Session["esPerfil"] != null && (bool)Session["esPerfil"] == true)
                {
                    Session.Remove("esPerfil");
                    Response.Redirect("Perfil.aspx", false);
                    return;
                }
                else
                {
                    Response.Redirect("FinalizarCompra.aspx", false);
                    return;
                }
            }
            catch (Exception)
            {
                Session["error"] = "No pudimos guardar la dirección elegida. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }
        }



        private int idDireSeleccionado()
        {
            int idDireccion;
            if (int.TryParse(Request.Form["grupoDireccion"], out idDireccion))
            {
                return idDireccion;
            }

            return 0;
        }

        private bool esDireccionPropia(int idDireccion)
        {
            List<Direccion> propias = Session["direccionActivo"] as List<Direccion>;
            if (propias == null)
            {
                return false;
            }
            foreach (Direccion d in propias)
            {
                if (d.IdDireccion == idDireccion)
                {
                    return true;
                }
            }
            return false;
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (Session["esPerfil"] == null || !(bool)Session["esPerfil"])
            {


                Response.Redirect("FinalizarCompra.aspx", false);
                return;

            }
            else
            {

                Response.Redirect("Perfil.aspx", false);
                return;
            }
        }


        private void cargarCard()
        {

            if(Session["direccionActivo"] !=null)
            {
                List<Direccion> dire = (List<Direccion>) Session["direccionActivo"];
                repetDire.DataSource= dire;
                repetDire.DataBind();

            }

            
        }




        private void actualizarEleccion(int idDireccion)
        {
            DireccionNegocio direN = new DireccionNegocio();


            direN.direccionDesactivar((int)Session["idActivo"]);

            direN.direccionReActivar(idDireccion);

        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["idActivo"] == null)
                {
                    Response.Redirect("Login.aspx", false);
                    return;
                }

                int idDire = idDireSeleccionado();
                if (!esDireccionPropia(idDire))
                {
                    lblErrorDireccionEnvio.Text = "Elegí una de tus direcciones para eliminarla.";
                    return;
                }

                DireccionNegocio direN = new DireccionNegocio();
                direN.EliminarDireccion(idDire);
                Session["direccionActivo"] = direN.buscarDireccionCliente((int)Session["idActivo"]);
                cargarCard();
            }
            catch (Exception)
            {
                Session["error"] = "No pudimos eliminar la dirección. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }
        }
    }
}