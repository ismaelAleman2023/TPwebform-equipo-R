<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="RegistrarProducto.aspx.cs" Inherits="tpc_webform_grupo_R.RegistrarProducto" Culture="en-US" UICulture="en-US" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

   <asp:UpdatePanel runat="server">
    <ContentTemplate>
<div class="container my-4">
            
            <div class="row justify-content-center g-4">
                
                <!-- CONTENEDOR BLANCO 1: Formulario del Producto (Izquierda) -->
                <div class="col-md-7 col-lg-6">
                    <div class="card shadow-sm px-4 py-3 bg-white rounded h-100">

                        <!-- Título, Subtítulo y Label de Mensajes arriba -->
                        <div class="text-center mb-3">
                            <h3 class="fw-bold text-dark m-0" runat="server" id="tipo"></h3>
                            <small class="text-muted d-block" runat="server" id="subtitulo"></small>
                            <div class="mt-2">
                                <asp:Label ID="lblMensaje" runat="server" CssClass="small fw-semibold" EnableViewState="false"></asp:Label>
                            </div>
                        </div>

                        <!-- Código y Nombre -->
                        <div class="row">
                            <div class="col-md-6 mb-2">
                                <label for="txtCodigo" class="form-label small fw-semibold">Código de producto</label>
                                <asp:TextBox ID="txtCodigo" runat="server" onkeypress="return event.charCode !== 32" MaxLength="50" CssClass="form-control form-control-sm" placeholder="Ej: PROD-001"></asp:TextBox>
                            </div>
                            <div class="col-md-6 mb-2">
                                <label for="txtNombre" class="form-label small fw-semibold">Nombre</label>
                                <asp:TextBox ID="txtNombre" runat="server" MaxLength="50" CssClass="form-control form-control-sm" placeholder="Nombre del producto" ></asp:TextBox>
                            </div>
                        </div>

                        <!-- Marca y Categoría -->
                        <div class="row">
                            <div class="col-md-6 mb-2">
                                <label for="ddlMarca" class="form-label small fw-semibold">Marca</label>
                                <asp:DropDownList ID="ddlMarca" runat="server" CssClass="form-select form-select-sm" required="true"></asp:DropDownList>
                            </div>
                            <div class="col-md-6 mb-2">
                                <label for="ddlCategoria" class="form-label small fw-semibold">Categoría</label>
                                <asp:DropDownList ID="ddlCategoria" runat="server" CssClass="form-select form-select-sm" required="true"></asp:DropDownList>
                            </div>
                        </div>

                        <!-- Fila de Precio y Checkbox OnDemand -->
                        <div class="row align-items-end mb-3">
                            <div class="col-md-6">
                                <label for="txtPrecio" class="form-label small fw-semibold">Precio</label>
                                <asp:TextBox ID="txtPrecio" runat="server" TextMode="Number" min="1000" step="0.01" CssClass="form-control form-control-sm" placeholder="0.00" ></asp:TextBox>
                            </div>
                            <div class="col-md-6 d-flex flex-column mb-1">
                                <div class="d-flex align-items-center mb-2">
                                    <asp:CheckBox ID="chkOnDemand" runat="server" CssClass="me-2" AutoPostBack="true" OnCheckedChanged="chkOnDemand_CheckedChanged" />
                                    <label class="form-check-label small fw-semibold mb-0" for="ContentPlaceHolder1_chkOnDemand">¿Es On Demand?</label>
                                </div>
                                
                                <!-- Panel de Stock: Se muestra si NO es On Demand -->
                                <asp:Panel ID="pnlStock" runat="server" Visible="true">
                                    <label for="txtStock" class="form-label small fw-semibold text-muted">Stock inicial</label>
                                    <asp:TextBox ID="txtStock" runat="server" TextMode="Number" min="1" CssClass="form-control form-control-sm" placeholder="Ej: 10"></asp:TextBox>
                                </asp:Panel>
                            </div>
                        </div>

                        <!-- Descripción -->
                        <div class="row">
                            <div class="col-12 mb-3">
                                <label for="txtDescripcion" class="form-label small fw-semibold">Descripción</label>
                                <asp:TextBox ID="txtDescripcion" runat="server" TextMode="MultiLine" Rows="3" CssClass="form-control form-control-sm" placeholder="Detalle del producto..." ></asp:TextBox>
                            </div>
                        </div>

                        <!-- Botón Aceptar / Registrarse -->
                        <div class="row justify-content-center mt-3">
                            <div class="col-md-8 d-grid">
                                <asp:Button ID="btnRegistrar" runat="server" CssClass="btn btn-dark btn-sm py-2 fw-semibold" OnClick="btnRegistrar_Click" />
                            </div>
                        </div>

                        <!-- Volver al Panel -->
                        <div class="text-center mt-2">
                            <small>
                                <a href="Administrar.aspx" class="text-decoration-none text-dark fw-bold">&larr; Volver al panel de administración</a>
                            </small>
                        </div>
                    </div>
                </div>

                <!-- CONTENEDOR BLANCO 2: Gestión de Imágenes (Derecha) -->
                <div class="col-md-5 col-lg-4">
                    <div class="card shadow-sm px-4 py-3 bg-white rounded h-100 d-flex flex-column justify-content-between">
                        <div>
                            <h5 class="fw-bold text-dark text-center mb-3 fs-6">Imágenes del Producto</h5>
                            
                            <!-- URL y Botones -->
                            <div class="mb-3">
                                <label for="txtImagenUrl" class="form-label small fw-semibold">URL de la Imagen</label>
                                <div class="input-group input-group-sm mb-2">
                                    <asp:TextBox ID="txtImagenUrl" runat="server" CssClass="form-control" placeholder="https://.../img.jpg"></asp:TextBox>
                                </div>
                                <div class="d-flex gap-2">
                                    <asp:Button ID="btnAgregarImagen" runat="server" Text="Agregar"  onclick="btnAgregarImagen_Click" CssClass="btn btn-outline-dark btn-sm w-50" />
                                    <asp:Button ID="btnEliminarImagen" runat="server" Text="Eliminar" onclick="btnEliminarImagen_Click" CssClass="btn btn-outline-danger btn-sm w-50" />
                                </div>
                            </div>

                            <!-- Vista Previa de la Imagen -->
                            <div class="text-center p-2 bg-light border rounded mb-3">
                                <span class="small fw-semibold text-muted d-block mb-2">Vista previa actual</span>
                             <asp:Image ID="imgPrevisualizacion" runat="server" CssClass="rounded mx-auto border bg-white shadow-sm" Style="width: 140px; height: 140px; object-fit: cover;" ImageUrl="https://us.123rf.com/450wm/koblizeek/koblizeek2204/koblizeek220400315/185376169-no-image-vector-symbol-missing-available-icon-no-gallery-for-this-moment-placeholder.jpg" onerror="this.onerror=null; this.src='https://placehold.co/140?text=Sin+Imagen';" />
                            </div>
                        </div>

                        <!-- Controles de Navegación inferior dentro del segundo contenedor -->
                        <div class="d-flex justify-content-center align-items-center gap-3 pt-2 border-top">
                            <asp:Button ID="btnAnterior" runat="server" Text="&lt;" onclick="btnAnterior_Click" CssClass="btn btn-sm btn-outline-secondary px-3 py-1 fw-bold" />
                            <asp:Label ID="lblContadorImagen" runat="server"  CssClass="small fw-bold text-dark" Text="0 / 0"></asp:Label>
                            <asp:Button ID="btnSiguiente" runat="server" Text="&gt;" OnClick="btnSiguiente_Click"  CssClass="btn btn-sm btn-outline-secondary px-3 py-1 fw-bold" />
                        </div>
                    </div>
                </div>

            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>

</asp:Content>
