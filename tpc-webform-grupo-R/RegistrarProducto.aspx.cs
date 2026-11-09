using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class RegistrarProducto : System.Web.UI.Page
    {
        private static List<string> listImg = new List<string>();
        private CategoriaNegocio categoriaNegocio=new CategoriaNegocio();
        private MarcaNegocio marcaNegocio= new MarcaNegocio();
        private static int indiceActual = 0;

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                ddlCategoria.DataSource =categoriaNegocio.listarCate();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "IdCategoria";
                ddlCategoria.DataBind();
                ddlMarca.DataSource=marcaNegocio.ListarMarca();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "IdMarca";
                ddlMarca.DataBind();
                listImg.Clear();
                indiceActual = 0;
                actualizarPreviewImagen(); // <--- Esto carga el estado inicial en cero
            }

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ProductoNegocio proNeg = new ProductoNegocio();
            Producto pro = new Producto();
            StockNegocio st = new StockNegocio();
            Stock stock = new Stock();
      

            if (Helper.Ayudante.esVacio(txtNombre.Text) || Helper.Ayudante.esVacio(txtCodigo.Text) || Helper.Ayudante.esVacio(txtPrecio.Text) 
                || Helper.Ayudante.esVacio(txtDescripcion.Text))
            {

                lblMensaje.Text = "Los campos no pueden estar vacios";
                return;

            }


            string codigo = txtCodigo.Text;
            string nombre = txtNombre.Text;
            string descripcion = txtDescripcion.Text;
            int marca =int.Parse(ddlMarca.SelectedValue);
            int categoria = int.Parse(ddlCategoria.SelectedValue);


            decimal precio = decimal.Parse(txtPrecio.Text);

            if (precio < 1000)
            {
                lblMensaje.Text = "El valor no puede ser inferior a 1000";
                txtPrecio.Text = string.Empty;
                return;
            }

            bool ondemand = chkOnDemand.Checked;
            int cantidad = 0;

            if (!ondemand)
            {
                if (string.IsNullOrEmpty(txtStock.Text))
                {
                    lblMensaje.Text = "Ingrese una cantidad mayor a 0";
                    txtStock.Text = string.Empty;
                    return;
                }

                cantidad = int.Parse(txtStock.Text);
            }

            string tipo = (string)Session["AgMd"];

            try
            {

                if (Helper.Ayudante.ExisteProduc(codigo))
                {
                    lblMensaje.Text = "Esta producto ya se encuentra registrado";
                    txtCodigo.Text = string.Empty;
                    return;
                }

             

                if (Helper.Ayudante.ValidarNoNumero(nombre))
                {
                    lblMensaje.Text = "El nombre no puedo contener un numero";
                    txtNombre.Text = string.Empty;
                    return;
                }

                pro.CodigoProducto = codigo;
                pro.Nombre = nombre;
                pro.Descripcion = descripcion;
                pro.Marca = marca;
                pro.Categoria = categoria;
                pro.Estado = 1;
                pro.Precio = precio;

                List<Imagen> lista = new List<Imagen>();
                foreach (string url in listImg)
                {
                    Imagen img = new Imagen();
                    img.UrlImagen = url;
                    lista.Add(img);
                }
                pro.ListaImagen = lista;

                proNeg.agregarProducto(pro);

                if (!ondemand)
                {
                    int ultiId = proNeg.ultimoId();

                    stock.IdProducto_stk = ultiId;
                    stock.Cantidad = cantidad;
                    stock.Estado = 1;
                    st.agregarStock(stock);
                }

                listImg.Clear();
                indiceActual = 0;

                lblMensaje.Text = "¡Producto agregado correctamente!";
                lblMensaje.CssClass = "small fw-semibold text-success";
            }
            catch (Exception)
            {
                throw;
            }
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string url = txtImagenUrl.Text.Trim();//trim elimina los espacios que pueden haber quedado 
            if (!string.IsNullOrEmpty(url)) {

                listImg.Add(url);
                indiceActual = listImg.Count - 1;
                txtImagenUrl.Text = string.Empty;
                actualizarPreviewImagen();

            }


        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            //verificamos que la lista no este vacia y que el indice sea mayor a 0 pero menor al total de listImg
            if (listImg != null && listImg.Count > 0 && indiceActual >=0 && indiceActual < listImg.Count) {
                
                listImg.RemoveAt(indiceActual);

                if (indiceActual >= listImg.Count && listImg.Count > 0)
                {

                    indiceActual = listImg.Count - 1;

                }
                else {


                    indiceActual = 0;
                
                }

                actualizarPreviewImagen();
            }

        }

        protected void chkOnDemand_CheckedChanged(object sender, EventArgs e)
        {
            pnlStock.Visible = !chkOnDemand.Checked;

        }

    

        protected void actualizarPreviewImagen() {

            if (listImg !=null && listImg.Count>0) {
                if (indiceActual >= listImg.Count)
                {
                    indiceActual = listImg.Count - 1;
                }
                if (indiceActual < 0)
                {
                    indiceActual = 0;
                }

                imgPrevisualizacion.ImageUrl = listImg[indiceActual];

              
                lblContadorImagen.Text = $"{indiceActual + 1} / {listImg.Count}";//se actualiza el contador visual de la cantidad de imagenes y posicion actual

            }
            else{

                imgPrevisualizacion.ImageUrl = "https://us.123rf.com/450wm/koblizeek/koblizeek2204/koblizeek220400315/185376169-no-image-vector-symbol-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg";
                lblContadorImagen.Text = "0 / 0";
                indiceActual = 0;

            }


        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (listImg != null && listImg.Count >0 && indiceActual > 0) {


                if (indiceActual == 0)
                {

                    indiceActual = listImg.Count - 1;

                }
                else { 
                
                indiceActual--;
                
                }


                actualizarPreviewImagen();

            } 


        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {


            if (listImg != null && listImg.Count > 0 ) {

                if (indiceActual != listImg.Count - 1)
                {

                    indiceActual++;

                }
              
                actualizarPreviewImagen();

            }

        }
    }
}