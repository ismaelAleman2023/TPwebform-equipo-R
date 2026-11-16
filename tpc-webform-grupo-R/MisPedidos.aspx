<%@ Page Title="Mis Pedidos" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="MisPedidos.aspx.cs" Inherits="tpc_webform_grupo_R.MisPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
   <div class="container mt-4 mb-5">
        <h2 class="mb-4 text-white">Mis Pedidos</h2>

        <div class="card p-4 shadow-sm border-0 bg-white rounded-3">
            <h4 class="text-primary mb-4 fw-bold">Historial de Compras</h4>

            <asp:Repeater ID="repPedidos" runat="server">
                <ItemTemplate>
                    <div class="card border mb-3 p-3 shadow-sm bg-light rounded-2">
                        <div class="row align-items-center text-center text-md-start">

                            <!-- N° de Pedido -->
                            <div class="col-md-3 mb-2 mb-md-0">
                                <span class="text-muted d-block small">N° de Pedido</span>
                                <span class="fw-bold fs-5">#<%# Eval("IdVenta_V") %></span>
                            </div>

                            <!-- Fecha -->
                            <div class="col-md-2 mb-2 mb-md-0">
                                <span class="text-muted d-block small">Fecha</span>
                                <span class="fw-semibold"><%# Eval("FechaVenta_V", "{0:dd/MM/yyyy}") %></span>
                            </div>

                            <!-- Total -->
                            <div class="col-md-2 mb-2 mb-md-0">
                                <span class="text-muted d-block small">Total</span>
                                <span class="text-success fw-bold"><%# Eval("TotalPago_V", "{0:C}") %></span>
                            </div>

                            <!-- Estado -->
                            <div class="col-md-2 mb-2 mb-md-0">
                                <span class="text-muted d-block small">Estado</span>
                                <span class="badge bg-secondary px-3 py-2"><%# Eval("EstadoPedido_v") %></span>
                            </div>

                            <!-- Botón Ver Detalle -->
                            <div class="col-md-3 text-md-end">
                                <asp:Button ID="btnVerDetalle" runat="server" Text="Ver Detalle" CssClass="btn btn-primary btn-sm px-3 py-2 fw-semibold shadow-sm" CommandName="VerDetalle" CommandArgument='<%# Eval("IdVenta_V") %>' OnClick="btnVerDetalle_Click" />
                            </div>

                        </div>
                    </div>
                </ItemTemplate>
            </asp:Repeater>


            <asp:Label ID="lblSinPedidos" runat="server" CssClass="text-muted fw-bold d-block text-center py-4" Text="No tenés pedidos registrados todavía." Visible="false" />

        </div>
    </div>

  
</asp:Content>
