using dominio;
using Microsoft.Ajax.Utilities;
using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{

    public partial class Informes : System.Web.UI.Page
    {
        private string diahoy => DateTime.Now.Day.ToString();

        private string meshoy => DateTime.Now.Month.ToString();
        private string añohoy => DateTime.Now.Year.ToString();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (ViewState["ListaVentas"] == null)
                {



                }
            }


        }

        protected void btnRangoFechas_Click(object sender, EventArgs e)
        {
            lblMensajeInicial.Visible = false;
            pnlTarjetaUnica.Visible = false;
            pnlFiltroFechas.Visible = true;



        }

        protected void btnTopProductos_Click(object sender, EventArgs e)
        {

        }

        protected void btnPorEstado_Click(object sender, EventArgs e)
        {

        }

        protected void btnPorPago_Click(object sender, EventArgs e)
        {

        }

        protected void btnTopClientes_Click(object sender, EventArgs e)
        {

        }

        protected void btnFiltrarFechas_Click(object sender, EventArgs e)
        {
            VentaNegocio ventN = new VentaNegocio();
            List<Venta> listvent = ventN.listarVentas();
            List<Venta> listvetFiltrada = new List<Venta>();

            lblMensajeInicial.Visible = false;
            pnlTarjetaUnica.Visible = false;
            pnlTarjetaUnica.Visible=true;


            try
            {
                if (listvent != null)
                {
                    if (string.IsNullOrWhiteSpace(txtFechaInicio.Text) || string.IsNullOrWhiteSpace(txtFechaFin.Text))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaFechas", "mostrarCartel('Ingrese Fecha Inicio y Fecha de Fin', 'error');", true);
                        return;
                    }

                    DateTime fechaInicio;
                    DateTime fechaFin;

                    if (!DateTime.TryParse(txtFechaInicio.Text, out fechaInicio) || !DateTime.TryParse(txtFechaFin.Text, out fechaFin))
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaFormatoFecha", "mostrarCartel('Formato de fecha inválido', 'error');", true);
                        return;
                    }

                    fechaInicio = fechaInicio.Date;
                    fechaFin = fechaFin.Date;

                    if (fechaInicio > fechaFin)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaRangoFecha", "mostrarCartel('La fecha de inicio no puede ser mayor a la fecha de fin', 'error');", true);
                        return;
                    }
                    if (fechaFin < fechaInicio)
                    {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaRangoFecha", "mostrarCartel('La fecha de fin no puede ser manor a la fecha de inicio', 'error');", true);
                        return;
                    }



                    lblTituloInforme.Text = "Ventas de " + fechaInicio.ToString("dd/MM/yyyy") + " a " + fechaFin.ToString("dd/MM/yyyy");
                    decimal total = 0;

                    foreach (Venta vn in listvent)
                    {
                        if (vn.FechaVenta_V.Date >= fechaInicio && vn.FechaVenta_V.Date <= fechaFin)
                        {
                            if (vn.EstadoPedido_v != 2 && vn.EstadoPedido_v != 0 && vn.EstadoPedido_v != 9 && vn.EstadoPedido_v != 10)
                            {
                                total += vn.TotalPago_V;
                                listvetFiltrada.Add(vn);
                            }
                        }
                    }

                    lblMontoTarjeta.Text = "$" + total.ToString("N2");
                    dgvInformes.DataSource = ArreglarLista(listvetFiltrada);
                    dgvInformes.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }


        }



        protected void btnVentasDia_Click(object sender, EventArgs e)
        {
            try
            {
                VentaNegocio ventN = new VentaNegocio();
                List<Venta> listvent = ventN.listarVentas();
                List<Venta> listvetFiltrada = new List<Venta>();
                if (listvent != null)
                {
                    lblTituloInforme.Visible = false;
                    lblMensajeInicial.Visible = false;
                    pnlTarjetaUnica.Visible = true;

                    pnlFiltroFechas.Visible = false;


                    lblTituloTarjeta.Text = "Ventas del Dia :";
                    decimal total = 0;
                    foreach (Venta vn in listvent)
                    {
                        string diavn = vn.FechaVenta_V.ToString("dd");
                        string mesvn = vn.FechaVenta_V.ToString("MM");
                        string añovn = vn.FechaVenta_V.ToString("yyyy");

                        if (diavn == diahoy && mesvn == meshoy && añovn == añohoy)
                        {


                            if (vn.EstadoPedido_v != 2 && vn.EstadoPedido_v != 0 && vn.EstadoPedido_v != 9 && vn.EstadoPedido_v != 10)
                            {

                                total += vn.TotalPago_V;
                                listvetFiltrada.Add(vn);

                            }

                        }


                    }

                    lblMontoTarjeta.Text = "$" + total.ToString("N2");



                    dgvInformes.DataSource = ArreglarLista(listvetFiltrada);
                    dgvInformes.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        protected void btnVentasMes_Click(object sender, EventArgs e)
        {
            try
            {
                VentaNegocio ventN = new VentaNegocio();
                List<Venta> listvent = ventN.listarVentas();
                List<Venta> listvetFiltrada = new List<Venta>();
                if (listvent != null)
                {
                    lblTituloInforme.Visible = false;
                    lblMensajeInicial.Visible = false;
                    pnlTarjetaUnica.Visible = true;

                    pnlFiltroFechas.Visible = false;


                    lblTituloTarjeta.Text = "Ventas del Mes :";
                    decimal total = 0;
                    foreach (Venta vn in listvent)
                    {
                        string diavn = vn.FechaVenta_V.ToString("dd");
                        string mesvn = vn.FechaVenta_V.ToString("MM");
                        string añovn = vn.FechaVenta_V.ToString("yyyy");

                        if (mesvn == meshoy && añovn == añohoy)
                        {


                            if (vn.EstadoPedido_v != 2 && vn.EstadoPedido_v != 0 && vn.EstadoPedido_v != 9 && vn.EstadoPedido_v != 10)
                            {

                                total += vn.TotalPago_V;
                                listvetFiltrada.Add(vn);

                            }

                        }


                    }

                    lblMontoTarjeta.Text = "$" + total.ToString("N2");



                    dgvInformes.DataSource = ArreglarLista(listvetFiltrada);
                    dgvInformes.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }




        }

        protected void btnVentasAnio_Click(object sender, EventArgs e)
        {
            try
            {
                VentaNegocio ventN = new VentaNegocio();
                List<Venta> listvent = ventN.listarVentas();
                List<Venta> listvetFiltrada = new List<Venta>();
                if (listvent != null)
                {
                    lblTituloInforme.Visible = false;
                    lblMensajeInicial.Visible = false;
                    pnlTarjetaUnica.Visible = true;

                    pnlFiltroFechas.Visible = false;


                    lblTituloTarjeta.Text = "Ventas del Año :";
                    decimal total = 0;
                    foreach (Venta vn in listvent)
                    {
                        string diavn = vn.FechaVenta_V.ToString("dd");
                        string mesvn = vn.FechaVenta_V.ToString("MM");
                        string añovn = vn.FechaVenta_V.ToString("yyyy");

                        if (añovn == añohoy)
                        {


                            if (vn.EstadoPedido_v != 2 && vn.EstadoPedido_v != 0 && vn.EstadoPedido_v != 9 && vn.EstadoPedido_v != 10)
                            {

                                total += vn.TotalPago_V;
                                listvetFiltrada.Add(vn);

                            }

                        }


                    }

                    lblMontoTarjeta.Text = "$" + total.ToString("N2");



                    dgvInformes.DataSource = ArreglarLista(listvetFiltrada);
                    dgvInformes.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }

        }

        private List<object> ArreglarLista(List<Venta> lst)
        {

            ClienteNegocio cliN = new ClienteNegocio();
            DireccionNegocio direN = new DireccionNegocio();
            EstadoNegocio estaN = new EstadoNegocio();
            TipoPagoNegocio tpN = new TipoPagoNegocio();
            List<object> listaNueva = new List<object>();

            foreach (Venta venta in lst)
            {

                string textoDireccion = "Retiro por local";

                if (venta.TipoEnvio == 1)
                {

                    Direccion unaDireccion = direN.buscarDireccion(venta.idDireccion);

                    if (unaDireccion != null)
                    {

                        textoDireccion = unaDireccion.Calle + " " + unaDireccion.Numero;
                    }
                }



                listaNueva.Add(new
                {
                    venta.IdVenta_V,
                    Cliente = (cliN.buscarCliente(venta.IdCliente_V)).Nombre,
                    Fecha = venta.FechaVenta_V.ToString("dd/MM/yyyy"),
                    Total_Pagado = "$" + venta.TotalPago_V,
                    Tipo_Pago = (tpN.buscarTipoPago(venta.TipoPago_V)).Descripcion,
                    Tipo_Envio = (venta.TipoEnvio == 1) ? "Envio" : "Retiro por local",
                    DireccionEnvio = textoDireccion,
                    Estado = (venta.Estado_V == true) ? "Activo" : "Inactivo",
                    Estado_Pedido = (estaN.buscarEstado(venta.EstadoPedido_v)).Descripcion_estado
                });

            }


            return listaNueva;
        }

        protected void btnCanceladosDevueltos_Click(object sender, EventArgs e)
        {

            try
            {
                VentaNegocio ventN = new VentaNegocio();
                List<Venta> listvent = ventN.listarVentas();
                List<Venta> listvetFiltrada = new List<Venta>();
                if (listvent != null)
                {
                    lblMensajeInicial.Visible = false;
                    pnlTarjetaUnica.Visible = false;
                    pnlFiltroFechas.Visible = false;


                    foreach (Venta vn in listvent)
                    {


                        if (vn.EstadoPedido_v == 2 || vn.EstadoPedido_v == 0 || vn.EstadoPedido_v == 9 || vn.EstadoPedido_v == 10)
                        {


                            listvetFiltrada.Add(vn);

                        }




                    }


                    dgvInformes.DataSource = ArreglarLista(listvetFiltrada);
                    dgvInformes.DataBind();
                }

            }
            catch (Exception)
            {

                throw;
            }



        }
    }
}