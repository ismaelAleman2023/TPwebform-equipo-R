<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="tpc_webform_grupo_R.RegistroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-10 col-lg-10">
                <div class="card shadow-sm p-4 bg-white rounded mx-auto" style="max-width: 800px;">
                
                    <div class="text-center mb-4">
                        <h2 class="fw-bold text-dark" runat="server" id="tipo"></h2>
                        <p class="text-muted" runat="server" id="subtitulo"></p>
                    </div>

                    <!-- Nombre y Apellido -->
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtNombre" class="form-label">Nombre</label>
                            <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtApellido" class="form-label">Apellido</label>
                            <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Correo y Teléfono -->
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtCorreo" class="form-label">Correo electrónico</label>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control" placeholder="nombre@ejemplo.com" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtTelefono" class="form-label">Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server"  TextMode="Phone" CssClass="form-control" placeholder="Ej:+5491112345678" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Contraseña y Fecha de nacimiento -->
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtPassword" class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="••••••••" ></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaNacimiento" class="form-label">Fecha de nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Botón Registrarse centrado -->
                    <div class="row justify-content-center mt-4">
                        <div class="col-md-6 d-grid">
                            <asp:Button ID="btnRegistrar" runat="server"  CssClass="btn btn-dark btn-lg" OnClick="btnRegistrar_Click" />
                        </div>
                    </div>

                    <!-- Enlace para iniciar sesión -->
                    <div class="text-center mt-3">
                        <small class="text-muted"><%: textInicio %> <a href=<%: UrlVolver %> class="text-decoration-none text-dark fw-bold"><%: textFinal %></a></small>
                    </div>

                </div>
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


    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
    <script src="Scripts/CartelFlotante.js"></script>
 



</asp:Content>