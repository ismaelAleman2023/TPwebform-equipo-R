<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="AdministrarPedidos.aspx.cs" Inherits="tpc_webform_grupo_R.AdministrarPedidos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-4 mb-5">
        <h2 class="text-white mb-4">Gestión de Pedidos</h2>


        <div class="card p-4 shadow-sm border-0 bg-white rounded-3">
            <h4 class="text-primary mb-4 fw-bold">Pedidos de Clientes</h4>

            <!-- Repeater de pedidos del vendedor -->
            <asp:Repeater ID="repPedidosVendedor" runat="server" OnItemCommand="repPedidosVendedor_ItemCommand" OnItemDataBound="repPedidosVendedor_ItemDataBound">
                <ItemTemplate>
                    <div class="card border mb-3 p-3 shadow-sm bg-light rounded-2">
                        <div class="row align-items-center">

                            <!-- ID y Cliente -->
                            <div class="col-md-3">
                                <span class="text-muted d-block small">Pedido #<%# Eval("IdVenta_V") %></span>
                                <span class="fw-bold text-dark">Cliente ID: <%# Eval("IdCliente_V") %></span>
                            </div>

                            <!-- Fecha y Total -->
                            <div class="col-md-2">
                                <span class="text-muted d-block small">Fecha</span>
                                <span class="fw-semibold"><%# Eval("FechaVenta_V", "{0:dd/MM/yyyy}") %></span>
                            </div>
                            <div class="col-md-2">
                                <span class="text-muted d-block small">Total</span>
                                <span class="text-success fw-bold">$<%# Eval("TotalPago_V", "{0:N2}") %></span>
                            </div>


                            <div class="col-md-2">
                                <span class="text-muted d-block small">Estado Actual</span>
                                <span class="fw-bold text-dark d-block">
                                    <asp:Label ID="lblEstadoActual" runat="server" Text='<%# Eval("EstadoPedido_v") %>' />
                                </span>
                            </div>


                            <!-- Selector de Estado -->
                            <div class="col-md-3">
                                <span class="text-muted d-block small">Estado</span>
                                <asp:DropDownList ID="ddlEstado" runat="server" CssClass="form-select form-select-sm">
                                </asp:DropDownList>

                                <div class="d-flex gap-2 mt-2">

                                    <asp:Button ID="btnActualizarEstado" runat="server" Text="Actualizar"
                                        CssClass="btn btn-primary btn-sm w-50"
                                        CommandName="ActualizarEstado"
                                        CommandArgument='<%# Eval("IdVenta_V") %>' />

                                    <asp:Button ID="btnVerDetalle" runat="server" Text="Detalle"
                                        CssClass="btn btn-outline-primary btn-sm w-50"
                                        CommandName="VerDetalle"
                                        CommandArgument='<%# Eval("IdVenta_V") %>' />

                                </div>

                              

                            </div>




                        </div>
                    </div>

                </ItemTemplate>
            </asp:Repeater>

            <asp:Label ID="lblSinPedidos" runat="server" CssClass="text-muted fw-semibold text-center py-4 d-block" Text="No se encontraron pedidos registrados en el sistema." Visible="false" />

        </div>
    </div>






</asp:Content>
