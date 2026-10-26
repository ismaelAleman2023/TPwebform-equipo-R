<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroVA.aspx.cs" Inherits="tpc_webform_grupo_R.AgregarVA" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-10 col-lg-10">
                <div class="card shadow-sm p-4 bg-white rounded mx-auto" style="max-width: 800px;">
                
                    <div class="text-center mb-4">




                        <h2 class="fw-bold text-dark">Registrar <%= nombre %></h2>
                        <p class="text-muted">Creá tu cuenta en V.DorregoDesign</p>
                    </div>

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

                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtCorreo" class="form-label">Correo electrónico</label>
                            <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control" placeholder="nombre@ejemplo.com" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtTelefono" class="form-label">Teléfono</label>
                            <asp:TextBox ID="txtTelefono" runat="server" TextMode="Phone" CssClass="form-control" placeholder="Ej: 1122334455" required="true"></asp:TextBox>
                        </div>
                    </div>

                    
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtPassword" class="form-label">Contraseña</label>
                            <asp:TextBox ID="txtPassword" runat="server" TextMode="Password" CssClass="form-control" placeholder="••••••••" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtFechaNacimiento" class="form-label">Fecha de nacimiento</label>
                            <asp:TextBox ID="txtFechaNacimiento" runat="server" TextMode="Date" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                    </div>

                   
                    <div class="row" id="legajoOculto" runat="server">
                        <div class="col-md-12 mb-3">
                            <label for="txtLegajo" class="form-label">Legajo</label>
                            <asp:TextBox ID="txtLegajo" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                    </div>

                    <!-- Botón Registrarse -->
                    <div class="row justify-content-center mt-4">
                        <div class="col-md-6 d-grid">
                            <asp:Button ID="btnRegistrar" runat="server" Text="Registrarse" CssClass="btn btn-dark btn-lg" OnClick="btnRegistrar_Click" />
                        </div>
                    </div>
                        
                </div>      
            </div>
        </div>
    </div>

</asp:Content>