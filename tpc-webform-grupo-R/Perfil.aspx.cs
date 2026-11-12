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
                cargarDireccion();

                clie = (Cliente)Session["usuarioActivo"];


                if (clie != null)
                {
                    Session["VolverPerfil"] = "Perfil.aspx";
                    txtNombre.Text = clie.Nombre;
                    txtApellido.Text = clie.Apellido;
                    txtEmail.Text = clie.Email;
                    txtTelefomo.Text = clie.Telefono;

                    if (clie.FotoPerfil ==null) {

                        imgPerfil.ImageUrl= "~/Images/Perfiles/fotoDefault.jpg";


                    }
                    else{

                        imgPerfil.ImageUrl ="~/images/Perfiles/" + clie.FotoPerfil; ;


                    }
                
                }
                else
                {
                    txtNombre.Text = "";
                    txtApellido.Text = "";
                    txtEmail.Text = "";
                    txtTelefomo.Text = "";



                }
                Session.Remove("esPerfil");

            }


        }



        protected void btnEditarDireccion_Click(object sender, EventArgs e)
        {
            Session["esPerfil"] = true;
            Response.Redirect("DireccionEnvio.aspx");

        }

        protected void btnEditarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                //escribir
                if (txtImagenPerf.PostedFile != null && txtImagenPerf.PostedFile.ContentLength >0)
                {

                    ClienteNegocio clieNe = new ClienteNegocio();
                    string ruta = Server.MapPath("~/images/Perfiles/");
                    Cliente cli = (Cliente)Session["usuarioActivo"];

                    txtImagenPerf.PostedFile.SaveAs(ruta + "Perfil-" + cli.IdPersona + ".jpg");


                    cli.FotoPerfil = "Perfil-" + cli.IdPersona + ".jpg";
                    clieNe.modificarFtPerfil(cli);

                    imgPerfil.ImageUrl = "~/images/Perfiles/" + cli.FotoPerfil;

                    //leer
                    Image img = (Image)Master.FindControl("imgUserPerfil");

                    if (img != null)
                    {
                        img.ImageUrl = "~/images/Perfiles/" + cli.FotoPerfil;

                    }
                }
            



            }
            catch (Exception)
            {

                throw;
            }




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