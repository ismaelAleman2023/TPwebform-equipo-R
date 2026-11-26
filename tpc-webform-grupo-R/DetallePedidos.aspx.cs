using dominio;
using Helper;
using negocio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class DetallePedidos : System.Web.UI.Page
    {
        public int idpedi = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {

                    if (Session["RolActivo"] != null && Request.QueryString["detalleVenta"] != null)
                    {
                        if (int.TryParse(Request.QueryString["detalleVenta"], out int idv))
                        {
                            cargarDetalle(idv);
                        }
                        else
                        {
                            Response.Redirect("MisPedidos.aspx", false);
                            return;
                        }
                    }
                    else
                    {
                        Response.Redirect("MisPedidos.aspx", false);
                        return;
                    }

                }

            }
            catch (Exception ex)
            {

                if (Session["RolActivo"] != null && (int)Session["RolActivo"] == 2)
                {
                    Session["error"] = "No pudimos cargar el detalle del pedido. Intentá de nuevo más tarde.";
                }
                else
                {
                    Session["error"] = Ayudante.aTexto(ex);
                }

                Response.Redirect("Error.aspx", false);
                return;
            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

            if ((int)Session["RolActivo"] == 2)
            {

                Response.Redirect("MisPedidos.aspx", false);
                return;
            }
            else
            {

                Response.Redirect("AdministrarPedidos.aspx", false);
                return;

            }
        }

        private void cargarDetalle(int idVenta)
        {
            try
            {
                DetalleVentaNegocio detaVenta = new DetalleVentaNegocio();

                var listDetalles = detaVenta.buscarDetalleVentas(idVenta).Select(d => new
                {
                    d.IdDetalleVenta,
                    d.IdVenta_Detalle,
                    NombreProducto = Helper.Ayudante.idxNproduc(d.IdProducto),
                    d.PrecioUnitario,
                    d.Subtotal,
                    d.Cantidad
                }).ToList();



                repDetalleProductos.DataSource = listDetalles;
                repDetalleProductos.DataBind();

                VentaNegocio ventN = new VentaNegocio();
                Venta ven = ventN.buscarVenta(idVenta);

                if (ven != null)
                {
                    EstadoNegocio estaN = new EstadoNegocio();
                    DireccionNegocio direN = new DireccionNegocio();
                    TipoPagoNegocio tipopago = new TipoPagoNegocio();
                    TipoPago tp = tipopago.buscarTipoPago(ven.TipoPago_V);

                    idpedi = ven.IdVenta_V;
                    lblFecha.Text = ven.FechaVenta_V.ToString("dd/MM/yyyy");
                    lblTotal.Text = ven.TotalPago_V.ToString("C");
                    lblTipoPago.Text = tp != null ? tp.Descripcion : "";
                    lblEstado.Text = estaN.buscarEstado(ven.EstadoPedido_v).ToString();

                    if (ven.TipoEnvio == 1)
                    {
                        Direccion dire = direN.buscarDireccion(ven.idDireccion);
                        lblDireccionEnvio.Text = dire != null ? dire.Calle + " " + dire.Numero : "No especificada";
                        lblTipoEnvio.Text = "Con Envio";
                    }
                    else if (ven.TipoEnvio == 0)
                    {
                        lblDireccionEnvio.Text = "Retiro por el local";
                        lblTipoEnvio.Text = "Retiro";
                    }
                }

            }
            catch (Exception ex)
            {

                if (Session["RolActivo"] != null && (int)Session["RolActivo"] == 2)
                {
                    Session["error"] = "No pudimos cargar el detalle del pedido. Intentá de nuevo más tarde.";
                }
                else
                {
                    Session["error"] = Ayudante.aTexto(ex);
                }

                Response.Redirect("Error.aspx", false);
                return;
            }



        }
    }
}