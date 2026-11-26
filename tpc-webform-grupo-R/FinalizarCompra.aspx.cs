using dominio;
using Helper;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MercadoPago.Client.Preference;
using MercadoPago.Config;
using MercadoPago.Resource.Preference;

namespace tpc_webform_grupo_R
{
    public partial class FinalizarCompra : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

                if (!IsPostBack)
                {

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
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
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
            try
            {
                TipoPagoNegocio pagoN = new TipoPagoNegocio();
                List<TipoPago> listaPago = pagoN.ListarTipoPago(1);

                repetformaPago.DataSource = listaPago;
                repetformaPago.DataBind();

            }
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }


        private int formaDePago()
        {
            if (string.IsNullOrEmpty(hfIdTipoPago.Value))
                return 1;

            return int.TryParse(hfIdTipoPago.Value, out int eleccion) ? eleccion : 1;
        }


        private void cargarResumen()
        {
            try
            {
                List<DetalleVenta> listaDetalle = (List<DetalleVenta>)Session["listaCarrito"];

                lblCantidadItems.Text = listaDetalle.Count.ToString();
                decimal envio = calcularEnvio();
                decimal sub = subTotal(listaDetalle);
                decimal descuento = sub * (aplicarDescuento() / 100m);
                lblSubtotal.Text = sub.ToString("C");
                lblCostoEnvio.Text = envio.ToString("C");
                lblTotalGeneral.Text = (sub + envio - descuento).ToString("C");
                lblDescuento.Text = " - " + descuento.ToString("C");


            }
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
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
            try
            {
                if (!rbConEnvio.Checked || Session["direccionUso"] == null)
                {
                    return 0;
                }
                return new EnvioNegocio().calcularCostoEnvio((Direccion)Session["direccionUso"]);

            }
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return 0;
            }
        }

        private decimal totalPago()
        {
            List<DetalleVenta> listaDetalle = (List<DetalleVenta>)Session["listaCarrito"];

            decimal total = 0;

            if (listaDetalle != null && listaDetalle.Count > 0)
            {
                decimal sub = subTotal(listaDetalle);
                decimal descuento = sub * (aplicarDescuento() / 100m);
                return total = sub + calcularEnvio() - descuento;
            }

            return total;

        }





        private void cargarDireccion()
        {
            try
            {
                if (Session["rolActivo"] != null && (int)Session["rolActivo"] == 2)
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
                                Session["direccionUso"] = item;

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
            catch (Exception ex)
            {

                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }

        }




        protected void btnDireccion_Click(object sender, EventArgs e)
        {
            try
            {
                DireccionNegocio direN = new DireccionNegocio();

                List<Direccion> listaDire = direN.buscarDireccionCliente((int)Session["idActivo"]);

                if (Session["direccionActivo"] == null)
                {
                    Response.Redirect("RegistroDireccion.aspx",false);
                    return;
                }
                else
                {
                    Response.Redirect("DireccionEnvio.aspx",false);
                    return;
                }

            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;
            }
        }



        protected void rbRetiroTienda_CheckedChanged(object sender, EventArgs e)
        {
            try
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
                    Session["conEnvio"] = true;
                }

                if (Session["listaCarrito"] != null)
                {
                    cargarResumen();
                }

                UpdatePanelResumen.Update();

            }
            catch (Exception ex)
            {
                Session["error"] = Ayudante.aTexto(ex);
                Response.Redirect("Error.aspx", false);
                return;

            }

        }




        protected async void btnPagarYFinalizar_Click(object sender, EventArgs e)
        {
            try
            {
                DireccionNegocio direN = new DireccionNegocio();
                VentaNegocio venN = new VentaNegocio();
                DetalleVentaNegocio detaN = new DetalleVentaNegocio();
                Venta ven = new Venta();
                Direccion dir = null;


                if (formaDePago() < 1 || formaDePago() > 3)
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

                }
                else
                {
                    ven.idDireccion = 0;
                }


                List<DetalleVenta> listaCarrito = (List<DetalleVenta>)Session["listaCarrito"];

                ven.FechaVenta_V = DateTime.Now;
                ven.Estado_V = true;
                ven.TotalPago_V = totalPago();
                ven.EstadoPedido_v = 0;
                ven.IdCliente_V = (int)Session["idActivo"];

                ven.TipoPago_V = formaDePago();
                ven.TipoEnvio = rbConEnvio.Checked ? 1 : 0;

                venN.agregar(ven);

                int idVenta = venN.ultimoIdVenta();

                if (listaCarrito != null)
                {
                    ProductoNegocio prodN = new ProductoNegocio();
                    var itemsComprobante = new List<ItemComprobante>();
                    StockNegocio stkN = new StockNegocio();

                    foreach (DetalleVenta item in listaCarrito)
                    {
                        item.IdVenta_Detalle = idVenta;
                        detaN.agregar(item);

                        Producto prod = prodN.buscarProduc(item.IdProducto);

                        if (!prod.OnDemand)
                        {
                            stkN.ModificarStockCantidad(prod.IdProducto, item.Cantidad, "-");
;                       }

                        int cantidad=stkN.buscarStockProd(prod.IdProducto).Cantidad;

                        if (cantidad == 0)
                        {                                                   
                            
                            Helper.Ayudante.cambiarEstadoProducto(prod.IdProducto, "baja");
                           
                        }

                        string nombreProd = prod != null ? prod.Nombre : $"Producto #{item.IdProducto}";

                        itemsComprobante.Add(new ItemComprobante
                        {
                            Producto = nombreProd,
                            Cantidad = item.Cantidad,
                            PrecioUnitario = item.PrecioUnitario
                        });
                    }

                    enviarComprobanteVenta(idVenta, ven.FechaVenta_V, ven.TotalPago_V, listaCarrito, itemsComprobante);

                    Session.Remove("listaCarrito");
                }

                if (formaDePago() == 2 //MP
                    )
                {
                    await RedirigirAMercadoPago(idVenta, ven.TotalPago_V);
                    return;
                }
                else
                {
                    mostrarMensaje("Venta agregada correctamente");
                    Response.Redirect("MisPedidos.aspx", false);
                    Context.ApplicationInstance.CompleteRequest();
                    return;
                }

            }
            catch (Exception)
            {
                Session["error"] = "No pudimos procesar la compra. Intentá de nuevo más tarde.";
                Response.Redirect("Error.aspx", false);
                return;
            }
        }





        private async Task RedirigirAMercadoPago(int idVenta, decimal montoTotal)
        {
            try
            {
                MercadoPagoConfig.AccessToken = ConfigurationManager.AppSettings["MP_AccessToken"];
                string baseUrl = Request.Url.GetLeftPart(UriPartial.Authority);

                var request = new PreferenceRequest
                {
                    Items = new List<PreferenceItemRequest>
                    {
                        new PreferenceItemRequest
                        {
                            Title = $"Compra en Tienda - Pedido #{idVenta}",
                            Quantity = 1,
                            CurrencyId = "ARS",
                            UnitPrice = montoTotal
                        }
                    },
                    BackUrls = new PreferenceBackUrlsRequest
                    {
                        Success = baseUrl + "/MisPedidos.aspx",
                        Failure = baseUrl + "/MisPedidos.aspx",
                        Pending = baseUrl + "/MisPedidos.aspx"
                    },
                    //AutoReturn = "approved",
                    ExternalReference = idVenta.ToString()
                };

                var client = new PreferenceClient();
                Preference preference = await client.CreateAsync(request);

                Response.Redirect(preference.SandboxInitPoint, false);
                Context.ApplicationInstance.CompleteRequest();
                return;
            }
            catch (Exception)
            {
                mostrarMensaje("No pudimos conectar con Mercado Pago en este momento. Intentá de nuevo más tarde.");
                return;
            }

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
            else if (fPago == 3)
            {
                descuento = 5;
            }

            return descuento;
        }



        private void enviarComprobanteVenta(int idVenta, DateTime fechaVenta, decimal totalPago, List<DetalleVenta> listaCarrito, List<ItemComprobante> itemsComprobante)
        {
            Cliente cliente = Session["usuarioActivo"] as Cliente;

            if (cliente == null || string.IsNullOrEmpty(cliente.Email))
                return;

            try
            {
                decimal subtotalCalc = subTotal(listaCarrito);
                decimal envioCalc = calcularEnvio();
                decimal descuentoCalc = subtotalCalc * (aplicarDescuento() / 100m);

                var datosComprobante = new DatosComprobante
                {
                    NumeroPedido = idVenta.ToString(),
                    NombreCliente = $"{cliente.Nombre} {cliente.Apellido}".Trim(),
                    EmailCliente = cliente.Email,
                    Fecha = fechaVenta,
                    RutaLogo = Server.MapPath("~/images/icons/dorregoDesign.png"),
                    Items = itemsComprobante,
                    Descuento = descuentoCalc,
                    Envio = envioCalc,
                    Total = totalPago
                };

                EnvioEmail envioEmail = new EnvioEmail();
                envioEmail.EnviarConfirmacionPedido(datosComprobante);
            }
            catch (Exception)
            {


            }
        }


        protected void btnCambiarPago_Click(object sender, EventArgs e)
        {
            try
            {
                if (Session["listaCarrito"] != null)
                {
                    cargarResumen();
                }
                UpdatePanelResumen.Update();
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