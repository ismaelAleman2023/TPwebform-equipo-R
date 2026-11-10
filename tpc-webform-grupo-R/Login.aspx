<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tpc_webform_grupo_R.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
       <script src="Scripts/CartelFlotante.js"></script>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">
                
                <asp:UpdatePanel ID="UpdatePanelLoginPagina" runat="server">
                    <ContentTemplate>

                        <div class="card shadow-sm p-4 bg-white rounded mx-auto text-dark" style="max-width: 450px;">
                            
                            <div class="text-center mb-4">
                                <h2 class="fw-bold">Iniciar Sesión</h2>
                                
                            </div>

                            <!-- Correo electrónico -->
                            <div class="mb-3">
                                <label for="txtCorreoLogin" class="form-label fw-semibold">Correo electrónico</label>
                                <asp:TextBox ID="txtCorreoLogin" runat="server" TextMode="Email" CssClass="form-control" placeholder="nombre@ejemplo.com" required="true"></asp:TextBox>
                            </div>

                            <!-- Contraseña -->
                            <div class="mb-3">
                                <label for="txtPasswordLogin" class="form-label fw-semibold">Contraseña</label>
                                <asp:TextBox ID="txtPassLogin" runat="server" TextMode="Password" CssClass="form-control" placeholder="••••••••" required="true"></asp:TextBox>
                            </div>

                            <!-- Se deja label para mas adelante mostrar un texto de error o contra incorrecta-->
                            <div class="mb-3 text-center">
                                <asp:Label ID="lblErrorLogin" runat="server" CssClass="text-danger small fw-bold" Text=""></asp:Label>
                            </div>

                            <!-- Botón de Ingreso -->
                            <div class="d-grid mt-4">
                                <asp:Button ID="btnLogin" runat="server" Text="Ingresar" CssClass="btn btn-dark btn-lg" Onclick="btnLogin_Click" />
                            </div>

                            <!-- Enlace de registro -->
                            <div class="text-center mt-3">
                                <small class="text-muted">¿No tenés cuenta? <a href="RegistroCliente.aspx" class="text-decoration-none text-dark fw-bold">Registrarse</a></small>
                            </div>

                        </div>

                    </ContentTemplate>
                </asp:UpdatePanel>

            </div>
        </div>
    </div>


    
            <div id="contenedorAlerta" class="position-fixed top-50 start-50 translate-middle p-3" style="z-index: 1050; display: none;">
                <div id="miAlerta" class="toast align-items-center text-white bg-dark border-0 shadow-lg" role="alert" aria-live="assertive" aria-atomic="true">
                    <div class="d-flex">
                        <div id="textoAlerta" class="toast-body fw-semibold px-4 py-3">
                            <!-- Aquí se inyecta el mensaje dinámicamente -->
                        </div>
                        <button type="button" class="btn-close btn-close-white me-2 m-auto" data-bs-dismiss="toast" aria-label="Close"></button>
                    </div>
                </div>
            </div>

</asp:Content>
