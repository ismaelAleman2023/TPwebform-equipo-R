<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Administrar.aspx.cs" Inherits="tpc_webform_grupo_R.Administrar" %>



<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
            <style>
            /* Fuerza a que la fila seleccionada se pinte de amarillo dorado */
            .table-dark tr.selected td, 
            .table-dark .selected > td {
                background-color: #151515 !important; 
                color: #FFFFFF !important;
                }
        </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

 
    <asp:UpdatePanel runat="server" ID="updatePanelgrilla">
        <ContentTemplate>
                            
           <div class="container-fluid my-4">
            <!-- Barra superior -->
            <nav class="navbar border rounded px-3 py-3 mb-3 shadow-sm" style="background-color: #000000; border: 1px solid #333 !important;">
                <div class="container-fluid">
                    <div class="d-flex flex-wrap gap-2 py-1 justify-content-center w-100">
                        <asp:Button ID="btnProd" runat="server" Text="Productos" CommandArgument="5" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap " Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnStk" runat="server" Text="Stock" CommandArgument="3" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnCat" runat="server" Text="Categorías" CommandArgument="1" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnMarc" runat="server" Text="Marcas" CommandArgument="2" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnVend" runat="server" Text="Vendedores" CommandArgument="6" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnAdmin" runat="server" Text="Administradores" CommandArgument="7" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnCli" runat="server" Text="Clientes" CommandArgument="8" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnRol" runat="server" Text="Roles" CommandArgument="11" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnVent" runat="server" Text="Ventas" CommandArgument="10" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnPago" runat="server" Text="Tipo Pago" CommandArgument="4" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnDir" runat="server" Text="Direcciónes" CommandArgument="9" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                        <asp:Button ID="btnEst" runat="server" Text="Estados" CommandArgument="12" OnClick="SeleccionarTabla_Click" CssClass="btn btn-sm text-nowrap" Style="background-color: #1a1a1a; color: #ddd; border: 1px solid #333;" />
                    </div>
                </div>
            </nav>

            <!-- Contenido Principal -->
            <div class="row g-3">
        
                <!-- GridView -->
                <div class="col-12 col-lg-9">
                    <div class="card shadow-sm h-100" style="background-color: #121212; border: 1px solid #333;">
                        <div class="card-header py-2.5" style="background-color: #1a1a1a; border-bottom: 1px solid #333;">
                            <h5 class="mb-0 fw-semibold fs-6" style="color: #ffc107;">Vista de Datos</h5>
                        </div>
                        <div class="card-body p-0">
                            <div class="table-responsive">                                  
                                
                                <asp:GridView ID="dgvGrilla" runat="server" OnSelectedIndexChanged="dgvGrilla_SelectedIndexChanged" AutoGenerateSelectButton="true"   CssClass="table table-dark table-hover table-bordered mb-0 align-middle text-sm">
                                 
                                 <SelectedRowStyle CssClass="selected" /> 
                                </asp:GridView>
                            
                            
                            </div>
                        </div>
                    </div>
                </div>

                <!-- Botones  derecha) -->
                <div class="col-12 col-lg-3">
                    <div class="card shadow-sm p-3 h-100" style="background-color: #121212; border: 1px solid #333;">
                        <div class="d-grid gap-2">
                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" OnClick="btnAgregar_Click" CssClass="btn btn-success d-flex align-items-center justify-content-center gap-2" />
                            <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" OnClick="btnEliminar_Click" CssClass="btn btn-danger d-flex align-items-center justify-content-center gap-2" />
                            <asp:Button ID="btnModificar" runat="server" Text="Modificar" OnClick="btnModificar_Click" CssClass="btn btn-primary d-flex align-items-center justify-content-center gap-2" />
                            <!--<asp:Button ID="btnListar" runat="server" Text="Listar" CssClass="btn btn-outline-light d-flex align-items-center justify-content-center gap-2" />-->
                        </div>
                    </div>
                </div>

            </div>
        </div>
    
    </ContentTemplate>
</asp:UpdatePanel>


</asp:Content>
