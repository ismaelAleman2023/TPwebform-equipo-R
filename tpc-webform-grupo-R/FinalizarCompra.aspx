<%@ Page Title="Finalizar Compra" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="FinalizarCompra.aspx.cs" Inherits="tpc_webform_grupo_R.FinalizarCompra" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Estilos o scripts específicos para esta vista si necesitás -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container py-5">
        <h2 class="mb-4 fw-bold">Finalizar tu Compra</h2>

        <div class="row g-4">
            
            <!-- COLUMNA IZQUIERDA: Envío y Medio de Pago -->
            <div class="col-lg-7">
                
                <!-- 1. FORMA DE ENTREGA -->
                <div class="card shadow-sm mb-4">
                    <div class="card-body">
                        <h5 class="card-title text-primary mb-3">Forma de Entrega</h5>
                        <div class="d-flex justify-content-between align-items-center">
                            <div>
                                <p class="mb-1 text-muted">Dirección de envío:</p>
                                <asp:Label ID="lblDireccionEnvio" runat="server" CssClass="fw-bold fs-5" Text="Calle XXX 2018"></asp:Label>
                            </div>
                            <asp:Button ID="btnCambiarDireccion" runat="server" CssClass="btn btn-outline-secondary btn-sm" Text="Cambiar Dirección"  />
                        </div>
                    </div>
                </div>

                <!-- 2. MEDIO DE PAGO -->
                <div class="card shadow-sm mb-4">
                    <div class="card-body">
                        <h5 class="card-title text-primary mb-3">Medio de Pago</h5>
                        <div class="mb-3">
                            <asp:RadioButtonList ID="rblMedioPago" runat="server" CssClass="form-check" RepeatLayout="Flow">
                                <asp:ListItem Text=" Tarjeta de Crédito / Débito" Value="Tarjeta" Selected="True" />
                                <asp:ListItem Text=" Transferencia Bancaria" Value="Transferencia" />
                                <asp:ListItem Text=" Efectivo (Pago en destino / Retiro)" Value="Efectivo" />
                            </asp:RadioButtonList>
                        </div>
                    </div>
                </div>

            </div>

            <!-- COLUMNA DERECHA: Resumen de Compra -->
            <div class="col-lg-5">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h5 class="card-title text-primary mb-3">Resumen de Compra</h5>
                        
                        <!-- Detalle de Productos -->
                        <div class="d-flex justify-content-between mb-2">
                            <span>Productos (<asp:Label ID="lblCantidadItems" runat="server" Text="3"></asp:Label>)</span>
                            <span><asp:Label ID="lblSubtotal" runat="server" Text="$ XXX"></asp:Label></span>
                        </div>

                        <!-- Costo de Envío -->
                        <div class="d-flex justify-content-between mb-3 pb-3 border-bottom">
                            <span>Envío</span>
                            <span><asp:Label ID="lblCostoEnvio" runat="server" Text="$ XXX"></asp:Label></span>
                        </div>

                        <!-- Total Final -->
                        <div class="d-flex justify-content-between align-items-center mb-4">
                            <span class="fw-bold fs-4">Total</span>
                            <asp:Label ID="lblTotalGeneral" runat="server" CssClass="fw-bold fs-4 text-success" Text="$ XXX"></asp:Label>
                        </div>

                        <!-- Botón Pagar y Finalizar -->
                        <asp:Button ID="btnPagarYFinalizar" runat="server" CssClass="btn btn-success w-100 py-2 fw-bold fs-5" Text="Pagar y Finalizar" />
                    </div>
                </div>
            </div>

        </div>
    </div>
</asp:Content>