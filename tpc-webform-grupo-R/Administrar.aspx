<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="tpc_webform_grupo_R.Administrar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
   <div class="container-fluid my-4">
    
    <!-- Barra de navegación superior -->
    <nav class="navbar border rounded px-3 py-3 mb-3 shadow-sm" style="background-color: #000000; border: 1px solid #333 !important;">
        <div class="container-fluid">
            <div class="d-flex flex-wrap gap-2 py-1 justify-content-center w-100">
                <asp:Button ID="btnCat" runat="server" Text="Categoría" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnMarc" runat="server" Text="Marca" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnStk" runat="server" Text="Stock" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnPago" runat="server" Text="Tipo Pago" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnProd" runat="server" Text="Producto" CssClass="btn btn-sm text-nowrap " Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnVend" runat="server" Text="Vendedor" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnAdmin" runat="server" Text="Administrador" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnCli" runat="server" Text="Cliente" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnDir" runat="server" Text="Dirección" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnVent" runat="server" Text="Venta" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnRol" runat="server" Text="Rol" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                <asp:Button ID="btnEst" runat="server" Text="Estado" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
            </div>
        </div>
    </nav>

    <!-- Contenido Principal -->
    <div class="row g-3">
        
        <!-- GridView de Datos (Izquierda - Fondo Negro, Borde Gris Medio Oscuro) -->
        <div class="col-12 col-lg-9">
            <div class="card shadow-sm h-100" style="background-color: #121212; border: 1px solid #333;">
                <div class="card-header py-2.5" style="background-color: #1a1a1a; border-bottom: 1px solid #333;">
                    <h5 class="mb-0 fw-semibold fs-6" style="color: #ffc107;">Vista de Datos</h5>
                </div>
                <div class="card-body p-0">
                    <div class="table-responsive">
                        <asp:GridView ID="dgvDatos" runat="server" 
                                      CssClass="table table-dark table-hover table-bordered mb-0 align-middle text-sm" 
                                      AutoGenerateColumns="false" 
                                      GridLines="None" 
                                      EmptyDataText="No hay datos para mostrar en este momento.">
                            <HeaderStyle BackColor="#ffc107" ForeColor="#000000" Font-Bold="true" />
                            <Columns>
                                <asp:BoundField HeaderText="#" DataField="Id" />
                                <asp:BoundField HeaderText="ID / Código" DataField="Codigo" />
                                <asp:BoundField HeaderText="Descripción / Nombre" DataField="Nombre" />
                                <asp:BoundField HeaderText="Detalle" DataField="Detalle" />
                                <asp:BoundField HeaderText="Estado" DataField="Estado" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>

        <!-- Botonera Lateral de Acciones (Derecha - Fondo Negro, Borde Gris Medio Oscuro) -->
        <div class="col-12 col-lg-3">
            <div class="card shadow-sm p-3 h-100" style="background-color: #121212; border: 1px solid #333;">
                <div class="d-grid gap-2">
                    <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-success d-flex align-items-center justify-content-center gap-2" />
                    <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-danger d-flex align-items-center justify-content-center gap-2" />
                    <asp:Button ID="btnModificar" runat="server" Text="Modificar" CssClass="btn btn-primary d-flex align-items-center justify-content-center gap-2" />
                    <asp:Button ID="btnListar" runat="server" Text="Listar" CssClass="btn btn-outline-light d-flex align-items-center justify-content-center gap-2" />
                </div>
            </div>
        </div>

    </div>
</div>

</asp:Content>
