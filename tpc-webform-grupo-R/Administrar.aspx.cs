using negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace tpc_webform_grupo_R
{
    public partial class Administrar : System.Web.UI.Page
    {

        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {

                if (Session["btnAgregar"] != null)
                {
                    int opcion = (int)Session["btnAgregar"];

                    cargarGrillaSegunOpcion(opcion);

                    Session.Remove("btnAdministrar");
                    
                }
                
            }

        }

        protected void SeleccionarTabla_Click(object sender, EventArgs e)
        {
            //  Convertimos el "sender" genérico en el botón específico que hizo clic
            Button btn = (Button)sender;

            // Leemos el número que guardó en su CommandArgument en el HTML
            int opcion = Convert.ToInt32(btn.CommandArgument);

            // C# ya sabe exactamente qué número de botón se presionó
            ViewState["TablaActiva"] = opcion;
            
            cargarGrillaSegunOpcion(opcion);
        }


        private void cargarGrillaSegunOpcion(int opcion)
        {
            switch (opcion)
            {
                case 1:

                    break;
                case 2:
                    cargarGrillaMarca();

                    break;
                case 3:

                    break;
                case 4:

                    break;
                case 5:

                    break;
                case 6:
                    cargarGrillaVendedor();
                    break;
                case 7:

                    break;
                case 8:
                    cargarGrillaCliente();

                    break;
                case 9:
                    cargarGrillaDireccion();
                    break;
                case 10:

                    break;
                case 11:

                    break;
                case 12:

                    break;
                default:

                    break;
            }
        }

        private void cargarGrillaCliente()
        {
            ClienteNegocio cliN = new ClienteNegocio();
            dgvGrilla.DataSource = cliN.listarClientes();
            dgvGrilla.DataKeyNames = new string[] { "IdPersona" };
            dgvGrilla.DataBind();
            ocultarItems();            

        }

        private void cargarGrillaVendedor()
        {

            VendedorNegocio vendedorN = new VendedorNegocio();
            dgvGrilla.DataSource = vendedorN.listarVendedores();
            dgvGrilla.DataKeyNames = new string[] { "IdPersona" };
            dgvGrilla.DataBind();
            ocultarItems();

        }

      

        private void cargarGrillaDireccion()
        {
            DireccionNegocio dirN = new DireccionNegocio();
            dgvGrilla.DataSource = dirN.listarDirecciones();
            dgvGrilla.DataKeyNames = new string[] { "IdDireccion" };
            dgvGrilla.DataBind();
        }

        private void cargarGrillaMarca() { 
        
        MarcaNegocio marcaNegocio = new MarcaNegocio();
            dgvGrilla.DataSource=marcaNegocio.ListarMarca();
            dgvGrilla.DataKeyNames = new string[] { "IdMarca" };
            dgvGrilla.DataBind();
            ocultarItems();
        
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            Session["btnAgregar"]= ViewState["TablaActiva"];

            int aux = Convert.ToInt32(ViewState["TablaActiva"]);

            switch (aux)
            {
                case 1://categorias

                    break;
                case 2:Response.Redirect("RegistroMarca.aspx");

                    break;
                case 3://stock

                    break;
                case 4://tipo pago

                    break;
                case 5://productos

                    break;
                case 6://vendedores
                    Response.Redirect("RegistroVA.aspx");

                    break;
                case 7://administradores
                    Response.Redirect("RegistroVA.aspx");
                    break;
                case 8://clientes
                    Response.Redirect("RegistroCliente.aspx");
                    break;
                case 9://direcciones

                    break;
                case 10:// ventas

                    break;
                case 11:// roles

                    break;
                case 12:// estados

                    break;

                default:
                    break;
            }

           


        }


        private void ocultarItems()
        {
            if (dgvGrilla.HeaderRow != null)
            {
                for (int i = 0; i < dgvGrilla.HeaderRow.Cells.Count; i++)
                {
                    string nombreColumna = dgvGrilla.HeaderRow.Cells[i].Text;

                    // Si la columna es el ID (idPersona, idCliente, idDireccion, etc.) la ocultamos
                    if (nombreColumna.Equals("idPersona", StringComparison.OrdinalIgnoreCase) ||
                        nombreColumna.Equals("Password", StringComparison.OrdinalIgnoreCase) ||
                        nombreColumna.EndsWith("IdMarca", StringComparison.OrdinalIgnoreCase)) 
                    {
                        // Ocultamos la celda en el encabezado
                        dgvGrilla.HeaderRow.Cells[i].Visible = false;

                        // Ocultamos la celda en cada una de las filas de datos
                        foreach (GridViewRow row in dgvGrilla.Rows)
                        {
                            row.Cells[i].Visible = false;
                        }
                    }
                }
            }
        }




    }
}