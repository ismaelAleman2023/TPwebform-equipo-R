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
                    Session.Remove("tipoPagoAModificar");
                    Session.Remove("NombreProducto");
                    Session.Remove("Stock");
                    Session.Remove("AgMd");

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
                case 1://categoria
                    cargarGrillaCategoria();
                    break;
                case 2://marca
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
                case 6://vendedores
                    cargarGrillaVendedor();

                    break;
                case 7://administradores
                    cargarGrillaAdministrador();

                    break;
                case 8://clientes   
                    cargarGrillaCliente();

                    break;
                case 9://direcciones
                    cargarGrillaDireccion();
                    break;
                case 10://rolles

                    break;
                case 11://ventas

                    break;
                case 12://estados
                    cargarGrillaEstado();

                    break;
                default:

                    break;
            }
        }

        private void cargarGrillaCliente()
        {
            ClienteNegocio cliN = new ClienteNegocio();
            EstadoNegocio estadoN = new EstadoNegocio();

            var listaClientesGrilla = cliN.listarClientes().Select(c => new
            {
                c.IdPersona,
                c.Nombre,
                c.Apellido,
                c.Email,
                c.FechaDeNacimiento,
                c.Password,
                c.Telefono,
                c.IdRol,
                correoOk = c.CorreoOk ? "Verificado" : "no verifi",
                Estado = estadoN.buscarEstado(c.Estado).Descripcion_estado

            }).ToList();

            dgvGrilla.DataSource = listaClientesGrilla;
            dgvGrilla.DataKeyNames = new string[] { "IdPersona" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");

        }

        private void cargarGrillaVendedor()
        {
            EstadoNegocio estadoN = new EstadoNegocio();
            VendedorNegocio vendedorN = new VendedorNegocio();

            var listaVendedoresGrilla = vendedorN.listarVendedores().Select(v => new
            {
                v.Legajo,
                v.IdPersona,
                v.Nombre,
                v.Apellido,
                v.Email,
                v.FechaDeNacimiento,
                v.Password,
                v.Telefono,
                v.IdRol,
                Estado = estadoN.buscarEstado(v.Estado).Descripcion_estado

            }).ToList();


            dgvGrilla.DataSource = listaVendedoresGrilla;
            dgvGrilla.DataKeyNames = new string[] { "IdPersona" };
            dgvGrilla.DataBind();
            ocultarItems();
            ViewState.Remove("eleccion");

        }


        private void cargarGrillaAdministrador()
        {   
           
            EstadoNegocio estadoN = new EstadoNegocio();
            AdministrarNegocio adminN = new AdministrarNegocio();

            var listaAdministradoresGrilla = adminN.listarAdministradores().Select(a => new
            {
                
                a.IdPersona,
                a.Nombre,
                a.Apellido,
                a.Cuil,
                a.Email,
                a.FechaDeNacimiento,
                a.Password,
                a.Telefono,
                a.IdRol,
                Estado = estadoN.buscarEstado(a.Estado).Descripcion_estado

            }).ToList();

            dgvGrilla.DataSource = listaAdministradoresGrilla;
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

            var listaParaGrilla = pro.listarProduc().Select(p => new {
                p.IdProducto,
                p.CodigoProducto,
                p.Nombre,
                p.Descripcion,
                Marca = Helper.Ayudante.idXmarca(p.Marca),
                Categoria = Helper.Ayudante.idxCategoria(p.Categoria),
                p.Precio,
                OnDemand = p.OnDemand ? "Si" : "NO",
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

            var listaActivos = stockNegocio.listaStock().Select(s => new {
                s.IdStock,
                Producto=Helper.Ayudante.idxNproduc(s.IdProducto_stk),
                s.Cantidad,
                s.Estado
            }).ToList();


            dgvGrilla.DataSource = listaActivos;
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
                case 1://catergoria
                    Response.Redirect("RegistroCategoria.aspx");

                    break;
                case 2://marca
                    Response.Redirect("RegistroMarca.aspx");

                    break;
                case 3://Stock
                    sumarStock("agregar");

                    break;
                case 4://tipo pago
                    Response.Redirect("RegistroTipoPago.aspx");
                    break;
                case 5://productos
                    Response.Redirect("RegistrarProducto.aspx");
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
            if (ViewState["eleccion"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaError", "mostrarCartel('¡Seleccione un elemento de la grilla para modificar!', 'error');", true);
                return;
            }

            if (ViewState["eleccion"] != null)
            {

                switch ((int)ViewState["TablaActiva"])
                {
                    case 1://categoria
                        eliminarCategoria();
                        cargarGrillaCategoria();

                        break;
                    case 2://marca
                        eliminarMarca();
                        cargarGrillaMarca();

                        break;
                    case 3://stock
                        

                        break;
                    case 4://tipo pago
                        eliminarTipoPago();
                        cargarGrillaTipoPago();
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
            if (ViewState["eleccion"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaError", "mostrarCartel('¡Seleccione un elemento de la grilla para modificar!', 'error');", true);
                return; 
            }
            Session["btnAgregar"] = ViewState["TablaActiva"];

            switch (ViewState["TablaActiva"])
                {
                    case 1://categoria
                      
                        break;
                    case 2://marca

                        break;
                    case 3://stock
                        sumarStock("modificar");
                        break;
                    case 4://tipo pago
                        modificarTipoPago();
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


        private void eliminarTipoPago()
        {
            try
            {
                TipoPagoNegocio tpN = new TipoPagoNegocio();
                tpN.BajaTipoPago((int)ViewState["eleccion"]);
                ViewState.Remove("eleccion");
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('Tipo de pago dado de baja correctamente', 'success');", true);
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


        private void modificarTipoPago()
        {
            TipoPagoNegocio tpN = new TipoPagoNegocio();
            try
            {
                int idTipoPago = (int)ViewState["eleccion"];
                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["tipoPagoAModificar"] = tpN.buscarTipoPago(idTipoPago);
                Response.Redirect("RegistroTipoPago.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }

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
                int idAdmin =(int)ViewState["eleccion"];
                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["adminAModificar"] = adminN.buscarAdministrador(idAdmin);
                Response.Redirect("RegistroVA.aspx");
            }
            catch (Exception)
            {
                throw;
            }
        }



        private void sumarStock(string agmd) {

            ProductoNegocio produc=new ProductoNegocio();
            StockNegocio st = new StockNegocio();
            if (ViewState["eleccion"] == null)
            {
                ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaError", "mostrarCartel('¡Seleccione un elemento de la grilla!', 'error');", true);
                return;
            }

            try
            {


                int idStock = (int)ViewState["eleccion"];
                Stock stock = st.buscarStock(idStock);
                 string nombre = produc.nombreprodu((int)stock.IdProducto_stk);

                    if (stock.Estado!=1) {
                        ScriptManager.RegisterStartupScript(this, this.GetType(), "alertaExito", "mostrarCartel('¡No se puede agregar o modificar stock a un producto no existente!', 'error');", true);
                        return;
                    }


                Session["btnAgregar"] = ViewState["TablaActiva"];
                Session["NombreProducto"] =nombre;
                Session["Stock"] = stock;
                Session["AgMd"] = agmd;
                Response.Redirect("SumarStock.aspx");
            
         
        
            }
            catch (Exception)
            {

                throw;
            }

        
        
        }





    }
}