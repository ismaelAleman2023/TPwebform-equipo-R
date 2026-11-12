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
                cargarDireccion();
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

        private void cargarDireccion()
        {
            if (Session["rolActivo"]!= null && (int)Session["rolActivo"] == 2)
            {
                DireccionNegocio direN = new DireccionNegocio();
                List<Direccion> listaDire = direN.buscarDireccionCliente((int)Session["idActivo"]);
                btnPagarYFinalizar.Enabled = true;
                btnDireccion.Enabled = true;

                if (listaDire.Count > 0)
                {
                    Session["direccionActivo"] = listaDire;
                    foreach (Direccion item in listaDire)
                    {
                        if (item.estado)
                        {
                            btnDireccion.Text = "cambiar direccion";
                            lblDireccionEnvio.Text = item.Calle.ToString() + " " + item.Numero.ToString();

                        }

                    }
                }
                else
                {
                    Session["direccionActivo"] = null;
                    lblDireccionEnvio.Text = "No posee";
                    btnDireccion.Text = "agregar Direccion";
                }
            }
            else
            {
                Session["direccionActivo"] = null;
                lblDireccionEnvio.Text = "No posee";
                btnDireccion.Text = "agregar Direccion";
                btnDireccion.Enabled = false;
                btnPagarYFinalizar.Enabled = false;
            }
        }



    
        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            DireccionNegocio direN = new DireccionNegocio();

            List<Direccion> listaDire = direN.buscarDireccionCliente((int)Session["idActivo"]);

            if (Session["direccionActivo"] == null)
            {
                Response.Redirect("RegistroDireccion.aspx");
               
            }
            else
            {
                Response.Redirect("DireccionEnvio.aspx");
            }


        }

           

        protected void rbRetiroTienda_CheckedChanged(object sender, EventArgs e)
        {
            if (rbRetiroTienda.Checked)
            {
                pnlDireccionEnvio.Enabled = false;
                pnlDireccionEnvio.CssClass = "opacity-50";
                Session["conEnvio"] = false;

            }
            else if (rbConEnvio.Checked)
            {
                pnlDireccionEnvio.Enabled = true;
                pnlDireccionEnvio.CssClass = "";
                Session["conEnvio"]=true;            
            }


        }
            

        

        protected void btnPagarYFinalizar_Click(object sender, EventArgs e)
        {
                  
            
          
            
        }

    }
}