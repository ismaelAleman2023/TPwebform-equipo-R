<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistroCategoria.aspx.cs" Inherits="tpc_webform_grupo_R.RegistroCategoria" %>

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
                                <h2 class="fw-bold">Registrar Categoria</h2>
                            </div>

                            <div class="mb-3">
                                <label from="lblRegistrarCategoria" class="form-label fw-semibold">Nombre de la Categoria</label>
                                <asp:TextBox ID="txtRegistrarCategoria" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                            </div>

                            <div class="mb-3 text-center">
                                <asp:Label ID="LblMensajeError" runat="server" CssClass="small fw-bold" Text=""></asp:Label>
                            </div>

                            <div class="d-grid mt-4">
                                <asp:Button ID="BtnRegistrarCategoria" runat="server" Text="Registrar" CssClass="btn btn-dark btn-lg" OnClick="BtnRegistrarCategoria_Click"></asp:Button>
                            </div>

                            <div class="text-center mt-3">
                                <small class="text-muted"><a href="Administrar.aspx" class="text-decoration-none text-dark fw-bold">← Volver al Panel de Administración</a></small>
                            </div>

                        </div>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </div>
        </div>
    </div>
</asp:Content>
