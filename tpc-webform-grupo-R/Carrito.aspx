<%@ Page Title="Carrito de Compras" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Carrito.aspx.cs" Inherits="tpc_webform_grupo_R.Carrito" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="container my-5 text-light">
        <h2 class="mb-4">
            <i class="fa-solid fa-cart-shopping text-warning me-2"></i> Tu Carrito de Compras
        </h2>

        <!-- Fila dividida en dos columnas -->
        <div class="row g-4">
            
            <!-- COLUMNA IZQUIERDA: LISTA DE CARDS DE PRODUCTOS -->
            <div class="col-lg-8">
                
                <div class="d-flex flex-column gap-3">
                   
                    <asp:Repeater ID="reapetCarrito" runat="server">
                        <ItemTemplate>


                        
                   <!-- CARD DE PRODUCTO (Acá después irá un Repeater o GridView de ASP.NET) -->
                    <div class="card bg-dark text-light border-secondary p-3">
                        <div class="row align-items-center">
                            
                            <!-- Imagen y Nombre -->
                            <div class="col-md-5 d-flex align-items-center gap-3">

                          
                                <asp:Image ID="imgCarrito" ImageUrl='<%# obtenerImagenProducto(Convert.ToInt32(Eval("IdProducto"))) %>' runat="server" alt="Producto" class="m-0 " style="width: 100px; height: 100px; object-fit: cover;" />
                                <div>
                                    <h5 runat="server" id="detalleCarrito" class="mb-1 fs-6"> <%# obtenerNombreProducto(Convert.ToInt32(Eval("IdProducto"))) %>  </h5>

                                    <span runat="server" id="precioCarrito" class="text-warning fw-bold">$ <%#Eval("PrecioUnitario") %> </span>
                                </div>


                            </div>

                            <!-- Centro: Control de Cantidad [- Cant +] -->
                            <div class="col-md-4 d-flex justify-content-center my-2 my-md-0">
                                <div class="input-group input-group-sm w-auto">
                                    <asp:Button ID="btnRestar" runat="server" Text="-" CssClass="btn btn-outline-secondary text-light px-3" CommandArgument='<%# Eval("IdProducto") %>' Onclick="btnRestar_Click" />
                                    
                                    <span class="input-group-text bg-secondary text-light border-secondary px-3" runat="server"><%#Eval("Cantidad") %></span>
                                    
                                    <asp:Button ID="btnSumar" runat="server" Text="+" CssClass="btn btn-outline-secondary text-light px-3" CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnSumar_Click" />
                                </div>
                            </div>

                            <!-- Derecha: Tacho de basura para eliminar -->
                            <div class="col-md-3 text-end">
                                <asp:LinkButton ID="btnEliminarCarrito" CommandArgument='<%# Eval("IdProducto") %>' OnClick="btnEliminarCarrito_Click" runat="server" CssClass="btn btn-outline-danger btn-sm">
                                    <i class="fa-solid fa-trash-can"></i> Eliminar
                                </asp:LinkButton>
                            </div>

                        </div>
                    </div>
                    <!-- Fin de la Card -->
            </ItemTemplate>
         </asp:Repeater>

                </div>

            </div>

            <!-- COLUMNA DERECHA: RECUADRO DE RESUMEN DE COMPRA -->
            <div class="col-lg-4">
                <div class="card bg-dark text-light border-secondary p-4 sticky-top" style="top: 90px;">
                    
                    <h4 class="border-bottom border-secondary pb-3 mb-3">Resumen Compra</h4>
                    
                    <div class="d-flex justify-content-between mb-2">
                        <span>Productos (<asp:Label ID="lblCant" runat="server" ></asp:Label>)</span>
                        <asp:Label ID="lblSubtotal" runat="server" ></asp:Label>
                    </div>

                    <div class="d-flex justify-content-between mb-3 text-muted small">
                        <span>Envío</span>
                        <span>A calcular</span>
                    </div>

                    <hr class="border-secondary" />

                    <div class="d-flex justify-content-between fs-4 fw-bold mb-4">
                        <span>TOTAL:</span>
                        <asp:Label ID="lblTotal" runat="server"  CssClass="text-warning"></asp:Label>
                    </div>

                    <div class="d-grid">
                        <asp:Button ID="btnContinuar" OnClick="btnContinuar_Click"  runat="server" Text="Continuar" CssClass="btn btn-warning fw-bold py-2 text-dark" />
                    </div>

                </div>
            </div>

        </div>
    </div>

</asp:Content>
    
     




