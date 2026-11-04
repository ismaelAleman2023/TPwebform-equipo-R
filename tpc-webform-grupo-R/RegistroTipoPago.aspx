<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroTipoPago.aspx.cs" Inherits="tpc_webform_grupo_R.RegistroTipoPago" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container mt-5 mb-5">
        <div class="row justify-content-center">
            <div class="col-md-6 col-lg-5">

                <asp:UpdatePanel runat="server">
                    <ContentTemplate>

                        <div class="card shadow-sm p-4 bg-white rounded mx-auto text-dark" style="max-width: 450px;">

                            <div class="text-center mb-4">
                                <h2 class="fw-bold">Registrar Tipo de Pago</h2>
                            </div>

                            <div class="mb-3">
                                <label for="txtDescripcionTipoPago" class="form-label fw-semibold">Descripcion</label>
                                <asp:TextBox ID="txtDescripcionTipoPago" runat="server" CssClass="form-control" MaxLength="50" required="true"></asp:TextBox>
                            </div>

                            <div class="mb-3 text-center">
                                <asp:Label ID="lblMensajeTipoPago" runat="server" CssClass="small fw-bold" Text=""></asp:Label>
                            </div>

                            <div class="d-grid mt-4">
                                <asp:Button ID="btnRegistrarTipoPago" runat="server" Text="Registrar" CssClass="btn btn-dark btn-lg" OnClick="btnRegistrarTipoPago_Click" />
                            </div>

                            <div class="text-center mt-3">
                                <small class="text-muted"><a href="Administrar.aspx" class="text-decoration-none text-dark fw-bold">Volver al Panel de Administracion</a></small>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
