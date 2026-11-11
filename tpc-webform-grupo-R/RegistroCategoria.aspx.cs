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
    public partial class RegistroCategoria : System.Web.UI.Page
    {
       Categoria cate = null;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                cate = (Categoria)Session["CategoriaModi"];
                if (cate != null)
                {

                    h2Titulo.InnerText = "Modificar Categoria";
                    txtRegistrarCategoria.Text = cate.Descripcion;
                    ViewState["modi"] = true;
                    BtnRegistrarCategoria.Text = "Modificar";


                }
                else
                {


                    ViewState["modi"] = false;
                    h2Titulo.InnerText = "Registrar Categoria";
                    BtnRegistrarCategoria.Text = "Registrar";

                }


            }


        }

        protected void BtnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio cateNego = new CategoriaNegocio();

            try
            {
                string nombre = txtRegistrarCategoria.Text;

                bool esModificar = false;

                if (ViewState["modi"] !=null && (bool)ViewState["modi"] == true) {

                    esModificar = true;
                
                }

                if (esModificar)
                {
                    


                    cate = (Categoria)Session["CategoriaModi"];

                    if (cateNego.existeOtraCategoria(nombre, cate.IdCategoria))
                    {
                        LblMensajeError.Text = "Ya está registrada otra categoría con ese nombre.";
                        return;
                    }

                }
                else { 
                
              
                    cate = new Categoria();

                }

                cate.Descripcion = nombre;

                if (esModificar)
                {
                    cateNego.Modificar(cate);
                    LblMensajeError.Text = "Categoria Modificada Correctamente.";
                    LblMensajeError.CssClass = "small fw-semibold text-success";

                }
                else {

                    if (cateNego.existeOtraCategoria(nombre, cate.IdCategoria))
                    {

                        LblMensajeError.Text = "Ya esta registrado una categoria con ese nombre.";
                        return;

                    }


                    cateNego.AgregarCategoria(cate);
                    LblMensajeError.Text = "Categoria Agregada Correctamente.";
                    LblMensajeError.CssClass = "small fw-semibold text-success";

                }



                Session.Remove("CategoriaModi");
                ViewState["modi"] = false;

            }
            catch (Exception)
            {

                throw;
            }




        }
    }
}