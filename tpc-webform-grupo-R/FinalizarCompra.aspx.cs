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
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack) { 

                cargarTipoPago();
                cargarDireccion(5);
                if (Session["listaCarrito"] == null)
                {
                    cargaInicial();
                }
                else
                {
                 cargarResumen();
                    
                }
            }
        }


        private void cargaInicial()
        {
            lblCantidadItems.Text = "0";
            lblSubtotal.Text = "0";
            lblCostoEnvio.Text = "0";
            lblTotalGeneral.Text = "0";
        }



        private void cargarTipoPago()
        {
            TipoPagoNegocio pagoN = new TipoPagoNegocio();
            List<TipoPago> listaPago = pagoN.ListarTipoPago();

            repetformaPago.DataSource = listaPago;
            repetformaPago.DataBind();                

        }

        private void cargarResumen()
        {
            List<DetalleVenta> listaDetalle = (List<DetalleVenta>) Session["listaCarrito"];

            lblCantidadItems.Text= listaDetalle.Count.ToString();
            lblSubtotal.Text =subTotal(listaDetalle).ToString("C");
            lblCostoEnvio.Text = "0";
            lblTotalGeneral.Text= subTotal(listaDetalle).ToString("C");


        }

        private decimal subTotal(List<DetalleVenta> listadeta)
        {            
            decimal subTotal = 0;

            foreach (DetalleVenta item in listadeta)
            {
                subTotal += item.Subtotal;
            }
            return subTotal;            

        }

        private void cargarDireccion(int idCliente)
        {
            DireccionNegocio direN = new DireccionNegocio();
            List<Direccion> listaDire = direN.buscarDireccionCliente(idCliente);

            if (listaDire.Count > 0)
            {
                btnDireccion.Text = "cambiar direccion";
                lblDireccionEnvio.Text = listaDire[0].Calle.ToString() + " " +listaDire[0].Numero.ToString();
            }
            else
            {
                lblDireccionEnvio.Text = "No posee";
                btnDireccion.Text = "agregar Direccion";

            }
        }

        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            DireccionNegocio direN = new DireccionNegocio();

            ///falta validacion de usuario logueado

            List<Direccion> listaDire = direN.buscarDireccionCliente(3); 

            if (listaDire.Count > 0)
            {
                btnDireccion.Text = "cambiar direccion";
                lblDireccionEnvio.Text = listaDire[0].Calle.ToString() + listaDire[0].Numero.ToString();
            }
            else
            {

                btnDireccion.Text = "agregar Direccion";

            }


        }
    }
}