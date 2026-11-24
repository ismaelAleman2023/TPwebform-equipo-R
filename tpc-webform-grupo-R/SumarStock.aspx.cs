using dominio;
using Helper;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace tpc_webform_grupo_R
{
    public partial class SumarStock : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Session["AgMd"] != null && Session["AgMd"].Equals("agregar"))
                    {
                        hTitulo.InnerText = "Sumar Stock";
                        txtCantidad.Text = "Cantidad a agregar:";

                    }
                    else if (Session["AgMd"] != null && Session["AgMd"].Equals("modificar"))
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
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }

        }

        protected void btnSumar_Click(object sender, EventArgs e)
        {
            StockNegocio stNego = new StockNegocio();

            try
            {
                if (!int.TryParse(txtCantidad.Text.Trim(), out int cantidad) || cantidad <= 0)
                {
                    lblMensaje.Text = "Ingresá una cantidad válida mayor a 0.";
                    lblMensaje.CssClass = "d-block text-center mt-3 text-danger";
                    return;
                }

                Stock st = (Stock)Session["Stock"];
                string accion = Session["AgMd"] as string;

                if (accion == "agregar")
                {
                    if (Helper.Ayudante.validadStock(st.Cantidad))
                    {
                        Helper.Ayudante.cambiarEstadoProducto(st.IdProducto_stk, "alta");
                    }

                    stNego.ModificarStockCantidad(st.IdProducto_stk, cantidad, "+");
                }
                else if (accion == "modificar")
                {
                    if (cantidad <= st.Cantidad)
                    {
                        int queda = st.Cantidad - cantidad;

                        if (queda == 0)
                        {
                            Helper.Ayudante.cambiarEstadoProducto(st.IdProducto_stk, "baja");
                        }

                        stNego.ModificarStockCantidad(st.IdProducto_stk, cantidad, "-");
                    }
                    else
                    {
                        lblMensaje.Text = "¡No se puede restar mas del stock total!";
                        lblMensaje.CssClass = "d-block text-center mt-3 text-danger";
                        return;
                    }
                }

                lblMensaje.Text = "¡Stock actualizado correctamente!";
                lblMensaje.CssClass = "d-block text-center mt-3 text-success";
            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }
    }
}