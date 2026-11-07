using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using negocio;
using dominio;
namespace tpc_webform_grupo_R
{
    public partial class SumarStock : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {

                if (Session["AgMd"].Equals("agregar"))
                {
                    hTitulo.InnerText = "Sumar Stock";
                    txtCantidad.Text = "Cantidad a agregar:";

                }
                else if (Session["AgMd"].Equals("modificar"))
                {
                    hTitulo.InnerText = "Restar Stock";
                    txtCantidad.Text = "Cantidad a restar:";


                }


                if (Session["NombreProducto"] != null && !string.IsNullOrEmpty(Session["NombreProducto"].ToString()))
                {
                    lblNombreProducto.Text = Session["NombreProducto"].ToString();
                }
                else
                {
                    lblNombreProducto.Text = "Producto sin nombre";
                }


            }
        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            StockNegocio stNego = new StockNegocio();

            try
            {
                int cantidad = int.Parse(txtCantidad.Text);

                Stock st = (Stock)Session["Stock"];

                if ((string)Session["AgMd"] == "agregar")
                {

                    stNego.ModificarStockCantidad(st.IdProducto_stk, cantidad, "+");

                    lblMensaje.Text = "¡Stock actualizado correctamente!";
                    lblMensaje.CssClass = "d-block text-center mt-3 text-success";


                }
                else if ((string)Session["AgMd"] == "modificar") {

                    stNego.ModificarStockCantidad(st.IdProducto_stk, cantidad, "-");

                    lblMensaje.Text = "¡Stock actualizado correctamente!";
                    lblMensaje.CssClass = "d-block text-center mt-3 text-success";


                }

            }
            catch (Exception ex)
            {

                lblMensaje.Text = "Error al actualizar: " + ex.Message;
                lblMensaje.CssClass = "d-block text-center mt-3 fw-bold text-danger";
            }

        }
    }
}