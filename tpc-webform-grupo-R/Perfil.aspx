<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Perfil.aspx.cs" Inherits="tpc_webform_grupo_R.Perfil" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>


<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-4" style="max-width: 800px;">

        <!-- Título principal -->
        <h2 class="mb-4 text-center fw-bold text-dark">Perfil</h2>

        <!-- Mensaje de feedback -->
        <asp:Label ID="LblMensaje" runat="server" CssClass="d-block mb-3 text-center" />

        <!-- BLOQUE 1: DATOS PERSONALES (Nombre y Apellido) -->
        <div class="card shadow-sm mb-4 border-0">
            <div class="card-body">
                <div class="row align-items-center">
                    <!-- Columnas de los inputs -->
                    <div class="col-md-10">
                        <h5 class="card-title text-secondary mb-3 fw-semibold fs-6">Información Personal</h5>
                        <div class="row g-3">
                            <div class="col-md-6">
                                <label for="lblNombre" class="form-label">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="lblApellido" class="form-label">Apellido</label>
                                <asp:TextBox ID="txtApellido" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>
                            <div class="col-md-6">
                                <label for="lblEmail" class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                            </div>

                            <div class="col-md-6">
                                <label for="lblTelefono" class="form-label">Telefono</label>
                                <asp:TextBox runat="server" ID="txtTelefomo" CssClass="form-control" ReadOnly="true" />
                            </div>
                        </div>
                    </div>
                    <!-- Único botón a la derecha del bloque -->
                    <div class="col-md-2 text-center mt-4 mt-md-0">
                        <asp:Button ID="btnEditarDatos" runat="server" Text="✏️ Editar" CssClass="btn btn-outline-primary w-100 py-3" OnClick="btnEditarDatos_Click" />
                    </div>
                </div>
            </div>
        </div>

        <!-- BLOQUE 2: DIRECCIÓN ACTIVA -->
        <div class="card shadow-sm mb-4 border-0">
            <div class="card-body">
                <div class="row align-items-center">
                    <!-- Columna del input de dirección -->
                    <div class="col-md-10">
                        <h5 class="card-title text-secondary mb-3 fw-semibold fs-6">Dirección Activa</h5>
                        <label for="txtDireccion" class="form-label">Calle, Número y Localidad</label>
                        <asp:TextBox ID="txtDireccion" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
                    </div>
                    <!-- Único botón a la derecha del bloque -->
                    <div class="col-md-2 text-center mt-4 mt-md-0">
                        <asp:Button ID="btnEditarDireccion" runat="server" Text="✏️ Editar" CssClass="btn btn-outline-primary w-100 py-3" OnClick="btnEditarDireccion_Click" />
                    </div>
                </div>
            </div>
        </div>

     

        <div class="card shadow-sm mb-4 border-0">
            <div class="card-body">
                <div class="row align-items-center">
                    <!-- Columna de la foto y el campo de imagen -->
                    <div class="col-md-10">
                        <h5 class="card-title text-secondary mb-3 fw-semibold fs-6">Foto de Perfil</h5>
                        <div class="row align-items-center">
                            <div class="col-md-3 text-center mb-2 mb-md-0">
                                <asp:Image ID="imgPerfil" runat="server" CssClass="rounded-circle img-thumbnail shadow-sm" Style="width: 80px;  height: 80px; object-fit: cover;" ImageUrl="~/Images/Perfiles/fotoDefault.jpg" />
                            </div>
                            <div class="col-md-9">
                                <input type="file" id="txtImagenPerf" runat="server" class="form-control" />
                            </div>
                        </div>
                    </div>
                    <!-- Único botón a la derecha del bloque -->
                    <div class="col-md-2 text-center mt-4 mt-md-0">
                        <asp:Button ID="btnEditarFoto" runat="server" Text="✏️ Editar" CssClass="btn btn-outline-primary w-100 py-3" OnClick="btnEditarFoto_Click" />
                    </div>
                </div>
            </div>
        </div>

            

    </div>





</asp:Content>
