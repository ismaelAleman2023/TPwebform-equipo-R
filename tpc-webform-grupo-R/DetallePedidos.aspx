<%@ Page Title="Detalle Pedido" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DetallePedidos.aspx.cs" Inherits="tpc_webform_grupo_R.DetallePedidos" %>

<asp:Content ID="Content2" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4 mb-5">

        <!-- Título y botón para volver -->
        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="text-white">Resumen del Pedido <%: idpedi %><asp:Label ID="lblIdVenta" runat="server"></asp:Label></h2>
            <asp:Button ID="btnVolver" runat="server" Text="&larr; Volver a Mis Pedidos" CssClass="btn btn-outline-light btn-sm px-3" OnClick="btnVolver_Click" />
        </div>

    <div class="card p-4 shadow-sm border-0 bg-white rounded-3 mb-4">
            <h4 class="text-primary mb-3 fw-bold">Información General</h4>
            
           
            <div class="row g-3 text-secondary mb-3">
                <div class="col-md-3">
                    <span class="d-block small text-muted">Fecha de Compra:</span>
                    <span class="fw-semibold text-dark">
                        <asp:Label ID="lblFecha" runat="server"></asp:Label></span>
                </div>

                <div class="col-md-3">
                    <span class="d-block small text-muted">Tipo de Pago:</span>
                    <span class="fw-semibold text-dark">
                        <asp:Label ID="lblTipoPago" runat="server"></asp:Label></span>
                </div>

                <div class="col-md-3">
                    <span class="d-block small text-muted">Estado del Pedido:</span>
                    <span class="badge bg-secondary px-3 py-2">
                        <asp:Label ID="lblEstado" runat="server"></asp:Label></span>
                </div>

                <div class="col-md-3 text-md-end">
                    <span class="d-block small text-muted">Total Final:</span>
                    <span class="fs-5 text-success fw-bold">
                        <asp:Label ID="lblTotal" runat="server"></asp:Label></span>
                </div>
            </div>

           
           <div class="row g-3 text-secondary border-top pt-3 align-items-center">
                <div class="col-md-3">
                    <span class="d-block small text-muted">Dirección de Envío:</span>
                    <span class="fw-semibold text-dark">
                        <asp:Label ID="lblDireccionEnvio" runat="server"></asp:Label>
                    </span>
                </div>

                <div class="col-md-3">
                    <span class="d-block small text-muted">Tipo de Envío:</span>
                    <span class="fw-semibold text-dark">
                        <asp:Label ID="lblTipoEnvio" runat="server"></asp:Label></span>
                </div>

               <div class="col-md-3">
                    <span class="d-block small text-muted">Costo de Envío:</span>
                    <span class="fw-semibold text-dark">
                        <asp:Label ID="lblCostoEnvio" runat="server"></asp:Label></span>
               </div>

            </div>

        </div>


        <!-- TARJETAS  -->
        <div class="card p-4 shadow-sm border-0 bg-white rounded-3">
            <h4 class="text-primary mb-4 fw-bold">Productos en este Pedido</h4>

            <!-- Repeater -->
            <asp:Repeater ID="repDetalleProductos" runat="server">
                <ItemTemplate>
                    <div class="card border mb-3 p-3 shadow-sm bg-light rounded-2">
                        <div class="row align-items-center text-center text-md-start">

                            <!-- Nombre del Producto -->
                            <div class="col-md-5 mb-2 mb-md-0">
                                <span class="text-muted d-block small">Producto</span>
                                <span class="fw-bold fs-6 text-dark"><%# Eval("NombreProducto") %></span>
                            </div>

                            <!-- Cantidad -->
                            <div class="col-md-2 mb-2 mb-md-0">
                                <span class="text-muted d-block small">Cantidad</span>
                                <span class="fw-semibold"><%# Eval("Cantidad") %></span>
                            </div>

                            <!-- Precio Unitario -->
                            <div class="col-md-2 mb-2 mb-md-0">
                                <span class="text-muted d-block small">Precio Unit.</span>
                                <span class="fw-semibold">$<%# Eval("PrecioUnitario", "{0:N2}") %></span>
                            </div>

                            <!-- Subtotal -->
                            <div class="col-md-3 text-md-end">
                                <span class="text-muted d-block small">Subtotal</span>
                                <span class="text-success fw-bold fs-5">$<%# Eval("Subtotal", "{0:N2}") %></span>
                            </div>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>

            <asp:Label ID="lblSinDetalle" runat="server" CssClass="text-muted fw-semibold text-center py-3" Text="No se encontraron productos para este pedido." Visible="false" />
        </div>

    </div>

</asp:Content>
