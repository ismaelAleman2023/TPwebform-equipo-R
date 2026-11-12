<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="DireccionEnvio.aspx.cs" Inherits="tpc_webform_grupo_R.DireccionEnvio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container my-4">
        
        <!-- Título de la sección -->
        <div class="row mb-4">
            <div class="col-12">
                <h2 class="fw-bold">Dirección de Envío</h2>
                <hr />
            </div>
        </div>

        <!-- Contenedor del formulario / listado de direcciones según el boceto -->
        <div class="card shadow-sm p-4 mb-4">
            <h5 class="card-title text-primary mb-3">Direcciones Registradas</h5>

           <asp:Repeater ID="repetDire" runat="server">
              <ItemTemplate>
                <!-- Tarjeta individual de dirección -->
                <div class="border rounded p-3 mb-3 bg-light">
                    <div class="row g-3 align-items-center">
         
                        <!-- Calle y Nro (Concatenados correctamente adentro del mismo Text) -->
                        <div class="col-md-2">
                            <label class="form-label fw-bold">Calle y N°</label>
                            <asp:TextBox ID="txtCalle" runat="server" CssClass="form-control" readonly="false" Text='<%# Eval("Calle") + " " + Eval("Numero") %>' placeholder="Ej: Av. San Martín 1234"></asp:TextBox>
                        </div>

                        <!-- Código Postal -->
                        <div class="col-md-1">
                            <label class="form-label fw-bold">C.P.</label>
                            <asp:TextBox ID="txtCP" runat="server" CssClass="form-control" readonly="false" Text='<%# Eval("CodigoPostal") %>' placeholder="1646"></asp:TextBox>
                        </div>

                        <!-- Localidad y Provincia (Concatenadas correctamente con coma y espacio) -->
                        <div class="col-md-3">
                            <label class="form-label fw-bold">Localidad / Provincia</label>
                            <asp:TextBox ID="txtLocalidad" runat="server" CssClass="form-control" readonly="false" Text='<%# Eval("Localidad") + ", " + Eval("Provincia") %>' placeholder="Victoria, Bs. As."></asp:TextBox>
                        </div>

                        <!-- Observaciones (Nombre de propiedad corregido con 'n') -->
                        <div class="col-md-4">
                            <label class="form-label fw-bold">Observación</label>
                            <asp:TextBox ID="txtObs" runat="server" CssClass="form-control" readonly="false" Text='<%# Eval("Observacion") %>' placeholder="Depto, timbre..."></asp:TextBox>
                        </div>

                        <!-- Radio / Selector de Activo -->
                       <div class="col-md-2 text-center">
                        <label class="form-label fw-bold d-block">Activo</label>
                        <div class="form-check d-inline-block">
                            
                            <input class="form-check-input" type="radio" name="grupoDireccion" value='<%# Eval("IdDireccion") %>' <%# (bool)Eval("estado") ? "checked" : "" %> />
                           
                                Seleccionar
                            </label>
                        </div>
                            </div>

                    </div>
                </div>
            </ItemTemplate>
</asp:Repeater>

           

          

        </div>

        <!-- Botón de Guardar / Aceptar al final -->
        <div class="row">
            <div class="col-12 text-end">
                <asp:Button ID="btnEliminar" runat="server" Text="Eliminar" CssClass="btn btn-secondary me-2 px-4"  OnClick="btnEliminar_Click" />
                <asp:Button ID="btnAgregarDire" runat="server" Text="Agregar Direccion" CssClass="btn btn-secondary me-2 px-4 " onclick="btnAgregarDire_Click"  />
                <asp:Button ID="btnCancelar" runat="server" Text="Cancelar" CssClass="btn btn-secondary me-2 px-4"  OnClick="btnCancelar_Click" />
                <asp:Button ID="btnGuardarDireccion" runat="server" Text="Guardar / Aceptar" CssClass="btn btn-success px-4" OnClick="btnGuardarDireccion_Click"  />
            </div>
        </div>

    </div>
</asp:Content>