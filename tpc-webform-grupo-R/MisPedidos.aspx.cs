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
    public partial class MisPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Session["usuarioActivo"] != null && (int)Session["rolActivo"] ==2 )
                {
                    Cliente cli = (Cliente)Session["usuarioActivo"];
                    cargarDetalle(cli.IdPersona);
                }
                else
                {
                    repPedidos.Visible = false;
                    lblSinPedidos.Text = "No tiene ningun pedido";
                    lblSinPedidos.Visible = true;
                }
            }
        }

        protected void btnVerDetalle_Click(object sender, EventArgs e)
        {
            int valor = int.Parse(((Button)sender).CommandArgument);
            Response.Redirect("DetallePedidos.aspx?detalleVenta=" + valor, false);

        }


        private void cargarDetalle(int cli)
        {

            VentaNegocio ventN = new VentaNegocio();
            EstadoNegocio esta = new EstadoNegocio();
            var listVen = ventN.buscarVentasXCliente(cli).Select(v => new
            {
                v.IdVenta_V,
                v.IdCliente_V,
                v.FechaVenta_V,
                v.TotalPago_V,
                v.TipoPago_V,
                v.Estado_V,
                EstadoPedido_v = esta.buscarEstado(v.EstadoPedido_v)
            }
                ).ToList();


            if (listVen != null & listVen.Count > 0)
            {


                repPedidos.DataSource = listVen;
                repPedidos.DataBind();
                repPedidos.Visible = true;
                lblSinPedidos.Visible = false;
            }
            else
            {
                repPedidos.Visible = false;
                lblSinPedidos.Text = "No tiene ningun pedido";
                lblSinPedidos.Visible = true;

            }



        }

        private void VerificarRetornoMercadoPago()
        {
            string status = Request.QueryString["status"];
            string externalReference = Request.QueryString["external_reference"];

            if (status == "approved" && int.TryParse(externalReference, out int idVenta))
            {
                VentaNegocio venN = new VentaNegocio();
                venN.actualizarEstadoPago(idVenta, 3); // 3 Pago recibido
            }
        }


    }
}