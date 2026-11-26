using dominio;
using Helper;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        private CategoriaNegocio categoriaNegocio = new CategoriaNegocio();
        private MarcaNegocio marcaNegocio = new MarcaNegocio();
        private static int indiceActual = 0;
        private Producto pro = null;

        public int Max = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    ddlCategoria.DataSource = categoriaNegocio.listarCate(1);
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "IdCategoria";
                    ddlCategoria.DataBind();

                    ddlMarca.DataSource = marcaNegocio.ListarMarca(1);
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "IdMarca";
                    ddlMarca.DataBind();
                    listImg.Clear();

                    pro = (Producto)Session["ProductoAmodificar"];

                    if (pro != null)
                    {
                        CargarProducto();
                        ViewState["modi"] = true;
                        btnRegistrar.Text = "Modificar Producto";
                        txtStock.ReadOnly = true;
                        txtCodigo.ReadOnly = true;
                        chkOnDemand.Enabled = false;
                    }
                    else
                    {
                        listImg.Clear();
                        ViewState["modi"] = false;
                        btnRegistrar.Text = "Registrar Producto";
                        indiceActual = 0;
                    }

                    actualizarPreviewImagen();
                }
            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        public void CargarProducto()
        {
            try
            {
                StockNegocio st = new StockNegocio();

                txtCodigo.Text = pro.CodigoProducto;
                txtNombre.Text = pro.Nombre;
                txtDescripcion.Text = pro.Descripcion;
                txtPrecio.Text = pro.Precio.ToString();

                if (ddlMarca.Items.FindByValue(pro.Marca.ToString()) != null)
                {
                    ddlMarca.SelectedValue = pro.Marca.ToString();
                }

                if (ddlCategoria.Items.FindByValue(pro.Categoria.ToString()) != null)
                {
                    ddlCategoria.SelectedValue = pro.Categoria.ToString();
                }

                chkOnDemand.Checked = pro.OnDemand;

                Stock stNuevo = st.buscarStockProd(pro.IdProducto);
                if (stNuevo != null)
                {
                    txtStock.Text = stNuevo.Cantidad.ToString();
                    Max = stNuevo.Cantidad;
                }
                else
                {
                    txtStock.Text = "0";
                    Max = 0;
                }

                ImagenNegocio imgNeg = new ImagenNegocio();
                List<Imagen> imagenesBD = imgNeg.buscarXcodProduc(pro.IdProducto);

                if (listImg == null)
                {
                    listImg = new List<string>();
                }
                listImg.Clear();

                if (imagenesBD != null && imagenesBD.Count > 0)
                {
                    foreach (Imagen img in imagenesBD)
                    {
                        listImg.Add(img.UrlImagen);
                    }
                    indiceActual = 0;
                }
            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            ProductoNegocio proNeg = new ProductoNegocio();
            Producto pro = new Producto();
            StockNegocio st = new StockNegocio();

            try
            {
                if (Helper.Ayudante.esVacio(txtNombre.Text) || Helper.Ayudante.esVacio(txtCodigo.Text) || Helper.Ayudante.esVacio(txtPrecio.Text)
                    || Helper.Ayudante.esVacio(txtDescripcion.Text))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCamposVacios", "mostrarCartel('Los campos no pueden estar vacios', 'error');", true);
                    return;
                }

                string codigo = "Prod-"+txtCodigo.Text;
                string nombre = txtNombre.Text;
                
                int aux = txtDescripcion.Text.Length;

                if(aux >350)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaCamposVacios", "mostrarCartel('Se a exedido el maximo de caracteres (max 350 caracteres)', 'error');", true);
                    return;
                }                
                

                string descripcion = txtDescripcion.Text;
                int marca = int.Parse(ddlMarca.SelectedValue);
                int categoria = int.Parse(ddlCategoria.SelectedValue);

                decimal precio;
                if (!decimal.TryParse(txtPrecio.Text.Trim(), out precio))
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaPrecioValido", "mostrarCartel('Ingrese un precio válido', 'error');", true);
                    txtPrecio.Text = string.Empty;
                    return;
                }

                if (precio < 1000)
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaPrecioMin", "mostrarCartel('El valor no puede ser inferior a 1000', 'error');", true);
                    txtPrecio.Text = string.Empty;
                    return;
                }

                bool ondemand = chkOnDemand.Checked;
                int cantidad = 0;

                if (!ondemand)
                {
                    if (string.IsNullOrEmpty(txtStock.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaStockVacio", "mostrarCartel('Ingrese una cantidad mayor a 0', 'error');", true);
                        txtStock.Text = string.Empty;
                        return;
                    }

                    if (!int.TryParse(txtStock.Text.Trim(), out cantidad) || cantidad <= 0)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaStockValido", "mostrarCartel('Ingrese una cantidad válida mayor a 0', 'error');", true);
                        txtStock.Text = string.Empty;
                        return;
                    }
                }

                string tipo = (string)Session["AgMd"];
                bool esModificar = false;

                if (ViewState["modi"] != null && (bool)ViewState["modi"] == true)
                {
                    esModificar = true;
                }

                if (esModificar)
                {
                    pro = (Producto)Session["ProductoAmodificar"];

                    if (pro == null)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaProdNull", "mostrarCartel('No se encontraron los datos del producto a modificar.', 'error');", true);
                        return;
                    }

                    if (Helper.Ayudante.ExisteOtroProduc(codigo, pro.IdProducto))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaProdExisteMod", "mostrarCartel('Este producto ya se encuentra registrado', 'error');", true);
                        txtCodigo.Text = string.Empty;
                        return;
                    }
                }

                pro.CodigoProducto = codigo;
                pro.Nombre = nombre;
                pro.Descripcion = descripcion;
                pro.Marca = marca;
                pro.Categoria = categoria;
                pro.Precio = precio;
                pro.OnDemand = ondemand;

                if (esModificar)
                {
                    proNeg.modificarProducto(pro);

                    ImagenNegocio imgn = new ImagenNegocio();
                    imgn.eliminarImagenesXproductos(pro.IdProducto);
                    foreach (string url in listImg)
                    {
                        Imagen imgM = new Imagen();
                        imgM.idProducto_img = pro.IdProducto;
                        imgM.UrlImagen = url;
                        imgn.agregarImagen(imgM);
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaProdModOk", "mostrarCartel('¡Producto modificado correctamente!', 'success');", true);
                }
                else
                {
                    pro.Estado = 1;

                    if (Helper.Ayudante.ExisteProduc(codigo))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaProdExiste", "mostrarCartel('Este producto ya se encuentra registrado', 'error');", true);
                        txtCodigo.Text = string.Empty;
                        return;
                    }

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
                        Stock stock = new Stock();
                        int ultiId = proNeg.ultimoId();
                        stock.IdProducto_stk = ultiId;
                        stock.Cantidad = cantidad;
                        stock.Estado = 1;
                        st.agregarStock(stock);
                    }

                    ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaProdOk", "mostrarCartel('¡Producto agregado correctamente!', 'success');", true);
                }

                listImg.Clear();
                indiceActual = 0;

                Session.Remove("ProductoAmodificar");
                ViewState["modi"] = false;

                txtNombre.ReadOnly = true;
                txtDescripcion.ReadOnly = true;
                txtImagenUrl.ReadOnly = true;
                txtPrecio.ReadOnly = true;

                btnAgregarImagen.Enabled = false;
                btnAnterior.Enabled = false;
                btnEliminarImagen.Enabled = false;
                btnRegistrar.Enabled = false;
                btnSiguiente.Enabled = false;

                ddlCategoria.Enabled = false;
                ddlMarca.Enabled = false;
            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }

        protected void btnAgregarImagen_Click(object sender, EventArgs e)
        {
            string url = txtImagenUrl.Text.Trim();
            if (string.IsNullOrWhiteSpace(url))
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaUrlVacia", "mostrarCartel('Ingrese una URL de imagen válida', 'error');", true);
                return;
            }

            listImg.Add(url);
            indiceActual = listImg.Count - 1;
            txtImagenUrl.Text = string.Empty;
            actualizarPreviewImagen();
        }

        protected void btnEliminarImagen_Click(object sender, EventArgs e)
        {
            if (listImg != null && listImg.Count > 0 && indiceActual >= 0 && indiceActual < listImg.Count)
            {
                listImg.RemoveAt(indiceActual);

                if (indiceActual >= listImg.Count && listImg.Count > 0)
                {
                    indiceActual = listImg.Count - 1;
                }
                else
                {
                    indiceActual = 0;
                }

                actualizarPreviewImagen();
            }
        }

        protected void chkOnDemand_CheckedChanged(object sender, EventArgs e)
        {
            pnlStock.Visible = !chkOnDemand.Checked;
            if (chkOnDemand.Checked)
            {
                txtStock.Text = string.Empty;
            }
        }

        protected void actualizarPreviewImagen()
        {
            if (listImg != null && listImg.Count > 0)
            {
                if (indiceActual >= listImg.Count)
                {
                    indiceActual = listImg.Count - 1;
                }
                if (indiceActual < 0)
                {
                    indiceActual = 0;
                }

                imgPrevisualizacion.ImageUrl = listImg[indiceActual];
                lblContadorImagen.Text = $"{indiceActual + 1} / {listImg.Count}";
            }
            else
            {
                imgPrevisualizacion.ImageUrl = "https://us.123rf.com/450wm/koblizeek/koblizeek2204/koblizeek220400315/185376169-no-image-vector-symbol-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg";
                lblContadorImagen.Text = "0 / 0";
                indiceActual = 0;
            }
        }

        protected void btnAnterior_Click(object sender, EventArgs e)
        {
            if (listImg != null && listImg.Count > 0)
            {
                if (indiceActual == 0)
                {
                    indiceActual = listImg.Count - 1;
                }
                else
                {
                    indiceActual--;
                }

                actualizarPreviewImagen();
            }
        }

        protected void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (listImg != null && listImg.Count > 0)
            {
                if (indiceActual >= listImg.Count - 1)
                {
                    indiceActual = 0;
                }
                else
                {
                    indiceActual++;
                }

                actualizarPreviewImagen();
            }
        }





    }
}