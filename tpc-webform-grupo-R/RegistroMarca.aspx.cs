using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
namespace tpc_webform_grupo_R
{
    public partial class RegistroMarca : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


        }

        protected void btnRegistrarMarca_Click(object sender, EventArgs e)
        {
            string nombreMarca=txtDescripcionMarca.Text;
            MarcaNegocio mar =new MarcaNegocio();
            

            if (Ayudante.ValidarNoNumero(nombreMarca)) 
            {

                lblMensajeMarca.Text = "El nombre de la marca no puede contener numeros.";
                return;
 
            }


            if (mar.ExisteDescripcion(nombreMarca))
            {

                lblMensajeMarca.Text = "Ya esta registrado una marca con ese nombre.";
                return;


            }

            Marca nmarca=new Marca();

            nmarca.Descripcion=nombreMarca;

            mar.AgregarMarca(nmarca);
            lblMensajeMarca.Text = "Marca Agregada Correctamente.";

        }
    }
}