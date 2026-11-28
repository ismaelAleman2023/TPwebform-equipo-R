<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ModificarNovedades.aspx.cs" Inherits="tpc_webform_grupo_R.ModificarNovedades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <section class="container mt-4">
        <div class="row">
            <div class="col-3">
                <h5>Titulo sup:</h5> <asp:TextBox ID="txtTitulosup1" runat="server" CssClass="live-edit" data-target="t_sup1"> </asp:TextBox>
                <h5>Titulo:</h5> <asp:TextBox ID="txtTitulo2" runat="server" CssClass="live-edit" data-target="t_tit2"></asp:TextBox>
                <h5>Descripcion:</h5> <asp:TextBox ID="txtDescripcion3" runat="server" CssClass="live-edit" data-target="t_desc3"></asp:TextBox>
                <h5>Boton info:</h5> <asp:TextBox ID="txtbotonInf4" runat="server" CssClass="live-edit" data-target="t_bot4"></asp:TextBox>
            </div>
            <div class="col-3">
                <h5>card1 titulo:</h5> <asp:TextBox ID="txtCard1Titulo" runat="server" CssClass="live-edit" data-target="t_c1_tit"></asp:TextBox>
                <h5>card1 precio:</h5> <asp:TextBox ID="txtCard1Precio" runat="server" CssClass="live-edit" data-target="t_c1_pre"></asp:TextBox>
                <h5>card1 detalle:</h5> <asp:TextBox ID="txtCard1Detalle" runat="server" CssClass="live-edit" data-target="t_c1_det"></asp:TextBox>
                <div class="d-flex">   
                <asp:Button Id="btnGuardar" Text="Guardar" runat="server" class="btn btn-success mt-4 ms-auto" OnClick="btnGuardar_Click"/>
                </div>
            </div>
            <div class="col-3">
                <h5>Card2 titulo:</h5> <asp:TextBox ID="txtCard2Titulo" runat="server" CssClass="live-edit" data-target="t_c2_tit"></asp:TextBox>
                <h5>Card2 precio:</h5> <asp:TextBox ID="txtCard2Precio" runat="server" CssClass="live-edit" data-target="t_c2_pre"></asp:TextBox>
                <h5>Card2 detalle:</h5> <asp:TextBox ID="txtCard2Detalle" runat="server" CssClass="live-edit" data-target="t_c2_det"></asp:TextBox>
                <div>
                <asp:Button Id="btnCancelar" Text="Cancelar" runat="server" class="btn btn-danger mt-4" OnClick="btnCancelar_Click" />
                </div>
            </div>
            <div class="col-3">
                <h5>card3 destacado:</h5> <asp:TextBox ID="txtCard3Destacado" runat="server" CssClass="live-edit" data-target="t_c3_des"></asp:TextBox>
                <h5>Card3 titulo:</h5> <asp:TextBox ID="txtCard3Titulo" runat="server" CssClass="live-edit" data-target="t_c3_tit"></asp:TextBox>
                <h5>Card3 precio:</h5> <asp:TextBox ID="txtCard3Precio" runat="server" CssClass="live-edit" data-target="t_c3_pre"></asp:TextBox>
                <h5>Card3 detalle:</h5> <asp:TextBox ID="txtCard3Detalle" runat="server" CssClass="live-edit" data-target="t_c3_det"></asp:TextBox>
            </div>
        </div>
    </section>

    <!-- 3. SECCIÓN NOVEDADES -->
    <section class="mb-4 mt-3" id="novedades1">
        <h3 class="border-bottom border-secondary pb-2 mb-3">Promociones / Novedades</h3>

        <div class="promo-banner-container p-4 p-md-5 rounded-4 border border-secondary">
            <div class="row align-items-center g-4">

                <!-- Columna Izquierda -->
                <div class="col-lg-5 text-start">
                    <span class="promo-eyebrow text-uppercase fw-bold d-block mb-2">
                        <span id="t_sup1"><asp:Literal ID="litPromoEyebrow" runat="server" Text="Titulo sup" /></span>
                    </span>

                    <h2 class="display-6 fw-bold text-white mb-3">
                        <span id="t_tit2"><asp:Literal ID="litPromoTitulo" runat="server" Text="Titulo" /></span>
                    </h2>

                    <p class="text-light opacity-75 mb-4">
                        <span id="t_desc3"><asp:Literal ID="litPromoDescripcion" runat="server" Text="Descripcion" /></span>
                    </p>

                    <div class="promo-pill d-inline-flex align-items-center px-3 py-2 rounded-pill">
                        <span class="me-2 text-warning">✓</span>
                        <span class="small fw-semibold text-uppercase">
                            <span id="t_bot4"><asp:Literal ID="litPromoBadgeInferior" runat="server" Text="botonInf" /></span>
                        </span>
                    </div>
                </div>

                <!-- Columna Derecha-->
                <div class="col-lg-7">
                    <div class="row g-3">

                        <!-- Tarjeta 1 -->
                        <div class="col-md-4">
                            <div class="promo-card h-100 p-4 rounded-4 d-flex flex-column justify-content-center">
                                <span class="promo-card-label text-uppercase small mb-2">
                                    <span id="t_c1_tit"><asp:Literal ID="litCard1Titulo" runat="server" Text="card1 titulo" /></span>
                                </span>
                                <div class="promo-card-price fw-bold text-white mb-2">
                                    <span id="t_c1_pre"><asp:Literal ID="litCard1Precio" runat="server" Text="card1 precio" /></span>
                                </div>
                                <span class="promo-card-sub small text-light opacity-75">
                                    <span id="t_c1_det"><asp:Literal ID="litCard1Subtitulo" runat="server" Text="card1 subtitulo" /></span>
                                </span>
                            </div>
                        </div>

                        <!-- Tarjeta 2 -->
                        <div class="col-md-4">
                            <div class="promo-card h-100 p-4 rounded-4 d-flex flex-column justify-content-center">
                                <span class="promo-card-label text-uppercase small mb-2">
                                    <span id="t_c2_tit"><asp:Literal ID="litCard2Titulo" runat="server" Text="card2 titulo" /></span>
                                </span>
                                <div class="promo-card-price fw-bold text-white mb-2">
                                    <span id="t_c2_pre"><asp:Literal ID="litCard2Precio" runat="server" Text="card2 precio" /></span>
                                </div>
                                <span class="promo-card-sub small text-light opacity-75">
                                    <span id="t_c2_det"><asp:Literal ID="litCard2Subtitulo" runat="server" Text="card2 subtitulo" /></span>
                                </span>
                            </div>
                        </div>

                        <!-- Tarjeta 3 -->
                        <div class="col-md-4">
                            <div class="promo-card promo-card-featured h-100 p-4 rounded-4 d-flex flex-column justify-content-center position-relative">
                                <span class="promo-featured-tag badge rounded-pill text-uppercase">
                                    <span id="t_c3_des"><asp:Literal ID="litCard3Badge" runat="server" Text="Destacado" /></span>
                                </span>
                                <span class="promo-card-label text-uppercase small mb-2 mt-2">
                                    <span id="t_c3_tit"><asp:Literal ID="litCard3Titulo" runat="server" Text="card3 titulo" /></span>
                                </span>
                                <div class="promo-card-price fw-bold text-white mb-2">
                                    <span id="t_c3_pre"><asp:Literal ID="litCard3Precio" runat="server" Text="card3 precio" /></span>
                                </div>
                                <span class="promo-card-sub small text-light opacity-75">
                                    <span id="t_c3_det"><asp:Literal ID="litCard3Subtitulo" runat="server" Text="card1 subtitulo" /></span>
                                </span>
                            </div>
                        </div>

                    </div>
                </div>

            </div>
        </div>
    </section>

    <script>
        document.querySelectorAll(".live-edit").forEach(function (tb) {
            var destino = document.getElementById(tb.dataset.target);
            if (!destino) return;
            var inicial = destino.textContent;
            tb.addEventListener("input", function () {
                destino.textContent = tb.value !== "" ? tb.value : inicial;
            });
        });
    </script>


</asp:Content>
