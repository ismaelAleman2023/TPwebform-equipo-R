using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Helper;
namespace tpc_webform_grupo_R
{
    public partial class RegistroMarca : System.Web.UI.Page
    {
        Marca marc = null;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {


                marc = (Marca)Session["MarcaModi"];
                if (marc != null)
                {

                    txtDescripcionMarca.Text = marc.Descripcion;
                    ViewState["modi"] = true;
                    h2Titulo.InnerText = "Modificar Marca";
                    btnRegistrarMarca.Text = "Modificar";
                }
                else
                {


                    ViewState["modi"] = false;
                    h2Titulo.InnerText = "Registrar Marca";
                    btnRegistrarMarca.Text = "Registrar";


                }




            }




        }

        protected void btnRegistrarMarca_Click(object sender, EventArgs e)
        {
            string nombreMarca = txtDescripcionMarca.Text;
            MarcaNegocio mar = new MarcaNegocio();
            Marca marc = null;


            if (Ayudante.ValidarNoNumero(nombreMarca))
            {

                lblMensajeMarca.Text = "El nombre de la marca no puede contener numeros.";
                return;

            }


            try
            {
                bool esModificar = false;

                if (ViewState["modi"] != null && (bool)ViewState["modi"] == true)
                {

                    esModificar = true;

                }

                if (esModificar)
                {
                    marc = (Marca)Session["MarcaModi"];


                if (mar.existeOtraMarca(nombreMarca,marc.IdMarca))
                {

                    lblMensajeMarca.Text = "Ya esta registrado una marca con ese nombre.";
                    return;


                }

                }
                else{
                
                marc=new Marca();
                }

                marc.Descripcion = nombreMarca;



                if (esModificar) {

                    mar.modificar(marc);

                    lblMensajeMarca.Text = "¡Marca modificada correctamente!";
                    lblMensajeMarca.CssClass = "small fw-semibold text-success";

                }
                else
                {
                    if (mar.existeOtraMarca(nombreMarca, marc.IdMarca))
                    {

                        lblMensajeMarca.Text = "Ya esta registrado una marca con ese nombre.";
                        return;


                    }

                    mar.AgregarMarca(marc);

                    lblMensajeMarca.Text = "¡Marca Agregada correctamente!";
                    lblMensajeMarca.CssClass = "small fw-semibold text-success";

                }



                Session.Remove("MarcaModi");
                ViewState["modi"]= false;

               

            }
            catch (Exception)
            {

                throw;
            }

        }
    }
}