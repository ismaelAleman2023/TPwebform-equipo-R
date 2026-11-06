<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="SumarStock.aspx.cs" Inherits="tpc_webform_grupo_R.SumarStock" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <asp:UpdatePanel runat="server">
        <ContentTemplate>

<div class="container my-5">
    <div class="row justify-content-center">
        <div class="col-md-6">
            <div class="card bg-white text-dark shadow p-4">
                <div class="card-body pb-0">
                    <!-- Título centrado -->
                    <h2 id="hTitulo" runat="server" class="text-center fw-bold mb-4"></h2>

                    <div class="mb-3">
                        <label class="form-label text-muted fw-semibold">Producto:</label>
                        <h5 class="fw-bold">
                            <asp:Label ID="lblNombreProducto" runat="server" Text="[Nombre del Producto]"></asp:Label>
                        </h5>
                    </div>

                    <div class="mb-3">
                        <label for="txtCantidad" class="form-label fw-semibold"></label>
                        <asp:TextBox ID="txtCantidad" runat="server" CssClass="form-control" TextMode="Number" min="1" Text="1"></asp:TextBox>
                    </div>

                    <div class="d-grid gap-2 mt-4">
                        <asp:Button ID="btnSumar" runat="server" Text="Actualizar Stock" CssClass="btn btn-dark" OnClick="btnSumar_Click" />
                    </div>

                    <div class="mb-2">

                    <asp:Label ID="lblMensaje" runat="server" CssClass="d-block text-center mt-3"></asp:Label>

                    </div>

                    <div class="text-center mt-4 mb-2">
                        <small>
                            <a href="Administrar.aspx" class="text-dark text-decoration-none fw-semibold">&larr; Volver al Panel de Administración</a>
                        </small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</div>
        </ContentTemplate>
    </asp:UpdatePanel>


</asp:Content>
