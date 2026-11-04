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

                    ViewState["TablaActiva"] = Session["btnAgregar"];

                 
                    Session.Remove("estadoAModificar");
                    Session.Remove("clienteAModificar");
                    Session.Remove("vendedorAModificar");
                    Session.Remove("adminAModificar");

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
                    cargarGrillaCategoria();
                    break;
                case 2:
                    cargarGrillaMarca();

                    break;
                case 3:
                    cargarGrillaStock();
                    break;
                case 4:
                    cargarGrillaTipoPago();
                    break;
                case 5:
                    cargarGrillaProducto();
                    break;
                case 6:
                    cargarGrillaVendedor();

                    break;
                case 7:
                    cargarGrillaAdministrador();

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
                    cargarGrillaEstado();

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
            ViewState.Remove("eleccion");

        }

        private void cargarGrillaVendedor()
        {
            VendedorNegocio vendedorN = new VendedorNegocio();
            dgvGrilla.DataSource = vendedorN.listarVendedores();
            dgvGrilla.DataKeyNames = new string[] { "IdPersona" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");

        }


        private void cargarGrillaAdministrador()
        {
            AdministrarNegocio adminN = new AdministrarNegocio();
            dgvGrilla.DataSource = adminN.listarAdministradores();
            dgvGrilla.DataKeyNames = new string[] { "IdPersona" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");
        }


        private void cargarGrillaDireccion()
        {
            DireccionNegocio dirN = new DireccionNegocio();
            dgvGrilla.DataSource = dirN.listarDirecciones();
            dgvGrilla.DataKeyNames = new string[] { "IdDireccion" };
            dgvGrilla.DataBind();
            ViewState.Remove("eleccion");
        }

        private void cargarGrillaMarca()
        {

            MarcaNegocio marcaNegocio = new MarcaNegocio();
            dgvGrilla.DataSource = marcaNegocio.ListarMarca();
            dgvGrilla.DataKeyNames = new string[] { "IdMarca" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");

        }

        private void cargarGrillaCategoria()
        {

            CategoriaNegocio cateNego = new CategoriaNegocio();
            dgvGrilla.DataSource = cateNego.listarCate();
            dgvGrilla.DataKeyNames = new string[] { "IdCategoria" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");

        }


        private void cargarGrillaTipoPago()
        {
            TipoPagoNegocio tpN = new TipoPagoNegocio();
            dgvGrilla.DataSource = tpN.ListarTipoPago();
            dgvGrilla.DataKeyNames = new string[] { "IdTipoPago" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");
        }

        private void cargarGrillaEstado()
        {
            EstadoNegocio estadoN = new EstadoNegocio();
            dgvGrilla.DataSource = estadoN.listarEstados();
            dgvGrilla.DataKeyNames = new string[] { "IdEstado" };
            dgvGrilla.DataBind();
            ViewState.Remove("eleccion");
        }

        private void cargarGrillaProducto() { 
        ProductoNegocio pro=new ProductoNegocio();
        MarcaNegocio marcaNeg=new MarcaNegocio();
        CategoriaNegocio cateNeg=new CategoriaNegocio();

            var listaMarcas = marcaNeg.ListarMarca();
            var listaCategorias = cateNeg.listarCate();

            var listaParaGrilla = pro.listarProduc().Select(p => new {
                p.IdProducto,
                p.CodigoProducto,
                p.Nombre,
                p.Descripcion,
                Marca = listaMarcas.FirstOrDefault(m => m.IdMarca == p.Marca)?.Descripcion ?? "Sin Marca",
                Categoria = listaCategorias.FirstOrDefault(c => c.IdCategoria == p.Categoria)?.Descripcion ?? "Sin Categoria",
                p.Precio,
                p.OnDemand,
                p.Estado

            }).ToList();


            dgvGrilla.DataSource =listaParaGrilla;
            dgvGrilla.DataKeyNames = new string[] {"IdProducto"};
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");

        
        
        
        }

        private void cargarGrillaStock() { 
        
            StockNegocio stockNegocio = new StockNegocio();

            dgvGrilla.DataSource=stockNegocio.listaStock();
            dgvGrilla.DataKeyNames = new string[] { "IdStock" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");
        
        
        
        }


        protected void btnAgregar_Click(object sender, EventArgs e)
        {


            Session["btnAgregar"] = ViewState["TablaActiva"];

            int aux = Convert.ToInt32(ViewState["TablaActiva"]);

            switch (aux)
            {
                case 1:
                    Response.Redirect("RegistroCategoria.aspx");

                    break;
                case 2:
                    Response.Redirect("RegistroMarca.aspx");

                    break;
                case 3:sumarStock();

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
                    Response.Redirect("RegistroEstado.aspx");
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

                    // Si la columna es igual se oculata
                    if (
                       nombreColumna.Equals("IdStock",StringComparison.OrdinalIgnoreCase) ||
                       nombreColumna.Equals("IdProducto",StringComparison.OrdinalIgnoreCase) ||
                        nombreColumna.Equals("idPersona", StringComparison.OrdinalIgnoreCase) ||
                        nombreColumna.Equals("Password", StringComparison.OrdinalIgnoreCase) ||
                        nombreColumna.Equals("IdCategoria", StringComparison.OrdinalIgnoreCase) ||
                        nombreColumna.EndsWith("IdMarca", StringComparison.OrdinalIgnoreCase))
                    {
                        // encabezado
                        dgvGrilla.HeaderRow.Cells[i].Visible = false;

                        // celda en cada una de las filas 
                        foreach (GridViewRow row in dgvGrilla.Rows)
                        {
                            row.Cells[i].Visible = false;
                        }
                    }
                }
            }
        }

        protected void dgvGrilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            int seleccion = int.Parse(dgvGrilla.SelectedDataKey.Value.ToString());
            ViewState["eleccion"] = seleccion;
           
        }

        protected void btnEliminar_Click(object sender, EventArgs e)
        {
            if (ViewState["eleccion"] != null)
            {

                switch (ViewState["TablaActiva"])
                {
                    case 1:
                        eliminarCategoria();
                        cargarGrillaCategoria();


                        break;
                    case 2:
                        eliminarMarca();
                        cargarGrillaMarca();

                        break;
                    case 3://stock

                        break;
                    case 4://tipo pago

                        break;
                    case 5://productos

                        break;
                    case 6://vendedores
                        eliminarVendedor();
                        cargarGrillaVendedor();

                        break;
                    case 7://administradores
                        eliminarAdministrador();
                        cargarGrillaAdministrador();

                        break;
                    case 8://clientes
                        eliminarCliente();
                        cargarGrillaCliente();

                        break;
                    case 9://direcciones
                        // no lo usamos

                        break;
                    case 10:// ventas

                        break;
                    case 11:// roles

                        break;
                    case 12:// estados
                        eliminarEstado();
                        cargarGrillaEstado();
                        break;

                    default:
                        break;
                }

            }

        }

        protected void btnModificar_Click(object sender, EventArgs e)
        {
            if (ViewState["eleccion"] != null)
            {
                switch (ViewState["TablaActiva"])
                {
                    case 1://categoria

                        break;
                    case 2://marca

                        break;
                    case 3://stock

                        break;
                    case 4://tipo pago

                        break;
                    case 5://productos

                        break;
                    case 6://vendedores
                        modificarVendedor();
                        break;
                    case 7://administradores
                        modificarAdministrador();
                        break;
                    case 8://clientes
                        modificarCliente();
                        break;
                    case 9://direcciones

                        break;
                    case 10:// ventas

                        break;
                    case 11:// roles

                        break;
                    case 12:// estados
                        modificarEstado();
                        break;

                    default:
                        break;
                }
            }
        }


        // Eliminar....

        private void eliminarCliente()
        {
            try
            {
                ClienteNegocio cliN = new ClienteNegocio();

                cliN.eliminarCliente((int)ViewState["eleccion"]);

                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Cliente eliminado correctamente!', 'error');", true);

            }
            catch (Exception)
            {
                throw;
            }
        }

        private void eliminarVendedor()
        {
            try
            {
                VendedorNegocio venN = new VendedorNegocio();
                venN.eliminarVendedor((int)ViewState["eleccion"]);
                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Vendedor eliminado correctamente!', 'error');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void eliminarMarca()
        {
            try
            {
                MarcaNegocio marcaNegocio = new MarcaNegocio();
                //falta el metodo para validar si esta asociado a un producto
                marcaNegocio.BajaMarca((int)ViewState["eleccion"]);
                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Marca eliminada correctamente!', 'success');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void eliminarCategoria()
        {
            try
            {
                CategoriaNegocio cate = new CategoriaNegocio();
                //falta el metodo para validar si esta asociado a un producto
                cate.bajaCategoria((int)ViewState["eleccion"]);
                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Marca eliminada correctamente!', 'success');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void eliminarAdministrador()
        {
            try
            {
                AdministrarNegocio adminN = new AdministrarNegocio();
                adminN.eliminarAdministrador((int)ViewState["eleccion"]);
                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Administrador eliminado correctamente!', 'error');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void eliminarEstado()
        {
            try
            {
                EstadoNegocio estadoN = new EstadoNegocio();
                estadoN.eliminarEstado((int)ViewState["eleccion"]);
                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Estado eliminado correctamente!', 'error');", true);
            }
            catch (Exception)
            {
                throw;
            }
        }



        //Modificar....


        private void modificarEstado()
        {
            EstadoNegocio estadoN = new EstadoNegocio();
            try
            {
                int idEstado = (int)ViewState["eleccion"];
                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["estadoAModificar"] = estadoN.buscarEstado(idEstado);
                Response.Redirect("RegistroEstado.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void modificarCliente()
        {
            ClienteNegocio cliN = new ClienteNegocio();
            try
            {
                int idCliente = (int)ViewState["eleccion"];
                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["clienteAModificar"] = cliN.buscarCliente(idCliente);

                Response.Redirect("RegistroCliente.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }


        private void modificarVendedor()
        {
            VendedorNegocio venN = new VendedorNegocio();
            try
            {
                int idVendedor = (int)ViewState["eleccion"];
                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["vendedorAModificar"] = venN.buscarVendedor(idVendedor);
                Response.Redirect("RegistroVA.aspx");
            }
            catch (Exception)
            {
                throw;
            }


        }

        private void modificarAdministrador()
        {
            AdministrarNegocio adminN = new AdministrarNegocio();
            try
            {
                int idAdmin = (int)ViewState["eleccion"];
                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["adminAModificar"] = adminN.buscarAdministrador(idAdmin);
                Response.Redirect("RegistroVA.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void sumarStock() {

            ProductoNegocio produc=new ProductoNegocio();
            StockNegocio st = new StockNegocio();


            try
            {

            if (ViewState["eleccion"]!=null) {

                int idStock = (int)ViewState["eleccion"];
                Stock stock = st.buscarStock(idStock);
                 string nombre = produc.nombreprodu((int)stock.IdProducto_stk);

                Session["btnAgregar"] = ViewState["TablaActiva"];
                 Session["NombreProducto"] =nombre;

                Response.Redirect("SumarStock.aspx?id="+stock.IdProducto_stk);


            }
            else{

                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡Seleccione un stock de la grilla!', 'error');", true);


            }
        
            }
            catch (Exception)
            {

                throw;
            }

        
        
        }

    }
}