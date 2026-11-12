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
    public partial class DireccionEnvio : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                cargarCard();


            }

        }

        protected void btnAgregarDire_Click(object sender, EventArgs e)
        {           
            Response.Redirect("RegistroDireccion.aspx");
        }

        protected void btnGuardarDireccion_Click(object sender, EventArgs e)
        {

            int idDire = idDireSeleccionado();

                actualizarEleccion(idDire);

                Session["IdDireccionEnUso"] = idDire;

            
            if (!(bool)Session["esPerfil"] || Session["esPerfil"]==null) { 
            
            
            Response.Redirect("FinalizarCompra.aspx");
            
            }
            else{

                Response.Redirect("Perfil.aspx");

            }
          
        }



        private int idDireSeleccionado()
        {
            int idDireccion = 0;
            string idSeleccionado = Request.Form["grupoDireccion"];
            if (!string.IsNullOrEmpty(idSeleccionado))
            {
                idDireccion = int.Parse(idSeleccionado);

                return idDireccion;
            }

            return 0;
        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            if (!(bool)Session["esPerfil"] || Session["esPerfil"] == null)
            {


                Response.Redirect("FinalizarCompra.aspx");

            }
            else
            {

                Response.Redirect("Perfil.aspx");

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
            DireccionNegocio direN = new DireccionNegocio();
            int idDire = idDireSeleccionado();
            direN.EliminarDireccion(idDire);


            Session["direccionActivo"] = direN.buscarDireccionCliente((int)Session["idActivo"]);

            cargarCard();

        }
    }
}