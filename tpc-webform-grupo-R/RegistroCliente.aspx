<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroCliente.aspx.cs" Inherits="tpc_webform_grupo_R.RegistroCliente" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5 card shadow-sm p-4 bg-white rounded">
                
               
                <div class="text-center mb-4">
                    <h2 class="fw-bold text-dark">Registrarse</h2>
                    <p class="text-muted">Creá tu cuenta en V.DorregoDesign</p>
                </div>

               
                <div class="mb-3">
                    <label for="txtNombre" class="form-label">Nombre</label>
                    <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" required="true"></asp:TextBox>
                </div>

                <div class="mb-3">
                    <label for="txtApellido" class="form-label">Apellido</label>
                    <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" placeholder="Ingrese su apellido" required="true"></asp:TextBox>
                </div>

               
                <div class="mb-3">
                    <label for="txtCorreo" class="form-label">Correo electrónico</label>
                    <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control" placeholder="nombre@ejemplo.com" required="true"></asp:TextBox>
                </div>

              
                <div class="mb-3">
                    <label for="txtTelefono" class="form-label">Teléfono</label>
                    <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone" CssClass="form-control" placeholder="Ej: 1122334455" required="true"></asp:TextBox>
                </div>

              
                <div class="mb-3">
                    <label for="txtPassword" class="form-label">Contraseña</label>
                    <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="••••••••" required="true"></asp:TextBox>
                </div>

               
                <div class="mb-3">
                    <label for="txtFechaNacimiento" class="form-label">Fecha de nacimiento</label>
                    <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control" required="true"></asp:TextBox>
                </div>

                <!-- Botón Registrarse -->
                <div class="d-grid gap-2 mt-4">
                    <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-dark btn-lg" OnClick="btnRegistrar_Click" />
                </div>
                   

                <!-- Enlace para iniciar sesión -->
                <div class="text-center mt-3">
                    <small class="text-muted">¿Ya tenés cuenta? <a href="Login.aspx" class="text-decoration-none text-dark fw-bold">Iniciar sesión</a></small>
                </div>

            </div>
        </div>
    </div>






</asp:Content>