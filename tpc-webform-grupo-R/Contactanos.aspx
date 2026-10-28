<%@ Page Title="" Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="Contactanos.aspx.cs" Inherits="tpc_webform_grupo_R.Contactanos" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    

    <div class="container mt-5 mb-5">
    <div class="row justify-content-center">
        <div class="col-md-10 col-lg-10">
            <div class="card shadow-sm p-4 bg-white rounded mx-auto" style="max-width: 800px;">
            
                <div class="text-center mb-4">




                    <h2 class="fw-bold text-dark">Contactanos</h2>
                  
                </div>
               

                <div class="row">
                    <div class="col-md-6 mb-3">
                   
                        <div>
                             <h3 Style="text-align:center">Estamos Hubicado</h3>
                        </div>
                         <h4 Style="text-align:center">en</h4>
                     
                    </div>
                    <div class="col-md-6 mb-3">
                        
                        <label for="txtNombre" class="form-label">Nombre</label>
                        <asp:TextBox ID="txtNombre" runat="server" CssClass="form-control" placeholder="Ingrese su nombre" required="true"></asp:TextBox>
                        
                    </div>
                </div>


                <div class="row">

                    <div class="row">

                          

                    </div>


                    <div class="col-md-6 mb-3">

                       
                    </div>

                    <div class="col-md-6 mb-3">
                     
                        <label for="txtCorreo" class="form-label">Email</label>
                        <asp:TextBox ID="txtCorreo" runat="server" TextMode="Email" CssClass="form-control" placeholder="nombre@ejemplo.com" required="true"></asp:TextBox>
                        
                    </div>
                </div>



                
                <div class="row">
                    <div class="col-md-6 mb-3">
                       

                    </div>
                    <div class="col-md-6 mb-3">


                        <label for="txtMensaje" class="form-label">Mensaje</label>
                       <asp:TextBox ID="txtMensaje" runat="server" TextMode="MultiLine" CssClass="form-control" required="true" Style="resize: none; height: 160px; max-height: 160px; overflow-y: auto;"></asp:TextBox>
                    </div>
                </div>

               
                  <div class="row">

                       <div class="row">

                       <asp:Label ID="Label4" runat="server" Text="Siguenos"></asp:Label>

                       </div>


                        <div class="col-md-6 mb-3">
                             <asp:Image ID="Image1" src="images/icons/face.png" runat="server" Height=40px />
                             <asp:Image ID="Image2" src="images/icons/insta.png" runat="server" Height=40px Style=" margin-left: 10px"  />
                             <asp:Image ID="Image3" src="images/icons/whatsap.png" runat="server" Height=47px Style="margin-left: 10px" />

                        </div>
                        <div class="col-md-6 mb-3">

                         <!-- Botón Enviar -->
                             <asp:Button ID="btnEnviar" runat="server" Text="Enviar" CssClass="btn btn-dark btn-lg" OnClick="btnEnviar_Click" />

                        </div>
                </div>

            
              
            </div>      
        </div>
    </div>
</div>













</asp:Content>
