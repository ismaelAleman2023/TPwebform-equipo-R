using dominio;
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
        public int idpedi=0;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) {

                if (Request.QueryString["detalleVenta"] !=null) {

                    string idVenta = Request.QueryString["detalleVenta"];
                    int idv = int.Parse(idVenta);
                    cargarDetalle(idv);
                }
                else {

                    Response.Redirect("MisPedidos.aspx", false);
                }
               
            }


        }

        protected void btnVolver_Click(object sender, EventArgs e)
        {

            Response.Redirect("MisPedidos.aspx", false);
        }

        private void cargarDetalle(int idVenta) {

            DetalleVentaNegocio detaVenta = new DetalleVentaNegocio();
            ProductoNegocio produN=new ProductoNegocio();


              var listDetalles = detaVenta.buscarDetalleVentas(idVenta).Select(d => new { 
              d.IdDetalleVenta,
              d.IdVenta_Detalle,
              NombreProducto = Helper.Ayudante.idxNproduc(d.IdProducto),
              d.PrecioUnitario,
              d.Subtotal,
              d.Cantidad
              }).ToList();



            repDetalleProductos.DataSource = listDetalles;
            repDetalleProductos.DataBind();

            VentaNegocio ventN=new VentaNegocio();

            EstadoNegocio estaN=new EstadoNegocio();
            DireccionNegocio direN=new DireccionNegocio();
            Venta ven= ventN.buscarVenta(idVenta);
            DetalleVenta deta=detaVenta.buscarDetalleVenta(idVenta);
            
            //direccion 

            Direccion dire= direN.buscarDireccion(ven.idDireccion);
           
            string DirecActiva= dire.Calle.ToString() + " " + dire.Numero.ToString();

            idpedi = ven.IdVenta_V;
            if (ven != null) {

                lblFecha.Text = ven.FechaVenta_V.ToString("dd/MM/yyyy");
                lblTotal.Text = ven.TotalPago_V.ToString("C");
                lblTipoPago.Text = ven.TipoPago_V.ToString();
                lblEstado.Text = estaN.buscarEstado(ven.EstadoPedido_v).ToString();
                lblDireccionEnvio.Text = DirecActiva;
                

            }



        }
    }
}