<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="tpc_webform_grupo_R.Login" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
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
                                <asp:TextBox ID="txtPasswordLogin" runat="server" TextMode="Password" CssClass="form-control" placeholder="••••••••" required="true"></asp:TextBox>
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




</asp:Content>
