<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SobreNosotros.aspx.cs" Inherits="tpc_webform_grupo_R.SobreNosotros" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5" style="max-width: 900px;">

        <div class="text-center mb-5">
            <h1 class="fw-bold" style="color: #ffcc00;">Sobre nosotros</h1>
            <div class="mx-auto mt-2" style="width: 80px; height: 3px; background-color: #ffcc00;"></div>
        </div>

        <div class="p-4 rounded-3 mb-5 text-center" style="background: linear-gradient(135deg, #1c1c1c 0%, #141414 100%); border: 1px solid #2a2a2a;">
            <p class="fs-5 mb-2" style="color: #f8f9fa;">
                En <span class="fw-bold" style="color: #ffcc00;">V. Dorrego Design</span> convertimos ideas en productos personalizados.
            </p>
            <p class="mb-0" style="color: #c7c7c7;">
                Combinamos distintos oficios en un mismo taller.
            </p>
        </div>

        <h4 class="fw-semibold text-center mb-4" style="color: #f8f9fa;">Lo que hacemos</h4>

        <div class="row g-3 mb-5">
            <div class="col-6 col-md-3">
                <div class="h-100 p-4 rounded-3 text-center" style="background-color: #161616; border: 1px solid #2a2a2a; border-top: 3px solid #ffcc00;">
                    <i class="fa-solid fa-cube fa-2x mb-3" style="color: #ffcc00;"></i>
                    <h6 class="fw-bold mb-2" style="color: #f8f9fa;">Polyfan</h6>
                    <p class="small mb-0" style="color: #b0b0b0;">Letras y carteles corporeos.</p>
                </div>
            </div>
            <div class="col-6 col-md-3">
                <div class="h-100 p-4 rounded-3 text-center" style="background-color: #161616; border: 1px solid #2a2a2a; border-top: 3px solid #ffcc00;">
                    <i class="fa-solid fa-print fa-2x mb-3" style="color: #ffcc00;"></i>
                    <h6 class="fw-bold mb-2" style="color: #f8f9fa;">Impresion 3D</h6>
                    <p class="small mb-0" style="color: #b0b0b0;">Llaveros y piezas personalizadas.</p>
                </div>
            </div>
            <div class="col-6 col-md-3">
                <div class="h-100 p-4 rounded-3 text-center" style="background-color: #161616; border: 1px solid #2a2a2a; border-top: 3px solid #ffcc00;">
                    <i class="fa-solid fa-bolt fa-2x mb-3" style="color: #ffcc00;"></i>
                    <h6 class="fw-bold mb-2" style="color: #f8f9fa;">Corte laser</h6>
                    <p class="small mb-0" style="color: #b0b0b0;">Carteles grabados y cortados en MDF.</p>
                </div>
            </div>
            <div class="col-6 col-md-3">
                <div class="h-100 p-4 rounded-3 text-center" style="background-color: #161616; border: 1px solid #2a2a2a; border-top: 3px solid #ffcc00;">
                    <i class="fa-solid fa-pen-nib fa-2x mb-3" style="color: #ffcc00;"></i>
                    <h6 class="fw-bold mb-2" style="color: #f8f9fa;">Papeleria creativa</h6>
                    <p class="small mb-0" style="color: #b0b0b0;">Stickers y articulos personalizados.</p>
                </div>
            </div>
        </div>

        <div class="p-4 rounded-3 mb-4" style="background-color: #161616; border: 1px solid #2a2a2a; border-left: 4px solid #ffcc00;">
            <h5 class="fw-bold mb-2" style="color: #ffcc00;">Trabajos a pedido</h5>
            <p class="mb-0" style="color: #c7c7c7;">
                Hacemos recuerdos para egresados y fiestas, entre otros trabajos. Muchos se hacen a pedido, con el modelo, el nombre y los detalles que quieras.
            </p>
        </div>

        <p class="text-center fw-semibold mb-0" style="color: #f8f9fa;">
            Contanos tu idea y la armamos juntos.
        </p>

    </div>
</asp:Content>
