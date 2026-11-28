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
    public partial class ModificarNovedades : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            NovedadesNegocio negoN = new NovedadesNegocio();

            if (!IsPostBack)
            {
                Novedades nov = negoN.BuscarNovedadActiva();
                if (nov != null)
                {
                    actualizarNovedades(nov);
                    ViewState["modificar"] = true;
                    ViewState["idNovedad"] = nov.idNovedad;
                }


            }


        }



        private void actualizarNovedades(Novedades nov)
        {
            

            if (nov != null) {

                litPromoEyebrow.Text = nov.TituloChicoIzq1;
                litPromoTitulo.Text = nov.TituloGrandeIzq2;
                litPromoDescripcion.Text = nov.DescripcionIzq3;
                litPromoBadgeInferior.Text = nov.BotonInfIzq4;

                litCard1Titulo.Text = nov.Card1Titulo;
                litCard1Precio.Text = decimal.Parse(nov.Card1Precio).ToString("C");
                litCard1Subtitulo.Text = nov.card1Subtitulo;

                litCard2Titulo.Text = nov.Card2Titulo;
                litCard2Precio.Text = decimal.Parse(nov.Card2Precio).ToString("C");
                litCard2Subtitulo.Text = nov.Card2Subtitulo;

                litCard3Titulo.Text = nov.Card3Titulo;
                litCard3Precio.Text = decimal.Parse(nov.Card3Precio).ToString("C");
                litCard3Subtitulo.Text = nov.Card3Subtitulo;
                litCard3Badge.Text = nov.DestacadoCard;

                //////

                txtTitulosup1.Text = nov.TituloChicoIzq1;
                txtTitulo2.Text = nov.TituloGrandeIzq2;
                txtDescripcion3.Text = nov.DescripcionIzq3;
                txtbotonInf4.Text = nov.BotonInfIzq4;

                txtCard1Titulo.Text = nov.Card1Titulo;
                txtCard1Precio.Text = nov.Card1Precio;
                txtCard1Detalle.Text = nov.card1Subtitulo;

                txtCard2Titulo.Text = nov.Card2Titulo;
                txtCard2Precio.Text = nov.Card2Precio;
                txtCard2Detalle.Text = nov.Card2Subtitulo;

                txtCard3Titulo.Text = nov.Card3Titulo;
                txtCard3Precio.Text = nov.Card3Precio;
                txtCard3Detalle.Text = nov.Card3Subtitulo;
                txtCard3Destacado.Text = nov.DestacadoCard;


            }


                
                
                
         }

        protected void btnGuardar_Click(object sender, EventArgs e)
        {

            NovedadesNegocio novN = new NovedadesNegocio();
            Novedades nov = new Novedades();

            nov.TituloChicoIzq1 = txtTitulosup1.Text;
            nov.TituloGrandeIzq2 = txtTitulo2.Text;
            nov.DescripcionIzq3 = txtDescripcion3.Text;
            nov.BotonInfIzq4 = txtbotonInf4.Text;

            nov.Card1Titulo= txtCard1Titulo.Text;
            nov.Card1Precio= txtCard1Precio.Text;
            nov.card1Subtitulo= txtCard1Detalle.Text;

            nov.Card2Titulo= txtCard2Titulo.Text;
            nov.Card2Precio= txtCard2Precio.Text;
            nov.Card2Subtitulo = txtCard2Detalle.Text;

            nov.Card3Titulo= txtCard3Titulo.Text;
            nov.Card3Precio = txtCard3Precio.Text;
            nov.Card3Subtitulo= txtCard3Detalle.Text;
            nov.DestacadoCard= txtCard3Destacado.Text;

            if (ViewState["modificar"]!= null && (bool)ViewState["modificar"])
            {
                nov.idNovedad = (int)ViewState["idNovedad"];
                novN.modificarNovedades(nov);
            }

            else
            {
                novN.agregarNovedades(nov);
            }

                Response.Redirect("~/Default.aspx#destacado1");

        }



        protected void btnCancelar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx#destacado1",false);
           
        }
    }
}