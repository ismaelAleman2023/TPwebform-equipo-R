<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroDireccion.aspx.cs" Inherits="tpc_webform_grupo_R.RegistroDireccion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-10 col-lg-10">
                <div class="card shadow-sm p-4 bg-white rounded mx-auto" style="max-width: 800px;">
                    <div class="text-center mb-4">
                        <h2 class="fw-bold text-dark">Registra tu direccion</h2>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtCalle" class="form-label">Calle</label>
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" placeholder="Ingrese la calle" MaxLength="50" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtNumero" class="form-label">Numero</label>
                            <asp:TextBox ID="txtNumero" runat="server" CssClass="form-control" placeholder="Ej: 1234" MaxLength="5" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label for="txtCodigoPostal" class="form-label">Codigo postal</label>
                            <asp:TextBox ID="txtCodigoPostal" runat="server" CssClass="form-control" placeholder="Ej: C1425" MaxLength="10" required="true"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label for="txtLocalidad" class="form-label">Localidad</label>
                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" placeholder="Ingrese la localidad" MaxLength="50" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <label for="txtProvincia" class="form-label">Provincia</label>
                            <asp:TextBox ID="txtProvincia" runat="server" CssClass="form-control" placeholder="Ingrese la provincia" MaxLength="50" required="true"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row">
                        <div class="col-md-12 mb-3">
                            <label for="txtObservacion" class="form-label">Observaciones (opcional)</label>
                            <asp:TextBox ID="txtObservacion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control" placeholder="Ej: Timbre B, porton negro" MaxLength="300"></asp:TextBox>
                        </div>
                    </div>
                    <div class="row justify-content-center mt-4">
                        <div class="col-md-6 d-grid">
                            <asp:Button ID="btnGuardar" runat="server" Text="Guardar direccion" CssClass="btn btn-dark btn-lg" OnClick="btnGuardar_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
