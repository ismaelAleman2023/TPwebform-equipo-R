<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ComoComprar.aspx.cs" Inherits="tpc_webform_grupo_R.ComoComprar" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5" style="max-width: 1100px;">

        <p class="text-uppercase fw-semibold small mb-2" style="letter-spacing: 0.15em; color: #ffcc00;">F&aacute;cil y directo</p>
        <h1 class="fw-bold mb-4" style="color: #f8f9fa;">&iquest;C&oacute;mo hacer tu pedido?</h1>

        <div class="row g-3 mb-4">

            <div class="col-12 col-sm-6 col-lg-3">
                <div class="h-100 p-4 rounded-4" style="background-color: #161616; border: 1px solid #2a2a2a;">
                    <i class="fa-solid fa-cart-shopping fa-2x mb-3" style="color: #ffcc00;"></i>
                    <p class="text-uppercase fw-bold small mb-2" style="letter-spacing: 0.12em; color: #ffcc00;">Paso 1</p>
                    <p class="mb-0" style="color: #c7c7c7;">Eleg&iacute; tus productos en el cat&aacute;logo y agregalos al carrito.</p>
                </div>
            </div>

            <div class="col-12 col-sm-6 col-lg-3">
                <div class="h-100 p-4 rounded-4" style="background-color: #161616; border: 1px solid #2a2a2a;">
                    <i class="fa-solid fa-clipboard-list fa-2x mb-3" style="color: #ffcc00;"></i>
                    <p class="text-uppercase fw-bold small mb-2" style="letter-spacing: 0.12em; color: #ffcc00;">Paso 2</p>
                    <p class="mb-0" style="color: #c7c7c7;">Abr&iacute; el carrito, revis&aacute; las cantidades y confirm&aacute; tu compra. Para eso necesit&aacute;s iniciar sesi&oacute;n o registrarte.</p>
                </div>
            </div>

            <div class="col-12 col-sm-6 col-lg-3">
                <div class="h-100 p-4 rounded-4" style="background-color: #161616; border: 1px solid #2a2a2a;">
                    <i class="fa-solid fa-truck fa-2x mb-3" style="color: #ffcc00;"></i>
                    <p class="text-uppercase fw-bold small mb-2" style="letter-spacing: 0.12em; color: #ffcc00;">Paso 3</p>
                    <p class="mb-0" style="color: #c7c7c7;">Eleg&iacute; c&oacute;mo recibirlo: retiro en el local o env&iacute;o a domicilio. Con env&iacute;o, te pedimos una direcci&oacute;n.</p>
                </div>
            </div>

            <div class="col-12 col-sm-6 col-lg-3">
                <div class="h-100 p-4 rounded-4" style="background-color: #161616; border: 1px solid #2a2a2a;">
                    <i class="fa-solid fa-credit-card fa-2x mb-3" style="color: #ffcc00;"></i>
                    <p class="text-uppercase fw-bold small mb-2" style="letter-spacing: 0.12em; color: #ffcc00;">Paso 4</p>
                    <p class="mb-0" style="color: #c7c7c7;">Eleg&iacute; la forma de pago y confirm&aacute; el pedido. Queda pendiente hasta que confirmemos el pago.</p>
                </div>
            </div>

        </div>

        <p class="small mb-3" style="color: #b0b0b0;">Formas de pago: Mercado Pago, transferencia bancaria o efectivo.</p>

        <a href="Default.aspx" class="fw-semibold text-decoration-underline" style="color: #f8f9fa;">Ir al cat&aacute;logo &rarr;</a>

    </div>
</asp:Content>
