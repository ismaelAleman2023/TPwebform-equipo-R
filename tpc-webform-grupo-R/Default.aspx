<%@ Page Title="Catálogo" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="tpc_webform_grupo_R.Default" %>


<%@ MasterType VirtualPath="~/Principal.master" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-4 text-light">

        <!-- 1. SECCIÓN DESTACADOS -->
        <section class="mb-5">
            <h3 class="border-bottom border-secondary pb-2 mb-3">Destacados</h3>
            <div class="p-4 bg-dark border border-secondary rounded text-center">
                <p class="text-muted mb-0">[ Espacio o Carrusel para Productos Destacados ]</p>
            </div>
        </section>

        <hr class="border-secondary my-4" />

        <!-- 2. SECCIÓN CATÁLOGO Y FILTROS -->
        <section class="mb-5">
            <h3 class="mb-3">Catálogo</h3>
            <p class=" small mb-3">Encontrá tu favorito</p>

            
         <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
           <ContentTemplate>
            <!-- Barra de botones de filtro -->
            <div class="d-flex flex-wrap gap-2 mb-4">
                <asp:Button ID="btnFiltroTodo" runat="server" Text="Todos" CommandArgument='0' OnClick="btnFiltroTodo_Click" CssClass="btn btn-warning btn-sm rounded-pill px-3 fw-bold text-dark" />
                <asp:Button ID="btnFiltroPolyfan" runat="server" Text="Polyfan" CommandArgument='6' OnClick="btnFiltroTodo_Click" CssClass="btn btn-outline-secondary btn-sm rounded-pill px-3 text-light" />
                <asp:Button ID="btnFiltroImpresion" runat="server" Text="Impresión 3D" CommandArgument='1' OnClick="btnFiltroTodo_Click" CssClass="btn btn-outline-secondary btn-sm rounded-pill px-3 text-light" />
                <asp:Button ID="btnFiltroPapeleria" runat="server" Text="Papelería" CommandArgument='5' OnClick="btnFiltroTodo_Click" CssClass="btn btn-outline-secondary btn-sm rounded-pill px-3 text-light" />
                <asp:Button ID="btnFiltroCorteLaser" runat="server" Text="Conte Laser" CommandArgument='2' OnClick="btnFiltroTodo_Click" CssClass="btn btn-outline-secondary btn-sm rounded-pill px-3 text-light" />
                <asp:Button ID="btnFiltroEgrasados" runat="server" Text="Egresados" CommandArgument='3' OnClick="btnFiltroTodo_Click" CssClass="btn btn-outline-secondary btn-sm rounded-pill px-3 text-light" />
                <asp:Button ID="btnFiltroOtros" runat="server" Text="Otros" CommandArgument='4' OnClick="btnFiltroTodo_Click" CssClass="btn btn-outline-secondary btn-sm rounded-pill px-3 text-light" />


            </div>

            <!-- Línea de separación  -->
            <hr class="border-secondary my-4" />



                    <!-- Grilla de Tarjetas -->
                    <div class="row row-cols-1 row-cols-sm-2 row-cols-md-3 row-cols-lg-4 g-3">

                        <asp:Repeater runat="server" ID="reapet">
                            <ItemTemplate>

                                <!-- Card de producto -->
                                <div class="col">
                                    <div class="card bg-dark text-light border-secondary h-100 p-3 shadow-sm">

                                        <!-- Marca y Categoría -->
                                        <div class="d-flex justify-content-between text-muted mb-2" style="font-size: 0.75rem;">
                                            <span>Marca </span>
                                            <span>Categoría</span>
                                        </div>

                                        <!-- Imagen con tamaño equilibrado para PC (~140px) -->
                                       <div class="bg-secondary rounded mb-3 d-flex align-items-center justify-content-center position-relative" style="height: 140px; overflow: hidden;">
                                       
                                        <asp:Image ID="imgCard" runat="server" 
                                            ImageUrl='<%# ObtenerImagenProducto(Convert.ToInt32(Eval("IdProducto"))) %>' 
                                            style="width: 100%; height: 100%; object-fit: cover;" 
                                            alt="Producto" />
                                    </div>

                                        <!-- Nombre y Precio -->
                                        <h6 class="card-title fw-bold mb-1 text-truncate"><%#Eval("Nombre")   %> </h6>
                                        <p class="text-warning fw-bold mb-2">$<%#Eval("Precio") %></p>

                                        <!-- Botones  -->
                                        <div class="mt-auto d-flex gap-2">
                                            <asp:Button ID="btnDetalle" runat="server" Text="Ver Detalle" CssClass="btn btn-outline-light btn-sm w-50 py-1" CommandArgument='<%#Eval("IdProducto") %>' OnClick="btnDetalle_Click" />
                                            <asp:Button ID="btnAgregar" runat="server" Text="Agregar" CssClass="btn btn-warning btn-sm w-50 fw-bold text-dark py-1" CommandArgument='<%#Eval("IdProducto") %>' OnClick="btnAgregar_Click" Style="font-size: 0.8rem;" />
                                        </div>

                                    </div>
                                </div>
                                <!-- Fin de la Card -->

                            </ItemTemplate>
                        </asp:Repeater>

                    </div>

                    <!-- Línea de separación al final de las cards -->
                    <hr class="border-secondary my-4" />


                </ContentTemplate>

            </asp:UpdatePanel>


            <!-- Modal -->
            <div class="modal fade" id="productoModal" tabindex="-1" aria-labelledby="productoModalLabel" aria-hidden="true">
                <div class="modal-dialog modal-lg modal-dialog-centered">

                    <div class="modal-content text-uppercase bg-dark text-light border border-secondary shadow-lg" style="background-color: #212529 !important;">

                        <asp:UpdatePanel ID="UpdatePanelModal" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>


                                <div class="modal-body py-4 px-4">
                                    <div class="row row-cols-1 row-cols-md-2 g-4">

                                        <!-- COLUMNA IZQUIERDA (IMAGEN + NAVEGACIÓN) -->

                                        <div class="col d-flex flex-column justify-content-between" style="height: 370px;">

                                            <!-- Marca y Categoría -->
                                            <div style="height: 80px;">
                                                <h5 class="fw-bold mb-1 text-truncate">Marca: <span class="fw-normal ">
                                                    <asp:Label ID="lblModalMarca" runat="server"></asp:Label></span>
                                                </h5>
                                                <p class="small mb-0 text-truncate">
                                                    Categoría: <span class="fw-normal">
                                                        <asp:Label ID="lblModalCategoria" runat="server"></asp:Label></span>
                                                </p>

                                                <p class="small mb-0">
                                                    Disponibles: <span ><asp:Label ID="lblModalStock" runat="server"></asp:Label></span>
                                                    <asp:Label ID="LblModalDisponibles" runat="server" class="fw-bold text-warning" >Disponibles: </asp:Label>
                                                </p>


                                            </div>

                                            <!-- Contenedor de la Imagen -->
                                            <div class="bg-secondary rounded d-flex align-items-center justify-content-center flex-shrink-0"
                                                style="height: 200px; border-radius: 4px;">
                                                <asp:Image ID="imgModalProducto" runat="server" CssClass="img-fluid h-100 w-100" Style="object-fit: contain;" AlternateText="Imagen del producto" />

                                            </div>

                                            <!-- Flechas de Navegación -->
                                            <div class="d-flex gap-2 justify-content-center mt-3" style="height: 45px;">
                                                <asp:Button ID="btnImgAnterior" runat="server" Text="&larr;" CssClass="btn btn-outline-light px-3 py-2 fw-bold" Style="width: 50px;" />
                                                <asp:Button ID="btnImgSiguiente" runat="server" Text="&rarr;" CssClass="btn btn-outline-light px-3 py-2 fw-bold" Style="width: 50px;" />
                                            </div>
                                        </div>

                                        <!-- COLUMNA DERECHA -->

                                        <div class="col d-flex flex-column justify-content-between" style="height: 370px;">

                                            <!-- Nombre y Precio -->
                                            <div class="mb-2" style="height: 85px;">
                                                <h5 class="fw-bold mb-1 text-truncate">Nombre: <span class="fw-normal text-light">
                                                    <asp:Label ID="lblModalNombre" runat="server"></asp:Label></span>
                                                </h5>
                                                <p class="fs-5 text-warning fw-bold mb-0">
                                                    Precio: <span class="fw-bold">
                                                        <asp:Label ID="lblModalPrecio" runat="server"></asp:Label></span>
                                                </p>
                                            </div>

                                            <!-- Sección Detalle -->
                                            <div class="d-flex flex-column" style="height: 175px; max-height: 175px;">
                                                <span class="fw-bold d-block mb-1" style="font-size: 0.9rem;">Detalle:</span>

                                                <div class="overflow-y-auto text-light flex-grow-1" style="font-size: 0.95rem; text-transform: none; padding-right: 5px;">
                                                    <asp:Label ID="lblModalDescripcion" runat="server">  </asp:Label>
                                                </div>
                                            </div>

                                            <!-- Botones -->
                                            <div class="d-flex gap-2 mt-3 " style="height: 45px;">
                                                <asp:Button ID="btnAgregarModal" runat="server" Text="Agregar" CssClass="btn btn-warning btn-sm w-50 fw-bold text-dark py-1" OnClick="btnAgregarModal_Click" Style="font-size: 0.8rem;" />

                                                <button type="button" class="btn btn-outline-light px-4 py-2 w-50" data-bs-dismiss="modal">Salir</button>
                                            </div>
                                        </div>

                                    </div>
                                </div>

                                </div>
                                
                        </div>
                    </div>

                            </ContentTemplate>
                        </asp:UpdatePanel>
                        </div>
                    </div>
                </div>
        </section>


        <!-- 3. SECCIÓN NOVEDADES -->
        <section class="mb-4">
            <h3 class="border-bottom border-secondary pb-2 mb-3">Promociones / Novedades</h3>
            <div class="p-4 bg-dark border border-secondary rounded text-center">
                <p class="text-muted mb-0">[ Espacio para sección de Novedades ]</p>
            </div>
        </section>

    </div>

</asp:Content>
