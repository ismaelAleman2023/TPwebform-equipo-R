<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Informes.aspx.cs" Inherits="tpc_webform_grupo_R.Informes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-4 mb-5">


        <div class="d-flex justify-content-between align-items-center mb-4">
            <h2 class="text-white fw-bold">Panel de Informes y Estadísticas</h2>
        </div>

        <!-- SECTOR INFERIOR: MENÚ LATERAL Y CONTENEDOR PRINCIPAL -->
        <asp:UpdatePanel runat="server">
            <ContentTemplate>

                <div class="row">

                    <!-- COLUMNA IZQUIERDA: BOTONES DE INFORMES Y VENTAS -->
                    <div class="col-md-3 mb-3">
                        <div class="card p-3 shadow-sm border-0 bg-white rounded-3 d-flex flex-column gap-2">
                            <h5 class="text-primary fw-bold mb-2">Reportes</h5>

                            <asp:Button ID="btnRangoFechas" runat="server" Text="Historial por Fechas"
                                CssClass="btn btn-outline-primary btn-sm text-start py-2" OnClick="btnRangoFechas_Click" />

                            <asp:Button ID="btnTopProductos" runat="server" Text="Productos Más Vendidos"
                                CssClass="btn btn-outline-primary btn-sm text-start py-2" OnClick="btnTopProductos_Click" />

                            <asp:Button ID="btnPorEstado" runat="server" Text="Ventas por Estado"
                                CssClass="btn btn-outline-primary btn-sm text-start py-2" OnClick="btnPorEstado_Click" />

                            <asp:Button ID="btnPorPago" runat="server" Text="Ventas por Forma de Pago"
                                CssClass="btn btn-outline-primary btn-sm text-start py-2" OnClick="btnPorPago_Click" />

                            <asp:Button ID="btnTopClientes" runat="server" Text="Mejores Clientes"
                                CssClass="btn btn-outline-primary btn-sm text-start py-2" OnClick="btnTopClientes_Click" />

                            <asp:Button ID="btnCanceladosDevueltos" Text="Cancelados / Devueltos" runat="server"
                                CssClass="btn btn-outline-primary btn-sm text-start py-2" OnClick="btnCanceladosDevueltos_Click" />

                            <hr class="my-2" />
                            <span class="small text-muted fw-bold">RESUMEN DE VENTAS</span>

                            <asp:Button ID="btnVentasDia" runat="server" Text="Ventas del Día"
                                CssClass="btn btn-outline-success btn-sm text-start py-2" OnClick="btnVentasDia_Click" />

                            <asp:Button ID="btnVentasMes" runat="server" Text="Ventas del Mes"
                                CssClass="btn btn-outline-success btn-sm text-start py-2" OnClick="btnVentasMes_Click" />

                            <asp:Button ID="btnVentasAnio" runat="server" Text="Ventas del Año"
                                CssClass="btn btn-outline-success btn-sm text-start py-2" OnClick="btnVentasAnio_Click" />
                        </div>
                    </div>

                    <!-- COLUMNA DERECHA: TARJETA BLANCA PRINCIPAL -->
                    <div class="col-md-9">
                        <div class="card p-4 shadow-sm border-0 bg-white rounded-3">


                            <h4 class="text-primary mb-3 fw-bold">
                                <asp:Label ID="lblTituloInforme" runat="server" Text="Panel de Informes"></asp:Label>
                            </h4>


                            <asp:Label ID="lblMensajeInicial" runat="server" CssClass="text-muted fst-italic" Text="Seleccione una opción a la izquierda para ver el reporte o resumen correspondiente."></asp:Label>


                            <asp:Panel ID="pnlTarjetaUnica" runat="server" Visible="false" class="text-center py-4">
                                <span class="text-muted d-block small fw-bold fs-5 mb-2">
                                    <asp:Label ID="lblTituloTarjeta" runat="server" Text=""></asp:Label>
                                </span>
                                <span class="fs-1 text-success fw-bold">
                                    <asp:Label ID="lblMontoTarjeta" runat="server" Text="$ 0,00"></asp:Label>
                                </span>
                            </asp:Panel>


                            <asp:Panel ID="pnlFiltroFechas" runat="server" Visible="false" class="row g-2 mb-3 align-items-end">
                                <div class="col-md-4">
                                    <label class="small text-muted">Desde:</label>
                                    <asp:TextBox ID="txtFechaInicio" runat="server"   CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <label class="small text-muted">Hasta:</label>
                                    <asp:TextBox ID="txtFechaFin" runat="server"  CssClass="form-control form-control-sm" TextMode="Date"></asp:TextBox>
                                </div>
                                <div class="col-md-4">
                                    <asp:Button ID="btnFiltrarFechas" runat="server" Text="Filtrar" CssClass="btn btn-primary btn-sm w-100" OnClick="btnFiltrarFechas_Click" />
                                </div>
                            </asp:Panel>

                            <!-- GRILLA DE RESULTADOS -->
                            <div class="table-responsive mt-3">
                                <asp:GridView ID="dgvInformes" runat="server" CssClass="table table-hover table-striped align-middle small"
                                    AutoGenerateColumns="true" GridLines="None" EmptyDataText="">
                                </asp:GridView>
                            </div>

                        </div>
                    </div>

                </div>

            </ContentTemplate>
        </asp:UpdatePanel>


    </div>

</asp:Content>
