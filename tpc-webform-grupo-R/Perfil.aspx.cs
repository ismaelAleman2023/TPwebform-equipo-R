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
    public partial class Perfil : System.Web.UI.Page
    {
        Cliente clie = null;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                clie = (Cliente)Session["usuarioActivo"];

                cargarDireccion();
                if (clie != null)
                {
                    Session["VolverPerfil"] = "Perfil.aspx";
                    txtNombre.Text = clie.Nombre;
                    txtApellido.Text = clie.Apellido;
                    txtEmail.Text = clie.Email;
                    txtTelefomo.Text = clie.Telefono;


                }
                else
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtTelefomo.Text = "";



                }

            }


        }



        protected void btnEditarDireccion_Click(object sender, EventArgs e)
        {
            Response.Redirect("DireccionEnvio.aspx");

        }

        protected void btnEditarFoto_Click(object sender, EventArgs e)
        {





        }

        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {
            Session["EsAgregar"] = false;
            Response.Redirect("RegistroCliente.aspx");
        }


        private void cargarDireccion()
        {

            try
            {

                if (Session["rolActivo"] != null && (int)Session["rolActivo"] == 2)
                {
                    DireccionNegocio direN = new DireccionNegocio();
                    List<Direccion> listaDire = direN.buscarDireccionCliente((int)Session["idActivo"]);

                    if (listaDire.Count > 0)
                    {
                        Session["direccionActivo"] = listaDire;
                        foreach (Direccion item in listaDire)
                        {
                            if (item.estado)
                            {

                                txtDireccion.Text = item.Calle.ToString() + " " + item.Numero.ToString();

                            }

                        }
                    }
                    else
                    {
                        Session["direccionActivo"] = null;
                        txtDireccion.Text = "No posee";

                    }
                }
                else
                {
                    Session["direccionActivo"] = null;
                    txtDireccion.Text = "No posee";
                    btnEditarDireccion.Enabled = false;

                }
            }
            catch (Exception)
            {

                throw;
            }
        }




    }
}