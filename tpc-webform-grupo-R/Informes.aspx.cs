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

        }



        protected void btnVentasDia_Click(object sender, EventArgs e)
        {
            try
            {
                VentaNegocio ventN = new VentaNegocio();
                List<Venta> listvent = ventN.listarVentas();

                if (listvent != null)
                {
                    lblMensajeInicial.Visible = false;
                    pnlTarjetaUnica.Visible = true;
                    dgvInformes.Visible = false;
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

                            total += vn.TotalPago_V;

                        }


                    }

                    lblMontoTarjeta.Text = "$" + total.ToString("N2");

                }

            }
            catch (Exception)
            {

                throw;
            }



        }

        protected void btnVentasMes_Click(object sender, EventArgs e)
        {

        }

        protected void btnVentasAnio_Click(object sender, EventArgs e)
        {

        }



    }
}