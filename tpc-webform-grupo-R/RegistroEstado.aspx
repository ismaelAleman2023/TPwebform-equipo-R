<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Estado.aspx.cs" Inherits="tpc_webform_grupo_R.RegistrarEstado" %>
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
                            <h2 class="fw-bold" > <%=titulo %>  </h2>
                        </div>

                        <!-- textbox Descripción -->
                        <div class="mb-3">
                            <label for="LblDescripcionEstado" class="form-label fw-semibold">Nombre de estado</label>
                            <asp:TextBox ID="txtDescripcionEstado" runat="server" CssClass="form-control" required="true"></asp:TextBox>
                        </div>
                                          
                        <!-- Botón Registrar -->
                        <div class="d-grid mt-4">
                            <asp:Button ID="btnRegistrarEstado" runat="server" Text="Registrar" CssClass="btn btn-dark btn-lg" OnClick="btnRegistrarEstado_Click" />
                        </div>

                        <!-- Enlace para volver o cancelar -->
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
