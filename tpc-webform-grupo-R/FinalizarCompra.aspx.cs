using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using dominio;
using Microsoft.Ajax.Utilities;
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
                        
           

            List<TipoPago> listaPago = pagoN.ListarTipoPago(1);

            repetformaPago.DataSource = listaPago;
            repetformaPago.DataBind();
        }


        private int formaDePago()
        {
            string valorSeleccionado = Request.Form["grupoPago"];

            if (string.IsNullOrEmpty(valorSeleccionado))
                return 1;

            return int.TryParse(valorSeleccionado, out int eleccion) ? eleccion : 1;
        }

        private void cargarResumen()
        {
            List<DetalleVenta> listaDetalle = (List<DetalleVenta>) Session["listaCarrito"];

            lblCantidadItems.Text= listaDetalle.Count.ToString();
            decimal envio = calcularEnvio();
            lblSubtotal.Text =subTotal(listaDetalle).ToString("C");
            lblCostoEnvio.Text = envio.ToString("C");
            lblTotalGeneral.Text= (subTotal(listaDetalle) + envio).ToString("C");

            decimal descuento = subTotal(listaDetalle) * (aplicarDescuento() / 100m);
            lblDescuento.Text = " - " + descuento.ToString("C");

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

        private decimal calcularEnvio()
        {
            if (!rbConEnvio.Checked || Session["direccionUso"] == null)
            {
                return 0;
            }
            return new EnvioNegocio().calcularCostoEnvio((Direccion)Session["direccionUso"]);
        }

        private decimal totalPago()
        {
            List<DetalleVenta> listaDetalle = (List<DetalleVenta>)Session["listaCarrito"];

            decimal total = 0;

            if(listaDetalle.Count>0 || listaDetalle != null)
            {
               return total = subTotal(listaDetalle) + calcularEnvio();

            }

            return total;

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
                            Session["direccionUso"]= item ;

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

            if (Session["listaCarrito"] != null)
            {
                cargarResumen();
            }


        }




        protected void btnPagarYFinalizar_Click(object sender, EventArgs e)
        {
            DireccionNegocio direN = new DireccionNegocio();
            VentaNegocio venN = new VentaNegocio();
            DetalleVentaNegocio detaN = new DetalleVentaNegocio();
            Venta ven = new Venta();
            Direccion dir = null;


            if (formaDePago()<1 || formaDePago()>3)
            {
                mostrarMensaje("¡Debe elegir una forma de pago!");
                return;

            }
                      

            if (rbConEnvio.Checked)
            {
                 dir = (Direccion)Session["direccionUso"];
               
                if (dir != null)
                {
                    ven.idDireccion = dir.IdDireccion;
                }
                else
                {
                    
                    ven.idDireccion = 0; 
                }
                                
            }else
            {
                ven.idDireccion = 0; 
            }

           
            List<DetalleVenta> listaCarrito = (List<DetalleVenta>)Session["listaCarrito"];

            ven.FechaVenta_V = DateTime.Now;
            ven.Estado_V =true;
            ven.TotalPago_V = totalPago();
            ven.EstadoPedido_v = 0;
            ven.IdCliente_V = (int)Session["idActivo"];
  
            ven.TipoPago_V = formaDePago();
            ven.TipoEnvio = rbConEnvio.Checked ? 1 : 0;

            venN.agregar(ven);

            int idVenta= venN.ultimoIdVenta();

            if (listaCarrito != null)
            {
                foreach (DetalleVenta item in listaCarrito)
                {
                    item.IdVenta_Detalle = idVenta;
                    detaN.agregar(item);
                }

               
                Session.Remove("listaCarrito");
            }

            mostrarMensaje("Venta agregada correctamente");

            Response.Redirect("MisPedidos.aspx");

            //agregar redireccion y cartel de exito
        }


        private void mostrarMensaje(string mensaje)
        {
            lblerror.Text = mensaje;
            lblerror.Style["display"] = "inline"; 

            string script = $"limpiarLabel('{lblerror.ClientID}', 2);";
            ScriptManager.RegisterStartupScript(this, this.GetType(), "borrarLabel", script, true);
        }


        private int aplicarDescuento()
        {
            int fPago = formaDePago();
            int descuento = 0;
            if (fPago == 1)
            {
                descuento = 10;
            }
            else if (fPago == 3 )
            {
                descuento = 5;
            }

            return descuento;
        }

     
    }
}