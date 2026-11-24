<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="tpc_webform_grupo_R.Contactanos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <style>
        .form-control::placeholder {
            color: #A0A0A0 !important;
            opacity: 1;
        }
        .form-control::-ms-input-placeholder {
            color: #A0A0A0 !important;
        }
    </style>

    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-10 col-lg-10">
                <div class="card shadow-sm p-4 bg-dark text-light border border-secondary rounded mx-auto" style="max-width: 800px; background-color: #181818 !important; border-color: #333333 !important;">

                    <div class="text-center mb-4">
                        <h2 class="fw-bold" style="color: #F4B41A;">Contactanos</h2>
                    </div>

                    <div class="row">
                        <div class="col-md-6 mb-3 d-flex flex-column justify-content-between">
                            <div>
                                <h3 style="text-align: center; color: #FFFFFF;">Estamos ubicado</h3>
                                <h4 style="text-align: center; color: #CCCCCC;">en</h4>
                                <h4 style="text-align: center; color: #CCCCCC;">Barrio Dorrego (Gonzales Catan)</h4>
                            </div>

                            <div class="mt-3">
                     
                            <iframe src="https://www.google.com/maps/embed?pb=!1m14!1m12!1m3!1d6554.495337283789!2d-58.61158777210538!3d-34.774539877017375!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!5e0!3m2!1ses-419!2sar!4v1795164475508!5m2!1ses-419!2sar" class="w-100 rounded mb-3" height="240" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="strict-origin-when-cross-origin"></iframe>
                            </div>
                        </div>

                        <div class="col-md-6 mb-3">
                            <div class="mb-3">
                                <label for="txtNombre" class="form-label text-light">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control bg-dark text-light border-secondary" placeholder="Ingrese su nombre" required="true" Style="background-color: #121212 !important; color: #FFFFFF !important; border-color: #444444 !important;"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="txtCorreo" class="form-label text-light">Email</label>
                                <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control bg-dark text-light border-secondary" placeholder="nombre@ejemplo.com" required="true" Style="background-color: #121212 !important; color: #FFFFFF !important; border-color: #444444 !important;"></asp:TextBox>
                            </div>

                            <div class="mb-3">
                                <label for="txtMensaje" class="form-label text-light">Mensaje</label>
                                <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" CssClass="form-control bg-dark text-light border-secondary" required="true" Style="resize: none; height: 160px; max-height: 160px; overflow-y: auto; background-color: #121212 !important; color: #FFFFFF !important; border-color: #444444 !important;"></asp:TextBox>
                            </div>

                            <div class="text-end">
                                <!-- Botón Enviar -->
                                <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-warning btn-lg fw-bold text-dark" Style="background-color: #F4B41A; border-color: #F4B41A;" OnClick="btnEnviar_Click" />
                            </div>
                        </div>
                    </div>

                </div>
            </div>
        </div>
    </div>

</asp:Content>