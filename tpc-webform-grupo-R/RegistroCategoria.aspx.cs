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
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnRegistrarCategoria_Click(object sender, EventArgs e)
        {
            CategoriaNegocio cateNego= new CategoriaNegocio();
            string nombre = txtRegistrarCategoria.Text;

        
            if (cateNego.existeCategoria(nombre)) {

                LblMensajeError.Text = "Ya esta registrado una categoria con ese nombre.";
                return;

            }

            Categoria cate= new Categoria();

            cate.Descripcion = nombre;

            cateNego.AgregarCategoria(cate);

            LblMensajeError.Text = "Categoria Agregada Correctamente.";
        }
    }
}