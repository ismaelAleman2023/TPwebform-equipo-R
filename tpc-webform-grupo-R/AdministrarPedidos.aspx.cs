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
    public partial class AdministrarPedidos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Session["usuarioActivo"] != null && (int)Session["rolActivo"] == 3 || Session["usuarioActivo"] != null && (int)Session["rolActivo"] == 1 ) {
                    cargarDetalle();                  

                }
                else
                {
                    repPedidosVendedor.Visible = true;
                    lblSinPedidos.Text = "No tiene ningun pedido";
                    lblSinPedidos.Visible = true;
                }                        
            
            
            }

        }

      

        protected void repPedidosVendedor_ItemCommand(object source, RepeaterCommandEventArgs e)
        {

            if (e.CommandName == "ActualizarEstado") {

                int idVenta = Convert.ToInt32(e.CommandArgument);

                DropDownList ddlList = (DropDownList)e.Item.FindControl("ddlEstado");


                if (ddlList != null) {

                    int estadoNuevo = Convert.ToInt32(ddlList.SelectedValue);



                    VentaNegocio ventaN = new VentaNegocio();

                    ventaN.modificarEstadoPedido(idVenta, estadoNuevo);


                    cargarDetalle();
                }


            } else if (e.CommandName == "VerDetalle") {


                int idVenta = Convert.ToInt32(e.CommandArgument);

                Response.Redirect("DetallePedidos.aspx?detalleVenta=" + idVenta, false);


            }



        }

        private void cargarDetalle() {



            VentaNegocio ventN = new VentaNegocio();
            EstadoNegocio esta = new EstadoNegocio();
            var listVen = ventN.listarVentas().Where(v => v.EstadoPedido_v != 8 && v.EstadoPedido_v != 9 && v.EstadoPedido_v != 10 )
                .Select(v => new
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


                repPedidosVendedor.DataSource = listVen;
                repPedidosVendedor.DataBind();
                repPedidosVendedor.Visible = true;
                lblSinPedidos.Visible = false;
            }
            else
            {
                repPedidosVendedor.Visible = false;
                lblSinPedidos.Text = "No tiene ningun pedido";
                lblSinPedidos.Visible = true;

            }





        }

        protected void repPedidosVendedor_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {

            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                // Buscamos el DropDownLis
                DropDownList ddlEstado = (DropDownList)e.Item.FindControl("ddlEstado");

                if (ddlEstado != null)
                {
                    // Lo cargamos
                    EstadoNegocio esta = new EstadoNegocio();
                    ddlEstado.DataSource = esta.listarEstados();
                    ddlEstado.DataTextField = "Descripcion_estado";
                    ddlEstado.DataValueField = "IdEstado";
                    ddlEstado.DataBind();
                }
            }


        }
    }
}