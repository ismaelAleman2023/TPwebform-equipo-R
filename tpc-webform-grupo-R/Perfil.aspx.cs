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
            try
            {
                if (!IsPostBack)
                {
                    int rol = 0;
                    if (Session["rolActivo"] != null)
                    {
                        rol = (int)Session["rolActivo"];
                    }

                    if (rol != 2)
                    {
                        Response.Redirect("default.aspx", false);
                        return;
                    }

                    cargarDireccion();
                    clie = (Cliente)Session["usuarioActivo"];


                    if (clie != null)
                    {
                        Session["VolverPerfil"] = "Perfil.aspx";
                        txtNombre.Text = clie.Nombre;
                        txtApellido.Text = clie.Apellido;
                        txtEmail.Text = clie.Email;
                        txtTelefomo.Text = clie.Telefono;

                        if (clie.FotoPerfil == null)
                        {

                            imgPerfil.ImageUrl = "~/Images/Perfiles/fotoDefault.jpg";


                        }
                        else
                        {

                            imgPerfil.ImageUrl = "~/images/Perfiles/" + clie.FotoPerfil + "?v=" + DateTime.Now.Ticks;


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
            catch (Exception)
            {
                Session["error"] = "No pudimos cargar tu perfil. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }


        }



        protected void btnEditarDireccion_Click(object sender, EventArgs e)
        {

            try
            {
                Session["esPerfil"] = true;
                Response.Redirect("DireccionEnvio.aspx", false);
                return;

            }
            catch (Exception)
            {
                Session["error"] = "No pudimos abrir la edición de dirección. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }


        }
        protected void btnEditarFoto_Click(object sender, EventArgs e)
        {
            try
            {
                //escribir
                if (txtImagenPerf.PostedFile != null && txtImagenPerf.PostedFile.ContentLength > 0)
                {

                    ClienteNegocio clieNe = new ClienteNegocio();
                    string ruta = Server.MapPath("~/images/Perfiles/");
                    Cliente cli = (Cliente)Session["usuarioActivo"];

                    txtImagenPerf.PostedFile.SaveAs(ruta + "Perfil-" + cli.IdPersona + ".jpg");


                    cli.FotoPerfil = "Perfil-" + cli.IdPersona + ".jpg";
                    clieNe.modificarFtPerfil(cli);

                    imgPerfil.ImageUrl = "~/images/Perfiles/" + cli.FotoPerfil + "?v=" + DateTime.Now.Ticks;

                    //leer
                    Image img = (Image)Master.FindControl("imgUserPerfil");

                    if (img != null)
                    {
                        img.ImageUrl = "~/images/Perfiles/" + cli.FotoPerfil + "?v=" + DateTime.Now.Ticks;

                    }
                }




            }
            catch (Exception)
            {
                Session["error"] = "No pudimos actualizar la foto de perfil. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }




        }

        protected void btnEditarDatos_Click(object sender, EventArgs e)
        {

            try
            {
                Session["EsAgregar"] = false;
                Response.Redirect("RegistroCliente.aspx",false);
                return;
            }
            catch (Exception)
            {
                Session["error"] = "No pudimos abrir la edición de tus datos. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }
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
                Session["error"] = "No pudimos cargar tu dirección. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }
        }




    }
}