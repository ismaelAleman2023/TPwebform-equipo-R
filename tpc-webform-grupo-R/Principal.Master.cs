using dominio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            textoLogin();
            
                if (Session["usuarioActivo"] != null)
                {
                string v= "~/images/Perfiles/" + ((Cliente)Session["usuarioActivo"]).FotoPerfil;
                imgUserPerfil.ImageUrl = v;
                }
                else
                {

                    imgUserPerfil.ImageUrl = "~/images/Perfiles/fotoDefault.jpg";
                }


            if (Session["listaCarrito"] != null)
            {
                List<DetalleVenta> carrito = (List<DetalleVenta>)Session["listaCarrito"];
                actualizarContador(carrito.Count);
            }
            else
            {
                actualizarContador(0);
            }

            if (!IsPostBack)
            {
                if (Session["tablaActiva"] == null)
                {
                    Session["tablaActiva"] = "b1";
                    marcarBordeMarter();
                }
                else
                {
                    marcarBordeMarter();

                }     
                
               
                

            }

            marcarBordeMarter();
        }



        protected void textoLogin()
        {
            string nombre= "Login";
            if (Session["usuarioActivo"] == null)
            {
                lblLogin.InnerText = nombre;

            }
            else
            {
                int rol =(int) Session["rolActivo"];
               
                if (rol == 1)
                {
                    Administrador admin = (Administrador)Session["usuarioActivo"];
                    nombre = admin.Nombre;
                    lblLogin.InnerText = nombre;

                }
                else if (rol == 2)
                {
                    Cliente cli = (Cliente)Session["usuarioActivo"];
                    nombre = cli.Nombre;
                    lblLogin.InnerText = nombre;
                }
                else if(rol == 3)
                {
                    Vendedor ven = (Vendedor)Session["usuarioActivo"];
                    nombre = ven.Nombre;
                    lblLogin.InnerText = nombre;
                }
            }
           
        }



        protected void btnLoginModal_Click(object sender, EventArgs e)
        {

        }


        public void actualizarContador(int cantidad)
        {
            lblContadorCarrito.Text = cantidad.ToString();
        }

        public string ObtenerIdContador()
        {
             return lblContadorCarrito.ClientID;
           
        }


        protected void btnBar_click(object sender, EventArgs e)
        {
            LinkButton btn = (LinkButton)sender;
            string eleccionTablaSuperior = btn.CommandArgument;
            Session["tablaActiva"] = eleccionTablaSuperior;
                    
            switch (eleccionTablaSuperior)
            {
                case "b1":
                    Response.Redirect("~/Default.aspx#destacado1");
                    break;
                case "b2":
                    Response.Redirect("~/Default.aspx#catalogo1");
                    break;
                case "b3":
                    Response.Redirect("~/Default.aspx#novedades1");
                    break;
                case "b4":
                    Response.Redirect("~/SobreNosotros.aspx");
                    break;
                case "b5":
                    Response.Redirect("~/ComoComprar.aspx");
                    break;
                case "b6":
                    Response.Redirect("~/Contactanos.aspx");
                    break;
                case "b7":
                    Response.Redirect("~/Perfil.aspx");
                    break;
                case "b8":
                    Response.Redirect("~/Administrar.aspx");
                    break;
                case "b9":
                    Response.Redirect("~/Informes.aspx");
                    break;
            }

        }

        protected void marcarBordeMarter()
        {
            string eleccionTablaSuperior = Session["tablaActiva"].ToString(); ;

            lnkDestacados.Style["border"] = "1px solid #333";
            lnkProductos.Style["border"] = "1px solid #333";
            lnkNovedades.Style["border"] = "1px solid #333";
            lnkSobreNosotros.Style["border"] = "1px solid #333";
            lnkComoComprar.Style["border"] = "1px solid #333";
            lnkContactanos.Style["border"] = "1px solid #333";
            lnkPerfil.Style["border"] = "1px solid #333";
            lnkAdministrar.Style["border"] = "1px solid #333";
            lnkAdministrar.Style["border"] = "1px solid #333";

            switch (eleccionTablaSuperior)
            {
                case "b1":
                    lnkDestacados.Style["border"] = "2px solid #ffc107";

                    break;
                case "b2":
                    lnkProductos.Style["border"] = "2px solid #ffc107";

                    break;
                case "b3":
                    lnkNovedades.Style["border"] = "2px solid #ffc107";

                    break;
                case "b4":
                    lnkSobreNosotros.Style["border"] = "2px solid #ffc107";
                    break;
                case "b5":
                    lnkComoComprar.Style["border"] = "2px solid #ffc107";
                    break;
                case "b6":
                    lnkContactanos.Style["border"] = "2px solid #ffc107";
                    break;
                case "b7":
                    lnkPerfil.Style["border"] = "2px solid #ffc107";
                    break;
                case "b8":
                    lnkAdministrar.Style["border"] = "2px solid #ffc107";
                  
                    break;
                case "b9":
                    lnkInformes.Style["border"] = "2px solid #ffc107";
                    break;
            }
        }

        }
}